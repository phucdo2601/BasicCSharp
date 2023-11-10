namespace Les09ComboBox
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
            this.cboDanhSach = new System.Windows.Forms.ComboBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnInsert = new System.Windows.Forms.Button();
            this.btnSelectedIndex = new System.Windows.Forms.Button();
            this.btnSelectedItem = new System.Windows.Forms.Button();
            this.btnCount = new System.Windows.Forms.Button();
            this.btnAddRange = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnRemoveIndex = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cboDanhSach
            // 
            this.cboDanhSach.FormattingEnabled = true;
            this.cboDanhSach.Items.AddRange(new object[] {
            "test-Item-b01",
            "test-item-b02",
            "test-item-b03",
            "test-item-b04"});
            this.cboDanhSach.Location = new System.Drawing.Point(61, 54);
            this.cboDanhSach.Name = "cboDanhSach";
            this.cboDanhSach.Size = new System.Drawing.Size(121, 24);
            this.cboDanhSach.TabIndex = 0;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(235, 54);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnInsert
            // 
            this.btnInsert.Location = new System.Drawing.Point(235, 97);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(75, 23);
            this.btnInsert.TabIndex = 2;
            this.btnInsert.Text = "Insert";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // btnSelectedIndex
            // 
            this.btnSelectedIndex.Location = new System.Drawing.Point(235, 144);
            this.btnSelectedIndex.Name = "btnSelectedIndex";
            this.btnSelectedIndex.Size = new System.Drawing.Size(169, 23);
            this.btnSelectedIndex.TabIndex = 3;
            this.btnSelectedIndex.Text = "Selected Index";
            this.btnSelectedIndex.UseVisualStyleBackColor = true;
            this.btnSelectedIndex.Click += new System.EventHandler(this.btnSelectedIndex_Click);
            // 
            // btnSelectedItem
            // 
            this.btnSelectedItem.Location = new System.Drawing.Point(235, 195);
            this.btnSelectedItem.Name = "btnSelectedItem";
            this.btnSelectedItem.Size = new System.Drawing.Size(169, 23);
            this.btnSelectedItem.TabIndex = 4;
            this.btnSelectedItem.Text = "SelectedItem";
            this.btnSelectedItem.UseVisualStyleBackColor = true;
            this.btnSelectedItem.Click += new System.EventHandler(this.btnSelectedItem_Click);
            // 
            // btnCount
            // 
            this.btnCount.Location = new System.Drawing.Point(235, 239);
            this.btnCount.Name = "btnCount";
            this.btnCount.Size = new System.Drawing.Size(75, 23);
            this.btnCount.TabIndex = 5;
            this.btnCount.Text = "Count";
            this.btnCount.UseVisualStyleBackColor = true;
            this.btnCount.Click += new System.EventHandler(this.btnCount_Click);
            // 
            // btnAddRange
            // 
            this.btnAddRange.Location = new System.Drawing.Point(383, 239);
            this.btnAddRange.Name = "btnAddRange";
            this.btnAddRange.Size = new System.Drawing.Size(148, 40);
            this.btnAddRange.TabIndex = 6;
            this.btnAddRange.Text = "Add Range";
            this.btnAddRange.UseVisualStyleBackColor = true;
            this.btnAddRange.Click += new System.EventHandler(this.btnAddRange_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(235, 287);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 7;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnRemoveIndex
            // 
            this.btnRemoveIndex.Location = new System.Drawing.Point(235, 330);
            this.btnRemoveIndex.Name = "btnRemoveIndex";
            this.btnRemoveIndex.Size = new System.Drawing.Size(157, 56);
            this.btnRemoveIndex.TabIndex = 8;
            this.btnRemoveIndex.Text = "Remove Index";
            this.btnRemoveIndex.UseVisualStyleBackColor = true;
            this.btnRemoveIndex.Click += new System.EventHandler(this.btnRemoveIndex_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(432, 330);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 9;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnRemoveIndex);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAddRange);
            this.Controls.Add(this.btnCount);
            this.Controls.Add(this.btnSelectedItem);
            this.Controls.Add(this.btnSelectedIndex);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.cboDanhSach);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cboDanhSach;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Button btnSelectedIndex;
        private System.Windows.Forms.Button btnSelectedItem;
        private System.Windows.Forms.Button btnCount;
        private System.Windows.Forms.Button btnAddRange;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnRemoveIndex;
        private System.Windows.Forms.Button btnClear;
    }
}

