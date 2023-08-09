namespace QuanLyQuanCafeb01
{
    partial class fAdmin
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
            this.tabBase = new System.Windows.Forms.TabControl();
            this.tcBill = new System.Windows.Forms.TabPage();
            this.tbFood = new System.Windows.Forms.TabPage();
            this.tbFoodCategory = new System.Windows.Forms.TabPage();
            this.tbTable = new System.Windows.Forms.TabPage();
            this.tbAccount = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dtpkFromDate = new System.Windows.Forms.DateTimePicker();
            this.dtpkToDate = new System.Windows.Forms.DateTimePicker();
            this.btnViewBill = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.dtgvFood = new System.Windows.Forms.DataGridView();
            this.btnFoodAdd = new System.Windows.Forms.Button();
            this.btnFoodEdit = new System.Windows.Forms.Button();
            this.btnFoodDelete = new System.Windows.Forms.Button();
            this.tabBase.SuspendLayout();
            this.tcBill.SuspendLayout();
            this.tbFood.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvFood)).BeginInit();
            this.SuspendLayout();
            // 
            // tabBase
            // 
            this.tabBase.Controls.Add(this.tcBill);
            this.tabBase.Controls.Add(this.tbFood);
            this.tabBase.Controls.Add(this.tbFoodCategory);
            this.tabBase.Controls.Add(this.tbTable);
            this.tabBase.Controls.Add(this.tbAccount);
            this.tabBase.Location = new System.Drawing.Point(13, 13);
            this.tabBase.Name = "tabBase";
            this.tabBase.SelectedIndex = 0;
            this.tabBase.Size = new System.Drawing.Size(933, 548);
            this.tabBase.TabIndex = 0;
            // 
            // tcBill
            // 
            this.tcBill.Controls.Add(this.panel2);
            this.tcBill.Controls.Add(this.panel1);
            this.tcBill.Location = new System.Drawing.Point(4, 25);
            this.tcBill.Name = "tcBill";
            this.tcBill.Padding = new System.Windows.Forms.Padding(3);
            this.tcBill.Size = new System.Drawing.Size(925, 519);
            this.tcBill.TabIndex = 0;
            this.tcBill.Text = "Doanh thu";
            this.tcBill.UseVisualStyleBackColor = true;
            // 
            // tbFood
            // 
            this.tbFood.Controls.Add(this.panel4);
            this.tbFood.Controls.Add(this.panel5);
            this.tbFood.Controls.Add(this.panel6);
            this.tbFood.Controls.Add(this.panel3);
            this.tbFood.Location = new System.Drawing.Point(4, 25);
            this.tbFood.Name = "tbFood";
            this.tbFood.Padding = new System.Windows.Forms.Padding(3);
            this.tbFood.Size = new System.Drawing.Size(925, 519);
            this.tbFood.TabIndex = 1;
            this.tbFood.Text = "Food";
            this.tbFood.UseVisualStyleBackColor = true;
            // 
            // tbFoodCategory
            // 
            this.tbFoodCategory.Location = new System.Drawing.Point(4, 25);
            this.tbFoodCategory.Name = "tbFoodCategory";
            this.tbFoodCategory.Padding = new System.Windows.Forms.Padding(3);
            this.tbFoodCategory.Size = new System.Drawing.Size(925, 519);
            this.tbFoodCategory.TabIndex = 2;
            this.tbFoodCategory.Text = "Food Category";
            this.tbFoodCategory.UseVisualStyleBackColor = true;
            // 
            // tbTable
            // 
            this.tbTable.Location = new System.Drawing.Point(4, 25);
            this.tbTable.Name = "tbTable";
            this.tbTable.Padding = new System.Windows.Forms.Padding(3);
            this.tbTable.Size = new System.Drawing.Size(925, 519);
            this.tbTable.TabIndex = 3;
            this.tbTable.Text = "Table";
            this.tbTable.UseVisualStyleBackColor = true;
            // 
            // tbAccount
            // 
            this.tbAccount.Location = new System.Drawing.Point(4, 25);
            this.tbAccount.Name = "tbAccount";
            this.tbAccount.Padding = new System.Windows.Forms.Padding(3);
            this.tbAccount.Size = new System.Drawing.Size(925, 519);
            this.tbAccount.TabIndex = 4;
            this.tbAccount.Text = "Account";
            this.tbAccount.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnViewBill);
            this.panel1.Controls.Add(this.dtpkToDate);
            this.panel1.Controls.Add(this.dtpkFromDate);
            this.panel1.Location = new System.Drawing.Point(7, 7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(912, 51);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Location = new System.Drawing.Point(7, 65);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(912, 446);
            this.panel2.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(4, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(905, 439);
            this.dataGridView1.TabIndex = 0;
            // 
            // dtpkFromDate
            // 
            this.dtpkFromDate.Location = new System.Drawing.Point(4, 3);
            this.dtpkFromDate.Name = "dtpkFromDate";
            this.dtpkFromDate.Size = new System.Drawing.Size(200, 22);
            this.dtpkFromDate.TabIndex = 1;
            // 
            // dtpkToDate
            // 
            this.dtpkToDate.Location = new System.Drawing.Point(283, 3);
            this.dtpkToDate.Name = "dtpkToDate";
            this.dtpkToDate.Size = new System.Drawing.Size(200, 22);
            this.dtpkToDate.TabIndex = 2;
            // 
            // btnViewBill
            // 
            this.btnViewBill.Location = new System.Drawing.Point(546, 3);
            this.btnViewBill.Name = "btnViewBill";
            this.btnViewBill.Size = new System.Drawing.Size(75, 23);
            this.btnViewBill.TabIndex = 3;
            this.btnViewBill.Text = "Analyst";
            this.btnViewBill.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnFoodDelete);
            this.panel3.Controls.Add(this.btnFoodEdit);
            this.panel3.Controls.Add(this.btnFoodAdd);
            this.panel3.Location = new System.Drawing.Point(6, 6);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(462, 97);
            this.panel3.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dtgvFood);
            this.panel4.Location = new System.Drawing.Point(6, 109);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(462, 393);
            this.panel4.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.Location = new System.Drawing.Point(495, 109);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(424, 393);
            this.panel5.TabIndex = 1;
            // 
            // panel6
            // 
            this.panel6.Location = new System.Drawing.Point(495, 10);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(424, 93);
            this.panel6.TabIndex = 1;
            // 
            // dtgvFood
            // 
            this.dtgvFood.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvFood.Location = new System.Drawing.Point(4, 4);
            this.dtgvFood.Name = "dtgvFood";
            this.dtgvFood.RowHeadersWidth = 51;
            this.dtgvFood.RowTemplate.Height = 24;
            this.dtgvFood.Size = new System.Drawing.Size(455, 386);
            this.dtgvFood.TabIndex = 0;
            // 
            // btnFoodAdd
            // 
            this.btnFoodAdd.Location = new System.Drawing.Point(18, 14);
            this.btnFoodAdd.Name = "btnFoodAdd";
            this.btnFoodAdd.Size = new System.Drawing.Size(75, 23);
            this.btnFoodAdd.TabIndex = 1;
            this.btnFoodAdd.Text = "Add";
            this.btnFoodAdd.UseVisualStyleBackColor = true;
            // 
            // btnFoodEdit
            // 
            this.btnFoodEdit.Location = new System.Drawing.Point(160, 14);
            this.btnFoodEdit.Name = "btnFoodEdit";
            this.btnFoodEdit.Size = new System.Drawing.Size(75, 23);
            this.btnFoodEdit.TabIndex = 2;
            this.btnFoodEdit.Text = "Edit";
            this.btnFoodEdit.UseVisualStyleBackColor = true;
            // 
            // btnFoodDelete
            // 
            this.btnFoodDelete.Location = new System.Drawing.Point(266, 14);
            this.btnFoodDelete.Name = "btnFoodDelete";
            this.btnFoodDelete.Size = new System.Drawing.Size(75, 23);
            this.btnFoodDelete.TabIndex = 3;
            this.btnFoodDelete.Text = "Delete";
            this.btnFoodDelete.UseVisualStyleBackColor = true;
            // 
            // fAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(949, 561);
            this.Controls.Add(this.tabBase);
            this.Name = "fAdmin";
            this.Text = "fAdminForm";
            this.tabBase.ResumeLayout(false);
            this.tcBill.ResumeLayout(false);
            this.tbFood.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvFood)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabBase;
        private System.Windows.Forms.TabPage tcBill;
        private System.Windows.Forms.TabPage tbFood;
        private System.Windows.Forms.TabPage tbFoodCategory;
        private System.Windows.Forms.TabPage tbTable;
        private System.Windows.Forms.TabPage tbAccount;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dtpkFromDate;
        private System.Windows.Forms.DateTimePicker dtpkToDate;
        private System.Windows.Forms.Button btnViewBill;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dtgvFood;
        private System.Windows.Forms.Button btnFoodAdd;
        private System.Windows.Forms.Button btnFoodEdit;
        private System.Windows.Forms.Button btnFoodDelete;
    }
}