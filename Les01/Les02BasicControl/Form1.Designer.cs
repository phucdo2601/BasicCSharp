namespace Les02BasicControl
{
    partial class Form1
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
            this.lblNumA = new System.Windows.Forms.Label();
            this.lblNumB = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblNumA
            // 
            this.lblNumA.AutoSize = true;
            this.lblNumA.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblNumA.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.18868F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumA.ForeColor = System.Drawing.Color.Red;
            this.lblNumA.Location = new System.Drawing.Point(84, 69);
            this.lblNumA.Name = "lblNumA";
            this.lblNumA.Size = new System.Drawing.Size(58, 18);
            this.lblNumA.TabIndex = 0;
            this.lblNumA.Text = "Num A";
            // 
            // lblNumB
            // 
            this.lblNumB.AutoSize = true;
            this.lblNumB.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblNumB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.18868F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumB.ForeColor = System.Drawing.Color.Red;
            this.lblNumB.Location = new System.Drawing.Point(84, 103);
            this.lblNumB.Name = "lblNumB";
            this.lblNumB.Size = new System.Drawing.Size(59, 18);
            this.lblNumB.TabIndex = 1;
            this.lblNumB.Text = "Num B";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblNumB);
            this.Controls.Add(this.lblNumA);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNumA;
        private System.Windows.Forms.Label lblNumB;
    }
}

