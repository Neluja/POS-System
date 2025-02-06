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
    public partial class Stock : Form
    {
        private DataTable tempStockDataTable;

        private DataTable stockDataTable;
        public Stock()
        {
            InitializeComponent();
            LoadCategories();
            InitializeStockDataTable();
        }


        private void ClearTextBoxes()
        {

            cmbCategory.SelectedIndex = -1;
            cmbCategory.Text = "";

            cmbModel.SelectedIndex = -1;
            cmbModel.Text = "";

            cmbProduct.SelectedIndex = -1;
            cmbProduct.Text = "";

            txtQuantity.Clear();


        }
        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCategory.SelectedValue != null)
            {
                int selectedCategoryId = (int)cmbCategory.SelectedValue;
                LoadProducts(selectedCategoryId); // Load products based on selected category

                // Optionally, you can clear the `cmbModel` or reset it if needed:
                cmbModel.DataSource = null;
            }
        }



        private void Stock_Load(object sender, EventArgs e)
        {

        }


        private void LoadCategories()
        {
            using (SqlConnection conn = new SqlConnection("Data Source=VIVOBOOK15\\SQLEXPRESS;Initial Catalog=Mobile_Pos_System;Integrated Security=True;Encrypt=False"))
            {
                string query = "SELECT category_id, category_name FROM Category";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable categoryTable = new DataTable();
                adapter.Fill(categoryTable);

                cmbCategory.DisplayMember = "category_name";
                cmbCategory.ValueMember = "category_id";
                cmbCategory.DataSource = categoryTable;
            }
        }

        private void categoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedCategoryId = (int)cmbCategory.SelectedValue;
            LoadProducts(selectedCategoryId);
            LoadModels(selectedCategoryId);
        }

        private void LoadProducts(int categoryId)
        {
            using (SqlConnection conn = new SqlConnection("Data Source=VIVOBOOK15\\SQLEXPRESS;Initial Catalog=Mobile_Pos_System;Integrated Security=True;Encrypt=False"))
            {
                string query = "SELECT product_id, product_name FROM Product WHERE category_id = @category_id";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.SelectCommand.Parameters.AddWithValue("@category_id", categoryId);

                DataTable productTable = new DataTable();
                adapter.Fill(productTable);

                cmbProduct.DisplayMember = "product_name";
                cmbProduct.ValueMember = "product_id";
                cmbProduct.DataSource = productTable;
            }
        }

        private void LoadModels(int categoryId)
        {
            using (SqlConnection conn = new SqlConnection("Data Source=VIVOBOOK15\\SQLEXPRESS;Initial Catalog=Mobile_Pos_System;Integrated Security=True;Encrypt=False"))
            {
                string query = "SELECT model_id, model_name FROM Model WHERE category_id = @category_id";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.SelectCommand.Parameters.AddWithValue("@category_id", categoryId);

                DataTable modelTable = new DataTable();
                adapter.Fill(modelTable);

                cmbModel.DisplayMember = "model_name";
                cmbModel.ValueMember = "model_id";
                cmbModel.DataSource = modelTable;
            }
        }

        private void cmbProduct_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cmbProduct.SelectedValue != null)
            {
                int selectedProductId = (int)cmbProduct.SelectedValue;
                LoadModelsByProduct(selectedProductId); // Load models based on selected product
            }

        }


        private void InitializeStockDataTable()
        {
            stockDataTable = new DataTable();
            stockDataTable.Columns.Add("StockID", typeof(string));
            stockDataTable.Columns.Add("Date", typeof(string));
            stockDataTable.Columns.Add("Category", typeof(string));
            stockDataTable.Columns.Add("Product", typeof(string));
            stockDataTable.Columns.Add("Model", typeof(string));
            stockDataTable.Columns.Add("Quantity", typeof(int));
        }

        private void btnOK_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {


            using (SqlConnection conn = new SqlConnection("Data Source=VIVOBOOK15\\SQLEXPRESS;Initial Catalog=Mobile_Pos_System;Integrated Security=True;Encrypt=False"))
            {
                try
                {
                    conn.Open();

                    foreach (DataRow row in stockDataTable.Rows)
                    {
                        string stockId = row["StockID"].ToString();
                        string category = row["Category"].ToString();
                        string product = row["Product"].ToString();
                        string model = row["Model"].ToString();
                        int quantity = Convert.ToInt32(row["Quantity"]);

                        // Convert date string to DateTime
                        DateTime date;
                        if (!DateTime.TryParse(row["Date"].ToString(), out date))
                        {
                            MessageBox.Show("Invalid date format. Please use YYYY-MM-DD format.");
                            return;
                        }

                        // Insert into Stock table
                        string stockQuery = @"
                    INSERT INTO Stock (stock_id, date, category, product, model, quantity) 
                    OUTPUT INSERTED.entry_id
                    VALUES (@stock_id, @date, @category, @product, @model, @quantity)";

                        int entryId;
                        using (SqlCommand stockCmd = new SqlCommand(stockQuery, conn))
                        {
                            stockCmd.Parameters.AddWithValue("@stock_id", stockId);
                            stockCmd.Parameters.AddWithValue("@date", date);
                            stockCmd.Parameters.AddWithValue("@category", category);
                            stockCmd.Parameters.AddWithValue("@product", product);
                            stockCmd.Parameters.AddWithValue("@model", model);
                            stockCmd.Parameters.AddWithValue("@quantity", quantity);

                            // Retrieve the entry_id of the inserted record
                            entryId = (int)stockCmd.ExecuteScalar();
                        }

                        // Insert into StockReport table with the same entry_id
                        string stockReportQuery = @"
                    INSERT INTO StockReport (entry_id, stock_id, date, category, product, model, quantity) 
                    VALUES (@entry_id, @stock_id, @date, @category, @product, @model, @quantity)";

                        using (SqlCommand reportCmd = new SqlCommand(stockReportQuery, conn))
                        {
                            reportCmd.Parameters.AddWithValue("@entry_id", entryId);
                            reportCmd.Parameters.AddWithValue("@stock_id", stockId);
                            reportCmd.Parameters.AddWithValue("@date", date);
                            reportCmd.Parameters.AddWithValue("@category", category);
                            reportCmd.Parameters.AddWithValue("@product", product);
                            reportCmd.Parameters.AddWithValue("@model", model);
                            reportCmd.Parameters.AddWithValue("@quantity", quantity);

                            reportCmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Data saved successfully to the Stock and StockReport tables.");
                    ClearTextBoxes();
                    // Clear the DataGridView
                    stockDataTable.Clear(); // Clear the underlying DataTable
                    dgvStock.DataSource = stockDataTable; // Refresh the DataGridView


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saving data: " + ex.Message);
                }
            }

        }

        private void btnCorrect_Click(object sender, EventArgs e)
        {

        }





        private void LoadTempStockData()
        {
            // Load data from the TempStock table into the DataGridView
            using (SqlConnection conn = new SqlConnection("Data Source=VIVOBOOK15\\SQLEXPRESS;Initial Catalog=Mobile_Pos_System;Integrated Security=True;Encrypt=False"))
            {
                string query = "SELECT * FROM TempStock";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable tempStockTable = new DataTable();
                adapter.Fill(tempStockTable);
                dgvStock.DataSource = tempStockTable;
            }
        }


        private void FILLDGV()
        {
            SqlConnection con = new SqlConnection("Data Source=VIVOBOOK15\\SQLEXPRESS;Initial Catalog=Mobile_Pos_System;Integrated Security=True;Encrypt=False");
            con.Open();
            string query = "Select * From TempStockDetails";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvStock.DataSource = dt;
            con.Close();
        }

        private void btnOK_Click_1(object sender, EventArgs e)
        {
            if (stockDataTable == null)
            {
                MessageBox.Show("Stock DataTable is not initialized.");
                return;
            }

            string stockId = txtStockID.Text;
            string date = txtDate.Text;
            string category = cmbCategory.Text;
            string product = cmbProduct.Text;
            string model = cmbModel.Text;
            int quantity;

            if (int.TryParse(txtQuantity.Text, out quantity))
            {
                stockDataTable.Rows.Add(stockId, date, category, product, model, quantity);
                dgvStock.DataSource = stockDataTable; // Bind DataTable to DataGridView
                ClearTextBoxes();
            }
            else
            {
                MessageBox.Show("Please enter a valid quantity.");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvStock.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete the selected record?",
                                                      "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    int selectedIndex = dgvStock.SelectedRows[0].Index; // Get the index of the selected row
                    stockDataTable.Rows.RemoveAt(selectedIndex); // Remove from DataTable
                    MessageBox.Show("Record deleted successfully.");
                }
            }
            else
            {
                MessageBox.Show("Please select a record to delete.");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvStock.SelectedRows.Count > 0)
            {
                int selectedIndex = dgvStock.SelectedRows[0].Index; // Get the index of the selected row

                DataRow selectedRow = stockDataTable.Rows[selectedIndex];

                // Update the DataTable with values from input fields
                selectedRow["StockID"] = txtStockID.Text;
                selectedRow["Date"] = txtDate.Text;
                selectedRow["Category"] = cmbCategory.Text;
                selectedRow["Product"] = cmbProduct.Text;
                selectedRow["Model"] = cmbModel.Text;

                int quantity;
                if (int.TryParse(txtQuantity.Text, out quantity))
                {
                    selectedRow["Quantity"] = quantity;
                    MessageBox.Show("Record updated successfully.");
                    ClearTextBoxes();
                }
                else
                {
                    MessageBox.Show("Please enter a valid quantity.");
                }

                dgvStock.DataSource = stockDataTable; // Refresh DataGridView
            }
            else
            {
                MessageBox.Show("Please select a record to update.");
            }
        }


        private void LoadModelsByProduct(int productId)
        {
            using (SqlConnection conn = new SqlConnection("Data Source=VIVOBOOK15\\SQLEXPRESS;Initial Catalog=Mobile_Pos_System;Integrated Security=True;Encrypt=False"))
            {
                string query = "SELECT model_id, model_name FROM Model WHERE product_id = @product_id";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.SelectCommand.Parameters.AddWithValue("@product_id", productId);

                DataTable modelTable = new DataTable();
                adapter.Fill(modelTable);

                cmbModel.DisplayMember = "model_name";
                cmbModel.ValueMember = "model_id";
                cmbModel.DataSource = modelTable;
            }
        }

        private void dgvStock_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the selected row is valid
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgvStock.Rows[e.RowIndex];

                // Fill the TextBoxes and ComboBoxes with the data from the selected row
                txtStockID.Text = selectedRow.Cells["StockID"].Value.ToString();
                txtDate.Text = selectedRow.Cells["Date"].Value.ToString();

                // Set Category ComboBox
                cmbCategory.Text = selectedRow.Cells["Category"].Value.ToString();

                // Set Product ComboBox
                cmbProduct.Text = selectedRow.Cells["Product"].Value.ToString();

                // Set Model ComboBox
                cmbModel.Text = selectedRow.Cells["Model"].Value.ToString();

                // Set Quantity TextBox
                txtQuantity.Text = selectedRow.Cells["Quantity"].Value.ToString();
            }
        }
    }


}
