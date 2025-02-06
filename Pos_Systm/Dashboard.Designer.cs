namespace Pos_Systm
{
    partial class Dashboard
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
            listBoxProductsPerCategory = new ListBox();
            btnRefresh = new Button();
            label1 = new Label();
            txtUser = new TextBox();
            txtProfit = new TextBox();
            label2 = new Label();
            SuspendLayout();
            // 
            // listBoxProductsPerCategory
            // 
            listBoxProductsPerCategory.BackColor = Color.White;
            listBoxProductsPerCategory.Font = new Font("Segoe UI Semibold", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            listBoxProductsPerCategory.FormattingEnabled = true;
            listBoxProductsPerCategory.ItemHeight = 37;
            listBoxProductsPerCategory.Location = new Point(863, 349);
            listBoxProductsPerCategory.Name = "listBoxProductsPerCategory";
            listBoxProductsPerCategory.Size = new Size(374, 115);
            listBoxProductsPerCategory.TabIndex = 0;
            // 
            // btnRefresh
            // 
            btnRefresh.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRefresh.Location = new Point(364, 349);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(116, 53);
            btnRefresh.TabIndex = 2;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Cyan;
            label1.Font = new Font("Segoe UI Semibold", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(166, 65);
            label1.Name = "label1";
            label1.Size = new Size(178, 38);
            label1.TabIndex = 3;
            label1.Text = "Total Users : ";
            // 
            // txtUser
            // 
            txtUser.Font = new Font("Segoe UI Semibold", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtUser.Location = new Point(350, 65);
            txtUser.Name = "txtUser";
            txtUser.Size = new Size(140, 43);
            txtUser.TabIndex = 4;
            // 
            // txtProfit
            // 
            txtProfit.Font = new Font("Segoe UI Semibold", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtProfit.Location = new Point(722, 65);
            txtProfit.Name = "txtProfit";
            txtProfit.Size = new Size(140, 43);
            txtProfit.TabIndex = 6;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Cyan;
            label2.Font = new Font("Segoe UI Semibold", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(538, 65);
            label2.Name = "label2";
            label2.Size = new Size(181, 38);
            label2.TabIndex = 5;
            label2.Text = "Daily Profit : ";
            // 
            // Dashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1303, 957);
            Controls.Add(txtProfit);
            Controls.Add(label2);
            Controls.Add(txtUser);
            Controls.Add(label1);
            Controls.Add(btnRefresh);
            Controls.Add(listBoxProductsPerCategory);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Dashboard";
            Text = "Dashboard";
            Load += Dashboard_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listBoxProductsPerCategory;
        private Button btnRefresh;
        private Label label1;
        private TextBox txtUser;
        private TextBox txtProfit;
        private Label label2;
    }
}