namespace Pos_Systm
{
    partial class AdminForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminForm));
            btnClose = new Button();
            panel1 = new Panel();
            btnback = new Button();
            btnPrediction = new Button();
            btnSalesReport = new Button();
            button5 = new Button();
            btnAllStock = new Button();
            button4 = new Button();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            btnAddUser = new Button();
            panel2 = new Panel();
            label1 = new Label();
            panel3 = new Panel();
            lblDateTime = new Label();
            pictureBox1 = new PictureBox();
            mainpanel = new Panel();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.Transparent;
            btnClose.BackgroundImage = (Image)resources.GetObject("btnClose.BackgroundImage");
            btnClose.BackgroundImageLayout = ImageLayout.Stretch;
            btnClose.FlatStyle = FlatStyle.Popup;
            btnClose.Location = new Point(996, 3);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(36, 33);
            btnClose.TabIndex = 2;
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.Controls.Add(btnback);
            panel1.Controls.Add(btnPrediction);
            panel1.Controls.Add(btnSalesReport);
            panel1.Controls.Add(button5);
            panel1.Controls.Add(btnAllStock);
            panel1.Controls.Add(button4);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(btnAddUser);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(267, 800);
            panel1.TabIndex = 3;
            // 
            // btnback
            // 
            btnback.BackColor = Color.Red;
            btnback.BackgroundImageLayout = ImageLayout.Stretch;
            btnback.FlatStyle = FlatStyle.Popup;
            btnback.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnback.ForeColor = Color.Silver;
            btnback.Location = new Point(55, 752);
            btnback.Name = "btnback";
            btnback.Size = new Size(131, 36);
            btnback.TabIndex = 0;
            btnback.Text = "LOGOUT";
            btnback.UseVisualStyleBackColor = false;
            btnback.Click += btnback_Click;
            // 
            // btnPrediction
            // 
            btnPrediction.FlatStyle = FlatStyle.Popup;
            btnPrediction.Font = new Font("Segoe UI Black", 10.2F, FontStyle.Bold);
            btnPrediction.ForeColor = Color.Silver;
            btnPrediction.Location = new Point(39, 656);
            btnPrediction.Name = "btnPrediction";
            btnPrediction.Size = new Size(191, 39);
            btnPrediction.TabIndex = 13;
            btnPrediction.Text = "Prediction";
            btnPrediction.UseVisualStyleBackColor = true;
            btnPrediction.Click += btnPrediction_Click;
            // 
            // btnSalesReport
            // 
            btnSalesReport.FlatStyle = FlatStyle.Popup;
            btnSalesReport.Font = new Font("Segoe UI Black", 10.2F, FontStyle.Bold);
            btnSalesReport.ForeColor = Color.Silver;
            btnSalesReport.Location = new Point(40, 593);
            btnSalesReport.Name = "btnSalesReport";
            btnSalesReport.Size = new Size(191, 39);
            btnSalesReport.TabIndex = 12;
            btnSalesReport.Text = "Sales Report";
            btnSalesReport.UseVisualStyleBackColor = true;
            btnSalesReport.Click += btnSalesReport_Click;
            // 
            // button5
            // 
            button5.FlatStyle = FlatStyle.Popup;
            button5.Font = new Font("Segoe UI Black", 10.2F, FontStyle.Bold);
            button5.ForeColor = Color.Silver;
            button5.Location = new Point(39, 527);
            button5.Name = "button5";
            button5.Size = new Size(191, 39);
            button5.TabIndex = 11;
            button5.Text = "Add Discount";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // btnAllStock
            // 
            btnAllStock.FlatStyle = FlatStyle.Popup;
            btnAllStock.Font = new Font("Segoe UI Black", 10.2F, FontStyle.Bold);
            btnAllStock.ForeColor = Color.Silver;
            btnAllStock.Location = new Point(39, 456);
            btnAllStock.Name = "btnAllStock";
            btnAllStock.Size = new Size(191, 39);
            btnAllStock.TabIndex = 10;
            btnAllStock.Text = "All Stock";
            btnAllStock.UseVisualStyleBackColor = true;
            btnAllStock.Click += btnAllStock_Click;
            // 
            // button4
            // 
            button4.FlatStyle = FlatStyle.Popup;
            button4.Font = new Font("Segoe UI Black", 10.2F, FontStyle.Bold);
            button4.ForeColor = Color.Silver;
            button4.Location = new Point(39, 390);
            button4.Name = "button4";
            button4.Size = new Size(191, 39);
            button4.TabIndex = 9;
            button4.Text = "Stock";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button3
            // 
            button3.FlatStyle = FlatStyle.Popup;
            button3.Font = new Font("Segoe UI Black", 10.2F, FontStyle.Bold);
            button3.ForeColor = Color.Silver;
            button3.Location = new Point(39, 328);
            button3.Name = "button3";
            button3.Size = new Size(191, 39);
            button3.TabIndex = 7;
            button3.Text = "Model";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.FlatStyle = FlatStyle.Popup;
            button2.Font = new Font("Segoe UI Black", 10.2F, FontStyle.Bold);
            button2.ForeColor = Color.Silver;
            button2.Location = new Point(38, 259);
            button2.Name = "button2";
            button2.Size = new Size(191, 39);
            button2.TabIndex = 6;
            button2.Text = "Add Product";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.FlatStyle = FlatStyle.Popup;
            button1.Font = new Font("Segoe UI Black", 10.2F, FontStyle.Bold);
            button1.ForeColor = Color.Silver;
            button1.Location = new Point(39, 185);
            button1.Name = "button1";
            button1.Size = new Size(191, 39);
            button1.TabIndex = 5;
            button1.Text = "Add Category";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // btnAddUser
            // 
            btnAddUser.BackColor = Color.Transparent;
            btnAddUser.FlatStyle = FlatStyle.Popup;
            btnAddUser.Font = new Font("Segoe UI Black", 10.2F, FontStyle.Bold);
            btnAddUser.ForeColor = Color.Silver;
            btnAddUser.Location = new Point(39, 118);
            btnAddUser.Name = "btnAddUser";
            btnAddUser.Size = new Size(191, 39);
            btnAddUser.TabIndex = 0;
            btnAddUser.Text = "Add User";
            btnAddUser.UseVisualStyleBackColor = false;
            btnAddUser.Click += btnAddUser_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Transparent;
            panel2.Controls.Add(label1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(267, 89);
            panel2.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.FlatStyle = FlatStyle.Popup;
            label1.Font = new Font("Segoe UI Black", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(72, 27);
            label1.Name = "label1";
            label1.Size = new Size(128, 41);
            label1.TabIndex = 3;
            label1.Text = "ADMIN";
            // 
            // panel3
            // 
            panel3.BackColor = Color.Transparent;
            panel3.Controls.Add(lblDateTime);
            panel3.Controls.Add(pictureBox1);
            panel3.Controls.Add(btnClose);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(267, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(1035, 89);
            panel3.TabIndex = 4;
            panel3.Paint += panel3_Paint;
            // 
            // lblDateTime
            // 
            lblDateTime.AutoSize = true;
            lblDateTime.BackColor = Color.Transparent;
            lblDateTime.FlatStyle = FlatStyle.Popup;
            lblDateTime.Font = new Font("Segoe UI Black", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDateTime.ForeColor = Color.White;
            lblDateTime.Location = new Point(614, 54);
            lblDateTime.Name = "lblDateTime";
            lblDateTime.Size = new Size(83, 31);
            lblDateTime.TabIndex = 21;
            lblDateTime.Text = "label2";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(202, 80);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // mainpanel
            // 
            mainpanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            mainpanel.BackColor = Color.Transparent;
            mainpanel.Location = new Point(267, 88);
            mainpanel.Name = "mainpanel";
            mainpanel.Size = new Size(1035, 712);
            mainpanel.TabIndex = 5;
            mainpanel.Paint += mainpanel_Paint_1;
            // 
            // AdminForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1302, 800);
            Controls.Add(mainpanel);
            Controls.Add(panel3);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "AdminForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AdminForm";
            Load += AdminForm_Load;
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Button btnClose;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel mainpanel;
        private Button btnAddUser;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button btnback;
        private Button btnAllStock;
        private Button button5;
        private Button btnSalesReport;
        private Button btnPrediction;
        private Label label1;
        private PictureBox pictureBox1;
        private Label lblDateTime;
    }
}