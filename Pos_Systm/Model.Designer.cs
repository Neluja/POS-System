namespace Pos_Systm
{
    partial class Model
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
            dataGridView1 = new DataGridView();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            cmbCategory = new ComboBox();
            cmbProduct = new ComboBox();
            txtUnitPrice = new TextBox();
            btnSave = new Button();
            txtModelName = new TextBox();
            label6 = new Label();
            btnDelete = new Button();
            txtModelID = new TextBox();
            btnUpdate = new Button();
            txtBuyingPrice = new TextBox();
            label1 = new Label();
            label5 = new Label();
            txtid = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(62, 423);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(906, 192);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label2.ForeColor = Color.White;
            label2.Location = new Point(337, 205);
            label2.Name = "label2";
            label2.Size = new Size(94, 28);
            label2.TabIndex = 2;
            label2.Text = "Category";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label3.ForeColor = Color.White;
            label3.Location = new Point(337, 261);
            label3.Name = "label3";
            label3.Size = new Size(83, 28);
            label3.TabIndex = 3;
            label3.Text = "Product";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label4.ForeColor = Color.White;
            label4.Location = new Point(337, 312);
            label4.Name = "label4";
            label4.Size = new Size(100, 28);
            label4.TabIndex = 4;
            label4.Text = "Unit Price";
            // 
            // cmbCategory
            // 
            cmbCategory.BackColor = Color.DimGray;
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Location = new Point(487, 205);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(195, 28);
            cmbCategory.TabIndex = 6;
            // 
            // cmbProduct
            // 
            cmbProduct.BackColor = Color.DimGray;
            cmbProduct.FormattingEnabled = true;
            cmbProduct.Location = new Point(487, 261);
            cmbProduct.Name = "cmbProduct";
            cmbProduct.Size = new Size(195, 28);
            cmbProduct.TabIndex = 7;
            // 
            // txtUnitPrice
            // 
            txtUnitPrice.BackColor = Color.DimGray;
            txtUnitPrice.BorderStyle = BorderStyle.None;
            txtUnitPrice.Location = new Point(487, 319);
            txtUnitPrice.Name = "txtUnitPrice";
            txtUnitPrice.Size = new Size(195, 20);
            txtUnitPrice.TabIndex = 8;
            txtUnitPrice.TextAlign = HorizontalAlignment.Center;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.MidnightBlue;
            btnSave.FlatStyle = FlatStyle.Popup;
            btnSave.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(732, 155);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(100, 44);
            btnSave.TabIndex = 9;
            btnSave.Text = "SAVE";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // txtModelName
            // 
            txtModelName.BackColor = Color.DimGray;
            txtModelName.BorderStyle = BorderStyle.None;
            txtModelName.Location = new Point(487, 155);
            txtModelName.Name = "txtModelName";
            txtModelName.Size = new Size(195, 20);
            txtModelName.TabIndex = 13;
            txtModelName.TextAlign = HorizontalAlignment.Center;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label6.ForeColor = Color.White;
            label6.Location = new Point(337, 148);
            label6.Name = "label6";
            label6.Size = new Size(130, 28);
            label6.TabIndex = 12;
            label6.Text = "Model Name";
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.Red;
            btnDelete.FlatStyle = FlatStyle.Popup;
            btnDelete.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(732, 621);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(100, 44);
            btnDelete.TabIndex = 14;
            btnDelete.Text = "DELETE";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // txtModelID
            // 
            txtModelID.Location = new Point(572, 738);
            txtModelID.Name = "txtModelID";
            txtModelID.Size = new Size(69, 27);
            txtModelID.TabIndex = 15;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.Orange;
            btnUpdate.FlatStyle = FlatStyle.Popup;
            btnUpdate.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(732, 346);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(100, 44);
            btnUpdate.TabIndex = 16;
            btnUpdate.Text = "UPDATE";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // txtBuyingPrice
            // 
            txtBuyingPrice.BackColor = Color.DimGray;
            txtBuyingPrice.BorderStyle = BorderStyle.None;
            txtBuyingPrice.Location = new Point(487, 370);
            txtBuyingPrice.Name = "txtBuyingPrice";
            txtBuyingPrice.Size = new Size(195, 20);
            txtBuyingPrice.TabIndex = 18;
            txtBuyingPrice.TextAlign = HorizontalAlignment.Center;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(337, 362);
            label1.Name = "label1";
            label1.Size = new Size(125, 28);
            label1.TabIndex = 17;
            label1.Text = "Buying Price";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.White;
            label5.Location = new Point(429, 55);
            label5.Name = "label5";
            label5.Size = new Size(163, 38);
            label5.TabIndex = 19;
            label5.Text = "Add Model";
            // 
            // txtid
            // 
            txtid.BackColor = Color.DimGray;
            txtid.BorderStyle = BorderStyle.FixedSingle;
            txtid.Location = new Point(838, 361);
            txtid.Name = "txtid";
            txtid.Size = new Size(65, 27);
            txtid.TabIndex = 20;
            txtid.TextAlign = HorizontalAlignment.Center;
            // 
            // Model
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1032, 712);
            Controls.Add(txtid);
            Controls.Add(label5);
            Controls.Add(txtBuyingPrice);
            Controls.Add(label1);
            Controls.Add(btnUpdate);
            Controls.Add(txtModelID);
            Controls.Add(btnDelete);
            Controls.Add(txtModelName);
            Controls.Add(label6);
            Controls.Add(btnSave);
            Controls.Add(txtUnitPrice);
            Controls.Add(cmbProduct);
            Controls.Add(cmbCategory);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(dataGridView1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Model";
            Text = "Model";
            Load += Model_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Label label2;
        private Label label3;
        private Label label4;
        private ComboBox cmbCategory;
        private ComboBox cmbProduct;
        private TextBox txtUnitPrice;
        private Button btnSave;
        private TextBox txtModelName;
        private Label label6;
        private Button btnDelete;
        private TextBox txtModelID;
        private Button btnUpdate;
        private TextBox txtBuyingPrice;
        private Label label1;
        private Label label5;
        private TextBox txtid;
    }
}