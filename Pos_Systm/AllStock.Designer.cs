namespace Pos_Systm
{
    partial class AllStock
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AllStock));
            dgvAllStock = new DataGridView();
            btnRefresh = new Button();
            dataGridView2 = new DataGridView();
            btnFinalize = new Button();
            btnCheck = new Button();
            btnDelete = new Button();
            label5 = new Label();
            dgvAll = new DataGridView();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvAllStock).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvAll).BeginInit();
            SuspendLayout();
            // 
            // dgvAllStock
            // 
            dgvAllStock.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAllStock.Location = new Point(12, 107);
            dgvAllStock.Name = "dgvAllStock";
            dgvAllStock.RowHeadersWidth = 51;
            dgvAllStock.Size = new Size(1008, 143);
            dgvAllStock.TabIndex = 0;
            // 
            // btnRefresh
            // 
            btnRefresh.FlatStyle = FlatStyle.Popup;
            btnRefresh.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(12, 53);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(94, 48);
            btnRefresh.TabIndex = 1;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click_1;
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(12, 265);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersWidth = 51;
            dataGridView2.Size = new Size(813, 195);
            dataGridView2.TabIndex = 2;
            dataGridView2.CellContentClick += dataGridView2_CellContentClick;
            // 
            // btnFinalize
            // 
            btnFinalize.BackColor = Color.FromArgb(0, 0, 192);
            btnFinalize.FlatStyle = FlatStyle.Popup;
            btnFinalize.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnFinalize.ForeColor = Color.White;
            btnFinalize.Location = new Point(926, 256);
            btnFinalize.Name = "btnFinalize";
            btnFinalize.Size = new Size(94, 48);
            btnFinalize.TabIndex = 3;
            btnFinalize.Text = "Finalize";
            btnFinalize.UseVisualStyleBackColor = false;
            btnFinalize.Click += btnFinalize_Click;
            // 
            // btnCheck
            // 
            btnCheck.BackColor = Color.FromArgb(0, 192, 0);
            btnCheck.FlatStyle = FlatStyle.Popup;
            btnCheck.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnCheck.ForeColor = Color.White;
            btnCheck.Location = new Point(926, 338);
            btnCheck.Name = "btnCheck";
            btnCheck.Size = new Size(94, 48);
            btnCheck.TabIndex = 4;
            btnCheck.Text = "Check";
            btnCheck.UseVisualStyleBackColor = false;
            btnCheck.Click += btnCheck_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.Red;
            btnDelete.FlatStyle = FlatStyle.Popup;
            btnDelete.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(926, 53);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 48);
            btnDelete.TabIndex = 5;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.White;
            label5.Location = new Point(443, 9);
            label5.Name = "label5";
            label5.Size = new Size(145, 38);
            label5.TabIndex = 21;
            label5.Text = "All Stocks";
            // 
            // dgvAll
            // 
            dgvAll.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAll.Location = new Point(12, 477);
            dgvAll.Name = "dgvAll";
            dgvAll.RowHeadersWidth = 51;
            dgvAll.Size = new Size(1008, 174);
            dgvAll.TabIndex = 22;
            // 
            // button1
            // 
            button1.BackColor = Color.Red;
            button1.FlatStyle = FlatStyle.Popup;
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            button1.ForeColor = Color.White;
            button1.Location = new Point(873, 657);
            button1.Name = "button1";
            button1.Size = new Size(147, 43);
            button1.TabIndex = 23;
            button1.Text = "Retun Stock";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // AllStock
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1032, 712);
            Controls.Add(button1);
            Controls.Add(dgvAll);
            Controls.Add(label5);
            Controls.Add(btnDelete);
            Controls.Add(btnCheck);
            Controls.Add(btnFinalize);
            Controls.Add(dataGridView2);
            Controls.Add(btnRefresh);
            Controls.Add(dgvAllStock);
            FormBorderStyle = FormBorderStyle.None;
            Name = "AllStock";
            Text = "AllStock";
            Load += AllStock_Load;
            ((System.ComponentModel.ISupportInitialize)dgvAllStock).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvAll).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvAllStock;
        private Button btnRefresh;
        private DataGridView dataGridView2;
        private Button btnFinalize;
        private Button btnCheck;
        private Button btnDelete;
        private Button button1;
        private Label label5;
        private DataGridView dgvAll;
    }
}