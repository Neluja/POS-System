using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Pos_Systm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /*int w = Screen.PrimaryScreen.Bounds.Width;
            int h = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point(0, 0);
            this.Size = new Size(w, h);*/
        }

        private void btnlog_Click(object sender, EventArgs e)
        {
            /* // Check for admin login
             if (txtUsername.Text == "Admin" && txtPassword.Text == "admin")
             {
                 MessageBox.Show("Admin Login Successful!");

                 // Open Admin form
                 AdminForm adminForm = new AdminForm();
                 adminForm.Show();

                 // Hide the Login form
                 this.Hide();
             }
             else
             {
                 // Database connection string
                 using (SqlConnection con = new SqlConnection("Data Source=VIVOBOOK15\\SQLEXPRESS;Initial Catalog=Mobile_Pos_System;Integrated Security=True;Encrypt=False"))
                 {
                     try
                     {
                         con.Open();
                         // Query to check if the user is a cashier
                         string query = "SELECT COUNT(1) FROM Users WHERE user_name=@username AND password=@password";
                         SqlCommand cmd = new SqlCommand(query, con);
                         cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                         cmd.Parameters.AddWithValue("@password", txtPassword.Text);

                         int count = Convert.ToInt32(cmd.ExecuteScalar());

                         if (count == 1)
                         {
                             MessageBox.Show("Cashier Login Successful!");

                             // Open Cashier form
                             CasheirForm cashierForm = new CasheirForm();
                             cashierForm.Show();

                             // Hide the Login form
                             this.Hide();*/

            // Check for admin login
            if (txtUsername.Text == "Admin" && txtPassword.Text == "admin")
            {
                MessageBox.Show("Admin Login Successful!");

                // Open Admin form
                AdminForm adminForm = new AdminForm();
                adminForm.Show();

                // Hide the Login form
                this.Hide();
            }
            else
            {
                // Database connection string
                using (SqlConnection con = new SqlConnection("Data Source=VIVOBOOK15\\SQLEXPRESS;Initial Catalog=Mobile_Pos_System;Integrated Security=True;Encrypt=False"))
                {
                    try
                    {
                        con.Open();
                        // Query to get user_id and user_name for the cashier
                        string query = "SELECT user_id, user_name FROM Users WHERE user_name=@username AND password=@password";
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                        cmd.Parameters.AddWithValue("@password", txtPassword.Text);

                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            // Retrieve user ID and username
                            int userId = reader.GetInt32(0);
                            string username = reader.GetString(1);

                            MessageBox.Show("Cashier Login Successful!");

                            // Open Cashier form with user ID and username
                            CasheirForm cashierForm = new CasheirForm(userId, username);
                            cashierForm.Show();

                            // Hide the Login form
                            this.Hide();

                        }
                        else
                        {
                            MessageBox.Show("Invalid Username or Password. Please try again.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message);
                    }
                }
            }
        }

       

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { 

                btnlog.PerformClick();
            
            
            }
        }
    }
}
