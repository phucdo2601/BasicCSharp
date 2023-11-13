namespace PracLes14_FunnyGame
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
            this.components = new System.ComponentModel.Container();
            this.lblNum1 = new System.Windows.Forms.Label();
            this.lblNum2 = new System.Windows.Forms.Label();
            this.lblNum3 = new System.Windows.Forms.Label();
            this.lblCoin = new System.Windows.Forms.Label();
            this.txtCoin = new System.Windows.Forms.TextBox();
            this.btnSpin = new System.Windows.Forms.Button();
            this.btnNewGame = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lblNum1
            // 
            this.lblNum1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblNum1.Font = new System.Drawing.Font("Microsoft YaHei UI", 48F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNum1.ForeColor = System.Drawing.Color.Red;
            this.lblNum1.Location = new System.Drawing.Point(29, 26);
            this.lblNum1.Name = "lblNum1";
            this.lblNum1.Size = new System.Drawing.Size(131, 123);
            this.lblNum1.TabIndex = 0;
            this.lblNum1.Text = "7";
            this.lblNum1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNum2
            // 
            this.lblNum2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblNum2.Font = new System.Drawing.Font("Microsoft YaHei UI", 48F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNum2.ForeColor = System.Drawing.Color.Red;
            this.lblNum2.Location = new System.Drawing.Point(224, 26);
            this.lblNum2.Name = "lblNum2";
            this.lblNum2.Size = new System.Drawing.Size(131, 123);
            this.lblNum2.TabIndex = 1;
            this.lblNum2.Text = "7";
            this.lblNum2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNum3
            // 
            this.lblNum3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblNum3.Font = new System.Drawing.Font("Microsoft YaHei UI", 48F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNum3.ForeColor = System.Drawing.Color.Red;
            this.lblNum3.Location = new System.Drawing.Point(433, 26);
            this.lblNum3.Name = "lblNum3";
            this.lblNum3.Size = new System.Drawing.Size(131, 123);
            this.lblNum3.TabIndex = 2;
            this.lblNum3.Text = "7";
            this.lblNum3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCoin
            // 
            this.lblCoin.AutoSize = true;
            this.lblCoin.Location = new System.Drawing.Point(32, 173);
            this.lblCoin.Name = "lblCoin";
            this.lblCoin.Size = new System.Drawing.Size(106, 16);
            this.lblCoin.TabIndex = 3;
            this.lblCoin.Text = "Tiền Người Chơi:";
            // 
            // txtCoin
            // 
            this.txtCoin.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCoin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txtCoin.Location = new System.Drawing.Point(154, 173);
            this.txtCoin.Name = "txtCoin";
            this.txtCoin.ReadOnly = true;
            this.txtCoin.Size = new System.Drawing.Size(235, 29);
            this.txtCoin.TabIndex = 4;
            this.txtCoin.Text = "100";
            this.txtCoin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnSpin
            // 
            this.btnSpin.Location = new System.Drawing.Point(35, 228);
            this.btnSpin.Name = "btnSpin";
            this.btnSpin.Size = new System.Drawing.Size(73, 39);
            this.btnSpin.TabIndex = 5;
            this.btnSpin.Text = "Spin";
            this.btnSpin.UseVisualStyleBackColor = true;
            this.btnSpin.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnNewGame
            // 
            this.btnNewGame.Location = new System.Drawing.Point(282, 228);
            this.btnNewGame.Name = "btnNewGame";
            this.btnNewGame.Size = new System.Drawing.Size(107, 39);
            this.btnNewGame.TabIndex = 6;
            this.btnNewGame.Text = "New Game";
            this.btnNewGame.UseVisualStyleBackColor = true;
            this.btnNewGame.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(154, 320);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(73, 39);
            this.btnExit.TabIndex = 7;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(154, 228);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(73, 39);
            this.btnStop.TabIndex = 8;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.button4_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 455);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnNewGame);
            this.Controls.Add(this.btnSpin);
            this.Controls.Add(this.txtCoin);
            this.Controls.Add(this.lblCoin);
            this.Controls.Add(this.lblNum3);
            this.Controls.Add(this.lblNum2);
            this.Controls.Add(this.lblNum1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNum1;
        private System.Windows.Forms.Label lblNum2;
        private System.Windows.Forms.Label lblNum3;
        private System.Windows.Forms.Label lblCoin;
        private System.Windows.Forms.TextBox txtCoin;
        private System.Windows.Forms.Button btnSpin;
        private System.Windows.Forms.Button btnNewGame;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Timer timer1;
    }
}

