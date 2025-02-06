namespace Pos_Systm
{
    partial class Stock
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Stock));
            label1 = new Label();
            label2 = new Label();
            txtStockID = new TextBox();
            txtDate = new TextBox();
            cmbCategory = new ComboBox();
            cmbProduct = new ComboBox();
            cmbModel = new ComboBox();
            txtQuantity = new TextBox();
            label3 = new Label();
            dgvStock = new DataGridView();
            btnSave = new Button();
            btnOK = new Button();
            btnDelete = new Button();
            btnUpdate = new Button();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvStock).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(352, 139);
            label1.Name = "label1";
            label1.Size = new Size(87, 28);
            label1.TabIndex = 0;
            label1.Text = "Stock ID";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label2.ForeColor = Color.White;
            label2.Location = new Point(352, 181);
            label2.Name = "label2";
            label2.Size = new Size(107, 28);
            label2.TabIndex = 1;
            label2.Text = "Enter Date";
            // 
            // txtStockID
            // 
            txtStockID.BackColor = Color.DarkGray;
            txtStockID.BorderStyle = BorderStyle.None;
            txtStockID.Location = new Point(474, 137);
            txtStockID.Name = "txtStockID";
            txtStockID.Size = new Size(159, 20);
            txtStockID.TabIndex = 2;
            txtStockID.TextAlign = HorizontalAlignment.Center;
            // 
            // txtDate
            // 
            txtDate.BackColor = Color.DarkGray;
            txtDate.BorderStyle = BorderStyle.None;
            txtDate.Location = new Point(474, 179);
            txtDate.Name = "txtDate";
            txtDate.Size = new Size(159, 20);
            txtDate.TabIndex = 3;
            txtDate.TextAlign = HorizontalAlignment.Center;
            // 
            // cmbCategory
            // 
            cmbCategory.BackColor = Color.DarkGray;
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Location = new Point(197, 264);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(119, 28);
            cmbCategory.TabIndex = 4;
            cmbCategory.Text = "Category";
            cmbCategory.SelectedIndexChanged += cmbCategory_SelectedIndexChanged;
            // 
            // cmbProduct
            // 
            cmbProduct.BackColor = Color.DarkGray;
            cmbProduct.FormattingEnabled = true;
            cmbProduct.Location = new Point(332, 264);
            cmbProduct.Name = "cmbProduct";
            cmbProduct.Size = new Size(125, 28);
            cmbProduct.TabIndex = 5;
            cmbProduct.Text = "Product";
            cmbProduct.SelectedIndexChanged += cmbProduct_SelectedIndexChanged;
            // 
            // cmbModel
            // 
            cmbModel.BackColor = Color.DarkGray;
            cmbModel.FormattingEnabled = true;
            cmbModel.Location = new Point(474, 264);
            cmbModel.Name = "cmbModel";
            cmbModel.Size = new Size(134, 28);
            cmbModel.TabIndex = 6;
            cmbModel.Text = "Model";
            // 
            // txtQuantity
            // 
            txtQuantity.BackColor = Color.DarkGray;
            txtQuantity.BorderStyle = BorderStyle.None;
            txtQuantity.Location = new Point(708, 263);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(75, 20);
            txtQuantity.TabIndex = 8;
            txtQuantity.TextAlign = HorizontalAlignment.Center;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label3.ForeColor = Color.White;
            label3.Location = new Point(612, 264);
            label3.Name = "label3";
            label3.Size = new Size(90, 28);
            label3.TabIndex = 7;
            label3.Text = "Quantity";
            // 
            // dgvStock
            // 
            dgvStock.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStock.Location = new Point(95, 358);
            dgvStock.Name = "dgvStock";
            dgvStock.RowHeadersWidth = 51;
            dgvStock.Size = new Size(742, 188);
            dgvStock.TabIndex = 10;
            dgvStock.CellDoubleClick += dgvStock_CellDoubleClick;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(0, 192, 0);
            btnSave.FlatStyle = FlatStyle.Popup;
            btnSave.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(843, 506);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(104, 40);
            btnSave.TabIndex = 11;
            btnSave.Text = "SAVE";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnOK
            // 
            btnOK.BackColor = Color.MediumBlue;
            btnOK.FlatStyle = FlatStyle.Popup;
            btnOK.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnOK.ForeColor = Color.White;
            btnOK.Location = new Point(843, 263);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(104, 37);
            btnOK.TabIndex = 12;
            btnOK.Text = "OK";
            btnOK.UseVisualStyleBackColor = false;
            btnOK.Click += btnOK_Click_1;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.Red;
            btnDelete.FlatStyle = FlatStyle.Popup;
            btnDelete.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(843, 435);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(104, 42);
            btnDelete.TabIndex = 13;
            btnDelete.Text = "DELETE";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.Orange;
            btnUpdate.FlatStyle = FlatStyle.Popup;
            btnUpdate.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(843, 358);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(104, 42);
            btnUpdate.TabIndex = 14;
            btnUpdate.Text = "UPDATE";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.White;
            label5.Location = new Point(426, 55);
            label5.Name = "label5";
            label5.Size = new Size(163, 38);
            label5.TabIndex = 20;
            label5.Text = "Add Stocks";
            // 
            // Stock
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1032, 712);
            Controls.Add(label5);
            Controls.Add(btnUpdate);
            Controls.Add(btnDelete);
            Controls.Add(btnOK);
            Controls.Add(btnSave);
            Controls.Add(dgvStock);
            Controls.Add(txtQuantity);
            Controls.Add(label3);
            Controls.Add(cmbModel);
            Controls.Add(cmbProduct);
            Controls.Add(cmbCategory);
            Controls.Add(txtDate);
            Controls.Add(txtStockID);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Stock";
            Text = "Stock";
            Load += Stock_Load;
            ((System.ComponentModel.ISupportInitialize)dgvStock).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtStockID;
        private TextBox txtDate;
        private ComboBox cmbCategory;
        private ComboBox cmbProduct;
        private ComboBox cmbModel;
        private TextBox txtQuantity;
        private Label label3;
        private DataGridView dgvStock;
        private Button btnSave;
        private Button btnOK;
        private Button btnDelete;
        private Button btnUpdate;
        private Label label5;
    }
}