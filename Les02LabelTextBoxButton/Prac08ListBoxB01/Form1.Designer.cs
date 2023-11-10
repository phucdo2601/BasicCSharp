namespace Prac08ListBoxB01
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtInputNumber = new System.Windows.Forms.TextBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.grbDanhSach = new System.Windows.Forms.GroupBox();
            this.grbChucNang = new System.Windows.Forms.GroupBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.lstNumber = new System.Windows.Forms.ListBox();
            this.btnAllList = new System.Windows.Forms.Button();
            this.btnDeleteFirstAndLast = new System.Windows.Forms.Button();
            this.btnDeleteSelected = new System.Windows.Forms.Button();
            this.btnIncrementTwo = new System.Windows.Forms.Button();
            this.btnSquaredNumber = new System.Windows.Forms.Button();
            this.btnEvenNumber = new System.Windows.Forms.Button();
            this.btnOddNumber = new System.Windows.Forms.Button();
            this.grbDanhSach.SuspendLayout();
            this.grbChucNang.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Input Number";
            // 
            // txtInputNumber
            // 
            this.txtInputNumber.Location = new System.Drawing.Point(255, 26);
            this.txtInputNumber.Name = "txtInputNumber";
            this.txtInputNumber.Size = new System.Drawing.Size(372, 22);
            this.txtInputNumber.TabIndex = 1;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(658, 25);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 2;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // grbDanhSach
            // 
            this.grbDanhSach.Controls.Add(this.lstNumber);
            this.grbDanhSach.Location = new System.Drawing.Point(26, 93);
            this.grbDanhSach.Name = "grbDanhSach";
            this.grbDanhSach.Size = new System.Drawing.Size(334, 412);
            this.grbDanhSach.TabIndex = 3;
            this.grbDanhSach.TabStop = false;
            this.grbDanhSach.Text = "Danh sách số";
            // 
            // grbChucNang
            // 
            this.grbChucNang.Controls.Add(this.btnOddNumber);
            this.grbChucNang.Controls.Add(this.btnEvenNumber);
            this.grbChucNang.Controls.Add(this.btnSquaredNumber);
            this.grbChucNang.Controls.Add(this.btnIncrementTwo);
            this.grbChucNang.Controls.Add(this.btnDeleteSelected);
            this.grbChucNang.Controls.Add(this.btnDeleteFirstAndLast);
            this.grbChucNang.Controls.Add(this.btnAllList);
            this.grbChucNang.Location = new System.Drawing.Point(430, 93);
            this.grbChucNang.Name = "grbChucNang";
            this.grbChucNang.Size = new System.Drawing.Size(453, 412);
            this.grbChucNang.TabIndex = 4;
            this.grbChucNang.TabStop = false;
            this.grbChucNang.Text = "Chức năng";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(26, 525);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(506, 40);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            // 
            // lstNumber
            // 
            this.lstNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstNumber.FormattingEnabled = true;
            this.lstNumber.ItemHeight = 16;
            this.lstNumber.Location = new System.Drawing.Point(3, 18);
            this.lstNumber.Name = "lstNumber";
            this.lstNumber.Size = new System.Drawing.Size(328, 391);
            this.lstNumber.TabIndex = 0;
            // 
            // btnAllList
            // 
            this.btnAllList.Location = new System.Drawing.Point(6, 32);
            this.btnAllList.Name = "btnAllList";
            this.btnAllList.Size = new System.Drawing.Size(403, 37);
            this.btnAllList.TabIndex = 0;
            this.btnAllList.Text = "Tổng của danh sách";
            this.btnAllList.UseVisualStyleBackColor = true;
            this.btnAllList.Click += new System.EventHandler(this.btnAllList_Click);
            // 
            // btnDeleteFirstAndLast
            // 
            this.btnDeleteFirstAndLast.Location = new System.Drawing.Point(6, 88);
            this.btnDeleteFirstAndLast.Name = "btnDeleteFirstAndLast";
            this.btnDeleteFirstAndLast.Size = new System.Drawing.Size(403, 37);
            this.btnDeleteFirstAndLast.TabIndex = 1;
            this.btnDeleteFirstAndLast.Text = "Xoá phần tử đầu và cuối";
            this.btnDeleteFirstAndLast.UseVisualStyleBackColor = true;
            this.btnDeleteFirstAndLast.Click += new System.EventHandler(this.btnDeleteFirstAndLast_Click);
            // 
            // btnDeleteSelected
            // 
            this.btnDeleteSelected.Location = new System.Drawing.Point(6, 144);
            this.btnDeleteSelected.Name = "btnDeleteSelected";
            this.btnDeleteSelected.Size = new System.Drawing.Size(403, 37);
            this.btnDeleteSelected.TabIndex = 2;
            this.btnDeleteSelected.Text = "Xóa phần tử đang chọn";
            this.btnDeleteSelected.UseVisualStyleBackColor = true;
            this.btnDeleteSelected.Click += new System.EventHandler(this.btnDeleteSelected_Click);
            // 
            // btnIncrementTwo
            // 
            this.btnIncrementTwo.Location = new System.Drawing.Point(6, 200);
            this.btnIncrementTwo.Name = "btnIncrementTwo";
            this.btnIncrementTwo.Size = new System.Drawing.Size(403, 37);
            this.btnIncrementTwo.TabIndex = 3;
            this.btnIncrementTwo.Text = "Tăng mỗi phần tử lên hai";
            this.btnIncrementTwo.UseVisualStyleBackColor = true;
            this.btnIncrementTwo.Click += new System.EventHandler(this.btnIncrementTwo_Click);
            // 
            // btnSquaredNumber
            // 
            this.btnSquaredNumber.Location = new System.Drawing.Point(6, 256);
            this.btnSquaredNumber.Name = "btnSquaredNumber";
            this.btnSquaredNumber.Size = new System.Drawing.Size(403, 37);
            this.btnSquaredNumber.TabIndex = 4;
            this.btnSquaredNumber.Text = "Thay bằng bình phương";
            this.btnSquaredNumber.UseVisualStyleBackColor = true;
            this.btnSquaredNumber.Click += new System.EventHandler(this.btnSquaredNumber_Click);
            // 
            // btnEvenNumber
            // 
            this.btnEvenNumber.Location = new System.Drawing.Point(6, 312);
            this.btnEvenNumber.Name = "btnEvenNumber";
            this.btnEvenNumber.Size = new System.Drawing.Size(403, 37);
            this.btnEvenNumber.TabIndex = 5;
            this.btnEvenNumber.Text = "Chọn số chẵn";
            this.btnEvenNumber.UseVisualStyleBackColor = true;
            this.btnEvenNumber.Click += new System.EventHandler(this.btnEvenNumber_Click);
            // 
            // btnOddNumber
            // 
            this.btnOddNumber.Location = new System.Drawing.Point(6, 368);
            this.btnOddNumber.Name = "btnOddNumber";
            this.btnOddNumber.Size = new System.Drawing.Size(403, 37);
            this.btnOddNumber.TabIndex = 6;
            this.btnOddNumber.Text = "Chọn số lẻ";
            this.btnOddNumber.UseVisualStyleBackColor = true;
            this.btnOddNumber.Click += new System.EventHandler(this.btnOddNumber_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(998, 577);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.grbChucNang);
            this.Controls.Add(this.grbDanhSach);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.txtInputNumber);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.grbDanhSach.ResumeLayout(false);
            this.grbChucNang.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtInputNumber;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.GroupBox grbDanhSach;
        private System.Windows.Forms.GroupBox grbChucNang;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.ListBox lstNumber;
        private System.Windows.Forms.Button btnOddNumber;
        private System.Windows.Forms.Button btnEvenNumber;
        private System.Windows.Forms.Button btnSquaredNumber;
        private System.Windows.Forms.Button btnIncrementTwo;
        private System.Windows.Forms.Button btnDeleteSelected;
        private System.Windows.Forms.Button btnDeleteFirstAndLast;
        private System.Windows.Forms.Button btnAllList;
    }
}

