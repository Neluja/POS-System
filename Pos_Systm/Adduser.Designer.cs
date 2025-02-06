namespace Pos_Systm
{
    partial class Adduser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Adduser));
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtUserName = new TextBox();
            txtUserPassword = new TextBox();
            txtUserAddress = new TextBox();
            btnInsert = new Button();
            txtId = new TextBox();
            label5 = new Label();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnSearch = new Button();
            dataGridView1 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(346, 48);
            label1.Name = "label1";
            label1.Size = new Size(174, 38);
            label1.TabIndex = 0;
            label1.Text = "Add Casheir";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(300, 140);
            label2.Name = "label2";
            label2.Size = new Size(66, 28);
            label2.TabIndex = 1;
            label2.Text = "Name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(300, 197);
            label3.Name = "label3";
            label3.Size = new Size(97, 28);
            label3.TabIndex = 2;
            label3.Text = "Password";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(300, 256);
            label4.Name = "label4";
            label4.Size = new Size(85, 28);
            label4.TabIndex = 3;
            label4.Text = "Address";
            // 
            // txtUserName
            // 
            txtUserName.BackColor = Color.DimGray;
            txtUserName.BorderStyle = BorderStyle.None;
            txtUserName.Location = new Point(409, 148);
            txtUserName.Name = "txtUserName";
            txtUserName.Size = new Size(143, 20);
            txtUserName.TabIndex = 4;
            txtUserName.TextAlign = HorizontalAlignment.Center;
            // 
            // txtUserPassword
            // 
            txtUserPassword.BackColor = Color.DimGray;
            txtUserPassword.BorderStyle = BorderStyle.None;
            txtUserPassword.Location = new Point(409, 204);
            txtUserPassword.Name = "txtUserPassword";
            txtUserPassword.Size = new Size(143, 20);
            txtUserPassword.TabIndex = 5;
            txtUserPassword.TextAlign = HorizontalAlignment.Center;
            // 
            // txtUserAddress
            // 
            txtUserAddress.BackColor = Color.DimGray;
            txtUserAddress.BorderStyle = BorderStyle.None;
            txtUserAddress.Location = new Point(409, 264);
            txtUserAddress.Name = "txtUserAddress";
            txtUserAddress.Size = new Size(143, 20);
            txtUserAddress.TabIndex = 6;
            txtUserAddress.TextAlign = HorizontalAlignment.Center;
            // 
            // btnInsert
            // 
            btnInsert.BackColor = Color.MediumBlue;
            btnInsert.FlatStyle = FlatStyle.Popup;
            btnInsert.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnInsert.ForeColor = Color.White;
            btnInsert.Location = new Point(627, 148);
            btnInsert.Name = "btnInsert";
            btnInsert.Size = new Size(94, 44);
            btnInsert.TabIndex = 7;
            btnInsert.Text = "Insert";
            btnInsert.UseVisualStyleBackColor = false;
            btnInsert.Click += btnInsert_Click;
            btnInsert.KeyPress += btnInsert_KeyPress;
            // 
            // txtId
            // 
            txtId.BackColor = Color.DimGray;
            txtId.BorderStyle = BorderStyle.None;
            txtId.Location = new Point(409, 327);
            txtId.Name = "txtId";
            txtId.Size = new Size(143, 20);
            txtId.TabIndex = 9;
            txtId.TextAlign = HorizontalAlignment.Center;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.White;
            label5.Location = new Point(300, 319);
            label5.Name = "label5";
            label5.Size = new Size(30, 28);
            label5.TabIndex = 8;
            label5.Text = "Id";
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.Orange;
            btnUpdate.FlatStyle = FlatStyle.Popup;
            btnUpdate.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(627, 230);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(94, 44);
            btnUpdate.TabIndex = 10;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.Red;
            btnDelete.FlatStyle = FlatStyle.Popup;
            btnDelete.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(796, 522);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 44);
            btnDelete.TabIndex = 11;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.ForestGreen;
            btnSearch.FlatStyle = FlatStyle.Popup;
            btnSearch.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(627, 310);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(94, 46);
            btnSearch.TabIndex = 12;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = Color.Gray;
            dataGridView1.BorderStyle = BorderStyle.Fixed3D;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(192, 419);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(598, 147);
            dataGridView1.TabIndex = 13;
            dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick;
            // 
            // Adduser
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1032, 712);
            Controls.Add(dataGridView1);
            Controls.Add(btnSearch);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(txtId);
            Controls.Add(label5);
            Controls.Add(btnInsert);
            Controls.Add(txtUserAddress);
            Controls.Add(txtUserPassword);
            Controls.Add(txtUserName);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Adduser";
            Text = "Adduser";
            Load += Adduser_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtUserName;
        private TextBox txtUserPassword;
        private TextBox txtUserAddress;
        private Button btnInsert;
        private TextBox txtId;
        private Label label5;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnSearch;
        private DataGridView dataGridView1;
    }
}