namespace Les08ListBox
{
    partial class btnIndex
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
            this.lstDanSach = new System.Windows.Forms.ListBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnCount = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnSelectIndiclices = new System.Windows.Forms.Button();
            this.btnGan = new System.Windows.Forms.Button();
            this.btnSelectedIndex = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstDanSach
            // 
            this.lstDanSach.FormattingEnabled = true;
            this.lstDanSach.ItemHeight = 16;
            this.lstDanSach.Items.AddRange(new object[] {
            "item_1",
            "item_2",
            "item_3",
            "item_4"});
            this.lstDanSach.Location = new System.Drawing.Point(177, 121);
            this.lstDanSach.Name = "lstDanSach";
            this.lstDanSach.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstDanSach.Size = new System.Drawing.Size(197, 148);
            this.lstDanSach.TabIndex = 0;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(435, 121);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnCount
            // 
            this.btnCount.Location = new System.Drawing.Point(435, 177);
            this.btnCount.Name = "btnCount";
            this.btnCount.Size = new System.Drawing.Size(75, 23);
            this.btnCount.TabIndex = 2;
            this.btnCount.Text = "Count";
            this.btnCount.UseVisualStyleBackColor = true;
            this.btnCount.Click += new System.EventHandler(this.btnCount_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(435, 229);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Index";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(435, 278);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 4;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnSelectIndiclices
            // 
            this.btnSelectIndiclices.Location = new System.Drawing.Point(435, 318);
            this.btnSelectIndiclices.Name = "btnSelectIndiclices";
            this.btnSelectIndiclices.Size = new System.Drawing.Size(114, 23);
            this.btnSelectIndiclices.TabIndex = 5;
            this.btnSelectIndiclices.Text = "SelectedIndiclice";
            this.btnSelectIndiclices.UseVisualStyleBackColor = true;
            this.btnSelectIndiclices.Click += new System.EventHandler(this.btnSelectIndex_Click);
            // 
            // btnGan
            // 
            this.btnGan.Location = new System.Drawing.Point(435, 368);
            this.btnGan.Name = "btnGan";
            this.btnGan.Size = new System.Drawing.Size(75, 34);
            this.btnGan.TabIndex = 6;
            this.btnGan.Text = "Gan";
            this.btnGan.UseVisualStyleBackColor = true;
            this.btnGan.Click += new System.EventHandler(this.btnGan_Click);
            // 
            // btnSelectedIndex
            // 
            this.btnSelectedIndex.Location = new System.Drawing.Point(435, 426);
            this.btnSelectedIndex.Name = "btnSelectedIndex";
            this.btnSelectedIndex.Size = new System.Drawing.Size(114, 23);
            this.btnSelectedIndex.TabIndex = 7;
            this.btnSelectedIndex.Text = "SelectedIndex";
            this.btnSelectedIndex.UseVisualStyleBackColor = true;
            this.btnSelectedIndex.Click += new System.EventHandler(this.btnSelectedIndex_Click);
            // 
            // btnIndex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 526);
            this.Controls.Add(this.btnSelectedIndex);
            this.Controls.Add(this.btnGan);
            this.Controls.Add(this.btnSelectIndiclices);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnCount);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lstDanSach);
            this.Name = "btnIndex";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstDanSach;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnCount;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnSelectIndiclices;
        private System.Windows.Forms.Button btnGan;
        private System.Windows.Forms.Button btnSelectedIndex;
    }
}

