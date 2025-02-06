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
    public partial class SalesReport : Form
    {
        public SalesReport()
        {
            InitializeComponent();
        }

        private void SalesReport_Load(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection("Data Source=VIVOBOOK15\\SQLEXPRESS;Initial Catalog=Mobile_Pos_System;Integrated Security=True;Encrypt=False"))
                {
                    conn.Open();

                    string query = "SELECT sale_id, transaction_date, total_amount, user_id, customer_given_amount, balance, category, model, product, price, quantity FROM Sales_New";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable salesTable = new DataTable();
                    adapter.Fill(salesTable);

                    dataGridViewSales.DataSource = salesTable; // Bind data to the DataGridView

                    // Auto-resize columns to fill the grid
                    dataGridViewSales.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading sales data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            LoadDailyProfit();
            LoadDailyMostSellingCategoryData();
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
                    CAST(strans_date AS DATE) AS [Date],
                    SUM(stot_amount) AS [Total Sales],
                    SUM(profit) AS [Profit]
                FROM test_sales
                GROUP BY CAST(strans_date AS DATE)
                ORDER BY [Date]";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        dgvProfit.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading daily profit: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDailyMostSellingCategoryData()
        {
            try
            {
                // Define the connection string
                string connectionString = "Data Source=VIVOBOOK15\\SQLEXPRESS;Initial Catalog=Mobile_Pos_System;Integrated Security=True;Encrypt=False";

                // Define the SQL query
                string query = @"
           WITH MostSellingItemPerDay AS (
    SELECT 
        CAST(transaction_date AS DATE) AS transaction_date, -- Group by day
        category,
        product,
        model,
        SUM(quantity) AS total_quantity, -- Aggregate quantity
        ROW_NUMBER() OVER (PARTITION BY CAST(transaction_date AS DATE) 
                           ORDER BY SUM(quantity) DESC) AS row_num -- Assign unique row numbers
    FROM Sales_New
    GROUP BY CAST(transaction_date AS DATE), category, product, model
)
SELECT 
    transaction_date, 
    category, 
    product, 
    model, 
    total_quantity
FROM MostSellingItemPerDay
WHERE row_num = 1 -- Only the top-ranked row per day
ORDER BY transaction_date ASC;


        ";

                // Create a connection to the database
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Open the connection
                    conn.Open();

                    // Create the command and set its properties
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Create a DataTable to hold the results
                        DataTable dt = new DataTable();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            // Load data from the reader to the DataTable
                            dt.Load(reader);
                        }

                        // Bind the DataTable to the DataGridView
                        dgvItem.DataSource = dt;
                    }
                }

            }
            catch (Exception ex)
            {
                // Display an error message if something goes wrong
                MessageBox.Show($"Error loading daily most selling category data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





    }
}
