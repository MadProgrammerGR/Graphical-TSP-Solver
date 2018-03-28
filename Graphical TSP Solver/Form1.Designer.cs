namespace Graphical_TSP_Solver {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.graphToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.randomCitiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.placeCitiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.giveMatrixToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.maxGenerationCountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.maxUnimprovedGenerationCountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.crossoverToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.partiallyMatchedCrossoverToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nPointCrossoverToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mutationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mutationRateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.swapMutationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reverseMutationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.populationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.numberOfChromosomesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startB = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.stopB = new System.Windows.Forms.Button();
            this.generationL = new System.Windows.Forms.Label();
            this.randomMutationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.canvas1 = new Graphical_TSP_Solver.Canvas();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.richTextBox1.Location = new System.Drawing.Point(436, 27);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richTextBox1.Size = new System.Drawing.Size(306, 333);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "Orange lines - best chromosome in current population.\nRed lines - best chromosome" +
    " found so far.\n\n";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.graphToolStripMenuItem,
            this.generationToolStripMenuItem,
            this.crossoverToolStripMenuItem,
            this.mutationToolStripMenuItem,
            this.populationToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(754, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // graphToolStripMenuItem
            // 
            this.graphToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.randomCitiesToolStripMenuItem,
            this.placeCitiesToolStripMenuItem,
            this.giveMatrixToolStripMenuItem});
            this.graphToolStripMenuItem.Name = "graphToolStripMenuItem";
            this.graphToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.graphToolStripMenuItem.Text = "Graph";
            // 
            // randomCitiesToolStripMenuItem
            // 
            this.randomCitiesToolStripMenuItem.Name = "randomCitiesToolStripMenuItem";
            this.randomCitiesToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.randomCitiesToolStripMenuItem.Text = "Random Cities";
            this.randomCitiesToolStripMenuItem.Click += new System.EventHandler(this.randomCitiesToolStripMenuItem_Click);
            // 
            // placeCitiesToolStripMenuItem
            // 
            this.placeCitiesToolStripMenuItem.Name = "placeCitiesToolStripMenuItem";
            this.placeCitiesToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.placeCitiesToolStripMenuItem.Text = "Place Cities";
            this.placeCitiesToolStripMenuItem.Click += new System.EventHandler(this.placeCitiesToolStripMenuItem_Click);
            // 
            // giveMatrixToolStripMenuItem
            // 
            this.giveMatrixToolStripMenuItem.Name = "giveMatrixToolStripMenuItem";
            this.giveMatrixToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.giveMatrixToolStripMenuItem.Text = "Give Matrix";
            this.giveMatrixToolStripMenuItem.Click += new System.EventHandler(this.giveMatrixToolStripMenuItem_Click);
            // 
            // generationToolStripMenuItem
            // 
            this.generationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.maxGenerationCountToolStripMenuItem,
            this.maxUnimprovedGenerationCountToolStripMenuItem});
            this.generationToolStripMenuItem.Name = "generationToolStripMenuItem";
            this.generationToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.generationToolStripMenuItem.Text = "Generation";
            // 
            // maxGenerationCountToolStripMenuItem
            // 
            this.maxGenerationCountToolStripMenuItem.Name = "maxGenerationCountToolStripMenuItem";
            this.maxGenerationCountToolStripMenuItem.Size = new System.Drawing.Size(262, 22);
            this.maxGenerationCountToolStripMenuItem.Text = "Max Generation Count";
            this.maxGenerationCountToolStripMenuItem.Click += new System.EventHandler(this.maxGenerationCountToolStripMenuItem_Click);
            // 
            // maxUnimprovedGenerationCountToolStripMenuItem
            // 
            this.maxUnimprovedGenerationCountToolStripMenuItem.Name = "maxUnimprovedGenerationCountToolStripMenuItem";
            this.maxUnimprovedGenerationCountToolStripMenuItem.Size = new System.Drawing.Size(262, 22);
            this.maxUnimprovedGenerationCountToolStripMenuItem.Text = "Max Unimproved Generation Count";
            this.maxUnimprovedGenerationCountToolStripMenuItem.Click += new System.EventHandler(this.maxUnimprovedGenerationCountToolStripMenuItem_Click);
            // 
            // crossoverToolStripMenuItem
            // 
            this.crossoverToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.partiallyMatchedCrossoverToolStripMenuItem,
            this.nPointCrossoverToolStripMenuItem});
            this.crossoverToolStripMenuItem.Name = "crossoverToolStripMenuItem";
            this.crossoverToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.crossoverToolStripMenuItem.Text = "Crossover";
            // 
            // partiallyMatchedCrossoverToolStripMenuItem
            // 
            this.partiallyMatchedCrossoverToolStripMenuItem.Checked = true;
            this.partiallyMatchedCrossoverToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.partiallyMatchedCrossoverToolStripMenuItem.Name = "partiallyMatchedCrossoverToolStripMenuItem";
            this.partiallyMatchedCrossoverToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.partiallyMatchedCrossoverToolStripMenuItem.Tag = "";
            this.partiallyMatchedCrossoverToolStripMenuItem.Text = "Partially Matched Crossover";
            this.partiallyMatchedCrossoverToolStripMenuItem.Click += new System.EventHandler(this.crossoverToolStrip_Click);
            // 
            // nPointCrossoverToolStripMenuItem
            // 
            this.nPointCrossoverToolStripMenuItem.Name = "nPointCrossoverToolStripMenuItem";
            this.nPointCrossoverToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.nPointCrossoverToolStripMenuItem.Text = "N-Point Crossover";
            this.nPointCrossoverToolStripMenuItem.Click += new System.EventHandler(this.crossoverToolStrip_Click);
            // 
            // mutationToolStripMenuItem
            // 
            this.mutationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mutationRateToolStripMenuItem,
            this.toolStripSeparator1,
            this.swapMutationToolStripMenuItem,
            this.reverseMutationToolStripMenuItem,
            this.randomMutationToolStripMenuItem});
            this.mutationToolStripMenuItem.Name = "mutationToolStripMenuItem";
            this.mutationToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.mutationToolStripMenuItem.Text = "Mutation";
            // 
            // mutationRateToolStripMenuItem
            // 
            this.mutationRateToolStripMenuItem.Name = "mutationRateToolStripMenuItem";
            this.mutationRateToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.mutationRateToolStripMenuItem.Text = "Mutation Rate";
            this.mutationRateToolStripMenuItem.Click += new System.EventHandler(this.mutationRateToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(168, 6);
            // 
            // swapMutationToolStripMenuItem
            // 
            this.swapMutationToolStripMenuItem.Checked = true;
            this.swapMutationToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.swapMutationToolStripMenuItem.Name = "swapMutationToolStripMenuItem";
            this.swapMutationToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.swapMutationToolStripMenuItem.Text = "Swap Mutation";
            this.swapMutationToolStripMenuItem.Click += new System.EventHandler(this.mutationToolStrip_Click);
            // 
            // reverseMutationToolStripMenuItem
            // 
            this.reverseMutationToolStripMenuItem.Name = "reverseMutationToolStripMenuItem";
            this.reverseMutationToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.reverseMutationToolStripMenuItem.Text = "Reverse Mutation";
            this.reverseMutationToolStripMenuItem.Click += new System.EventHandler(this.mutationToolStrip_Click);
            // 
            // populationToolStripMenuItem
            // 
            this.populationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.numberOfChromosomesToolStripMenuItem});
            this.populationToolStripMenuItem.Name = "populationToolStripMenuItem";
            this.populationToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.populationToolStripMenuItem.Text = "Population";
            // 
            // numberOfChromosomesToolStripMenuItem
            // 
            this.numberOfChromosomesToolStripMenuItem.Name = "numberOfChromosomesToolStripMenuItem";
            this.numberOfChromosomesToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.numberOfChromosomesToolStripMenuItem.Text = "Total Chromosomes ";
            this.numberOfChromosomesToolStripMenuItem.Click += new System.EventHandler(this.numberOfChromosomesToolStripMenuItem_Click);
            // 
            // startB
            // 
            this.startB.Location = new System.Drawing.Point(436, 393);
            this.startB.Name = "startB";
            this.startB.Size = new System.Drawing.Size(114, 28);
            this.startB.TabIndex = 0;
            this.startB.Text = "Start";
            this.startB.UseVisualStyleBackColor = true;
            this.startB.Click += new System.EventHandler(this.startB_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.checkBox1.Location = new System.Drawing.Point(436, 366);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(74, 21);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.Text = "Animate";
            this.checkBox1.UseVisualStyleBackColor = false;
            // 
            // stopB
            // 
            this.stopB.Enabled = false;
            this.stopB.Location = new System.Drawing.Point(628, 393);
            this.stopB.Name = "stopB";
            this.stopB.Size = new System.Drawing.Size(114, 28);
            this.stopB.TabIndex = 5;
            this.stopB.Text = "Stop";
            this.stopB.UseVisualStyleBackColor = true;
            this.stopB.Click += new System.EventHandler(this.stopB_Click);
            // 
            // generationL
            // 
            this.generationL.AutoSize = true;
            this.generationL.Location = new System.Drawing.Point(12, 424);
            this.generationL.Name = "generationL";
            this.generationL.Size = new System.Drawing.Size(86, 17);
            this.generationL.TabIndex = 6;
            this.generationL.Text = "Generation: 0";
            // 
            // randomMutationToolStripMenuItem
            // 
            this.randomMutationToolStripMenuItem.Name = "randomMutationToolStripMenuItem";
            this.randomMutationToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.randomMutationToolStripMenuItem.Text = "Random Mutation";
            this.randomMutationToolStripMenuItem.Click += new System.EventHandler(this.mutationToolStrip_Click);
            // 
            // canvas1
            // 
            this.canvas1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.canvas1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.canvas1.Location = new System.Drawing.Point(12, 27);
            this.canvas1.Name = "canvas1";
            this.canvas1.Size = new System.Drawing.Size(418, 394);
            this.canvas1.TabIndex = 0;
            this.canvas1.Paint += new System.Windows.Forms.PaintEventHandler(this.canvas1_Paint);
            this.canvas1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.canvas1_MouseClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(754, 450);
            this.Controls.Add(this.generationL);
            this.Controls.Add(this.stopB);
            this.Controls.Add(this.startB);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.canvas1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Graphical TSP Solver";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Canvas canvas1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem generationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem crossoverToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mutationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem graphToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem randomCitiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem placeCitiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem giveMatrixToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem maxGenerationCountToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem maxUnimprovedGenerationCountToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem partiallyMatchedCrossoverToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nPointCrossoverToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mutationRateToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem swapMutationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reverseMutationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem populationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem numberOfChromosomesToolStripMenuItem;
        private System.Windows.Forms.Button startB;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button stopB;
        private System.Windows.Forms.Label generationL;
        private System.Windows.Forms.ToolStripMenuItem randomMutationToolStripMenuItem;
    }
}

