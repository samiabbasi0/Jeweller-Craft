using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using LiveCharts;
using LiveCharts.Wpf;
using System.Collections.Generic;

namespace Page_Navigation_App.View
{
    public partial class Orders : UserControl, INotifyPropertyChanged
    {
        private string connectionString = @"Data Source=DESKTOP-01A3CCI\SQLEXPRESS;Initial Catalog=jewelry;Integrated Security=True";

        private DateTime? _fromDate;
        public DateTime? FromDate
        {
            get { return _fromDate; }
            set
            {
                _fromDate = value;
                OnPropertyChanged(nameof(FromDate));
            }
        }

        private DateTime? _toDate;
        public DateTime? ToDate
        {
            get { return _toDate; }
            set
            {
                _toDate = value;
                OnPropertyChanged(nameof(ToDate));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public Orders()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void GenerateReport_Click(object sender, RoutedEventArgs e)
        {
            if (FromDate == null || ToDate == null)
            {
                MessageBox.Show("Please select both From Date and To Date.");
                return;
            }

            LoadTopCustomers();
            LoadBestSellingProducts();
            LoadStatistics();
            LoadCategoryChart();
        }

        private void LoadTopCustomers()
        {
            string query = @"
                SELECT TOP 5 orders.customer_id, customers.customer_name, SUM(orders.total_price) AS Total_sales
                FROM orders 
                INNER JOIN customers ON customers.customer_id = orders.customer_id
                WHERE orders.order_date BETWEEN @FromDate AND @ToDate
                GROUP BY orders.customer_id, customers.customer_name
                ORDER BY Total_sales DESC";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@FromDate", FromDate.Value);
                cmd.Parameters.AddWithValue("@ToDate", ToDate.Value);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                top_customers.ItemsSource = dt.DefaultView;
            }
        }

        private void LoadBestSellingProducts()
        {
            string query = @"
                SELECT TOP 5 transactions.tag_number, products.category, SUM(transactions.quantity) AS Quantity
                FROM transactions
                INNER JOIN orders ON orders.order_id = transactions.order_id
                INNER JOIN products ON transactions.tag_number = products.tag_number
                WHERE orders.order_date BETWEEN @FromDate AND @ToDate
                GROUP BY transactions.tag_number, products.category
                ORDER BY Quantity DESC";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@FromDate", FromDate.Value);
                cmd.Parameters.AddWithValue("@ToDate", ToDate.Value);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                top_products.ItemsSource = dt.DefaultView;
            }
        }

        private void LoadStatistics()
        {
            LoadTotalOrders();
            LoadTotalSales();
            LoadInvestmentsMade();
            LoadInvestmentsReturned();
        }

        private void LoadTotalOrders()
        {
            string query = @"
                SELECT COUNT(order_id) AS Total_Orders
                FROM orders
                WHERE order_date BETWEEN @FromDate AND @ToDate";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@FromDate", FromDate.Value);
                cmd.Parameters.AddWithValue("@ToDate", ToDate.Value);

                conn.Open();
                int totalOrders = (int)cmd.ExecuteScalar();
                conn.Close();

                txtTotalOrders.Text = $"Total Orders: {totalOrders}";
            }
        }

        private void LoadTotalSales()
        {
            string query = @"
        SELECT SUM(total_price) AS Total_Price
        FROM orders
        WHERE order_date BETWEEN @FromDate AND @ToDate";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@FromDate", FromDate.Value);
                cmd.Parameters.AddWithValue("@ToDate", ToDate.Value);

                conn.Open();
                object result = cmd.ExecuteScalar();
                conn.Close();

                if (result != DBNull.Value)
                {
                    decimal totalSales = Convert.ToDecimal(result);
                    txtTotalSales.Text = $"Total Sales: PKR {totalSales}";
                }
                else
                {
                    txtTotalSales.Text = "Total Sales: PKR 0";
                }
            }
        }

        private void LoadInvestmentsMade()
        {
            string query = @"
                SELECT COUNT(investment_no)
                FROM investments
                WHERE buying_date BETWEEN @FromDate AND @ToDate";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@FromDate", FromDate.Value);
                cmd.Parameters.AddWithValue("@ToDate", ToDate.Value);

                conn.Open();
                int investmentsMade = (int)cmd.ExecuteScalar();
                conn.Close();

                txtInvestmentsMade.Text = $"Investments Made: {investmentsMade}";
            }
        }

        private void LoadInvestmentsReturned()
        {
            string query = @"
                SELECT COUNT(investment_no)
                FROM investments
                WHERE selling_date BETWEEN @FromDate AND @ToDate";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@FromDate", FromDate.Value);
                cmd.Parameters.AddWithValue("@ToDate", ToDate.Value);

                conn.Open();
                int investmentsReturned = (int)cmd.ExecuteScalar();
                conn.Close();

                txtInvestmentsReturned.Text = $"Investments Returned: {investmentsReturned}";
            }
        }

        private void LoadCategoryChart()
        {
            string query = @"
                SELECT products.category AS Category, SUM(transactions.quantity) AS Total_Sales
                FROM products
                INNER JOIN transactions ON products.tag_number = transactions.tag_number
                INNER JOIN orders ON transactions.order_id = orders.order_id
                WHERE orders.order_date BETWEEN @startDate AND @endDate
                GROUP BY products.category";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@startDate", FromDate.Value);
                cmd.Parameters.AddWithValue("@endDate", ToDate.Value);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                var categories = new List<string>();
                var values = new ChartValues<int>();

                foreach (DataRow row in dt.Rows)
                {
                    categories.Add(row["Category"].ToString());
                    values.Add(Convert.ToInt32(row["Total_Sales"]));
                }

                if (categoryChart == null)
                {
                    MessageBox.Show("Category chart is not initialized properly.");
                    return;
                }

                if (categoryChart.Series == null)
                {
                    categoryChart.Series = new SeriesCollection();
                }

                categoryChart.Series.Clear();
                categoryChart.Series.Add(new ColumnSeries
                {
                    Title = "Total Sales",
                    Values = values,
                     Fill = System.Windows.Media.Brushes.DarkBlue
                });

                if (categoryChart.AxisX == null)
                {
                    categoryChart.AxisX = new AxesCollection();
                }

                if (categoryChart.AxisX.Count == 0)
                {
                    categoryChart.AxisX.Add(new Axis { Labels = categories });
                }
                else
                {
                    categoryChart.AxisX[0].Labels = categories;
                }
            }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            FromDate = null;
            ToDate = null;
            fromDatePicker.SelectedDate = null;
            toDatePicker.SelectedDate = null;
            top_customers.ItemsSource = null;
            top_products.ItemsSource = null;
            txtTotalOrders.Text = "Total Orders: ";
            txtTotalSales.Text = "Total Sales: ";
            txtInvestmentsMade.Text = "Investments Made: ";
            txtInvestmentsReturned.Text = "Investments Returned: ";
            categoryChart.Series.Clear();
        }

        private void CartesianChart_Loaded(object sender, RoutedEventArgs e)
        {
            // Add any required logic for the CartesianChart here
        }
    }
}
