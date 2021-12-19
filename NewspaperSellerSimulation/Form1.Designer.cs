namespace NewspaperSellerSimulation
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
            this.scrap_t = new System.Windows.Forms.TextBox();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.table_dgv = new System.Windows.Forms.DataGridView();
            this.simulate_b = new System.Windows.Forms.Button();
            this.selling_t = new System.Windows.Forms.TextBox();
            this.purchace_t = new System.Windows.Forms.TextBox();
            this.records_t = new System.Windows.Forms.TextBox();
            this.newspaper_t = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.table_dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // scrap_t
            // 
            this.scrap_t.BackColor = System.Drawing.SystemColors.Control;
            this.scrap_t.Location = new System.Drawing.Point(937, 345);
            this.scrap_t.Margin = new System.Windows.Forms.Padding(2);
            this.scrap_t.Name = "scrap_t";
            this.scrap_t.Size = new System.Drawing.Size(43, 20);
            this.scrap_t.TabIndex = 27;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "daily net profit";
            this.Column10.MinimumWidth = 8;
            this.Column10.Name = "Column10";
            this.Column10.Width = 150;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "Scrap profit";
            this.Column9.MinimumWidth = 8;
            this.Column9.Name = "Column9";
            this.Column9.Width = 150;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Lost profit";
            this.Column8.MinimumWidth = 8;
            this.Column8.Name = "Column8";
            this.Column8.Width = 150;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Sales profit";
            this.Column7.MinimumWidth = 8;
            this.Column7.Name = "Column7";
            this.Column7.Width = 150;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Daily cost";
            this.Column6.MinimumWidth = 8;
            this.Column6.Name = "Column6";
            this.Column6.Width = 150;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "demand";
            this.Column5.MinimumWidth = 8;
            this.Column5.Name = "Column5";
            this.Column5.Width = 150;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Random demand";
            this.Column4.MinimumWidth = 8;
            this.Column4.Name = "Column4";
            this.Column4.Width = 150;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "news day type";
            this.Column3.MinimumWidth = 8;
            this.Column3.Name = "Column3";
            this.Column3.Width = 150;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Random news day type";
            this.Column2.MinimumWidth = 8;
            this.Column2.Name = "Column2";
            this.Column2.Width = 150;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "DayNo";
            this.Column1.MinimumWidth = 8;
            this.Column1.Name = "Column1";
            this.Column1.Width = 150;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(873, 347);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 26;
            this.label5.Text = "Scrap Price";
            // 
            // table_dgv
            // 
            this.table_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.table_dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column10});
            this.table_dgv.Location = new System.Drawing.Point(13, 13);
            this.table_dgv.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.table_dgv.Name = "table_dgv";
            this.table_dgv.RowHeadersWidth = 62;
            this.table_dgv.RowTemplate.Height = 24;
            this.table_dgv.Size = new System.Drawing.Size(1045, 313);
            this.table_dgv.TabIndex = 25;
            // 
            // simulate_b
            // 
            this.simulate_b.Location = new System.Drawing.Point(490, 412);
            this.simulate_b.Name = "simulate_b";
            this.simulate_b.Size = new System.Drawing.Size(100, 51);
            this.simulate_b.TabIndex = 24;
            this.simulate_b.Text = "Start Simulation";
            this.simulate_b.UseVisualStyleBackColor = true;
            this.simulate_b.Click += new System.EventHandler(this.simulate_b_Click);
            // 
            // selling_t
            // 
            this.selling_t.Location = new System.Drawing.Point(754, 345);
            this.selling_t.Name = "selling_t";
            this.selling_t.ReadOnly = true;
            this.selling_t.Size = new System.Drawing.Size(43, 20);
            this.selling_t.TabIndex = 23;
            // 
            // purchace_t
            // 
            this.purchace_t.Location = new System.Drawing.Point(578, 345);
            this.purchace_t.Name = "purchace_t";
            this.purchace_t.ReadOnly = true;
            this.purchace_t.Size = new System.Drawing.Size(43, 20);
            this.purchace_t.TabIndex = 22;
            // 
            // records_t
            // 
            this.records_t.Location = new System.Drawing.Point(376, 345);
            this.records_t.Name = "records_t";
            this.records_t.ReadOnly = true;
            this.records_t.Size = new System.Drawing.Size(43, 20);
            this.records_t.TabIndex = 21;
            // 
            // newspaper_t
            // 
            this.newspaper_t.Location = new System.Drawing.Point(152, 345);
            this.newspaper_t.Name = "newspaper_t";
            this.newspaper_t.ReadOnly = true;
            this.newspaper_t.Size = new System.Drawing.Size(43, 20);
            this.newspaper_t.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 347);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Number of Newspapers";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(271, 347);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Number Of Records";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(680, 347);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Selling Price";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(488, 347);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Purchacing Price";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1070, 529);
            this.Controls.Add(this.scrap_t);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.table_dgv);
            this.Controls.Add(this.simulate_b);
            this.Controls.Add(this.selling_t);
            this.Controls.Add(this.purchace_t);
            this.Controls.Add(this.records_t);
            this.Controls.Add(this.newspaper_t);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.table_dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox scrap_t;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView table_dgv;
        private System.Windows.Forms.Button simulate_b;
        private System.Windows.Forms.TextBox selling_t;
        private System.Windows.Forms.TextBox purchace_t;
        private System.Windows.Forms.TextBox records_t;
        private System.Windows.Forms.TextBox newspaper_t;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}