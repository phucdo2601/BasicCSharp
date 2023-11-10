namespace Les12MDIForm
{
    partial class W
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuMain = new System.Windows.Forms.MenuStrip();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOpenForm1 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOpenForm2 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOpenForm3 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuForm4 = new System.Windows.Forms.ToolStripMenuItem();
            this.performanceCounter1 = new System.Diagnostics.PerformanceCounter();
            this.performanceCounter2 = new System.Diagnostics.PerformanceCounter();
            this.menuMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.performanceCounter1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.performanceCounter2)).BeginInit();
            this.SuspendLayout();
            // 
            // menuMain
            // 
            this.menuMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem});
            this.menuMain.Location = new System.Drawing.Point(0, 0);
            this.menuMain.Name = "menuMain";
            this.menuMain.Size = new System.Drawing.Size(800, 28);
            this.menuMain.TabIndex = 0;
            this.menuMain.Text = "menuStrip1";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuOpenForm1,
            this.mnuOpenForm2,
            this.mnuOpenForm3,
            this.mnuForm4});
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(59, 24);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // mnuOpenForm1
            // 
            this.mnuOpenForm1.Name = "mnuOpenForm1";
            this.mnuOpenForm1.Size = new System.Drawing.Size(224, 26);
            this.mnuOpenForm1.Text = "Form1";
            this.mnuOpenForm1.Click += new System.EventHandler(this.mnuOpenForm1_Click);
            // 
            // mnuOpenForm2
            // 
            this.mnuOpenForm2.Name = "mnuOpenForm2";
            this.mnuOpenForm2.Size = new System.Drawing.Size(224, 26);
            this.mnuOpenForm2.Text = "Form2";
            // 
            // mnuOpenForm3
            // 
            this.mnuOpenForm3.Name = "mnuOpenForm3";
            this.mnuOpenForm3.Size = new System.Drawing.Size(224, 26);
            this.mnuOpenForm3.Text = "Form3";
            // 
            // mnuForm4
            // 
            this.mnuForm4.Name = "mnuForm4";
            this.mnuForm4.Size = new System.Drawing.Size(224, 26);
            this.mnuForm4.Text = "Form4";
            // 
            // W
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuMain);
            this.MainMenuStrip = this.menuMain;
            this.Name = "W";
            this.Text = "frm4";
            this.menuMain.ResumeLayout(false);
            this.menuMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.performanceCounter1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.performanceCounter2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuMain;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuOpenForm1;
        private System.Windows.Forms.ToolStripMenuItem mnuOpenForm2;
        private System.Windows.Forms.ToolStripMenuItem mnuOpenForm3;
        private System.Windows.Forms.ToolStripMenuItem mnuForm4;
        private System.Diagnostics.PerformanceCounter performanceCounter1;
        private System.Diagnostics.PerformanceCounter performanceCounter2;
    }
}