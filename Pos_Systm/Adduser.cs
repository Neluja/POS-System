using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pos_Systm
{
    public partial class Adduser : Form
    {
        public Adduser()
        {
            InitializeComponent();



        }


        private void ClearTextBoxes()
        {
            txtId.Clear();
            txtUserName.Clear();
            txtUserPassword.Clear();
            txtUserAddress.Clear();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=VIVOBOOK15\\SQLEXPRESS;Initial Catalog=Mobile_Pos_System;Integrated Security=True;Encrypt=False");
            con.Open();

            // Check if any textbox is empty
            if (string.IsNullOrWhiteSpace(txtId.Text) ||
                string.IsNullOrWhiteSpace(txtUserName.Text) ||
                string.IsNullOrWhiteSpace(txtUserPassword.Text) ||
                string.IsNullOrWhiteSpace(txtUserAddress.Text))
            {
                MessageBox.Show("Please fill in all fields.");
                con.Close();
                return;
            }

            // Check if the same ID already exists in the database
            SqlCommand checkIdCmd = new SqlCommand("SELECT COUNT(*) FROM Users WHERE user_id = @user_id", con);
            checkIdCmd.Parameters.AddWithValue("@user_id", int.Parse(txtId.Text));

            int idExists = (int)checkIdCmd.ExecuteScalar();
            if (idExists > 0)
            {
                MessageBox.Show("The ID already exists. Please use a different ID.");
                con.Close();
                return;
            }

            //SqlConnection con = new SqlConnection("Data Source=VIVOBOOK15\\SQLEXPRESS;Initial Catalog=Mobile_Pos_System;Integrated Security=True;Encrypt=False");
            //con.Open();
            SqlCommand cmd = new SqlCommand("insert into Users  values(@user_id,@user_name,@password,@user_Address)", con);
            cmd.Parameters.AddWithValue("@user_id", int.Parse(txtId.Text));
            cmd.Parameters.AddWithValue("@user_name", txtUserName.Text);
            cmd.Parameters.AddWithValue("@password", int.Parse(txtUserPassword.Text));
            cmd.Parameters.AddWithValue("@user_Address", txtUserAddress.Text);
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Successfully saved");
            ClearTextBoxes();
            FILLDGV();


        }



        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=VIVOBOOK15\\SQLEXPRESS;Initial Catalog=Mobile_Pos_System;Integrated Security=True;Encrypt=False");
            con.Open();

            // Check if any textbox is empty
            if (string.IsNullOrWhiteSpace(txtId.Text) ||
                string.IsNullOrWhiteSpace(txtUserName.Text) ||
                string.IsNullOrWhiteSpace(txtUserPassword.Text) ||
                string.IsNullOrWhiteSpace(txtUserAddress.Text))
            {
                MessageBox.Show("Please fill in all fields.");
                con.Close();
                return;
            }


            // SqlConnection con = new SqlConnection("Data Source=VIVOBOOK15\\SQLEXPRESS;Initial Catalog=Mobile_Pos_System;Integrated Security=True;Encrypt=False");
            // con.Open();
            SqlCommand cmd = new SqlCommand("update Users set user_name=@user_name, password=@password,user_Address=@user_Address where user_id=@user_id", con);
            cmd.Parameters.AddWithValue("@user_id", int.Parse(txtId.Text));
            cmd.Parameters.AddWithValue("@user_name", txtUserName.Text);
            cmd.Parameters.AddWithValue("@password", int.Parse(txtUserPassword.Text));
            cmd.Parameters.AddWithValue("@user_Address", txtUserAddress.Text);
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Successfully Upadated");

            ClearTextBoxes();
            FILLDGV();

        }


        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ensure the selected row index is valid
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Populate text boxes with the values from the selected row
                txtId.Text = row.Cells["user_id"].Value.ToString();
                txtUserName.Text = row.Cells["user_name"].Value.ToString();
                txtUserPassword.Text = row.Cells["password"].Value.ToString();
                txtUserAddress.Text = row.Cells["user_Address"].Value.ToString();
            }
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Ensure a row is selected in the DataGridView
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to delete.");
                return;
            }

            // Get the user_id from the selected row
            int userId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["user_id"].Value);

            // Confirmation dialog
            DialogResult confirm = MessageBox.Show("Are you sure you want to delete this record?", "Confirm Delete", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.No)
                return;

            // Perform the delete operation
            SqlConnection con = new SqlConnection("Data Source=VIVOBOOK15\\SQLEXPRESS;Initial Catalog=Mobile_Pos_System;Integrated Security=True;Encrypt=False");
            con.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM Users WHERE user_id = @user_id", con);
            cmd.Parameters.AddWithValue("@user_id", userId);
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Successfully Deleted");

            ClearTextBoxes();
            FILLDGV();

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=VIVOBOOK15\\SQLEXPRESS;Initial Catalog=Mobile_Pos_System;Integrated Security=True;Encrypt=False");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Users where user_id=@user_id ", con);
            cmd.Parameters.AddWithValue("@user_id", int.Parse(txtId.Text));
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView1.DataSource = dt;
        }

        private void FILLDGV()
        {
            SqlConnection con = new SqlConnection("Data Source=VIVOBOOK15\\SQLEXPRESS;Initial Catalog=Mobile_Pos_System;Integrated Security=True;Encrypt=False");
            con.Open();
            string query = "Select * From Users";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void Adduser_Load(object sender, EventArgs e)
        {
            FILLDGV();

            this.KeyPreview = true; // Enables the form to capture key presses
            this.KeyDown += AddUser_KeyDown;
        }

        private void AddUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.I) // Check if the 'I' key is pressed
            {
                btnInsert.PerformClick(); // Simulate button click
                e.Handled = true; // Prevent further processing
            }

            if (e.KeyCode == Keys.D) // Check if the 'I' key is pressed
            {
                btnDelete.PerformClick(); // Simulate button click
                e.Handled = true; // Prevent further processing
            }
        }

        private void btnInsert_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ensure the double-clicked row index is valid
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Populate text boxes with values from the selected row
                txtId.Text = row.Cells["user_id"].Value?.ToString();
                txtUserName.Text = row.Cells["user_name"].Value?.ToString();
                txtUserPassword.Text = row.Cells["password"].Value?.ToString();
                txtUserAddress.Text = row.Cells["user_Address"].Value?.ToString();
            }
        }
    }
}
