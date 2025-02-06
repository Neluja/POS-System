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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {

        }

        private void LoadDashboardCounts()
        {
            using (SqlConnection con = new SqlConnection("Data Source=VIVOBOOK15\\SQLEXPRESS;Initial Catalog=Mobile_Pos_System;Integrated Security=True;Encrypt=False"))
            {
                con.Open();

                // 1. Retrieve count of products per category
                SqlCommand cmdProductsPerCategory = new SqlCommand(
                    "SELECT Category.category_name, COUNT(Product.product_id) AS ProductCount " +
                    "FROM Product JOIN Category ON Product.category_id = Category.category_id " +
                    "GROUP BY Category.category_name", con);

                SqlDataReader reader = cmdProductsPerCategory.ExecuteReader();
                while (reader.Read())
                {
                    // Assuming you have a ListBox or DataGridView to display this
                    string category = reader["category_name"].ToString();
                    int productCount = Convert.ToInt32(reader["ProductCount"]);
                    listBoxProductsPerCategory.Items.Add($"{category}: {productCount} products");
                }
                reader.Close();

                // 2. Retrieve total number of users
                SqlCommand cmdTotalUsers = new SqlCommand("SELECT COUNT(*) AS UserCount FROM Users", con);
                int userCount = (int)cmdTotalUsers.ExecuteScalar();

                // Display user count on a label
                txtUser.Text = userCount.ToString();

            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadDashboardCounts();
            LoadDailyProfit();


        }

        private void LoadDailyProfit()
        {
            try
            {
                string connectionString = "Data Source=VIVOBOOK15\\SQLEXPRESS;Initial Catalog=Mobile_Pos_System;Integrated Security=True;Encrypt=False";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"
                SELECT 
                    SUM(profit) AS TodayProfit
                FROM test_sales
                WHERE CAST(strans_date AS DATE) = CAST(GETDATE() AS DATE)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        object result = cmd.ExecuteScalar();

                        // If result is not null or DBNull, display it in txtProfit
                        if (result != null && result != DBNull.Value)
                        {
                            decimal todayProfit = Convert.ToDecimal(result);
                            txtProfit.Text = todayProfit.ToString("C"); // Display as currency (e.g., $1,234.56)
                        }
                        else
                        {
                            txtProfit.Text = "0.00"; // Default if no profit is recorded for today
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading today's profit: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
