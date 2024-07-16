using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Data.SqlClient;
using System.Data;
using static Page_Navigation_App.View.Shipments;
using System.ComponentModel;
using System.Windows.Data;

namespace Page_Navigation_App.View
{
    public partial class Settings : UserControl
    {
        string connectionString = @"Data Source=DESKTOP-01A3CCI\SQLEXPRESS;Initial Catalog=jewelry;Integrated Security=True";
        private List<Order> originalOrders;

        public Settings()
        {
            InitializeComponent();

            // Initialize originalOrders and DataContext properly
            originalOrders = new List<Order>();
            DataContext = new SampleData1 { Orders = originalOrders };

            // Load data from the database asynchronously
            LoadDatafromDatabase();

            // Subscribe to checkbox events
            CompletedCheckBox.Checked += CheckBox_Checked;
            CompletedCheckBox.Unchecked += CheckBox_Unchecked;
            PendingCheckBox.Checked += CheckBox_Checked;
            PendingCheckBox.Unchecked += CheckBox_Unchecked;
        }

        public async void LoadDatafromDatabase()
        {
            try
            {
                var orders = await Task.Run(() =>
                {
                    List<Order> ordersList = new List<Order>();

                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        string query = "SELECT [order_id], [order_date], [customer_id], [total_price], [discount], [advance], [remaining], [status] FROM [jewelry].[dbo].[orders]";
                        con.Open();
                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            SqlDataReader reader = cmd.ExecuteReader();
                            while (reader.Read())
                            {
                                Order order = new Order
                                {
                                    OrderId = (int)reader["order_id"],
                                    OrderDate = (DateTime)reader["order_date"],
                                    CustomerId = (int)reader["customer_id"],
                                    TotalPrice = reader["total_price"] == DBNull.Value ? 0f : Convert.ToSingle(reader["total_price"]),
                                    Discount = reader["discount"] == DBNull.Value ? 0f : Convert.ToSingle(reader["discount"]),
                                    Advance = reader["advance"] == DBNull.Value ? 0f : Convert.ToSingle(reader["advance"]),
                                    Remaining = reader["remaining"] == DBNull.Value ? 0f : Convert.ToSingle(reader["remaining"])
                                };

                                // Check if 'status' field is DBNull or null, assign a default value accordingly
                                if (reader["status"] == DBNull.Value || reader["status"] == null)
                                {
                                    order.Status = "Pending"; // Or any other default value you prefer
                                }
                                else
                                {
                                    order.Status = reader["status"].ToString();
                                }

                                ordersList.Add(order);
                            }
                        }
                    }

                    return ordersList;
                });

                // Update the UI with the loaded data
                Dispatcher.Invoke(() =>
                {
                    originalOrders.Clear();
                    originalOrders.AddRange(orders);
                    datagrid.ItemsSource = null; // Reset the ItemsSource to avoid inconsistency
                    datagrid.ItemsSource = originalOrders;
                });
            }
            catch (Exception ex)
            {
                Dispatcher.Invoke(() =>
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                });
            }
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            DateTime? startDate = dpStartDate.SelectedDate;
            DateTime? endDate = dpEndDate.SelectedDate;

            if (startDate != null && endDate != null && startDate <= endDate)
            {
                var filteredOrders = originalOrders
                                        .Where(o => o.OrderDate >= startDate && o.OrderDate <= endDate)
                                        .ToList();
                datagrid.ItemsSource = null; // Reset the ItemsSource to avoid inconsistency
                datagrid.ItemsSource = filteredOrders;
            }
            else
            {
                MessageBox.Show("Please select valid start and end dates.");
            }
        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            dpStartDate.SelectedDate = null;
            dpEndDate.SelectedDate = null;
            datagrid.ItemsSource = null; // Reset the ItemsSource to avoid inconsistency
            datagrid.ItemsSource = originalOrders; // Reset to display all records
        }

        private void BtnUpdateStatus_Click(object sender, RoutedEventArgs e)
        {
            var selectedOrder = datagrid.SelectedItem as Order;
            if (selectedOrder != null && selectedOrder.Status == "Pending")
            {
                UpdateOrderStatus(selectedOrder.OrderId, "Completed");
                selectedOrder.Status = "Completed";
                datagrid.ItemsSource = null; // Reset the ItemsSource to avoid inconsistency
                datagrid.ItemsSource = originalOrders; // Update UI with new status
            }
            else
            {
                MessageBox.Show("Please select a pending order to update.");
            }
        }

        private void UpdateOrderStatus(int orderId, string newStatus)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = "UPDATE [jewelry].[dbo].[orders] SET [status] = @status WHERE [order_id] = @orderId";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@status", newStatus);
                        cmd.Parameters.AddWithValue("@orderId", orderId);

                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating order status: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void FilterData()
        {
            string statusQuery = GetStatusQuery();

            if (string.IsNullOrEmpty(statusQuery))
            {
                datagrid.ItemsSource = originalOrders;
            }
            else
            {
                var filteredOrders = originalOrders
                    .Where(o => o.Status == statusQuery)
                    .ToList();
                datagrid.ItemsSource = filteredOrders;
            }

            // Force data grid to refresh
            ICollectionView view = CollectionViewSource.GetDefaultView(datagrid.ItemsSource);
            view?.Refresh();
        }

        private string GetStatusQuery()
        {
            if (CompletedCheckBox.IsChecked == true && PendingCheckBox.IsChecked == true)
            {
                return null; // No filter
            }
            else if (CompletedCheckBox.IsChecked == true)
            {
                return "Completed";
            }
            else if (PendingCheckBox.IsChecked == true)
            {
                return "Pending";
            }
            else
            {
                return null; // No filter
            }
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            FilterData();
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            FilterData();
        }
    }

    // Define the Order class
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public int CustomerId { get; set; }
        public float TotalPrice { get; set; }
        public float Discount { get; set; }
        public float Advance { get; set; }
        public float Remaining { get; set; }
        public string Status { get; set; }
    }

    // Define the SampleData class
    public class SampleData1
    {
        public List<Order> Orders { get; set; }
    }
}
