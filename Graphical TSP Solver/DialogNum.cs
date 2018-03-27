using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graphical_TSP_Solver {
    public partial class DialogNum : Form {
        public DialogNum(String prompt, int min, int max) {
            InitializeComponent();
            label1.Text = prompt;
            numericUpDown1.Value = numericUpDown1.Minimum = min;
            numericUpDown1.Maximum = max;
        }
    }

    //flicker fix
    public class Canvas : Panel {
        public Canvas() {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
        }
    }

}
