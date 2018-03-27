using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graphical_TSP_Solver {
    public partial class Form1 {
        Random rand = new Random();
        double[][] G;
        int[][] chros; //plh8ysmos
        int NUM_CHROMOSOMES = 8;
        int MAX_GENERATIONS = 100;
        int FITNESS_CHECK_RATE = 50;
        double MUTATION_RATE = 0.05;
        int[] totalBestChromosome, currBestChromosome;
        int generation;
        int cuts; //gia thn periptwsh tou N-Point crossover
        String crossoverOp = "pmx";
        String mutationOp = "swap";

        //genetic algorithm
        private void solve() {
            //arxikopoihsh xrwmoswmatwn ws tyxaies meta8eseis
            chros = new int[NUM_CHROMOSOMES][];
            for(int i = 0;i < chros.Length;i++)
                chros[i] = randomPermutation(G.Length);

            //o kainourgios plh8ysmos prepei na apo8hkeuetai se diaforetiko 2d pinaka
            //alliws se mia genia 8a epilegontan paidia twn paidiwn
            int[][] nextChros = (int[][])chros.Clone();//idiou mege8ous
            double[] fitnesses = calcFitnesses();

            double batchBestFitness = fitnesses.Max();
            double totalBestFitness = batchBestFitness;
            totalBestChromosome = (int[])chros[Array.IndexOf(fitnesses, batchBestFitness)].Clone(); //argmax
            int bestGeneration = 0;
            generation = 0;
            while(++generation < MAX_GENERATIONS) {

                double[] probs = selectionProbabilies(fitnesses);
                for(int i = 0;i < chros.Length / 2;i++) {
                    int[] parent1 = chros[pickRandomIndex(probs)];
                    int[] parent2 = chros[pickRandomIndex(probs)];

                    int[][] childs = (crossoverOp == "pmx") ? pmxCrossover(parent1, parent2) : orderCrossover(parent1, parent2);

                    if(rand.NextDouble() < MUTATION_RATE) {
                        if(mutationOp == "swap") {
                            swapMutate(childs[0]);
                            swapMutate(childs[1]);
                        } else {
                            reverseMutate(childs[0]);
                            reverseMutate(childs[1]);
                        }
                    }

                    nextChros[2 * i] = childs[0];
                    nextChros[2 * i + 1] = childs[1];
                }
                chros = (int[][])nextChros.Clone();
                fitnesses = calcFitnesses();

                double currMaxFitness = fitnesses.Max();
                currBestChromosome = (int[])chros[Array.IndexOf(fitnesses, currMaxFitness)].Clone(); //argmax

                //an veltiw8hke to kalytero fitness
                if(currMaxFitness > batchBestFitness) {
                    batchBestFitness = currMaxFitness;
                    totalBestChromosome = (int[])currBestChromosome.Clone(); //argmax
                    bestGeneration = generation;
                }

                //ka8e FITNESS_CHECK_RATE genies
                if(generation % FITNESS_CHECK_RATE == 0) {
                    if(batchBestFitness <= totalBestFitness) { //an de veltiw8hke stamatame
                        break;
                    } else { //alliws synexizoume
                        totalBestFitness = batchBestFitness;
                    }
                }
                //repaint
                if(animate) {
                    this.Invoke((MethodInvoker)delegate { canvas1.Invalidate(); });
                    Thread.Sleep(1000 / animFPS);//ka8ysterhsh wste na fenetai to animation
                }
            }

            this.Invoke((MethodInvoker)delegate {
                canvas1.Invalidate(); //repaint
                startB.Enabled = checkBox1.Enabled = menuStrip1.Enabled = true;
                stopB.Enabled = false;
                richTextBox1.AppendText("Finished after " + generation + " generations.\n");
                richTextBox1.AppendText("Found best chromosome in generation: " + bestGeneration + "\n");
                richTextBox1.AppendText("Best chromosome: " + ToString(totalBestChromosome) + "\n");
                richTextBox1.AppendText("with total distance (cost): " + (int)(1 / totalBestFitness) + "\n\n");
            });
        }

        //allazei 8esh se 2 tyxaia stoixeia
        private void swapMutate(int[] c) {
            int n = c.Length;
            int i1 = rand.Next(n);
            int i2 = (i1 + rand.Next(1, n)) % n;
            int t = c[i1];
            c[i1] = c[i2];
            c[i2] = t;
        }

        //antistrefei th seira se ena tyxaio diasthma tou pinaka
        private void reverseMutate(int[] chromosome) {
            int n = chromosome.Length;
            int r = rand.Next(n - 1);
            Array.Reverse(chromosome, r, rand.Next(n - r));
        }

        //dialegei 2 tyxaia shmeia kophs k efarmozei to pmx 2 fores
        private int[][] pmxCrossover(int[] p1, int[] p2) {
            int n = p1.Length;
            int i1 = rand.Next(n);
            int i2 = (i1 + rand.Next(1, n)) % n;
            return new int[][] { pmx(p1, p2, Math.Min(i1, i2), Math.Max(i1, i2)),
                                 pmx(p2, p1, Math.Min(i1, i2), Math.Max(i1, i2))};
        }

        /**
         * partially matched crossover (PMX)
         * paradeigma:
         * [i1,i2)=[3,6)
         * p1: 052|(346)|17
         * p2: 265| 470 |13
         * c:  205|(346)|17
         * apo to p1 antigrafontai ston c ta stoixeia tou sto diasthma [i1,i2)
         * ta ypoloipa stoixeia tou c antigrafontai apo ta stoixeia tou p2 ektos tou [i1,i2) dld [0,i1)U[i2,n)
         * otan ta stoixeia pou erxontai apo ton p2 yparxoun hdh, tote xrhsimopoieitai to messaio diasthma gia th meta8esh tous
         * gia paradeigma tou 3 apo ton p2 ginetai 3->4->7 epeidh yparxei hdh to 3 kai to 4 alla to 7 oxi
         */
        private int[] pmx(int[] p1, int[] p2, int i1, int i2) {
            int n = p1.Length;
            int[] c = new int[n];
            int[] map = new int[n]; //leei pou vrisketai ka8e stoixeio ston pinaka c
            for(int i = 0;i < n;i++) map[i] = -1;
            for(int i = i1;i < i2;i++) {
                c[i] = p1[i];
                map[p1[i]] = i;
            }
            for(int i = 0;i < n;i++) {
                if(i == i1) i = i2; //skip [i1,i2)
                int k = p2[i];
                while(map[k] != -1) { //mexri na vre8ei kapoio pou den yparxei sto c
                    k = p2[map[k]];
                }
                c[i] = k;
            }
            return c;
        }


        //dialegei tyxaia N shmeia kophs (N=cuts pou exei dwsei o xrhsths kai ta arxikopoiei me tyxaio tropo
        //gia na ekfrazoun ta shmeia auta "egkyra"(mporei na einai kena) diasthmata
        //prepei to plh8os tous na einai artio opote, an einai peritto apla eisagw ena extra 0 sthn arxh
        private int[][] orderCrossover(int[] p1, int[] p2) {
            int n = p1.Length;
            //+ena parapanw an einai perittos
            int[] points = new int[cuts + (cuts % 2)];
            //diale3e 'cuts' diaforetikes tyxaies 8eseis sto [1,p1.length-1]
            bool[] tmp = new bool[n];
            for(int i = 0;i < cuts;i++) tmp[i] = true;
            shuffleArray(tmp);
            if(cuts % 2 == 1) points[0] = 0;
            for(int i = cuts % 2, k = cuts % 2;i < n;i++) {
                if(tmp[i]) points[k++] = i;
            }
            return new int[][] { ox(p1, p2, points),
                                 ox(p2, p1, points)};
        }

        /** 
         * N-point order crossover
         * paradeigma: 
         * points: 1,3,6,9
         * p1: 0|(12)|345|(678)|9    
         * p2: 6245310879
         * c:  9|(12)|453|(678)|0
         * apo to p1 antigrafontai ekeina stis paren8eseis
         * oi ypoloipes 8eseis gemizontai me ta stoixeia pou leipoun 3ekinwntas apo th 8esh 3 (=points[1])
         * lamvanontas ypopshn thn seira pou emfanizontai ston p2 (3ekinwntas apo thn arxh)
        */
        private int[] ox(int[] p1, int[] p2, int[] points) {
            int n = p1.Length;
            int[] c = new int[n];
            bool[] found = new bool[n]; // k -> {true,false} ama yparxei to k ston c
            for(int j = 0;j < points.Length - 1;j += 2) {
                for(int i = points[j];i != points[j + 1];i = (i + 1) % n) {
                    c[i] = p1[i];
                    found[p1[i]] = true;
                }
            }

            int m = 1;
            int k = points[1];
            for(int i = 0;i < n;i++) {     // p2 3e3kinwntas apo thn arxh
                                           //for(int j = 0;j < n;j++) {   // p2 3ekinwntas apo to points[1] (opws to p1)
                                           //int i = (points[1] + j) % n; // ----------//-------------------------------
                if(!found[p2[i]]) {
                    c[k] = p2[i];
                    k = (k + 1) % n;
                    if(m < points.Length - 2 && k == points[m + 1]) {
                        k = points[m + 2];
                        m += 2;
                    }
                }
            }
            return c;
        }

        // Wheel selection
        private int pickRandomIndex(double[] probs) {
            double s = 0;
            double r = rand.NextDouble();
            for(int i = 0;i < probs.Length;i++) {
                s += probs[i];
                if(r <= s) return i;
            }
            return 0; //de symvainei pote dioti s=S(p[i])=1 kai to r vrisketai [0,1)
        }

        public int[] randomPermutation(int n) {
            //tautotikh meta8esh
            int[] perm = new int[n];
            for(int i = 0;i < n;i++) perm[i] = i;
            //anakatema auths
            shuffleArray(perm);
            return perm;
        }

        private void shuffleArray<T>(T[] arr) {
            for(int i = arr.Length - 1;i > 0;--i) {
                int j = rand.Next(i + 1);
                T t = arr[i];
                arr[i] = arr[j];
                arr[j] = t;
            }
        }

        private double calcFitness(int[] c) {
            double f = 0;
            for(int i = 0;i < c.Length - 1;i++)
                f += G[c[i]][c[i + 1]]; //endiamesoi desmoi
            return 1 / (f + G[c[0]][c[c.Length - 1]]); //+ desmos (prwtos,teleutaios)
        }

        private double[] calcFitnesses() {
            double[] f = new double[chros.Length];
            for(int i = 0;i < chros.Length;i++)
                f[i] = calcFitness(chros[i]);
            return f;
        }

        private double[] selectionProbabilies(double[] f) {
            double[] p = new double[chros.Length];
            double sum = f.Sum();
            for(int i = 0;i < p.Length;i++)
                p[i] = f[i] / sum;
            return p;
        }

    }
}
