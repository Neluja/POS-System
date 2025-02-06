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
using System.Windows.Forms.DataVisualization.Charting;

namespace Pos_Systm
{
    public partial class Prediction : Form
    {
        public Prediction()
        {
            InitializeComponent();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void LoadSalesData()
        {
            // Replace with your actual connection string
            string connectionString = "Data Source=VIVOBOOK15\\SQLEXPRESS;Initial Catalog=Mobile_Pos_System;Integrated Security=True;Encrypt=False";
            string query = @"
    SELECT FORMAT(transaction_date, 'yyyy-MM') AS SaleMonth, SUM(price) AS TotalSales
    FROM Sales_New
    GROUP BY FORMAT(transaction_date, 'yyyy-MM')
    ORDER BY SaleMonth";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable salesData = new DataTable();
                        adapter.Fill(salesData);

                        // Clear existing series
                        chart1.Series.Clear();

                        // Add three separate series for the previous 3 months' sales
                        Series salesSeries1 = new Series("Month 1")
                        {
                            ChartType = SeriesChartType.Column,
                            XValueType = ChartValueType.String,
                            YValueType = ChartValueType.Double,
                            Color = Color.Blue
                        };

                        Series salesSeries2 = new Series("Month 2")
                        {
                            ChartType = SeriesChartType.Column,
                            XValueType = ChartValueType.String,
                            YValueType = ChartValueType.Double,
                            Color = Color.Blue
                        };

                        Series salesSeries3 = new Series("Month 3")
                        {
                            ChartType = SeriesChartType.Column,
                            XValueType = ChartValueType.String,
                            YValueType = ChartValueType.Double,
                            Color = Color.Blue
                        };

                        int rowCount = salesData.Rows.Count;

                        // Add the previous 3 months' data to separate series
                        if (rowCount >= 3)
                        {
                            // Get data for last 3 months
                            for (int i = rowCount - 3; i < rowCount; i++)
                            {
                                string saleMonth = salesData.Rows[i]["SaleMonth"].ToString();
                                double totalSales = Convert.ToDouble(salesData.Rows[i]["TotalSales"]);

                                // Add each month's sales to its respective series
                                if (i == rowCount - 3)
                                    salesSeries1.Points.AddXY(saleMonth, totalSales);
                                else if (i == rowCount - 2)
                                    salesSeries2.Points.AddXY(saleMonth, totalSales);
                                else
                                    salesSeries3.Points.AddXY(saleMonth, totalSales);
                            }
                        }

                        // Add the 3 months' sales series to the chart
                        chart1.Series.Add(salesSeries1);
                        chart1.Series.Add(salesSeries2);
                        chart1.Series.Add(salesSeries3);

                        // Adjust the spacing for each series
                        salesSeries1["PointWidth"] = "0.3";  // Adjust bar width (less than 1 makes them thinner)
                        salesSeries1["PointSpacing"] = "0.7"; // Increase space between bars of the series
                        salesSeries1["GapWidth"] = "50"; // Set gap width between series
                        salesSeries2["PointWidth"] = "0.3";  // Adjust bar width for second series
                        salesSeries2["PointSpacing"] = "0.7"; // Same as above
                        salesSeries2["GapWidth"] = "50"; // Set gap width for second series
                        salesSeries3["PointWidth"] = "0.3";  // Adjust bar width for third series
                        salesSeries3["PointSpacing"] = "0.7"; // Same as above
                        salesSeries3["GapWidth"] = "50"; // Set gap width for third series

                        // Add labels for each sales data point (TotalSales) on top of the bars
                        foreach (var series in chart1.Series)
                        {
                            foreach (var point in series.Points)
                            {
                                point.Label = point.YValues[0].ToString("C");  // Format as currency
                                point.LabelForeColor = Color.Black;  // Set the color of the label text
                                point.LabelBackColor = Color.Transparent; // Make background transparent
                                point.LabelBorderWidth = 0;  // No border around label
                                point.LabelAngle = 0;  // No rotation for the label
                            }
                        }

                        // Predict next month's sales
                        if (rowCount >= 3)
                        {
                            // Retrieve the last three months' sales
                            double sales1 = Convert.ToDouble(salesData.Rows[rowCount - 3]["TotalSales"]);
                            double sales2 = Convert.ToDouble(salesData.Rows[rowCount - 2]["TotalSales"]);
                            double sales3 = Convert.ToDouble(salesData.Rows[rowCount - 1]["TotalSales"]);

                            // Calculate growth rates
                            double growthRate1 = (sales2 - sales1) / sales1;
                            double growthRate2 = (sales3 - sales2) / sales2;

                            // Average growth rate
                            double avgGrowthRate = (growthRate1 + growthRate2) / 2;

                            // Predict sales for the next month
                            double predictedSales = sales3 * (1 + avgGrowthRate);
                            string nextMonth = DateTime.Parse(salesData.Rows[rowCount - 1]["SaleMonth"].ToString())
                                               .AddMonths(1).ToString("yyyy-MM");

                            // Add predicted sales as a separate series in red color
                            Series predictedSeries = new Series("Predicted Sales")
                            {
                                ChartType = SeriesChartType.Column,
                                XValueType = ChartValueType.String,
                                YValueType = ChartValueType.Double,
                                Color = Color.Red
                            };

                            predictedSeries.Points.AddXY(nextMonth, predictedSales);
                            predictedSeries.Points[0].Label = $"Predicted: {predictedSales:C}";

                            // Add predicted sales series to the chart
                            chart1.Series.Add(predictedSeries);
                        }
                        else
                        {
                            MessageBox.Show("Not enough data to make a prediction. Please ensure at least 3 months' data is available.");
                        }

                        // Customize chart appearance
                        chart1.ChartAreas[0].AxisX.Title = "Months";
                        chart1.ChartAreas[0].AxisY.Title = "Total Sales (USD)";
                        chart1.Titles.Clear();
                        chart1.Titles.Add("Sales Prediction Chart - Monthly Sales Analysis");

                        // Set X-axis label formatting for month-year
                        chart1.ChartAreas[0].AxisX.Interval = 1; // Set the interval for the X-axis
                        chart1.ChartAreas[0].AxisX.LabelStyle.Angle = 45; // Rotate labels for readability
                        chart1.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Arial", 10, FontStyle.Regular);

                        // Adjust spacing between bars: Increase gap width
                        foreach (var series in chart1.Series)
                        {
                            series["PointWidth"] = "0.3";  // Adjust bar width (less than 1 makes them thinner)
                            series["PointSpacing"] = "0.7"; // Increase space between bars of each series
                            series["GapWidth"] = "50"; // Set gap width between series
                        }

                        // Set unique X labels for each series by adding a small offset
                        int offset = 0;
                        foreach (var series in chart1.Series)
                        {
                            foreach (var point in series.Points)
                            {
                                point.SetCustomProperty("PointWidth", "0.3");
                                point.SetCustomProperty("PointSpacing", "0.7");
                                point.SetCustomProperty("GapWidth", "50");

                                // Offset the X values slightly for each series
                                point.XValue += offset;
                            }
                            offset += 1; // Increment the offset for the next series
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void LoadSalesDataWithPieChart()
        {
            DateTime lastMonthStart = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(-1);
            DateTime lastMonthEnd = lastMonthStart.AddMonths(1).AddDays(-1);

            DateTime prevMonthStart = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(-2);
            DateTime prevMonthEnd = prevMonthStart.AddMonths(1).AddDays(-1);

            string query = @"
    SELECT 
        model,
        SUM(CASE WHEN transaction_date >= @LastMonthStart AND transaction_date <= @LastMonthEnd THEN quantity ELSE 0 END) AS LastMonthQuantity,
        SUM(CASE WHEN transaction_date >= @PrevMonthStart AND transaction_date <= @PrevMonthEnd THEN quantity ELSE 0 END) AS PrevMonthQuantity
    FROM Sales_New
    WHERE transaction_date >= @PrevMonthStart
    GROUP BY model
    ORDER BY model";

            try
            {
                using (SqlConnection conn = new SqlConnection("Data Source=VIVOBOOK15\\SQLEXPRESS;Initial Catalog=Mobile_Pos_System;Integrated Security=True;Encrypt=False"))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@LastMonthStart", lastMonthStart);
                        cmd.Parameters.AddWithValue("@LastMonthEnd", lastMonthEnd);
                        cmd.Parameters.AddWithValue("@PrevMonthStart", prevMonthStart);
                        cmd.Parameters.AddWithValue("@PrevMonthEnd", prevMonthEnd);

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable salesData = new DataTable();
                        adapter.Fill(salesData);

                        if (salesData.Rows.Count == 0)
                        {
                            MessageBox.Show("No sales data available for the last two months.");
                            return;
                        }

                        chart2.Series.Clear();

                        Series pieSeries = new Series("Item Needs")
                        {
                            ChartType = SeriesChartType.Pie,
                            XValueType = ChartValueType.String,
                            YValueType = ChartValueType.Int32,
                            IsValueShownAsLabel = true
                        };

                        int grandTotal = 0;

                        // Check if previous month has any data
                        bool prevMonthExists = false;
                        foreach (DataRow row in salesData.Rows)
                        {
                            int prevMonthQuantity = Convert.ToInt32(row["PrevMonthQuantity"]);
                            if (prevMonthQuantity > 0)
                            {
                                prevMonthExists = true;
                                break;
                            }
                        }

                        // Calculate total quantity (grandTotal) dynamically
                        foreach (DataRow row in salesData.Rows)
                        {
                            int lastMonthQuantity = Convert.ToInt32(row["LastMonthQuantity"]);
                            int prevMonthQuantity = prevMonthExists ? Convert.ToInt32(row["PrevMonthQuantity"]) : 0;
                            grandTotal += lastMonthQuantity + prevMonthQuantity;
                        }

                        // Add data points to the pie chart with correct percentages
                        foreach (DataRow row in salesData.Rows)
                        {
                            string model = row["model"].ToString();
                            int lastMonthQuantity = Convert.ToInt32(row["LastMonthQuantity"]);
                            int prevMonthQuantity = prevMonthExists ? Convert.ToInt32(row["PrevMonthQuantity"]) : 0;

                            int totalQuantitySold = lastMonthQuantity + prevMonthQuantity;

                            if (totalQuantitySold > 0)
                            {
                                // Add data point
                                var point = new DataPoint
                                {
                                    AxisLabel = model,
                                    YValues = new double[] { totalQuantitySold }
                                };

                                // Calculate and set the percentage label
                                double percentage = (double)totalQuantitySold / grandTotal * 100;
                                point.Label = $"{model} - {percentage:0.00}%";

                                pieSeries.Points.Add(point);
                            }
                        }

                        chart2.Series.Add(pieSeries);

                        if (chart2.ChartAreas.Count == 0)
                        {
                            chart2.ChartAreas.Add(new ChartArea());
                        }

                        chart2.Titles.Clear();
                        chart2.Titles.Add("Items Needed for Next Month Based on Sales Data");

                        chart2.ChartAreas[0].Area3DStyle.Enable3D = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }



        private void Prediction_Load(object sender, EventArgs e)
        {
            // Call the method to load chart data
            LoadSalesData();
            LoadSalesDataWithPieChart();
            loaduser();
            LoadDailyProfit();



        }

        private void loaduser()
        {

            using (SqlConnection con = new SqlConnection("Data Source=VIVOBOOK15\\SQLEXPRESS;Initial Catalog=Mobile_Pos_System;Integrated Security=True;Encrypt=False"))
            {
                con.Open();


                // 2. Retrieve total number of users
                SqlCommand cmdTotalUsers = new SqlCommand("SELECT COUNT(*) AS UserCount FROM Users", con);
                int userCount = (int)cmdTotalUsers.ExecuteScalar();

                // Display user count on a label
                txtUser.Text = userCount.ToString();


            }
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

                        // Check if the result is null or DBNull
                        if (result == DBNull.Value || result == null)
                        {
                            MessageBox.Show("No profit recorded for today.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtProfit.Text = "LKR 0.00"; // Default if no profit is recorded for today
                        }
                        else
                        {
                            decimal todayProfit = Convert.ToDecimal(result);
                            txtProfit.Text = "LKR " + todayProfit.ToString("N2"); // Display as LKR 1,234.56
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
