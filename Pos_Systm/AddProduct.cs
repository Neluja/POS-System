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
    public partial class AddProduct : Form
    {

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public AddProduct()
        {
            InitializeComponent();
        }

        private void ClearTextBoxes()
        {
            txtProductID.Clear();
            txtProductName.Clear();
            cmbCategory.SelectedIndex = -1;
            cmbCategory.Text = "";

        }

        private void AddProduct_Load(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection("Data Source=VIVOBOOK15\\SQLEXPRESS;Initial Catalog=Mobile_Pos_System;Integrated Security=True;Encrypt=False"))
            {
                try
                {
                    con.Open();

                    // Load categories into ComboBox
                    SqlCommand cmd = new SqlCommand("SELECT category_id, category_name FROM Category", con);
                    SqlDataReader reader = cmd.ExecuteReader();

                    DataTable dt = new DataTable();
                    dt.Load(reader);

                    cmbCategory.DisplayMember = "category_name"; // Display category name
                    cmbCategory.ValueMember = "category_id"; // Use category_id as the value
                    cmbCategory.DataSource = dt; // Set data source
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading categories: " + ex.Message);
                }
            }
            FILLDGV();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection("Data Source=VIVOBOOK15\\SQLEXPRESS;Initial Catalog=Mobile_Pos_System;Integrated Security=True;Encrypt=False"))
            {
                try
                {
                    con.Open();

                    // Check if required fields are filled
                    if (string.IsNullOrWhiteSpace(txtProductID.Text) || string.IsNullOrWhiteSpace(txtProductName.Text) || cmbCategory.SelectedIndex == -1)
                    {
                        MessageBox.Show("Please fill in all fields.");
                        return;
                    }

                    // Validate Product ID as integer
                    if (!int.TryParse(txtProductID.Text, out int productId))
                    {
                        MessageBox.Show("Product ID must be a valid integer.");
                        return;
                    }

                    // Check if the product ID already exists
                    SqlCommand checkIdCmd = new SqlCommand("SELECT COUNT(*) FROM Product WHERE product_id = @product_id", con);
                    checkIdCmd.Parameters.AddWithValue("@product_id", productId);

                    int idExists = (int)checkIdCmd.ExecuteScalar();
                    if (idExists > 0)
                    {
                        MessageBox.Show("The ID already exists. Please use a different ID.");
                        return;
                    }

                    // Get the selected category ID
                    int categoryId = (int)cmbCategory.SelectedValue;

                    // Insert new product with category ID
                    SqlCommand cmd = new SqlCommand("INSERT INTO Product (product_id, product_name, category_id) VALUES (@product_id, @product_name, @category_id)", con);
                    cmd.Parameters.AddWithValue("@product_id", productId);
                    cmd.Parameters.AddWithValue("@product_name", txtProductName.Text);
                    cmd.Parameters.AddWithValue("@category_id", categoryId);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Successfully saved.");
                    ClearTextBoxes();

                    // Refresh DataGridView
                    FILLDGV();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Check if a row is selected in the DataGridView
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Get the product ID from the selected row
            int productId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["product_id"].Value);

            // Confirm deletion
            DialogResult result = MessageBox.Show("Are you sure you want to delete this product and its related models?",
                                                  "Confirm Deletion",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                using (SqlConnection con = new SqlConnection("Data Source=VIVOBOOK15\\SQLEXPRESS;Initial Catalog=Mobile_Pos_System;Integrated Security=True;Encrypt=False"))
                {
                    con.Open();
                    using (SqlTransaction transaction = con.BeginTransaction())
                    {
                        try
                        {
                            // Step 1: Delete dependent records from the Model table
                            SqlCommand deleteModelCmd = new SqlCommand(
                                "DELETE FROM Model WHERE product_id = @product_id", con, transaction);
                            deleteModelCmd.Parameters.AddWithValue("@product_id", productId);
                            deleteModelCmd.ExecuteNonQuery();

                            // Step 2: Delete the record from the Product table
                            SqlCommand deleteProductCmd = new SqlCommand(
                                "DELETE FROM Product WHERE product_id = @product_id", con, transaction);
                            deleteProductCmd.Parameters.AddWithValue("@product_id", productId);
                            int rowsAffected = deleteProductCmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                // Commit transaction
                                transaction.Commit();
                                MessageBox.Show("Product and related models successfully deleted.",
                                                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ClearTextBoxes();
                                // Remove the row from DataGridView
                                dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
                            }
                            else
                            {
                                transaction.Rollback();
                                MessageBox.Show("No matching Product ID found.",
                                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        catch (Exception ex)
                        {
                            // Rollback transaction on error
                            transaction.Rollback();
                            MessageBox.Show("Error occurred: " + ex.Message,
                                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Delete operation canceled.", "Canceled", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void FILLDGV()
        {
            SqlConnection con = new SqlConnection("Data Source=VIVOBOOK15\\SQLEXPRESS;Initial Catalog=Mobile_Pos_System;Integrated Security=True;Encrypt=False");
            con.Open();
            string query = "Select * From Product";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void LoadCategoryComboBox()
        {
            SqlConnection con = new SqlConnection("Data Source=VIVOBOOK15\\SQLEXPRESS;Initial Catalog=Mobile_Pos_System;Integrated Security=True;Encrypt=False");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT category_id, category_name FROM Category", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmbCategory.DataSource = dt;
            cmbCategory.DisplayMember = "category_name";
            cmbCategory.ValueMember = "category_id";
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Make sure the necessary fields are filled
            if (string.IsNullOrWhiteSpace(txtProductID.Text) ||
                string.IsNullOrWhiteSpace(txtProductName.Text) ||
                cmbCategory.SelectedIndex == -1)
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            int productId = int.Parse(txtProductID.Text);
            string productName = txtProductName.Text;
            int categoryId = (int)cmbCategory.SelectedValue;

            using (SqlConnection con = new SqlConnection("Data Source=VIVOBOOK15\\SQLEXPRESS;Initial Catalog=Mobile_Pos_System;Integrated Security=True;Encrypt=False"))
            {
                try
                {
                    con.Open();

                    // Check if the product exists in the database
                    SqlCommand checkProductCmd = new SqlCommand("SELECT COUNT(*) FROM Product WHERE product_id = @product_id", con);
                    checkProductCmd.Parameters.AddWithValue("@product_id", productId);

                    int productExists = (int)checkProductCmd.ExecuteScalar();

                    // If product doesn't exist, show error
                    if (productExists == 0)
                    {
                        MessageBox.Show("The specified Product ID does not exist.");
                        return;
                    }

                    // Update the product details in the database
                    SqlCommand updateCmd = new SqlCommand("UPDATE Product SET product_name = @product_name, category_id = @category_id WHERE product_id = @product_id", con);
                    updateCmd.Parameters.AddWithValue("@product_name", productName);
                    updateCmd.Parameters.AddWithValue("@category_id", categoryId);
                    updateCmd.Parameters.AddWithValue("@product_id", productId);

                    updateCmd.ExecuteNonQuery();

                    // Success message
                    MessageBox.Show("Product updated successfully.");
                    ClearTextBoxes();

                    // Refresh the DataGridView to show updated data
                    SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Product", con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dataGridView1.DataSource = dt;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Populate the text boxes with relevant data
                txtProductID.Text = row.Cells["product_id"].Value?.ToString();
                txtProductName.Text = row.Cells["product_name"].Value?.ToString();

                // Populate ComboBox with the corresponding category
                int categoryId = Convert.ToInt32(row.Cells["category_id"].Value);
                cmbCategory.SelectedValue = categoryId;
            }
        }
    }
}
