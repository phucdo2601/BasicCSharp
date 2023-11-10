namespace Les13ImageLít
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btn1 = new System.Windows.Forms.Button();
            this.lblImageDis = new System.Windows.Forms.Label();
            this.btnDislayImage = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.imageList1.Images.SetKeyName(0, "testDev02.jpg");
            this.imageList1.Images.SetKeyName(1, "testDev04.jpg");
            this.imageList1.Images.SetKeyName(2, "testDev03.jpg");
            this.imageList1.Images.SetKeyName(3, "testDev01.jpg");
            // 
            // btn1
            // 
            this.btn1.ImageIndex = 0;
            this.btn1.ImageList = this.imageList1;
            this.btn1.Location = new System.Drawing.Point(89, 93);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(147, 79);
            this.btn1.TabIndex = 0;
            this.btn1.Text = "TestBut";
            this.btn1.UseVisualStyleBackColor = true;
            // 
            // lblImageDis
            // 
            this.lblImageDis.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblImageDis.ImageList = this.imageList1;
            this.lblImageDis.Location = new System.Drawing.Point(158, 204);
            this.lblImageDis.Name = "lblImageDis";
            this.lblImageDis.Size = new System.Drawing.Size(278, 153);
            this.lblImageDis.TabIndex = 1;
            this.lblImageDis.Text = "label1";
            // 
            // btnDislayImage
            // 
            this.btnDislayImage.Location = new System.Drawing.Point(357, 93);
            this.btnDislayImage.Name = "btnDislayImage";
            this.btnDislayImage.Size = new System.Drawing.Size(140, 59);
            this.btnDislayImage.TabIndex = 2;
            this.btnDislayImage.Text = "DisplayImage";
            this.btnDislayImage.UseVisualStyleBackColor = true;
            this.btnDislayImage.Click += new System.EventHandler(this.btnDislayImage_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 518);
            this.Controls.Add(this.btnDislayImage);
            this.Controls.Add(this.lblImageDis);
            this.Controls.Add(this.btn1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btn1;
        private System.Windows.Forms.Label lblImageDis;
        private System.Windows.Forms.Button btnDislayImage;
    }
}

