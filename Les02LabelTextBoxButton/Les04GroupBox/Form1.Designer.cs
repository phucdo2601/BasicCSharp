namespace Les04GroupBox
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
            this.lblInput = new System.Windows.Forms.Label();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.grColor = new System.Windows.Forms.GroupBox();
            this.rbtnBlack = new System.Windows.Forms.RadioButton();
            this.rbtnBlue = new System.Windows.Forms.RadioButton();
            this.rbtnGreen = new System.Windows.Forms.RadioButton();
            this.rbtnRed = new System.Windows.Forms.RadioButton();
            this.grTextStyle = new System.Windows.Forms.GroupBox();
            this.chkUnderline = new System.Windows.Forms.CheckBox();
            this.chkItalic = new System.Windows.Forms.CheckBox();
            this.chkBold = new System.Windows.Forms.CheckBox();
            this.lblTextDis = new System.Windows.Forms.Label();
            this.lblResult = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.grColor.SuspendLayout();
            this.grTextStyle.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblInput
            // 
            this.lblInput.AutoSize = true;
            this.lblInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInput.Location = new System.Drawing.Point(13, 31);
            this.lblInput.Name = "lblInput";
            this.lblInput.Size = new System.Drawing.Size(116, 25);
            this.lblInput.TabIndex = 0;
            this.lblInput.Text = "Input Text:";
            // 
            // txtInput
            // 
            this.txtInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInput.Location = new System.Drawing.Point(189, 28);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(429, 30);
            this.txtInput.TabIndex = 1;
            this.txtInput.TextChanged += new System.EventHandler(this.txtInput_TextChanged);
            // 
            // grColor
            // 
            this.grColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.grColor.Controls.Add(this.rbtnBlack);
            this.grColor.Controls.Add(this.rbtnBlue);
            this.grColor.Controls.Add(this.rbtnGreen);
            this.grColor.Controls.Add(this.rbtnRed);
            this.grColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grColor.Location = new System.Drawing.Point(18, 84);
            this.grColor.Name = "grColor";
            this.grColor.Size = new System.Drawing.Size(238, 251);
            this.grColor.TabIndex = 2;
            this.grColor.TabStop = false;
            this.grColor.Text = "Color Group";
            // 
            // rbtnBlack
            // 
            this.rbtnBlack.AutoSize = true;
            this.rbtnBlack.Location = new System.Drawing.Point(30, 149);
            this.rbtnBlack.Name = "rbtnBlack";
            this.rbtnBlack.Size = new System.Drawing.Size(72, 24);
            this.rbtnBlack.TabIndex = 3;
            this.rbtnBlack.TabStop = true;
            this.rbtnBlack.Text = "Black";
            this.rbtnBlack.UseVisualStyleBackColor = true;
            // 
            // rbtnBlue
            // 
            this.rbtnBlue.AutoSize = true;
            this.rbtnBlue.ForeColor = System.Drawing.Color.Blue;
            this.rbtnBlue.Location = new System.Drawing.Point(30, 105);
            this.rbtnBlue.Name = "rbtnBlue";
            this.rbtnBlue.Size = new System.Drawing.Size(64, 24);
            this.rbtnBlue.TabIndex = 2;
            this.rbtnBlue.TabStop = true;
            this.rbtnBlue.Text = "Blue";
            this.rbtnBlue.UseVisualStyleBackColor = true;
            // 
            // rbtnGreen
            // 
            this.rbtnGreen.AutoSize = true;
            this.rbtnGreen.ForeColor = System.Drawing.Color.Green;
            this.rbtnGreen.Location = new System.Drawing.Point(30, 65);
            this.rbtnGreen.Name = "rbtnGreen";
            this.rbtnGreen.Size = new System.Drawing.Size(76, 24);
            this.rbtnGreen.TabIndex = 1;
            this.rbtnGreen.TabStop = true;
            this.rbtnGreen.Text = "Green";
            this.rbtnGreen.UseVisualStyleBackColor = true;
            // 
            // rbtnRed
            // 
            this.rbtnRed.AutoSize = true;
            this.rbtnRed.ForeColor = System.Drawing.Color.Red;
            this.rbtnRed.Location = new System.Drawing.Point(30, 26);
            this.rbtnRed.Name = "rbtnRed";
            this.rbtnRed.Size = new System.Drawing.Size(60, 24);
            this.rbtnRed.TabIndex = 0;
            this.rbtnRed.TabStop = true;
            this.rbtnRed.Text = "Red";
            this.rbtnRed.UseVisualStyleBackColor = true;
            // 
            // grTextStyle
            // 
            this.grTextStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.grTextStyle.Controls.Add(this.chkUnderline);
            this.grTextStyle.Controls.Add(this.chkItalic);
            this.grTextStyle.Controls.Add(this.chkBold);
            this.grTextStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grTextStyle.Location = new System.Drawing.Point(436, 84);
            this.grTextStyle.Name = "grTextStyle";
            this.grTextStyle.Size = new System.Drawing.Size(238, 251);
            this.grTextStyle.TabIndex = 3;
            this.grTextStyle.TabStop = false;
            this.grTextStyle.Text = "Text Font";
            // 
            // chkUnderline
            // 
            this.chkUnderline.AutoSize = true;
            this.chkUnderline.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkUnderline.Location = new System.Drawing.Point(32, 133);
            this.chkUnderline.Name = "chkUnderline";
            this.chkUnderline.Size = new System.Drawing.Size(117, 29);
            this.chkUnderline.TabIndex = 2;
            this.chkUnderline.Text = "Underline";
            this.chkUnderline.UseVisualStyleBackColor = true;
            this.chkUnderline.CheckedChanged += new System.EventHandler(this.chkUnderline_CheckedChanged);
            // 
            // chkItalic
            // 
            this.chkItalic.AutoSize = true;
            this.chkItalic.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkItalic.Location = new System.Drawing.Point(32, 86);
            this.chkItalic.Name = "chkItalic";
            this.chkItalic.Size = new System.Drawing.Size(73, 29);
            this.chkItalic.TabIndex = 1;
            this.chkItalic.Text = "Italic";
            this.chkItalic.UseVisualStyleBackColor = true;
            this.chkItalic.CheckedChanged += new System.EventHandler(this.chkItalic_CheckedChanged);
            // 
            // chkBold
            // 
            this.chkBold.AutoSize = true;
            this.chkBold.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkBold.Location = new System.Drawing.Point(32, 39);
            this.chkBold.Name = "chkBold";
            this.chkBold.Size = new System.Drawing.Size(77, 29);
            this.chkBold.TabIndex = 0;
            this.chkBold.Text = "Bold";
            this.chkBold.UseVisualStyleBackColor = true;
            this.chkBold.CheckedChanged += new System.EventHandler(this.chkBold_CheckedChanged);
            // 
            // lblTextDis
            // 
            this.lblTextDis.AutoSize = true;
            this.lblTextDis.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTextDis.Location = new System.Drawing.Point(23, 386);
            this.lblTextDis.Name = "lblTextDis";
            this.lblTextDis.Size = new System.Drawing.Size(128, 25);
            this.lblTextDis.TabIndex = 4;
            this.lblTextDis.Text = "Result Text:";
            // 
            // lblResult
            // 
            this.lblResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResult.Location = new System.Drawing.Point(189, 386);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(462, 33);
            this.lblResult.TabIndex = 5;
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(682, 386);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 33);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(843, 549);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.lblTextDis);
            this.Controls.Add(this.grTextStyle);
            this.Controls.Add(this.grColor);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.lblInput);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.grColor.ResumeLayout(false);
            this.grColor.PerformLayout();
            this.grTextStyle.ResumeLayout(false);
            this.grTextStyle.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblInput;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.GroupBox grColor;
        private System.Windows.Forms.GroupBox grTextStyle;
        private System.Windows.Forms.Label lblTextDis;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.RadioButton rbtnBlack;
        private System.Windows.Forms.RadioButton rbtnBlue;
        private System.Windows.Forms.RadioButton rbtnGreen;
        private System.Windows.Forms.RadioButton rbtnRed;
        private System.Windows.Forms.CheckBox chkUnderline;
        private System.Windows.Forms.CheckBox chkItalic;
        private System.Windows.Forms.CheckBox chkBold;
        private System.Windows.Forms.Button btnExit;
    }
}

