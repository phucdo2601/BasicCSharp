namespace PracLes08BasicFromStudentManageB01
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
            this.lblCode = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.lsDanhSach = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Location = new System.Drawing.Point(36, 30);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(40, 16);
            this.lblCode.TabIndex = 0;
            this.lblCode.Text = "Code";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(36, 78);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(44, 16);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Name";
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(112, 30);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(281, 22);
            this.txtCode.TabIndex = 2;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(112, 78);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(281, 22);
            this.txtName.TabIndex = 3;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(112, 135);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(249, 135);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 5;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // lsDanhSach
            // 
            this.lsDanhSach.FormattingEnabled = true;
            this.lsDanhSach.ItemHeight = 16;
            this.lsDanhSach.Location = new System.Drawing.Point(39, 182);
            this.lsDanhSach.Name = "lsDanhSach";
            this.lsDanhSach.Size = new System.Drawing.Size(501, 276);
            this.lsDanhSach.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(928, 493);
            this.Controls.Add(this.lsDanhSach);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblCode);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.ListBox lsDanhSach;
    }
}

