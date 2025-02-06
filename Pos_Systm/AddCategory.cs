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
    public partial class AddCategory : Form
    {
        public AddCategory()
        {
            InitializeComponent();
        }

        private void ClearTextBoxes()
        {
            txtCategoryID.Clear();
            txtCategoryName.Clear();

        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=VIVOBOOK15\\SQLEXPRESS;Initial Catalog=Mobile_Pos_System;Integrated Security=True;Encrypt=False");
            con.Open();

            if (string.IsNullOrWhiteSpace(txtCategoryID.Text) ||
               string.IsNullOrWhiteSpace(txtCategoryName.Text))

            {
                MessageBox.Show("Please fill in all fields.");
                con.Close();
                return;
            }

            // Check if the same ID 
            SqlCommand checkIdCmd = new SqlCommand("SELECT COUNT(*) FROM Category WHERE category_id = @category_id", con);
            checkIdCmd.Parameters.AddWithValue("@category_id", int.Parse(txtCategoryID.Text));

            int idExists = (int)checkIdCmd.ExecuteScalar();
            if (idExists > 0)
            {
                MessageBox.Show("The ID already exists. Please use a different ID.");
                con.Close();
                return;
            }

            SqlCommand cmd = new SqlCommand("insert into Category  values(@category_id,@category_name)", con);
            cmd.Parameters.AddWithValue("@category_id", int.Parse(txtCategoryID.Text));
            cmd.Parameters.AddWithValue("@category_name", txtCategoryName.Text);

            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Successfully saved");
            ClearTextBoxes();
            FILLDGV();


        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection("Data Source=VIVOBOOK15\\SQLEXPRESS;Initial Catalog=Mobile_Pos_System;Integrated Security=True;Encrypt=False"))
            {
                con.Open();

                // Check if any textbox is empty
                if (string.IsNullOrWhiteSpace(txtCategoryID.Text) || string.IsNullOrWhiteSpace(txtCategoryName.Text))
                {
                    MessageBox.Show("Please fill in all fields.");
                    return;
                }

                // Update the category name for the given ID
                SqlCommand cmd = new SqlCommand("UPDATE Category SET category_name = @category_name WHERE category_id = @category_id", con);
                cmd.Parameters.AddWithValue("@category_id", int.Parse(txtCategoryID.Text));
                cmd.Parameters.AddWithValue("@category_name", txtCategoryName.Text);

                int rowsAffected = cmd.ExecuteNonQuery(); // Get affected row count
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Category successfully updated.");
                    ClearTextBoxes();
                    FILLDGV(); // Refresh DataGridView
                }
                else
                {
                    MessageBox.Show("No matching Category ID found.");
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Check if a row is selected in the DataGridView
            if (dataGridView1.CurrentRow == null || dataGridView1.CurrentRow.Cells["category_id"].Value == null)
            {
                MessageBox.Show("Please select a row to delete.", "No Row Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Retrieve the category_id from the selected row
            int categoryId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["category_id"].Value);

            // Confirmation dialog before deletion
            DialogResult result = MessageBox.Show("Are you sure you want to delete the selected category?\nThis will also delete related products and models.",
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
                            // Step 1: Delete related records from the Model table
                            SqlCommand deleteModelCmd = new SqlCommand(
                                "DELETE FROM Model WHERE product_id IN (SELECT product_id FROM Product WHERE category_id = @category_id)", con, transaction);
                            deleteModelCmd.Parameters.AddWithValue("@category_id", categoryId);
                            deleteModelCmd.ExecuteNonQuery();

                            // Step 2: Delete related records from the Product table
                            SqlCommand deleteProductCmd = new SqlCommand(
                                "DELETE FROM Product WHERE category_id = @category_id", con, transaction);
                            deleteProductCmd.Parameters.AddWithValue("@category_id", categoryId);
                            deleteProductCmd.ExecuteNonQuery();

                            // Step 3: Delete the category from the Category table
                            SqlCommand deleteCategoryCmd = new SqlCommand(
                                "DELETE FROM Category WHERE category_id = @category_id", con, transaction);
                            deleteCategoryCmd.Parameters.AddWithValue("@category_id", categoryId);
                            int rowsAffected = deleteCategoryCmd.ExecuteNonQuery();

                            // Commit transaction if everything succeeded
                            if (rowsAffected > 0)
                            {
                                transaction.Commit();
                                MessageBox.Show("Category, related products, and models successfully deleted.",
                                                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ClearTextBoxes();
                                FILLDGV(); // Refresh the DataGridView
                            }
                            else
                            {
                                transaction.Rollback();
                                MessageBox.Show("No matching Category ID found.",
                                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        catch (Exception ex)
                        {
                            // Rollback the transaction in case of any errors
                            transaction.Rollback();
                            MessageBox.Show("Error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Delete operation canceled.", "Operation Canceled", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void FILLDGV()
        {
            SqlConnection con = new SqlConnection("Data Source=VIVOBOOK15\\SQLEXPRESS;Initial Catalog=Mobile_Pos_System;Integrated Security=True;Encrypt=False");
            con.Open();
            string query = "Select * From Category";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void AddCategory_Load(object sender, EventArgs e)
        {
            FILLDGV();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Populate text boxes with values from the selected row
                txtCategoryID.Text = row.Cells["category_id"].Value?.ToString();
                txtCategoryName.Text = row.Cells["category_name"].Value?.ToString();
               
            }
        }
    }
}
