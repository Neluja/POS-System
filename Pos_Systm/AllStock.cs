using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace Pos_Systm
{
    public partial class AllStock : Form
    {
        private string connectionString = "Data Source=VIVOBOOK15\\SQLEXPRESS;Initial Catalog=Mobile_Pos_System;Integrated Security=True;Encrypt=False";

        public AllStock()
        {
            InitializeComponent();

        }

        private void FinalizeStock()
        {


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Insert or update aggregated stock data into TrueStock
                string mergeQuery = @"
MERGE INTO TrueStock AS target
USING (
    SELECT 
        s.Category, 
        s.Product, 
        s.Model, 
        SUM(s.Quantity) AS TotalQuantity,
        m.unit_price AS Price
    FROM Stock s
    INNER JOIN Model m ON s.Model = m.model_name
    GROUP BY s.Category, s.Product, s.Model, m.unit_price
) AS source
ON target.Category = source.Category AND target.Product = source.Product AND target.Model = source.Model
WHEN MATCHED THEN
    UPDATE SET target.Quantity = target.Quantity + source.TotalQuantity
WHEN NOT MATCHED THEN
    INSERT (Category, Product, Model, Quantity, Price)
    VALUES (source.Category, source.Product, source.Model, source.TotalQuantity, source.Price);";

                using (SqlCommand mergeCommand = new SqlCommand(mergeQuery, connection))
                {
                    mergeCommand.ExecuteNonQuery();
                }

                // Clear all data in the Stock table
                string deleteStockQuery = "DELETE FROM Stock";
                using (SqlCommand deleteCommand = new SqlCommand(deleteStockQuery, connection))
                {
                    deleteCommand.ExecuteNonQuery();
                }

                MessageBox.Show("Stock has been finalized, TrueStock table updated, and Stock table cleared.");
            }
            // Clear the DataGridView
            dgvAllStock.DataSource = null; // If bound to a data source
            dgvAllStock.Rows.Clear();      // If rows were manually added
        }







        private void AllStock_Load(object sender, EventArgs e)
        {
            LoadTrueStockData();
            FILLDGV();


        }


        private void LoadStockData()
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadStockData();
        }

        private void btnFinalize_Click(object sender, EventArgs e)
        {
            FinalizeStock(); // Finalize stock and update TrueStock
            LoadTrueStockData(); // Load the updated data into the second DataGridView
                                 // LoadStockReportData();


        }

        private void LoadTrueStockData()
        {
            string query = "SELECT StockID, Category, Product, Model, Quantity, Price FROM TrueStock"; // Include Price

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                dataGridView2.DataSource = dataTable; // Assuming your second DataGridView is named dataGridView2
            }
        }

        private void btnRefresh_Click_1(object sender, EventArgs e)
        {
            LoadTempStockData();
        }

        private void LoadTempStockData()
        {
            string query = "SELECT * FROM Stock";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable tempStockTable = new DataTable();
                adapter.Fill(tempStockTable);

                dgvAllStock.DataSource = tempStockTable; // Assuming this is the DataGridView for Stock
            }
        }

        private void ConfigureDataGridView()
        {
            dgvAllStock.Columns[0].HeaderText = "Category";
            dgvAllStock.Columns[1].HeaderText = "Product";
            dgvAllStock.Columns[2].HeaderText = "Model";
            dgvAllStock.Columns[3].HeaderText = "Quantity";
            dgvAllStock.Columns[4].HeaderText = "Price"; // Add header for Price
        }

        private void SendEmail(string emailBody)
        {
            try
            {
                // SMTP configuration
                string smtpHost = "smtp.gmail.com"; // Gmail SMTP server
                int smtpPort = 587; // SMTP port for Gmail
                string smtpUsername = "nelujachandimal123@gmail.com"; // Replace with your Gmail
                string smtpPassword = "nkzg chxb ciul cflh"; // Replace with your App Password

                // Email settings
                string fromEmail = smtpUsername;
                string toEmail = "chandimalneluja05@gmail.com"; // Replace with admin email
                string subject = "Low Stock Alert";

                // Create email message
                MailMessage mailMessage = new MailMessage(fromEmail, toEmail, subject, emailBody);

                // SMTP client
                SmtpClient smtpClient = new SmtpClient(smtpHost, smtpPort)
                {
                    Credentials = new NetworkCredential(smtpUsername, smtpPassword),
                    EnableSsl = true
                };

                // Send email
                smtpClient.Send(mailMessage);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error sending email: {ex.Message}", "Email Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btnCheck_Click(object sender, EventArgs e)
        {
            // Connection string to your database
            string connectionString = "Data Source=VIVOBOOK15\\SQLEXPRESS;Initial Catalog=Mobile_Pos_System;Integrated Security=True;Encrypt=False";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Query to get items with quantity less than 20
                    string query = "SELECT Category, Product,  Quantity FROM TrueStock WHERE Quantity < 20";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable lowStockItems = new DataTable();
                    adapter.Fill(lowStockItems);

                    if (lowStockItems.Rows.Count > 0)
                    {
                        string emailBody = "The following items have low stock:\n\n";

                        // Construct email body
                        foreach (DataRow row in lowStockItems.Rows)
                        {
                            emailBody += $"Category: {row["Category"]}, Product: {row["Product"]},  Quantity: {row["Quantity"]}\n";
                        }

                        // Send email
                        SendEmail(emailBody);
                        MessageBox.Show("Low stock items have been emailed to the admin.", "Email Sent", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("All items are sufficiently stocked.", "No Low Stock", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error checking stock or sending email: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {


            // Ensure a row is selected
            if (dgvAllStock.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Get the selected row
            DataGridViewRow selectedRow = dgvAllStock.SelectedRows[0];
            string stockId = selectedRow.Cells["entry_id"].Value.ToString();

            // Confirm deletion
            DialogResult result = MessageBox.Show("Are you sure you want to delete this stock entry?",
                                                  "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Delete the entry from the database
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();

                        // Transaction to ensure both deletions happen together
                        using (SqlTransaction transaction = conn.BeginTransaction())
                        {
                            try
                            {
                                // Delete from Stock table
                                string deleteStockQuery = "DELETE FROM Stock WHERE entry_id = @entry_id";
                                using (SqlCommand cmd = new SqlCommand(deleteStockQuery, conn, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@entry_id", stockId);
                                    cmd.ExecuteNonQuery();
                                }

                                // Delete from StockReport table
                                string deleteStockReportQuery = "DELETE FROM StockReport WHERE entry_id = @entry_id";
                                using (SqlCommand cmd = new SqlCommand(deleteStockReportQuery, conn, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@entry_id", stockId);
                                    cmd.ExecuteNonQuery();
                                }

                                // Commit transaction
                                transaction.Commit();

                                // Remove the entry from the DataGridView
                                dgvAllStock.Rows.Remove(selectedRow);
                                MessageBox.Show("Stock entry deleted successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch
                            {
                                // Rollback transaction in case of error
                                transaction.Rollback();
                                throw;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error deleting stock entry: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }




        private void btnArrange_Click(object sender, EventArgs e)
        {

        }

        private void FILLDGV()
        {
            SqlConnection con = new SqlConnection("Data Source=VIVOBOOK15\\SQLEXPRESS;Initial Catalog=Mobile_Pos_System;Integrated Security=True;Encrypt=False");
            con.Open();
            string query = "Select * From StockReport";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvAll.DataSource = dt;
            con.Close();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void StockReportDelete()
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Ensure a row is selected
            if (dgvAll.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Get the selected row
            DataGridViewRow selectedRow = dgvAll.SelectedRows[0];
            string stockId = selectedRow.Cells["entry_id"].Value.ToString();
            string productModel = selectedRow.Cells["Model"].Value.ToString();
            int stockQuantity = Convert.ToInt32(selectedRow.Cells["Quantity"].Value);

            // Confirm deletion
            DialogResult result = MessageBox.Show("Are you sure you want to delete this stock entry?",
                                                  "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Delete the entry from the database
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();

                        // Transaction to ensure both operations happen together
                        using (SqlTransaction transaction = conn.BeginTransaction())
                        {
                            try
                            {
                                // Update the quantity in the TruStock table
                                UpdateTruStockQuantity(conn, transaction, productModel, stockQuantity);

                                // Delete from StockReport table
                                string deleteStockReportQuery = "DELETE FROM StockReport WHERE entry_id = @entry_id";
                                using (SqlCommand cmd = new SqlCommand(deleteStockReportQuery, conn, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@entry_id", stockId);
                                    cmd.ExecuteNonQuery();
                                }

                                // Commit transaction
                                transaction.Commit();

                                // Remove the entry from the DataGridView
                                dgvAll.Rows.Remove(selectedRow);
                                MessageBox.Show("Stock entry deleted and TrueStock quantity updated successfully.",
                                                "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                RefreshAllGridViews();
                            }
                            catch
                            {
                                // Rollback transaction in case of error
                                transaction.Rollback();
                                throw;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error deleting stock entry: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }


        }

        private void UpdateTruStockQuantity(SqlConnection conn, SqlTransaction transaction, string productModel, int stockQuantity)
        {
            string getQuantityQuery = @"
        SELECT Quantity
        FROM TrueStock
        WHERE Model = @productModel";

            string updateQuantityQuery;

            using (SqlCommand getCmd = new SqlCommand(getQuantityQuery, conn, transaction))
            {
                getCmd.Parameters.AddWithValue("@productModel", productModel);

                object result = getCmd.ExecuteScalar();
                if (result == null)
                {
                    MessageBox.Show("Product model not found in TrueStock.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int currentQuantity = Convert.ToInt32(result);

                // Determine the new quantity
                if (currentQuantity <= stockQuantity)
                {
                    // Set to 0 if stock quantity exceeds or matches
                    updateQuantityQuery = @"
                UPDATE TrueStock
                SET Quantity = 0
                WHERE Model = @productModel";
                }
                else
                {
                    // Reduce by stock quantity
                    updateQuantityQuery = @"
                UPDATE TrueStock
                SET Quantity = Quantity - @stockQuantity
                WHERE Model = @productModel";
                }

                using (SqlCommand updateCmd = new SqlCommand(updateQuantityQuery, conn, transaction))
                {
                    updateCmd.Parameters.AddWithValue("@productModel", productModel);

                    if (currentQuantity > stockQuantity)
                    {
                        updateCmd.Parameters.AddWithValue("@stockQuantity", stockQuantity);
                    }

                    updateCmd.ExecuteNonQuery();
                }
            }
        }

        private void RefreshStockReportGridView()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Query to fetch all records from StockReport table
                    string query = "SELECT * FROM StockReport";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Bind data to dgvAll
                        dgvAll.DataSource = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error refreshing StockReport grid view: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshTruStockGridView()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Query to fetch all records from TruStock table
                    string query = "SELECT * FROM TrueStock";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Bind data to dgvTruStock
                        dataGridView2.DataSource = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error refreshing TrueStock grid view: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshAllGridViews()
        {
            RefreshStockReportGridView();
            RefreshTruStockGridView();
        }



    }
}

