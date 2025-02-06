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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Pos_Systm
{
    public partial class AddDiscount : Form
    {
        public AddDiscount()
        {
            InitializeComponent();
        }

        private void ClearTextBoxes()
        {
            txtDiscountName.Clear();
            txtDiscountRate.Clear();
            txtThresholdAmount.Clear();
            txtid.Clear();

            if (chkIsSeasonal.Checked)
            {
                chkIsSeasonal.Checked = false;
            }
        }

        private void AddDiscount_Load(object sender, EventArgs e)
        {
            FILLDGV();
        }


        private void FILLDGV()
        {
            SqlConnection con = new SqlConnection("Data Source=VIVOBOOK15\\SQLEXPRESS;Initial Catalog=Mobile_Pos_System;Integrated Security=True;Encrypt=False");
            con.Open();
            string query = "Select * From Discount";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvDiscounts.DataSource = dt;
            con.Close();
        }

        // Load discounts into DataGridView
        private void LoadDiscountData()
        {
            using (SqlConnection conn = new SqlConnection("Data Source=VIVOBOOK15\\SQLEXPRESS;Initial Catalog=Mobile_Pos_System;Integrated Security=True;Encrypt=False"))
            {
                try
                {
                    string query = "SELECT DiscountID, DiscountName, ThresholdAmount, DiscountRate, IsSeasonal, SeasonalDate FROM Discount";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);

                    DataTable discountTable = new DataTable();
                    adapter.Fill(discountTable);

                    dgvDiscounts.DataSource = discountTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading discounts: " + ex.Message);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Get inputs
            string discountName = txtDiscountName.Text.Trim();
            decimal thresholdAmount;
            decimal discountRate;
            bool isSeasonal = chkIsSeasonal.Checked;
            DateTime? seasonalDate = null;

            // Validate inputs
            if (string.IsNullOrEmpty(discountName))
            {
                MessageBox.Show("Discount Name is required.");
                return;
            }
            if (!decimal.TryParse(txtThresholdAmount.Text, out thresholdAmount) || thresholdAmount <= 0)
            {
                MessageBox.Show("Invalid Threshold Amount.");
                return;
            }
            if (!decimal.TryParse(txtDiscountRate.Text, out discountRate) || discountRate <= 0 || discountRate > 100)
            {
                MessageBox.Show("Invalid Discount Rate.");
                return;
            }
            if (isSeasonal)
            {
                seasonalDate = dtpSeasonalDate.Value.Date;
            }

            // Save to database
            using (SqlConnection conn = new SqlConnection("Data Source=VIVOBOOK15\\SQLEXPRESS;Initial Catalog=Mobile_Pos_System;Integrated Security=True;Encrypt=False"))
            {
                try
                {
                    string query = @"
                        INSERT INTO Discount (DiscountName, ThresholdAmount, DiscountRate, IsSeasonal, SeasonalDate)
                        VALUES (@DiscountName, @ThresholdAmount, @DiscountRate, @IsSeasonal, @SeasonalDate);
                    ";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@DiscountName", discountName);
                    cmd.Parameters.AddWithValue("@ThresholdAmount", thresholdAmount);
                    cmd.Parameters.AddWithValue("@DiscountRate", discountRate);
                    cmd.Parameters.AddWithValue("@IsSeasonal", isSeasonal);
                    cmd.Parameters.AddWithValue("@SeasonalDate", (object)seasonalDate ?? DBNull.Value);

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Discount added successfully!");
                    ClearTextBoxes();
                    LoadDiscountData(); // Refresh DataGridView
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error adding discount: " + ex.Message);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvDiscounts.SelectedRows.Count > 0) // Check if a row is selected
                {
                    // Get the DiscountID of the selected row
                    int discountID = Convert.ToInt32(dgvDiscounts.SelectedRows[0].Cells["DiscountID"].Value);

                    // Ask for confirmation
                    DialogResult result = MessageBox.Show("Are you sure you want to delete this record?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        // Delete the record from the database
                        using (SqlConnection con = new SqlConnection("Data Source=VIVOBOOK15\\SQLEXPRESS;Initial Catalog=Mobile_Pos_System;Integrated Security=True;Encrypt=False"))
                        {
                            con.Open();
                            string query = "DELETE FROM Discount WHERE DiscountID = @DiscountID";
                            using (SqlCommand cmd = new SqlCommand(query, con))
                            {
                                cmd.Parameters.AddWithValue("@DiscountID", discountID);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        // Refresh the DataGridView
                        MessageBox.Show("Record deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDiscountData(); // Call a method to reload the data
                    }
                }
                else
                {
                    MessageBox.Show("Please select a row to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate inputs
                if (string.IsNullOrWhiteSpace(txtid.Text))
                {
                    MessageBox.Show("Please select a discount to update.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int discountID = int.Parse(txtid.Text);
                string discountName = txtDiscountName.Text.Trim();
                decimal thresholdAmount;
                decimal discountRate;
                bool isSeasonal = chkIsSeasonal.Checked;
                DateTime? seasonalDate = null;

                if (string.IsNullOrEmpty(discountName))
                {
                    MessageBox.Show("Discount Name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!decimal.TryParse(txtThresholdAmount.Text, out thresholdAmount) || thresholdAmount <= 0)
                {
                    MessageBox.Show("Invalid Threshold Amount.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!decimal.TryParse(txtDiscountRate.Text, out discountRate) || discountRate <= 0 || discountRate > 100)
                {
                    MessageBox.Show("Invalid Discount Rate.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (isSeasonal)
                {
                    seasonalDate = dtpSeasonalDate.Value.Date;
                }

                // Update the record in the database
                using (SqlConnection conn = new SqlConnection("Data Source=VIVOBOOK15\\SQLEXPRESS;Initial Catalog=Mobile_Pos_System;Integrated Security=True;Encrypt=False"))
                {
                    conn.Open();
                    string query = @"
                UPDATE Discount
                SET DiscountName = @DiscountName,
                    ThresholdAmount = @ThresholdAmount,
                    DiscountRate = @DiscountRate,
                    IsSeasonal = @IsSeasonal,
                    SeasonalDate = @SeasonalDate
                WHERE DiscountID = @DiscountID;
            ";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@DiscountID", discountID);
                        cmd.Parameters.AddWithValue("@DiscountName", discountName);
                        cmd.Parameters.AddWithValue("@ThresholdAmount", thresholdAmount);
                        cmd.Parameters.AddWithValue("@DiscountRate", discountRate);
                        cmd.Parameters.AddWithValue("@IsSeasonal", isSeasonal);
                        cmd.Parameters.AddWithValue("@SeasonalDate", (object)seasonalDate ?? DBNull.Value);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Discount updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Clear textboxes and refresh DataGridView
                ClearTextBoxes();
                LoadDiscountData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating discount: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDiscounts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Ensure the click is on a valid row, not the header
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dgvDiscounts.Rows[e.RowIndex];

                    // Auto-fill the textboxes with data from the selected row
                    txtid.Text = row.Cells["DiscountID"].Value?.ToString();
                    txtDiscountName.Text = row.Cells["DiscountName"].Value?.ToString();
                    txtThresholdAmount.Text = row.Cells["ThresholdAmount"].Value?.ToString();
                    txtDiscountRate.Text = row.Cells["DiscountRate"].Value?.ToString();

                    // Check and set the checkbox based on IsSeasonal
                    if (row.Cells["IsSeasonal"].Value != null && Convert.ToBoolean(row.Cells["IsSeasonal"].Value))
                    {
                        chkIsSeasonal.Checked = true;

                        // Set the seasonal date if available
                        if (row.Cells["SeasonalDate"].Value != DBNull.Value)
                        {
                            dtpSeasonalDate.Value = Convert.ToDateTime(row.Cells["SeasonalDate"].Value);
                        }
                    }
                    else
                    {
                        chkIsSeasonal.Checked = false;
                        dtpSeasonalDate.Value = DateTime.Today; // Default date
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while selecting discount: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
