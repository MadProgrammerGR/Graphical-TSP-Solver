using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graphical_TSP_Solver {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }
        
        Point[] cities;
        int currCityIndex = -1; //otan tis topo8etei sto "xarth"
        bool animate;
        int animFPS = 10; // frames/genies to deuterolepto
        Thread solverThread;

        private void canvas1_Paint(object sender, PaintEventArgs e) {
            if(cities == null) return;
            Graphics g = e.Graphics;
            if(animate) drawChromosomeCircle(g, Pens.Orange, currBestChromosome);
            drawChromosomeCircle(g, Pens.Red, totalBestChromosome);
            drawCities(g, Brushes.BlueViolet, Brushes.Black, cities);
            generationL.Text = "Generation: " + generation;
        }

        private void drawCities(Graphics g, Brush b1, Brush b2, Point[] c) {
            for(int i=0;i<cities.Length;i++) {
                g.FillEllipse(b1, cities[i].X - 5, cities[i].Y - 5, 10, 10);
                g.DrawString(i.ToString(), this.Font, b2, cities[i].X - 5, cities[i].Y - 20);
            }
        }

        private void drawChromosomeCircle(Graphics g, Pen p, int[] c) {
            if(c == null) return;
            for(int i = 0;i < c.Length - 1;i++) {
                Point curr = cities[c[i]];
                Point next = cities[c[i + 1]];
                g.DrawLine(p, curr, next);
            }
            g.DrawLine(p, cities[c[0]], cities[c[c.Length - 1]]);
        }

        private void randomCitiesToolStripMenuItem_Click(object sender, EventArgs e) {
            DialogNum dialog = new DialogNum("Cities", 5, 1000);
            if(dialog.ShowDialog() == DialogResult.OK) {
                int n = (int)dialog.numericUpDown1.Value;
                cuts = -1;
                eraseChromosomes();
                initRandomCities(n);
                richTextBox1.AppendText("Spawning " + n + " random cities...\n");
                richTextBox1.AppendText("Computing all distances.....");
                initGraphDistances();
                richTextBox1.AppendText("Done\n\n");
                canvas1.Invalidate(); //paint
            }
            dialog.Dispose();
        }

        private void eraseChromosomes() {
            totalBestChromosome = null;
            currBestChromosome = null;
            chros = null;
            generation = 0;
        }

        private void initRandomCities(int n) {
            cities = new Point[n];
            for(int i = 0;i < n;i++) {
                cities[i] = new Point(rand.Next(canvas1.Width), rand.Next(canvas1.Height));
            }
        }

        private void initGraphDistances() {
            int n = cities.Length;
            G = new double[n][];
            for(int i = 0;i < n;i++)
                G[i] = new double[n];
            for(int i = 0;i < n;i++) {
                G[i][i] = 0;
                for(int j = i + 1;j < n;j++) {
                    Point c1 = cities[i];
                    Point c2 = cities[j];
                    G[i][j] = G[j][i] = Math.Sqrt((c1.X - c2.X) * (c1.X - c2.X) + (c1.Y - c2.Y) * (c1.Y - c2.Y));
                }
            }
        }

        private void startB_Click(object sender, EventArgs e) {
            if(G == null) { MessageBox.Show("Please initialize the graph first."); return; }
            if(nPointCrossoverToolStripMenuItem.Checked && cuts == -1) { MessageBox.Show("Please specify new number of cuts from order crossover, or change crossover operator."); return; }
            startB.Enabled = checkBox1.Enabled = menuStrip1.Enabled = false;
            stopB.Enabled = true;
            animate = checkBox1.Checked;
            eraseChromosomes();
            startThread();
        }

        private void startThread() {
            solverThread = new Thread((ThreadStart)delegate {
                try {
                    solve();
                }catch(ThreadAbortException) {
                    this.Invoke((MethodInvoker)delegate {
                        richTextBox1.AppendText("Stopped.\n\n");
                    });
                }catch(Exception) { }
            });
            solverThread.Priority = ThreadPriority.Highest;
            solverThread.Start();
        }

        private void stopB_Click(object sender, EventArgs e) {
            if(solverThread.IsAlive) solverThread.Abort();
            startB.Enabled = checkBox1.Enabled = menuStrip1.Enabled = true;
            stopB.Enabled = false;
            eraseChromosomes();
        }

        private void crossoverToolStrip_Click(object sender, EventArgs e) {
            if(cities == null || G == null) { MessageBox.Show("Please initialize the graph first."); return; }
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            if(item == partiallyMatchedCrossoverToolStripMenuItem) {
                crossoverOp = "pmx";
                nPointCrossoverToolStripMenuItem.Checked = false;
                item.Checked = true;
                richTextBox1.AppendText("Crossover operator set to PMX.\n");
            } else if(item == nPointCrossoverToolStripMenuItem){
                DialogNum dialog = new DialogNum("Points(Cuts)", 1, cities.Length - 2);
                if(dialog.ShowDialog() == DialogResult.OK) {
                    crossoverOp = "order";
                    cuts = (int)dialog.numericUpDown1.Value;
                    partiallyMatchedCrossoverToolStripMenuItem.Checked = false;
                    item.Checked = true;
                    richTextBox1.AppendText("Crossover operator set to " + cuts + "-Point.\n");
                }
                dialog.Dispose();
            }
        }

        private void numberOfChromosomesToolStripMenuItem_Click(object sender, EventArgs e) {
            DialogNum dialog = new DialogNum("#chromosomes", 4, 2000);
            if(dialog.ShowDialog() == DialogResult.OK) {
                int n = (int)dialog.numericUpDown1.Value;
                if(n % 2 != 0) {MessageBox.Show("Must be even."); return;}
                NUM_CHROMOSOMES = n;
                richTextBox1.AppendText("Population size(#chromosomes) set to " + n + ".\n");
            }
            dialog.Dispose();
        }

        private void maxGenerationCountToolStripMenuItem_Click(object sender, EventArgs e) {
            DialogNum dialog = new DialogNum("Max generations", 50, 100000);
            if(dialog.ShowDialog() == DialogResult.OK) {
                int n = (int)dialog.numericUpDown1.Value;
                MAX_GENERATIONS = n;
                richTextBox1.AppendText("Max generations set to " + MAX_GENERATIONS + ".\n");
            }
            dialog.Dispose();
        }

        private void maxUnimprovedGenerationCountToolStripMenuItem_Click(object sender, EventArgs e) {
            DialogNum dialog = new DialogNum("Max unimproved", 10, 100000);
            if(dialog.ShowDialog() == DialogResult.OK) {
                int n = (int)dialog.numericUpDown1.Value;
                FITNESS_CHECK_RATE = n;
                richTextBox1.AppendText("Max unimproved generation count set to " + FITNESS_CHECK_RATE + ".\n");
            }
            dialog.Dispose();
        }

        private void mutationRateToolStripMenuItem_Click(object sender, EventArgs e) {
            DialogNum dialog = new DialogNum("Mutation rate %", 0, 100);
            if(dialog.ShowDialog() == DialogResult.OK) {
                int n = (int)dialog.numericUpDown1.Value;
                MUTATION_RATE = n/100.0;
                richTextBox1.AppendText("Mutation rate set to " + n + "%.\n");
            }
            dialog.Dispose();
        }

        private void mutationToolStrip_Click(object sender, EventArgs e) {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            if(item == swapMutationToolStripMenuItem) {
                mutationOp = "swap";
                reverseMutationToolStripMenuItem.Checked = randomMutationToolStripMenuItem.Checked = false;
                item.Checked = true;
                richTextBox1.AppendText("Mutation operator set to Swap.\n");
            } else if(item == reverseMutationToolStripMenuItem) {
                mutationOp = "reverse";
                swapMutationToolStripMenuItem.Checked = randomMutationToolStripMenuItem.Checked = false;
                item.Checked = true;
                richTextBox1.AppendText("Mutation operator set to Reverse.\n");
            } else if(item == randomMutationToolStripMenuItem) {
                mutationOp = "random";
                swapMutationToolStripMenuItem.Checked = reverseMutationToolStripMenuItem.Checked = false;
                item.Checked = true;
                richTextBox1.AppendText("Mutation operator set to Random.\n");
            }
        }

        private void placeCitiesToolStripMenuItem_Click(object sender, EventArgs e) {
            DialogNum dialog = new DialogNum("Total Cities", 3, 50);
            if(dialog.ShowDialog() == DialogResult.OK) {
                int n = (int)dialog.numericUpDown1.Value;
                cities = new Point[n];
                currCityIndex = 0;
                eraseChromosomes();
                startB.Enabled = false;
            }
            dialog.Dispose();
        }

        private void canvas1_MouseClick(object sender, MouseEventArgs e) {
            if(currCityIndex == -1) return;
            cities[currCityIndex++] = new Point(e.X, e.Y);
            canvas1.Invalidate(); //paint
            if(currCityIndex == cities.Length) {
                richTextBox1.AppendText("All " + cities.Length + " cities are placed.");
                currCityIndex = -1;
                initGraphDistances();
                startB.Enabled = true;
            }
        }

        private void giveMatrixToolStripMenuItem_Click(object sender, EventArgs e) {
            DialogMatrix dialog = new DialogMatrix();
            if(dialog.ShowDialog() == DialogResult.OK) {
                try {
                    G = dialog.richTextBox1.Text.Trim().Split("\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                        .Select(line => line.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                            .Select(num => Double.Parse(num)).ToArray())
                        .ToArray();
                }catch(Exception) {
                    MessageBox.Show("Invalid number(s)."); return;
                }
                cuts = -1;
                eraseChromosomes();
                richTextBox1.AppendText("Initialized Graph's Matrix to:\n"+ToString(G)+"\n\n");
            }
            dialog.Dispose();
        }

        private string ToString<T>(T[] arr) {
            StringBuilder sb = new StringBuilder(2 * arr.Length + 1);
            sb.Append("[" + arr[0]);
            for(int i = 1;i < arr.Length;i++) {
                sb.Append(",");
                sb.Append(arr[i]);
            }
            return sb.Append("]").ToString();
        }

        private string ToString<T>(T[][] arr) {
            StringBuilder sb = new StringBuilder(2 * arr.Length + 1);
            sb.Append("[" + ToString(arr[0]));
            for(int i = 1;i < arr.Length;i++) {
                sb.Append(",\n");
                sb.Append(ToString(arr[i]));
            }
            return sb.Append("]").ToString();
        }

    }

}
