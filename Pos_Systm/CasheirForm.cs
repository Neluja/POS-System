
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using PdfSharp.Drawing;
using PdfSharp.Pdf;




using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Reflection;




namespace Pos_Systm
{
    public partial class CasheirForm : Form
    {
        private int userId;
        private string username;
        private bool isDiscountApplied = false;
        private int previousRowCount = 0;
        private DateTime transactionDate;



        private System.Windows.Forms.Timer timer;
        // Timer will be accessible by all methods in this class
        private readonly string connectionString = "Data Source=VIVOBOOK15\\SQLEXPRESS;Initial Catalog=Mobile_Pos_System;Integrated Security=True;Encrypt=False";
        public CasheirForm(int userId, string username)
        {
            InitializeComponent();
            this.userId = userId;
            this.username = username;
            /* LoadDiscount();
             cmbDscount.SelectedIndexChanged += cmbDscount_SelectedIndexChanged;*/
            dataGridViewCart.RowsAdded += DataGridViewCart_RowsAdded;

            this.KeyPreview = true; // Enables form-wide key handling
            this.KeyDown += Cashier_KeyDown; // Attach the KeyDown event handler
            this.KeyDown += Enter_KeyDown; // Attach the KeyDown event handler
            this.KeyDown += TextBox_KeyDown; // Attach the KeyDown event handler
            this.KeyDown += Space_KeyDown;
            this.KeyDown += TotalTextBox_KeyDown;
            this.KeyDown += CAmount_KeyDown;
            this.KeyDown += btnSetDateTime_KeyDown_1;
            this.KeyDown += btnAddDiscount_KeyDown;
            this.KeyDown += btnPay_KeyDown;
            this.KeyDown += btnRemove_KeyDown;
            this.KeyDown += EnterCart_KeyDown;
            this.KeyDown += Cart_KeyDown;




        }

