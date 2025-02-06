namespace Pos_Systm
{
    partial class AddDiscount
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddDiscount));
            txtDiscountName = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtDiscountRate = new TextBox();
            txtThresholdAmount = new TextBox();
            chkIsSeasonal = new CheckBox();
            dtpSeasonalDate = new DateTimePicker();
            btnSave = new Button();
            dgvDiscounts = new DataGridView();
            btnDelete = new Button();
            label5 = new Label();
            btnUpdate = new Button();
            txtid = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvDiscounts).BeginInit();
            SuspendLayout();
            // 
            // txtDiscountName
            // 
            txtDiscountName.BackColor = Color.DimGray;
            txtDiscountName.BorderStyle = BorderStyle.None;
            txtDiscountName.Location = new Point(514, 155);
            txtDiscountName.Name = "txtDiscountName";
            txtDiscountName.Size = new Size(163, 20);
            txtDiscountName.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.FlatStyle = FlatStyle.Popup;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(310, 148);
            label1.Name = "label1";
            label1.Size = new Size(152, 28);
            label1.TabIndex = 1;
            label1.Text = "Discount Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.FlatStyle = FlatStyle.Popup;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label2.ForeColor = Color.White;
            label2.Location = new Point(310, 256);
            label2.Name = "label2";
            label2.Size = new Size(204, 28);
            label2.TabIndex = 2;
            label2.Text = "Discount Percentage.";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.FlatStyle = FlatStyle.Popup;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label3.ForeColor = Color.White;
            label3.Location = new Point(310, 200);
            label3.Name = "label3";
            label3.Size = new Size(188, 28);
            label3.TabIndex = 3;
            label3.Text = "Threshold Amount.";
            // 
            // txtDiscountRate
            // 
            txtDiscountRate.BackColor = Color.DimGray;
            txtDiscountRate.BorderStyle = BorderStyle.None;
            txtDiscountRate.Location = new Point(514, 263);
            txtDiscountRate.Name = "txtDiscountRate";
            txtDiscountRate.Size = new Size(163, 20);
            txtDiscountRate.TabIndex = 4;
            // 
            // txtThresholdAmount
            // 
            txtThresholdAmount.BackColor = Color.DimGray;
            txtThresholdAmount.BorderStyle = BorderStyle.None;
            txtThresholdAmount.Location = new Point(514, 207);
            txtThresholdAmount.Name = "txtThresholdAmount";
            txtThresholdAmount.Size = new Size(163, 20);
            txtThresholdAmount.TabIndex = 5;
            // 
            // chkIsSeasonal
            // 
            chkIsSeasonal.AutoSize = true;
            chkIsSeasonal.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            chkIsSeasonal.ForeColor = Color.White;
            chkIsSeasonal.Location = new Point(310, 363);
            chkIsSeasonal.Name = "chkIsSeasonal";
            chkIsSeasonal.Size = new Size(171, 27);
            chkIsSeasonal.TabIndex = 6;
            chkIsSeasonal.Text = "Seasonal Discount";
            chkIsSeasonal.UseVisualStyleBackColor = true;
            // 
            // dtpSeasonalDate
            // 
            dtpSeasonalDate.CalendarMonthBackground = Color.DarkOrange;
            dtpSeasonalDate.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dtpSeasonalDate.Location = new Point(310, 309);
            dtpSeasonalDate.Name = "dtpSeasonalDate";
            dtpSeasonalDate.Size = new Size(367, 34);
            dtpSeasonalDate.TabIndex = 7;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(0, 192, 0);
            btnSave.FlatStyle = FlatStyle.Popup;
            btnSave.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(728, 303);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(103, 40);
            btnSave.TabIndex = 8;
            btnSave.Text = "SAVE";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // dgvDiscounts
            // 
            dgvDiscounts.BackgroundColor = Color.DimGray;
            dgvDiscounts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDiscounts.Location = new Point(150, 417);
            dgvDiscounts.Name = "dgvDiscounts";
            dgvDiscounts.RowHeadersWidth = 51;
            dgvDiscounts.Size = new Size(681, 214);
            dgvDiscounts.TabIndex = 9;
            dgvDiscounts.CellDoubleClick += dgvDiscounts_CellDoubleClick;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.Red;
            btnDelete.FlatStyle = FlatStyle.Popup;
            btnDelete.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(728, 637);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(103, 40);
            btnDelete.TabIndex = 10;
            btnDelete.Text = "DELETE";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.White;
            label5.Location = new Point(420, 47);
            label5.Name = "label5";
            label5.Size = new Size(195, 38);
            label5.TabIndex = 22;
            label5.Text = "Add Discount";
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.FromArgb(0, 192, 0);
            btnUpdate.FlatStyle = FlatStyle.Popup;
            btnUpdate.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(728, 371);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(103, 40);
            btnUpdate.TabIndex = 23;
            btnUpdate.Text = "UPDATE";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // txtid
            // 
            txtid.BackColor = Color.DimGray;
            txtid.BorderStyle = BorderStyle.None;
            txtid.Location = new Point(837, 391);
            txtid.Name = "txtid";
            txtid.Size = new Size(41, 20);
            txtid.TabIndex = 24;
            // 
            // AddDiscount
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1032, 712);
            Controls.Add(txtid);
            Controls.Add(btnUpdate);
            Controls.Add(label5);
            Controls.Add(btnDelete);
            Controls.Add(dgvDiscounts);
            Controls.Add(btnSave);
            Controls.Add(dtpSeasonalDate);
            Controls.Add(chkIsSeasonal);
            Controls.Add(txtThresholdAmount);
            Controls.Add(txtDiscountRate);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtDiscountName);
            FormBorderStyle = FormBorderStyle.None;
            Name = "AddDiscount";
            Text = "AddDiscount";
            Load += AddDiscount_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDiscounts).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtDiscountName;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtDiscountRate;
        private TextBox txtThresholdAmount;
        private CheckBox chkIsSeasonal;
        private DateTimePicker dtpSeasonalDate;
        private Button btnSave;
        private DataGridView dgvDiscounts;
        private Button btnDelete;
        private Label label5;
        private Button btnUpdate;
        private TextBox txtid;
    }
}