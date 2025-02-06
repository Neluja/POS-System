namespace Pos_Systm
{
    partial class CasheirForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CasheirForm));
            label1 = new Label();
            cmbCategory = new ComboBox();
            btnAddToCart = new Button();
            dataGridViewStock = new DataGridView();
            dataGridViewCart = new DataGridView();
            txtTotal = new TextBox();
            label3 = new Label();
            txtCustomerAmount = new TextBox();
            label4 = new Label();
            txtBalance = new TextBox();
            label5 = new Label();
            btnPay = new Button();
            btnSearch = new Button();
            label6 = new Label();
            txtQty = new TextBox();
            btnRemove = new Button();
            lblDateTime = new Label();
            dateTimePickerManual = new DateTimePicker();
            btnSetDateTime = new Button();
            txtCashierID = new TextBox();
            txtCashierName = new TextBox();
            btnLogOut = new Button();
            btnAddDiscount = new Button();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)dataGridViewStock).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewCart).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(36, 507);
            label1.Name = "label1";
            label1.Size = new Size(94, 28);
            label1.TabIndex = 0;
            label1.Text = "Category";
            // 
            // cmbCategory
            // 
            cmbCategory.BackColor = Color.DimGray;
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Location = new Point(139, 504);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(151, 28);
            cmbCategory.TabIndex = 1;
            // 
            // btnAddToCart
            // 
            btnAddToCart.BackColor = Color.FromArgb(0, 192, 0);
            btnAddToCart.FlatStyle = FlatStyle.Popup;
            btnAddToCart.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnAddToCart.ForeColor = Color.White;
            btnAddToCart.Location = new Point(312, 557);
            btnAddToCart.Name = "btnAddToCart";
            btnAddToCart.Size = new Size(149, 41);
            btnAddToCart.TabIndex = 4;
            btnAddToCart.Text = "Add To Cart";
            btnAddToCart.UseVisualStyleBackColor = false;
            btnAddToCart.Click += btnAddToCart_Click;
            // 
            // dataGridViewStock
            // 
            dataGridViewStock.BackgroundColor = Color.DimGray;
            dataGridViewStock.BorderStyle = BorderStyle.None;
            dataGridViewStock.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewStock.Location = new Point(22, 156);
            dataGridViewStock.Name = "dataGridViewStock";
            dataGridViewStock.ReadOnly = true;
            dataGridViewStock.RowHeadersWidth = 51;
            dataGridViewStock.Size = new Size(678, 293);
            dataGridViewStock.TabIndex = 5;
            // 
            // dataGridViewCart
            // 
            dataGridViewCart.BackgroundColor = Color.DimGray;
            dataGridViewCart.BorderStyle = BorderStyle.None;
            dataGridViewCart.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCart.Location = new Point(742, 156);
            dataGridViewCart.Name = "dataGridViewCart";
            dataGridViewCart.RowHeadersWidth = 51;
            dataGridViewCart.Size = new Size(549, 293);
            dataGridViewCart.TabIndex = 6;
            // 
            // txtTotal
            // 
            txtTotal.BackColor = Color.DimGray;
            txtTotal.BorderStyle = BorderStyle.None;
            txtTotal.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold);
            txtTotal.Location = new Point(1016, 507);
            txtTotal.Name = "txtTotal";
            txtTotal.Size = new Size(151, 24);
            txtTotal.TabIndex = 8;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label3.ForeColor = Color.White;
            label3.Location = new Point(833, 503);
            label3.Name = "label3";
            label3.Size = new Size(55, 28);
            label3.TabIndex = 7;
            label3.Text = "Total";
            // 
            // txtCustomerAmount
            // 
            txtCustomerAmount.BackColor = Color.DimGray;
            txtCustomerAmount.BorderStyle = BorderStyle.None;
            txtCustomerAmount.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold);
            txtCustomerAmount.Location = new Point(1016, 560);
            txtCustomerAmount.Name = "txtCustomerAmount";
            txtCustomerAmount.Size = new Size(151, 24);
            txtCustomerAmount.TabIndex = 10;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label4.ForeColor = Color.White;
            label4.Location = new Point(830, 557);
            label4.Name = "label4";
            label4.Size = new Size(180, 28);
            label4.TabIndex = 9;
            label4.Text = "Customer Amount";
            // 
            // txtBalance
            // 
            txtBalance.BackColor = Color.DimGray;
            txtBalance.BorderStyle = BorderStyle.None;
            txtBalance.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold);
            txtBalance.Location = new Point(1016, 617);
            txtBalance.Name = "txtBalance";
            txtBalance.Size = new Size(151, 24);
            txtBalance.TabIndex = 12;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label5.ForeColor = Color.White;
            label5.Location = new Point(833, 613);
            label5.Name = "label5";
            label5.Size = new Size(81, 28);
            label5.TabIndex = 11;
            label5.Text = "Balance";
            // 
            // btnPay
            // 
            btnPay.BackColor = Color.FromArgb(0, 192, 0);
            btnPay.FlatStyle = FlatStyle.Popup;
            btnPay.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnPay.ForeColor = Color.White;
            btnPay.Location = new Point(977, 760);
            btnPay.Name = "btnPay";
            btnPay.Size = new Size(128, 41);
            btnPay.TabIndex = 13;
            btnPay.Text = "Pay";
            btnPay.UseVisualStyleBackColor = false;
            btnPay.Click += btnPay_Click;
            btnPay.KeyDown += btnPay_KeyDown;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.Black;
            btnSearch.FlatStyle = FlatStyle.Popup;
            btnSearch.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(312, 491);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(149, 41);
            btnSearch.TabIndex = 14;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label6.ForeColor = Color.White;
            label6.Location = new Point(36, 570);
            label6.Name = "label6";
            label6.Size = new Size(90, 28);
            label6.TabIndex = 16;
            label6.Text = "Quantity";
            // 
            // txtQty
            // 
            txtQty.BackColor = Color.DimGray;
            txtQty.BorderStyle = BorderStyle.None;
            txtQty.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold);
            txtQty.Location = new Point(139, 574);
            txtQty.Name = "txtQty";
            txtQty.Size = new Size(151, 24);
            txtQty.TabIndex = 17;
            // 
            // btnRemove
            // 
            btnRemove.BackColor = Color.Red;
            btnRemove.FlatStyle = FlatStyle.Popup;
            btnRemove.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnRemove.ForeColor = Color.White;
            btnRemove.Location = new Point(1122, 760);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(128, 41);
            btnRemove.TabIndex = 19;
            btnRemove.Text = "Remove";
            btnRemove.UseVisualStyleBackColor = false;
            btnRemove.Click += btnRemove_Click;
            btnRemove.KeyDown += btnRemove_KeyDown;
            // 
            // lblDateTime
            // 
            lblDateTime.AutoSize = true;
            lblDateTime.BackColor = Color.Transparent;
            lblDateTime.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDateTime.ForeColor = Color.White;
            lblDateTime.Location = new Point(910, 9);
            lblDateTime.Name = "lblDateTime";
            lblDateTime.Size = new Size(117, 46);
            lblDateTime.TabIndex = 20;
            lblDateTime.Text = "label2";
            // 
            // dateTimePickerManual
            // 
            dateTimePickerManual.CalendarFont = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dateTimePickerManual.Location = new Point(833, 680);
            dateTimePickerManual.Name = "dateTimePickerManual";
            dateTimePickerManual.Size = new Size(334, 27);
            dateTimePickerManual.TabIndex = 21;
            // 
            // btnSetDateTime
            // 
            btnSetDateTime.BackColor = Color.FromArgb(255, 128, 0);
            btnSetDateTime.FlatStyle = FlatStyle.Popup;
            btnSetDateTime.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnSetDateTime.ForeColor = Color.White;
            btnSetDateTime.Location = new Point(1184, 672);
            btnSetDateTime.Name = "btnSetDateTime";
            btnSetDateTime.Size = new Size(77, 41);
            btnSetDateTime.TabIndex = 22;
            btnSetDateTime.Text = "Set";
            btnSetDateTime.UseVisualStyleBackColor = false;
            btnSetDateTime.Click += btnSetDateTime_Click_1;
            btnSetDateTime.KeyDown += btnSetDateTime_KeyDown_1;
            // 
            // txtCashierID
            // 
            txtCashierID.BackColor = Color.Black;
            txtCashierID.BorderStyle = BorderStyle.None;
            txtCashierID.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtCashierID.ForeColor = Color.White;
            txtCashierID.Location = new Point(45, 55);
            txtCashierID.Name = "txtCashierID";
            txtCashierID.Size = new Size(74, 36);
            txtCashierID.TabIndex = 23;
            txtCashierID.TextAlign = HorizontalAlignment.Center;
            // 
            // txtCashierName
            // 
            txtCashierName.BackColor = Color.Black;
            txtCashierName.BorderStyle = BorderStyle.None;
            txtCashierName.Font = new Font("Segoe UI Black", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtCashierName.ForeColor = Color.White;
            txtCashierName.Location = new Point(22, 12);
            txtCashierName.Name = "txtCashierName";
            txtCashierName.Size = new Size(125, 37);
            txtCashierName.TabIndex = 24;
            txtCashierName.TextAlign = HorizontalAlignment.Center;
            // 
            // btnLogOut
            // 
            btnLogOut.BackColor = Color.FromArgb(192, 0, 0);
            btnLogOut.FlatStyle = FlatStyle.Popup;
            btnLogOut.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnLogOut.ForeColor = Color.White;
            btnLogOut.Location = new Point(36, 760);
            btnLogOut.Name = "btnLogOut";
            btnLogOut.Size = new Size(128, 41);
            btnLogOut.TabIndex = 25;
            btnLogOut.Text = "LOGOUT";
            btnLogOut.UseVisualStyleBackColor = false;
            btnLogOut.Click += btnLogOut_Click;
            // 
            // btnAddDiscount
            // 
            btnAddDiscount.BackColor = Color.MediumBlue;
            btnAddDiscount.FlatStyle = FlatStyle.Popup;
            btnAddDiscount.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnAddDiscount.ForeColor = Color.White;
            btnAddDiscount.Location = new Point(801, 760);
            btnAddDiscount.Name = "btnAddDiscount";
            btnAddDiscount.Size = new Size(157, 41);
            btnAddDiscount.TabIndex = 29;
            btnAddDiscount.Text = "Add Discount";
            btnAddDiscount.UseVisualStyleBackColor = false;
            btnAddDiscount.Click += btnAddDiscount_Click;
            btnAddDiscount.KeyDown += btnAddDiscount_KeyDown;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(182, -1);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(254, 118);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 32;
            pictureBox1.TabStop = false;
            // 
            // CasheirForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1303, 957);
            Controls.Add(pictureBox1);
            Controls.Add(btnAddDiscount);
            Controls.Add(btnLogOut);
            Controls.Add(txtCashierName);
            Controls.Add(txtCashierID);
            Controls.Add(btnSetDateTime);
            Controls.Add(dateTimePickerManual);
            Controls.Add(lblDateTime);
            Controls.Add(btnRemove);
            Controls.Add(txtQty);
            Controls.Add(label6);
            Controls.Add(btnSearch);
            Controls.Add(btnPay);
            Controls.Add(txtBalance);
            Controls.Add(label5);
            Controls.Add(txtCustomerAmount);
            Controls.Add(label4);
            Controls.Add(txtTotal);
            Controls.Add(label3);
            Controls.Add(dataGridViewCart);
            Controls.Add(dataGridViewStock);
            Controls.Add(btnAddToCart);
            Controls.Add(cmbCategory);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "CasheirForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CasheirForm";
            Load += CasheirForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewStock).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewCart).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox cmbCategory;
        private Button btnAddToCart;
        private DataGridView dataGridViewStock;
        private DataGridView dataGridViewCart;
        private TextBox txtTotal;
        private Label label3;
        private TextBox txtCustomerAmount;
        private Label label4;
        private TextBox txtBalance;
        private Label label5;
        private Button btnPay;
        private Button btnSearch;
        private Label label6;
        private TextBox txtQty;
        private Button btnRemove;
        private Label lblDateTime;
        private DateTimePicker dateTimePickerManual;
        private Button btnSetDateTime;
        private TextBox txtCashierID;
        private TextBox txtCashierName;
        private Button btnLogOut;
        private Button btnAddDiscount;
        private PictureBox pictureBox1;
    }
}