        private void CasheirForm_Load(object sender, EventArgs e)
        {
            LoadTrueStock();
            //LoadDiscount();
            LoadCategories();
            InitializeCartGrid();
            txtCustomerAmount.TextChanged += txtCustomerAmount_TextChanged;
            HideStockIDColumn();
            // Initialize and configure the timer
            timer = new System.Windows.Forms.Timer();  // Specify the Forms Timer explicitly
            timer.Interval = 1000; // 1 second interval
            timer.Tick += Timer_Tick; // Event handler for Tick event
            timer.Start(); // Start the timer

            // Initialize the live date and time display
            lblDateTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            // Set the DateTimePicker control to the current time for manual editing
            dateTimePickerManual.Value = DateTime.Now;

            // Set the text boxes with the provided user details
            txtCashierID.Text = userId.ToString();
            txtCashierName.Text = username;



        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Update live date and time in the label
            lblDateTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private void btnSetDateTime_Click(object sender, EventArgs e)
        {
            // Set the manual date and time to the label
            lblDateTime.Text = dateTimePickerManual.Value.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private void InitializeCartGrid()
        {
            dataGridViewCart.Columns.Clear();
            dataGridViewCart.Columns.Add("StockID", "Stock ID");
            dataGridViewCart.Columns.Add("Category", "Category");
            dataGridViewCart.Columns.Add("Product", "Product");
            dataGridViewCart.Columns.Add("Model", "Model");
            dataGridViewCart.Columns.Add("Quantity", "Quantity");
            dataGridViewCart.Columns.Add("Price", "Price");
        }

        private void LoadCart()
        {
            // Create columns for the cart DataGridView (dgvcart)
            dataGridViewCart.Columns.Clear();
            dataGridViewCart.Columns.Add("StockID", "Stock ID");
            dataGridViewCart.Columns.Add("Category", "Category");
            dataGridViewCart.Columns.Add("Product", "Product");
            dataGridViewCart.Columns.Add("Quantity", "Quantity");

            dataGridViewCart.Columns.Add("Model", "Model"); // Add Model column
            dataGridViewCart.Columns.Add("Price", "Price"); // Add Price column
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (cmbCategory.SelectedItem == null)
            {
                MessageBox.Show("Please select a category.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string selectedCategory = cmbCategory.SelectedItem.ToString();
            LoadDataByCategory(selectedCategory);
        }

        private void btnback_Click(object sender, EventArgs e)
        {

        }

        private void LoadDefaultStockData()
        {
        }

        private void OpenCashierForm()
        {

        }

        private void LoadTrueStock()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT StockID, Category, Product, Model, Quantity, Price FROM TrueStock";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable stockTable = new DataTable();
                    adapter.Fill(stockTable);

                    dataGridViewStock.DataSource = stockTable;

                    // Set column properties
                    foreach (DataGridViewColumn column in dataGridViewStock.Columns)
                    {
                        column.ReadOnly = true;
                    }
                    dataGridViewStock.Columns["Quantity"].ReadOnly = false; // Allow Quantity to be editable if needed
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading stock: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCategories()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT DISTINCT Category FROM TrueStock";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    cmbCategory.Items.Clear();
                    while (reader.Read())
                    {
                        cmbCategory.Items.Add(reader["Category"].ToString());
                    }
                    if (cmbCategory.Items.Count > 0)
                    {
                        cmbCategory.SelectedIndex = 0; // Set default selection
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading categories: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void LoadDataByCategory(string category)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT StockID, Category, Product, Model, Quantity, Price FROM TrueStock WHERE Category = @Category";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Category", category);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable filteredTable = new DataTable();
                    adapter.Fill(filteredTable);

                    dataGridViewStock.DataSource = filteredTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error filtering stock: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            // Check if a row is selected in dataGridViewStock
            if (dataGridViewStock.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridViewStock.SelectedRows[0];

                // Extract data from selected row
                string stockID = selectedRow.Cells["StockID"].Value.ToString();
                string category = selectedRow.Cells["Category"].Value.ToString();
                string product = selectedRow.Cells["Product"].Value.ToString();
                string model = selectedRow.Cells["Model"].Value.ToString();
                decimal price = Convert.ToDecimal(selectedRow.Cells["Price"].Value.ToString());

                // Get the quantity from txtQty TextBox
                string quantityText = txtQty.Text.Trim();

                // Check if quantity is valid
                if (!int.TryParse(quantityText, out int quantity) || quantity <= 0)
                {
                    MessageBox.Show("Please enter a valid quantity (positive integer).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Check if enough stock is available
                int availableQuantity = Convert.ToInt32(selectedRow.Cells["Quantity"].Value);
                if (quantity > availableQuantity)
                {
                    MessageBox.Show("Not enough stock available for this item.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Add the item to the cart
                dataGridViewCart.Rows.Add(stockID, category, product, model, quantity, price * quantity);

                // Update stock quantity in the DataGridView
                selectedRow.Cells["Quantity"].Value = availableQuantity - quantity;

                // Update stock quantity in the TrueStock table
                using (SqlConnection conn = new SqlConnection("Data Source=VIVOBOOK15\\SQLEXPRESS;Initial Catalog=Mobile_Pos_System;Integrated Security=True;Encrypt=False"))
                {
                    conn.Open();
                    string updateQuery = "UPDATE TrueStock SET Quantity = Quantity - @quantity WHERE StockID = @stockID";
                    using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@quantity", quantity);
                        cmd.Parameters.AddWithValue("@stockID", stockID);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected <= 0)
                        {
                            MessageBox.Show("Failed to update the stock in the database.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }

                // Update the total price after adding the item
                UpdateCartTotal();

                MessageBox.Show("Item added to the cart and stock updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please select an item from the stock to add to the cart.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void AddToCart(string stockID, string category, string model, string product, int quantity, int price)
        {
            // Add a new row to the Cart DataGridView
            dataGridViewCart.Rows.Add(stockID, category, model, product, quantity, price);

            MessageBox.Show("Item added to cart successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }


        private bool UpdateStockQuantity(string stockID, int quantityToAdd)
        {
            try
            {
                // Create your connection string
                string connectionString = "Data Source=VIVOBOOK15\\SQLEXPRESS;Initial Catalog=Mobile_Pos_System;Integrated Security=True;Encrypt=False";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Check if StockID exists in the database
                    string queryCheckStock = "SELECT Quantity FROM TrueStock WHERE StockID = @stockID";
                    SqlCommand cmdCheckStock = new SqlCommand(queryCheckStock, conn);
                    cmdCheckStock.Parameters.AddWithValue("@stockID", stockID);
                    var currentQuantityObj = cmdCheckStock.ExecuteScalar();

                    if (currentQuantityObj == DBNull.Value)
                    {
                        return false; // StockID not found in the database
                    }

                    int currentQuantity = Convert.ToInt32(currentQuantityObj);

                    // Add the quantity back to the stock
                    string queryUpdateStock = "UPDATE TrueStock SET Quantity = Quantity + @quantityToAdd WHERE StockID = @stockID";
                    SqlCommand cmdUpdateStock = new SqlCommand(queryUpdateStock, conn);
                    cmdUpdateStock.Parameters.AddWithValue("@quantityToAdd", quantityToAdd);
                    cmdUpdateStock.Parameters.AddWithValue("@stockID", stockID);

                    int rowsAffected = cmdUpdateStock.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating stock: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void UpdateTrueStockQuantity(string stockID, int newQuantity)
        {
            string connectionString = "Data Source=VIVOBOOK15\\SQLEXPRESS;Initial Catalog=Mobile_Pos_System;Integrated Security=True;Encrypt=False";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Query to update quantity in the TrueStock table
                    string query = "UPDATE TrueStock SET Quantity = @Quantity WHERE StockID = @StockID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Quantity", newQuantity);
                    cmd.Parameters.AddWithValue("@StockID", stockID);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating stock data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeDataGridViewStock()
        {
            dataGridViewStock.Columns.Clear();
            dataGridViewStock.Columns.Add("StockID", "Stock ID");
            dataGridViewStock.Columns.Add("Product", "Product");
            dataGridViewStock.Columns.Add("Model", "Model"); // Ensure Model column exists
            dataGridViewStock.Columns.Add("Price", "Price"); // Ensure Price column exists
            dataGridViewStock.Columns.Add("Quantity", "Quantity");
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            // Check if a row is selected in dataGridViewCart
            if (dataGridViewCart.SelectedRows.Count > 0)
            {
                var selectedCartRow = dataGridViewCart.SelectedRows[0];
                string stockIDToRemove = selectedCartRow.Cells["StockID"].Value.ToString();

                // Find the stock row in the stock grid
                foreach (DataGridViewRow stockRow in dataGridViewStock.Rows)
                {
                    if (stockRow.Cells["StockID"].Value?.ToString() == stockIDToRemove)
                    {
                        // Get the quantity in the cart and restore it to stock
                        int quantityToRemove = Convert.ToInt32(selectedCartRow.Cells["Quantity"].Value);
                        int currentStockQuantity = Convert.ToInt32(stockRow.Cells["Quantity"].Value);

                        // Update stock quantity in DataGridView (temporary in-memory update)
                        stockRow.Cells["Quantity"].Value = currentStockQuantity + quantityToRemove;

                        // Now update the quantity in the database permanently
                        UpdateStockQuantityInDatabase(stockIDToRemove, currentStockQuantity + quantityToRemove);

                        // Remove the selected row from the cart
                        dataGridViewCart.Rows.Remove(selectedCartRow);

                        // Update the total price after removing the item
                        UpdateCartTotal();

                        MessageBox.Show("Item removed from the cart, and quantity restored to stock.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select an item from the cart to remove.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void UpdateStockQuantityInDatabase(string stockID, int newQuantity)
        {
            // Assuming you're using SQL Server or another database system
            string connectionString = "your_connection_string_here"; // Replace with your connection string
            using (SqlConnection conn = new SqlConnection("Data Source=VIVOBOOK15\\SQLEXPRESS;Initial Catalog=Mobile_Pos_System;Integrated Security=True;Encrypt=False"))
            {
                string query = "UPDATE TrueStock SET Quantity = @Quantity WHERE StockID = @StockID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Quantity", newQuantity);
                cmd.Parameters.AddWithValue("@StockID", stockID);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        private void RefreshStockGrid()
        {

            // Reload stock data into the DataGridViewStock
            string query = "SELECT StockID, Product, Quantity FROM TrueStock";
            using (SqlConnection conn = new SqlConnection("Data Source=VIVOBOOK15\\SQLEXPRESS;Initial Catalog=Mobile_Pos_System;Integrated Security=True;Encrypt=False"))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conn);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                dataGridViewStock.DataSource = dataTable;
            }
        }





        private void dataGridViewCart_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the edited cell is in the 'Quantity' column
            if (e.ColumnIndex == dataGridViewCart.Columns["Quantity"].Index)
            {
                // Get the new quantity value
                object quantityValue = dataGridViewCart.Rows[e.RowIndex].Cells["Quantity"].Value;
                if (quantityValue == null || string.IsNullOrWhiteSpace(quantityValue.ToString()))
                {
                    MessageBox.Show("Quantity cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Validate if it's a valid number and update total price
                if (int.TryParse(quantityValue.ToString(), out int newQuantity) && newQuantity > 0)
                {
                    decimal price = Convert.ToDecimal(dataGridViewCart.Rows[e.RowIndex].Cells["Price"].Value);
                    decimal totalPrice = newQuantity * price;
                    dataGridViewCart.Rows[e.RowIndex].Cells["TotalPrice"].Value = totalPrice;
                }
                else
                {
                    MessageBox.Show("Invalid quantity. Please enter a positive number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    // Reset the quantity cell to the original value
                    dataGridViewCart.Rows[e.RowIndex].Cells["Quantity"].Value = 1; // Set default value or keep old value
                }
            }
        }

        private void UpdateCartTotal()
        {
            decimal total = 0;

            foreach (DataGridViewRow row in dataGridViewCart.Rows)
            {
                if (row.Cells["Price"].Value != null && decimal.TryParse(row.Cells["Price"].Value.ToString(), out decimal price))
                {
                    total += price;
                }
            }

            txtTotal.Text = total.ToString("F2"); // Display total with two decimal places
        }

        private void txtCustomerAmount_TextChanged(object sender, EventArgs e)
        {
            // Ensure the Total Amount field is not empty or invalid
            if (decimal.TryParse(txtTotal.Text, out decimal totalAmount) && totalAmount > 0)
            {
                // Get the customer given amount
                if (decimal.TryParse(txtCustomerAmount.Text, out decimal customerGivenAmount))
                {
                    // Calculate the balance
                    decimal balance = customerGivenAmount - totalAmount;

                    // Update the balance textbox
                    txtBalance.Text = balance.ToString("F2"); // Display with two decimal places
                }
                else
                {
                    // If invalid input, clear the balance textbox
                    txtBalance.Clear();
                }
            }
            else
            {
                // If total amount is not valid, clear the balance textbox
                txtBalance.Clear();
            }
        }

        private void HideStockIDColumn()
        {
            // Hide the StockID column in dataGridViewStock
            if (dataGridViewStock.Columns["StockID"] != null)
            {
                dataGridViewStock.Columns["StockID"].Visible = false;
            }

            // Hide the StockID column in dataGridViewCart
            if (dataGridViewCart.Columns["StockID"] != null)
            {
                dataGridViewCart.Columns["StockID"].Visible = false;
            }
        }

        private void btnSetDateTime_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Get the selected date and time from the DateTimePicker
                transactionDate = dateTimePickerManual.Value;

                // Display the selected date and time (optional)
                lblDateTime.Text = transactionDate.ToString("yyyy-MM-dd HH:mm:ss");

                MessageBox.Show("Transaction date set successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error setting transaction date: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPay_Click(object sender, EventArgs e)
        {




            try
            {
                if (string.IsNullOrWhiteSpace(txtCustomerAmount.Text) || string.IsNullOrWhiteSpace(txtCashierID.Text))
                {
                    MessageBox.Show("Please enter all required payment details.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                decimal customerAmount = Convert.ToDecimal(txtCustomerAmount.Text);
                decimal totalAmount = Convert.ToDecimal(txtTotal.Text);
                decimal balance = customerAmount - totalAmount;

                if (balance < 0)
                {
                    MessageBox.Show("Customer amount is insufficient.", "Payment Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string model = "", product = "", category = "";
                decimal price = 0;
                int quantity = 0;
                // DateTime transactionDate = DateTime.Now; // Use current date for transaction
                decimal totalBuyingAmount = 0;

                using (SqlConnection conn = new SqlConnection("Data Source=VIVOBOOK15\\SQLEXPRESS;Initial Catalog=Mobile_Pos_System;Integrated Security=True;Encrypt=False"))
                {
                    conn.Open();

                    foreach (DataGridViewRow row in dataGridViewCart.Rows)
                    {
                        if (row.Cells["Category"].Value != null && row.Cells["Product"].Value != null)
                        {
                            model = row.Cells["Model"].Value.ToString();
                            product = row.Cells["Product"].Value.ToString();
                            category = row.Cells["Category"].Value.ToString();
                            price = Convert.ToDecimal(row.Cells["Price"].Value);
                            quantity = Convert.ToInt32(row.Cells["Quantity"].Value);

                            // Fetch buying amount for the model
                            string buyingAmountQuery = "SELECT BuyingPrice FROM model WHERE model_name = @model";
                            decimal buyingAmountPerUnit = 0;

                            using (SqlCommand cmd = new SqlCommand(buyingAmountQuery, conn))
                            {
                                cmd.Parameters.AddWithValue("@model", model);
                                object result = cmd.ExecuteScalar();
                                if (result != null)
                                {
                                    buyingAmountPerUnit = Convert.ToDecimal(result);
                                }
                            }

                            totalBuyingAmount += buyingAmountPerUnit * quantity;

                            // Insert detailed sales data for each cart item into Sales_New table
                            string salesNewQuery = "INSERT INTO Sales_New (transaction_date, total_amount, user_id, customer_given_amount, balance, category, model, product, price, quantity) " +
                                                    "VALUES (@transaction_date, @total_amount, @user_id, @customer_given_amount, @balance, @category, @model, @product, @price, @quantity)";

                            using (SqlCommand cmd = new SqlCommand(salesNewQuery, conn))
                            {
                                cmd.Parameters.AddWithValue("@transaction_date", transactionDate);
                                cmd.Parameters.AddWithValue("@total_amount", totalAmount);
                                cmd.Parameters.AddWithValue("@user_id", txtCashierID.Text);
                                cmd.Parameters.AddWithValue("@customer_given_amount", customerAmount);
                                cmd.Parameters.AddWithValue("@balance", balance);
                                cmd.Parameters.AddWithValue("@category", category);
                                cmd.Parameters.AddWithValue("@model", model);
                                cmd.Parameters.AddWithValue("@product", product);
                                cmd.Parameters.AddWithValue("@price", price);
                                cmd.Parameters.AddWithValue("@quantity", quantity);

                                cmd.ExecuteNonQuery();
                            }
                        }
                    }

                    decimal profit = totalAmount - totalBuyingAmount;

                    // Insert consolidated data into test_sales table
                    string insertSalesQuery = "INSERT INTO test_sales (strans_date, stot_amount, stot_buying, profit) VALUES (@strans_date, @stot_amount, @stot_buying, @profit)";

                    using (SqlCommand cmd = new SqlCommand(insertSalesQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@strans_date", transactionDate);
                        cmd.Parameters.AddWithValue("@stot_amount", totalAmount);
                        cmd.Parameters.AddWithValue("@stot_buying", totalBuyingAmount);
                        cmd.Parameters.AddWithValue("@profit", profit);

                        cmd.ExecuteNonQuery();
                    }
                }

                // Generate the PDF after payment is processed
                GenerateInvoicePDF(customerAmount, totalAmount, balance, model, product, category, price, quantity, transactionDate);

                MessageBox.Show("Payment processed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Reset the UI after processing
                dataGridViewCart.Rows.Clear();
                txtTotal.Text = "0.00";
                txtCustomerAmount.Text = "";
                txtBalance.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error processing the sale: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void GenerateInvoicePDF(decimal customerAmount, decimal totalAmount, decimal balance,
             string model, string product, string category,
             decimal price, int quantity, DateTime transactionDate)
        {
            try
            {
                // Generate a unique timestamp for the invoice file name
                string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                string filePath = $@"C:\Users\neluj\OneDrive\Desktop\Project Invoice\Invoice_{timestamp}.pdf";

                // Create the PDF document
                PdfSharp.Pdf.PdfDocument pdfDoc = new PdfSharp.Pdf.PdfDocument();
                pdfDoc.Info.Title = "Invoice";

                // Add a page to the document
                PdfSharp.Pdf.PdfPage page = pdfDoc.AddPage();

                // Create a graphics object to draw content on the PDF
                XGraphics gfx = XGraphics.FromPdfPage(page);

                // Define fonts and brushes
                XFont headerFont = new XFont("Verdana", 16); // Use "Verdana" with size 16 (no Bold/Regular required)
                XFont regularFont = new XFont("Verdana", 12); // Regular font with size 12
                XFont smallFont = new XFont("Verdana", 10); // Small font with size 10
                XBrush whiteBrush = XBrushes.White; // Change to white brush

                // Load the background image
                string backgroundImagePath = "Pos_Systm.Resources.page.jpg"; // Make sure the namespace is correct
                using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(backgroundImagePath))
                {
                    if (stream != null)
                    {
                        XImage backgroundImage = XImage.FromStream(stream);
                        // Draw the background image to fill the entire page
                        gfx.DrawImage(backgroundImage, 0, 0, page.Width, page.Height);
                    }
                }

                // Add the title and business details on top of the background image
                gfx.DrawString("MOBICARE SHOP", headerFont, whiteBrush, new XPoint(200, 50));
                gfx.DrawString("INVOICE", regularFont, whiteBrush, new XPoint(200, 80));
                gfx.DrawString("Benthara", smallFont, whiteBrush, new XPoint(200, 100));
                gfx.DrawString("Phone: 123-456-7890 | Email: chandimalneluja05@gmail.com", smallFont, whiteBrush, new XPoint(200, 120));

                // Draw a horizontal line below the header
                gfx.DrawLine(XPens.White, 20, 140, page.Width - 20, 140);

                // Display invoice details
                gfx.DrawString($"Transaction Date: {transactionDate:dd/MM/yyyy}", regularFont, whiteBrush, new XPoint(20, 160));
                gfx.DrawString($"Invoice #: {timestamp}", regularFont, whiteBrush, new XPoint(20, 180));

                // Draw table headers for product details
                int startY = 220;
                int rowHeight = 25;

                gfx.DrawString("Model", regularFont, whiteBrush, new XPoint(20, startY));
                gfx.DrawString("Product", regularFont, whiteBrush, new XPoint(120, startY));
                gfx.DrawString("Category", regularFont, whiteBrush, new XPoint(220, startY));
                gfx.DrawString("Price", regularFont, whiteBrush, new XPoint(320, startY));
                gfx.DrawString("Quantity", regularFont, whiteBrush, new XPoint(420, startY));
                gfx.DrawString("Total", regularFont, whiteBrush, new XPoint(520, startY));

                startY += rowHeight;

                // Loop through all cart items and add each one to the invoice
                foreach (DataGridViewRow row in dataGridViewCart.Rows)
                {
                    if (row.Cells["Category"].Value != null && row.Cells["Product"].Value != null)
                    {
                        model = row.Cells["Model"].Value.ToString();
                        product = row.Cells["Product"].Value.ToString();
                        category = row.Cells["Category"].Value.ToString();
                        price = Convert.ToDecimal(row.Cells["Price"].Value);
                        quantity = Convert.ToInt32(row.Cells["Quantity"].Value);

                        // Display product details for each item in the cart
                        gfx.DrawString(model, regularFont, whiteBrush, new XPoint(20, startY));
                        gfx.DrawString(product, regularFont, whiteBrush, new XPoint(120, startY));
                        gfx.DrawString(category, regularFont, whiteBrush, new XPoint(220, startY));
                        gfx.DrawString($"LKR {price:N2}", regularFont, whiteBrush, new XPoint(320, startY));

                        gfx.DrawString(quantity.ToString(), regularFont, whiteBrush, new XPoint(420, startY));
                        gfx.DrawString($"LKR {(price * quantity):N2}", regularFont, whiteBrush, new XPoint(520, startY));


                        startY += rowHeight; // Move to the next row
                    }
                }

                // Display totals
                startY += rowHeight;
                gfx.DrawString($"Customer Amount: LKR {customerAmount:N2}", regularFont, whiteBrush, new XPoint(20, startY));
                gfx.DrawString($"Total Amount: LKR {totalAmount:N2}", regularFont, whiteBrush, new XPoint(20, startY + rowHeight));
                gfx.DrawString($"Balance: LKR {balance:N2}", regularFont, whiteBrush, new XPoint(20, startY + rowHeight * 2));


                // Add footer details
                gfx.DrawLine(XPens.White, 20, page.Height - 100, page.Width - 20, page.Height - 100);
                gfx.DrawString("Thank you for your business!", regularFont, whiteBrush, new XPoint(20, page.Height - 80));
                gfx.DrawString("Contact us: 123-456-7890 | chandimalneluja05@gmail.com", smallFont, whiteBrush, new XPoint(20, page.Height - 60));
                gfx.DrawString("Visit us: www.mobicare.com", smallFont, whiteBrush, new XPoint(20, page.Height - 40));

                // Add the logo to the top left
                string logoPath = "Pos_Systm.Resources.logo.png"; // Embedded logo path
                using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(logoPath))
                {
                    if (stream != null)
                    {
                        XImage logo = XImage.FromStream(stream);
                        gfx.DrawImage(logo, 20, 20, 100, 50);
                    }
                    else
                    {
                        MessageBox.Show("Logo image not found!");
                    }
                }


                // Save the document to the specified file path
                pdfDoc.Save(filePath);
                pdfDoc.Close();

                // Notify the user of successful invoice generation
                MessageBox.Show($"Invoice generated successfully! Saved at: {filePath}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Display error details
                MessageBox.Show($"Error: {ex.Message}\n{ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





        private void btnLogOut_Click(object sender, EventArgs e)
        {
            // Display confirmation message
            DialogResult result = MessageBox.Show("Are you sure you want to log out?", "Confirm Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Redirect to Form1
                Form1 loginForm = new Form1();
                loginForm.Show();

                // Close the current form
                this.Close();
            }
        }

        /*private void LoadDiscount()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT DISTINCT ThresholdAmount FROM Discount";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    cmbDscount.Items.Clear();
                    while (reader.Read())
                    {
                        cmbDscount.Items.Add(reader["ThresholdAmount"].ToString());
                    }
                    if (cmbDscount.Items.Count > 0)
                    {
                        cmbDscount.SelectedIndex = 0; // Set default selection
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading discounts: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbDscount_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDscount.SelectedItem != null)
            {
                string selectedThreshold = cmbDscount.SelectedItem.ToString();
                LoadDiscountNames(selectedThreshold);
            }
        }

        private void LoadDiscountNames(string thresholdAmount)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT DiscountName FROM Discount WHERE ThresholdAmount = @ThresholdAmount";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ThresholdAmount", thresholdAmount);
                    SqlDataReader reader = cmd.ExecuteReader();

                    cmbDisName.Items.Clear();
                    while (reader.Read())
                    {
                        cmbDisName.Items.Add(reader["DiscountName"].ToString());
                    }
                    if (cmbDisName.Items.Count > 0)
                    {
                        cmbDisName.SelectedIndex = 0; // Set default selection
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading discount names: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }*/

        private void btnAddDiscount_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewCart.Rows.Count == 0)
                {
                    MessageBox.Show("No items in the cart to apply a discount.", "Empty Cart", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (dataGridViewCart.Rows.Count == previousRowCount)
                {
                    if (isDiscountApplied)
                    {
                        MessageBox.Show("Discount has already been applied. Please add new items to the cart to apply a new discount.", "Discount Already Applied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                if (decimal.TryParse(txtTotal.Text, out decimal totalAmount))
                {
                    decimal discountAmount = 0;
                    bool discountApplied = false;

                    using (SqlConnection conn = new SqlConnection("Data Source=VIVOBOOK15\\SQLEXPRESS;Initial Catalog=Mobile_Pos_System;Integrated Security=True;Encrypt=False"))
                    {
                        conn.Open();

                        // Query to check both seasonal and regular discounts
                        string query = @"SELECT DiscountID, DiscountName, ThresholdAmount, DiscountRate, IsSeasonal, SeasonalDate
                                 FROM Discount
                                 WHERE (ThresholdAmount <= @ThresholdAmount AND IsSeasonal = 0) -- Regular discount
                                       OR (IsSeasonal = 1 AND SeasonalDate = @SelectedDate) -- Seasonal discount
                                 ORDER BY IsSeasonal DESC, ThresholdAmount DESC"; // Prioritize seasonal discounts

                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@ThresholdAmount", totalAmount);
                        cmd.Parameters.AddWithValue("@SelectedDate", transactionDate.Date); // Use the user-set date instead of today's date

                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            string discountName = reader["DiscountName"].ToString();
                            decimal discountRate = Convert.ToDecimal(reader["DiscountRate"]);
                            bool isSeasonal = Convert.ToBoolean(reader["IsSeasonal"]);

                            // Determine discount type
                            string discountType = isSeasonal ? "Seasonal Discount" : "Regular Discount";

                            // Calculate discount amount and update total
                            discountAmount = totalAmount * (discountRate / 100);
                            totalAmount -= discountAmount;

                            // Display discount details
                            MessageBox.Show($"Discount Applied: {discountName} ({discountType}, {discountRate}% off)\n" +
                                            $"Discount Amount: {discountAmount:C}\n" +
                                            $"New Total: {totalAmount:C}",
                                            "Discount Applied", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            txtTotal.Text = totalAmount.ToString("0.00");

                            discountApplied = true;
                            isDiscountApplied = true;
                            previousRowCount = dataGridViewCart.Rows.Count;
                        }
                        else
                        {
                            MessageBox.Show("No applicable discount found for the selected total amount and date.", "No Discount", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }

                    if (!discountApplied)
                    {
                        MessageBox.Show("The total amount does not qualify for any discount.", "No Discount Available", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a valid total amount.", "Invalid Total", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error applying discount: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DataGridViewCart_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            isDiscountApplied = false;
            previousRowCount = dataGridViewCart.Rows.Count;
        }

        private void Cashier_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab) // Detect Tab key
            {
                dataGridViewStock.Focus(); // Focus the DataGridView
                e.Handled = true; // Prevent default behavior
            }
        }

        private void Enter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) // Detect Enter key
            {
                if (dataGridViewStock.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = dataGridViewStock.SelectedRows[0];
                    MessageBox.Show("Row selected: " + selectedRow.Cells[0].Value.ToString()); // Example action
                }
                else
                {
                    if (dataGridViewStock.Rows.Count > 0)
                    {
                        dataGridViewStock.Rows[0].Selected = true; // Select the first row
                    }
                }
                e.Handled = true; // Prevent the default Enter key behavior
            }
        }
        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Q) // Detect if the "Q" key is pressed
            {
                txtQty.Focus(); // Focus on the txtQty control
                e.Handled = true; // Prevent default behavior if necessary
            }
        }

        private void Space_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space) // Detect if the Space key is pressed
            {
                btnAddToCart.PerformClick(); // Trigger the button's click event programmatically
                e.Handled = true; // Prevent default behavior if necessary
            }
        }


        private void TotalTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.T) // Detect if the "Q" key is pressed
            {
                txtTotal.Focus(); // Focus on the txtQty control
                e.Handled = true; // Prevent default behavior if necessary
            }
        }

        private void CAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.C) // Detect if the "Q" key is pressed
            {
                txtCustomerAmount.Focus(); // Focus on the txtQty control
                e.Handled = true; // Prevent default behavior if necessary
            }
        }

        private void btnSetDateTime_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void AddDiscount_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void Pay_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void Remove_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void Cart_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Shift) // Detect Tab key
            {
                dataGridViewCart.Focus(); // Focus the DataGridView
                e.Handled = true; // Prevent default behavior
            }
        }


        private void EnterCart_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Alt) // Detect Enter key
            {
                if (dataGridViewCart.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = dataGridViewCart.SelectedRows[0];
                    MessageBox.Show("Row selected: " + selectedRow.Cells[0].Value.ToString()); // Example action
                }
                else
                {
                    if (dataGridViewCart.Rows.Count > 0)
                    {
                        dataGridViewCart.Rows[0].Selected = true; // Select the first row
                    }
                }
                e.Handled = true; // Prevent the default Enter key behavior
            }
        }

        private void btnRemove_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.R) // Detect if the "Q" key is pressed
            {
                btnRemove.PerformClick(); // Focus on the txtQty control
                e.Handled = true; // Prevent default behavior if necessary
            }
        }

        private void btnPay_KeyDown(object sender, KeyEventArgs e)
        {


            if (e.KeyCode == Keys.P) // Detect if the "Q" key is pressed
            {
                btnPay.PerformClick(); // Focus on the txtQty control
                e.Handled = true; // Prevent default behavior if necessary
            }

        }

        private void btnAddDiscount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A) // Detect if the "Q" key is pressed
            {
                btnAddDiscount.PerformClick(); // Focus on the txtQty control
                e.Handled = true; // Prevent default behavior if necessary
            }
        }

        private void btnSetDateTime_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.S) // Detect if the "Q" key is pressed
            {
                btnSetDateTime.PerformClick(); // Focus on the txtQty control
                e.Handled = true; // Prevent default behavior if necessary
            }
        }
    }
}
