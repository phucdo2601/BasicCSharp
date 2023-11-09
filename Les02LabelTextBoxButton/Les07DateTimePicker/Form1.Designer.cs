namespace Les07DateTimePicker
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
            this.grbThongTinDangKy = new System.Windows.Forms.GroupBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.dtpDk = new System.Windows.Forms.DateTimePicker();
            this.txtAge = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.errPhone = new System.Windows.Forms.ErrorProvider(this.components);
            this.errAge = new System.Windows.Forms.ErrorProvider(this.components);
            this.errRegisterDate = new System.Windows.Forms.ErrorProvider(this.components);
            this.grbThongTinDangKy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errPhone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errAge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errRegisterDate)).BeginInit();
            this.SuspendLayout();
            // 
            // grbThongTinDangKy
            // 
            this.grbThongTinDangKy.Controls.Add(this.btnSubmit);
            this.grbThongTinDangKy.Controls.Add(this.dtpDk);
            this.grbThongTinDangKy.Controls.Add(this.txtAge);
            this.grbThongTinDangKy.Controls.Add(this.txtPhone);
            this.grbThongTinDangKy.Controls.Add(this.label3);
            this.grbThongTinDangKy.Controls.Add(this.label2);
            this.grbThongTinDangKy.Controls.Add(this.label1);
            this.grbThongTinDangKy.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbThongTinDangKy.Location = new System.Drawing.Point(13, 13);
            this.grbThongTinDangKy.Name = "grbThongTinDangKy";
            this.grbThongTinDangKy.Size = new System.Drawing.Size(590, 364);
            this.grbThongTinDangKy.TabIndex = 0;
            this.grbThongTinDangKy.TabStop = false;
            this.grbThongTinDangKy.Text = "Thông Tin Đăng Ký";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(252, 227);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(84, 35);
            this.btnSubmit.TabIndex = 6;
            this.btnSubmit.Text = "Đăng Ký";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // dtpDk
            // 
            this.dtpDk.CustomFormat = "dd/MM/yyyy";
            this.dtpDk.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDk.Location = new System.Drawing.Point(135, 163);
            this.dtpDk.Name = "dtpDk";
            this.dtpDk.Size = new System.Drawing.Size(363, 27);
            this.dtpDk.TabIndex = 5;
            // 
            // txtAge
            // 
            this.txtAge.Location = new System.Drawing.Point(135, 114);
            this.txtAge.Name = "txtAge";
            this.txtAge.Size = new System.Drawing.Size(363, 27);
            this.txtAge.TabIndex = 4;
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(135, 67);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(363, 27);
            this.txtPhone.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 163);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "Register Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Age";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Phone";
            // 
            // errPhone
            // 
            this.errPhone.ContainerControl = this;
            // 
            // errAge
            // 
            this.errAge.ContainerControl = this;
            // 
            // errRegisterDate
            // 
            this.errRegisterDate.ContainerControl = this;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(615, 389);
            this.Controls.Add(this.grbThongTinDangKy);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng Ký Xem Phim";
            this.grbThongTinDangKy.ResumeLayout(false);
            this.grbThongTinDangKy.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errPhone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errAge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errRegisterDate)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbThongTinDangKy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.DateTimePicker dtpDk;
        private System.Windows.Forms.TextBox txtAge;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ErrorProvider errPhone;
        private System.Windows.Forms.ErrorProvider errAge;
        private System.Windows.Forms.ErrorProvider errRegisterDate;
    }
}

