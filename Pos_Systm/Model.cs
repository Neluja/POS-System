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
    public partial class Model : Form
    {


        public int ModelId { get; set; }
        public string ModelName { get; set; }
        public Model()
        {
            InitializeComponent();
        }

        private void ClearTextBoxes()
        {
            txtBuyingPrice.Clear();
            txtid.Clear();
            
            txtModelName.Clear();
            txtUnitPrice.Clear();
            cmbCategory.SelectedIndex = -1;
            cmbCategory.Text = "";
            cmbCategory.SelectedIndex = -1;
            cmbProduct.Text = "";


        }

        private void Model_Load(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection("Data Source=VIVOBOOK15\\SQLEXPRESS;Initial Catalog=Mobile_Pos_System;Integrated Security=True;Encrypt=False"))

                LoadCategoryComboBox();
            FILLDGV();



        }


        private void categoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedCategoryId = (int)cmbCategory.SelectedValue;
            SqlConnection con = new SqlConnection("Data Source=VIVOBOOK15\\SQLEXPRESS;Initial Catalog=Mobile_Pos_System;Integrated Security=True;Encrypt=False");
            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT product_id, product_name FROM Product WHERE category_id = @category_id", con);
            cmd.Parameters.AddWithValue("@category_id", selectedCategoryId);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            cmbProduct.DisplayMember = "product_name";
            cmbProduct.ValueMember = "product_id";
            cmbProduct.DataSource = dt;

            con.Close();
        }



        private void btnSave_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection("Data Source=VIVOBOOK15\\SQLEXPRESS;Initial Catalog=Mobile_Pos_System;Integrated Security=True;Encrypt=False"))
            {
                try
                {
                    con.Open();

                    // Check if required fields are filled
                    if (string.IsNullOrWhiteSpace(txtModelName.Text) ||
                        string.IsNullOrWhiteSpace(txtUnitPrice.Text) ||
                        cmbProduct.SelectedIndex == -1 ||
                        cmbCategory.SelectedIndex == -1) // Ensure category is selected
                    {
                        MessageBox.Show("Please fill in all fields.");
                        return;
                    }

                    // Get the selected product ID and category ID
                    int productId = (int)cmbProduct.SelectedValue;
                    int categoryId = (int)cmbCategory.SelectedValue; // Get the selected category ID

                    // Insert new model with product ID and category ID
                    SqlCommand cmd = new SqlCommand("INSERT INTO Model (model_name, unit_price, product_id, category_id, quantity, BuyingPrice) VALUES (@model_name, @unit_price, @product_id, @category_id, @quantity, @BuyingPrice)", con);
                    cmd.Parameters.AddWithValue("@model_name", txtModelName.Text);
                    cmd.Parameters.AddWithValue("@unit_price", decimal.Parse(txtUnitPrice.Text));
                    cmd.Parameters.AddWithValue("@product_id", productId);
                    cmd.Parameters.AddWithValue("@category_id", categoryId); // Pass the selected category ID
                    cmd.Parameters.AddWithValue("@quantity", 0); // or any default value
                    cmd.Parameters.AddWithValue("@BuyingPrice", decimal.Parse(txtBuyingPrice.Text));

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Model saved successfully.");
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


        private void ClearFields()
        {
            txtModelName.Clear();
            txtUnitPrice.Clear();

            cmbCategory.SelectedIndex = -1;
            cmbProduct.DataSource = null;
        }

        private void LoadModelData()
        {
            SqlConnection con = new SqlConnection("Data Source=VIVOBOOK15\\SQLEXPRESS;Initial Catalog=Mobile_Pos_System;Integrated Security=True;Encrypt=False");
            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT Model.model_id, Model.model_name, Model.unit_price,  Product.product_name, Category.category_name FROM Model JOIN Product ON Model.product_id = Product.product_id JOIN Category ON Model.category_id = Category.category_id", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;


            con.Close();





        }
        private void FILLDGV()
        {
            SqlConnection con = new SqlConnection("Data Source=VIVOBOOK15\\SQLEXPRESS;Initial Catalog=Mobile_Pos_System;Integrated Security=True;Encrypt=False");
            con.Open();

            // Select only the desired columns from the Model table
            string query = "SELECT model_id,model_name, unit_price, BuyingPrice, product_id, category_id FROM Model";

            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            // Set the DataGridView's data source to the DataTable
            dataGridView1.DataSource = dt;

            con.Close();
        }



        // Load categories into ComboBox
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

            // Add event handler for category selection change
            cmbCategory.SelectedIndexChanged += cmbCategory_SelectedIndexChanged;
        }

        // Event handler to load products based on selected category
        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCategory.SelectedValue != null)
            {
                int selectedCategoryId = Convert.ToInt32(cmbCategory.SelectedValue);
                LoadProductsByCategory(selectedCategoryId);
            }
        }

        // Load products for the selected category into ComboBox
        private void LoadProductsByCategory(int categoryId)
        {
            SqlConnection con = new SqlConnection("Data Source=VIVOBOOK15\\SQLEXPRESS;Initial Catalog=Mobile_Pos_System;Integrated Security=True;Encrypt=False");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT product_id, product_name FROM Product WHERE category_id = @category_id", con);
            cmd.Parameters.AddWithValue("@category_id", categoryId);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            cmbProduct.DataSource = dt;
            cmbProduct.DisplayMember = "product_name";  // Display product name
            cmbProduct.ValueMember = "product_id";       // Use product_id as the value

            con.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Check if a row is selected in the DataGridView
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to delete.");
                return;
            }

            // Get the model_id from the selected row
            int modelId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["model_id"].Value);

            // Confirm deletion with a message box
            DialogResult result = MessageBox.Show("Are you sure you want to delete this model?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    // Establish the database connection
                    using (SqlConnection con = new SqlConnection("Data Source=VIVOBOOK15\\SQLEXPRESS;Initial Catalog=Mobile_Pos_System;Integrated Security=True;Encrypt=False"))
                    {
                        con.Open();

                        // Delete the model based on the selected model_id
                        SqlCommand cmd = new SqlCommand("DELETE FROM Model WHERE model_id = @model_id", con);
                        cmd.Parameters.AddWithValue("@model_id", modelId);

                        // Execute the command
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Model successfully deleted.");
                            FILLDGV(); // Refresh the DataGridView
                        }
                        else
                        {
                            MessageBox.Show("No matching model found.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error occurred: " + ex.Message);
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Ensure a row is selected in the DataGridView
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to update.");
                return;
            }

            // Ensure that required fields are filled
            if (string.IsNullOrWhiteSpace(txtid.Text) ||
                string.IsNullOrWhiteSpace(txtModelName.Text) ||
                string.IsNullOrWhiteSpace(txtUnitPrice.Text) ||
                cmbProduct.SelectedIndex == -1 ||
                cmbCategory.SelectedIndex == -1)
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            // Validate Model ID as an integer
            if (!int.TryParse(txtid.Text, out int modelId))
            {
                MessageBox.Show("Model ID must be a valid integer.");
                return;
            }

            // Get the selected row from the DataGridView
            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

            // Check if the Model ID in the text box matches the selected row's Model ID
            int selectedModelId = Convert.ToInt32(selectedRow.Cells["model_id"].Value);
            if (selectedModelId != modelId)
            {
                MessageBox.Show("Please select the correct row to update.");
                return;
            }

            // Connect to the database
            using (SqlConnection con = new SqlConnection("Data Source=VIVOBOOK15\\SQLEXPRESS;Initial Catalog=Mobile_Pos_System;Integrated Security=True;Encrypt=False"))
            {
                try
                {
                    con.Open();

                    // Get the selected product ID and category ID
                    int productId = (int)cmbProduct.SelectedValue;
                    int categoryId = (int)cmbCategory.SelectedValue;

                    // Prepare the SQL command to update the Model table
                    SqlCommand cmd = new SqlCommand("UPDATE Model SET model_name = @model_name, unit_price = @unit_price, product_id = @product_id, category_id = @category_id WHERE model_id = @model_id", con);
                    cmd.Parameters.AddWithValue("@model_name", txtModelName.Text);
                    cmd.Parameters.AddWithValue("@unit_price", decimal.Parse(txtUnitPrice.Text));
                    cmd.Parameters.AddWithValue("@product_id", productId);
                    cmd.Parameters.AddWithValue("@category_id", categoryId);
                    cmd.Parameters.AddWithValue("@model_id", modelId);

                    // Execute the update query
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Model details updated successfully.");
                    ClearTextBoxes();

                    // Refresh the DataGridView
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

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Populate the text boxes with relevant data
                txtBuyingPrice.Text = row.Cells["BuyingPrice"].Value?.ToString();
                txtid.Text = row.Cells["model_id"].Value?.ToString();
                txtModelName.Text = row.Cells["model_name"].Value?.ToString();
                txtUnitPrice.Text = row.Cells["unit_price"].Value?.ToString();

                // Populate ComboBox with the corresponding category
                int categoryId = Convert.ToInt32(row.Cells["category_id"].Value);
                cmbCategory.SelectedValue = categoryId;

                // Load products for the selected category
                LoadProductsByCategory(categoryId);

                // Set the product ComboBox to the correct product
                int productId = Convert.ToInt32(row.Cells["product_id"].Value);
                cmbProduct.SelectedValue = productId;
            }
        }
    }
}

