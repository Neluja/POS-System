namespace Pos_Systm
{
    partial class SalesReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SalesReport));
            dataGridViewSales = new DataGridView();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            dgvProfit = new DataGridView();
            dgvItem = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewSales).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvProfit).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvItem).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewSales
            // 
            dataGridViewSales.BackgroundColor = Color.DimGray;
            dataGridViewSales.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewSales.Location = new Point(10, 77);
            dataGridViewSales.Name = "dataGridViewSales";
            dataGridViewSales.RowHeadersWidth = 51;
            dataGridViewSales.Size = new Size(1014, 188);
            dataGridViewSales.TabIndex = 0;
            // 
            // dgvProfit
            // 
            dgvProfit.BackgroundColor = Color.DimGray;
            dgvProfit.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProfit.Location = new Point(10, 364);
            dgvProfit.Name = "dgvProfit";
            dgvProfit.RowHeadersWidth = 51;
            dgvProfit.Size = new Size(395, 188);
            dgvProfit.TabIndex = 1;
            // 
            // dgvItem
            // 
            dgvItem.BackgroundColor = Color.DimGray;
            dgvItem.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvItem.Location = new Point(481, 364);
            dgvItem.Name = "dgvItem";
            dgvItem.RowHeadersWidth = 51;
            dgvItem.Size = new Size(543, 188);
            dgvItem.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.FlatStyle = FlatStyle.Popup;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(404, 9);
            label1.Name = "label1";
            label1.Size = new Size(210, 38);
            label1.TabIndex = 3;
            label1.Text = "SALES REPORT";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.FlatStyle = FlatStyle.Popup;
            label2.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold);
            label2.ForeColor = Color.White;
            label2.Location = new Point(99, 309);
            label2.Name = "label2";
            label2.Size = new Size(200, 38);
            label2.TabIndex = 4;
            label2.Text = "DAILY PROFIT";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.FlatStyle = FlatStyle.Popup;
            label3.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold);
            label3.ForeColor = Color.White;
            label3.Location = new Point(597, 309);
            label3.Name = "label3";
            label3.Size = new Size(353, 38);
            label3.TabIndex = 5;
            label3.Text = "MOST SELLING PRODUCT";
            // 
            // SalesReport
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1032, 712);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dgvItem);
            Controls.Add(dgvProfit);
            Controls.Add(dataGridViewSales);
            FormBorderStyle = FormBorderStyle.None;
            Name = "SalesReport";
            Text = "SalesReport";
            Load += SalesReport_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewSales).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvProfit).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvItem).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewSales;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private DataGridView dgvProfit;
        private DataGridView dgvItem;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}