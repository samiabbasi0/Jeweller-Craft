using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Page_Navigation_App.View
{
    public partial class Shipments : UserControl
    {
        private readonly ObservableCollection<ShipmentItem> _shipmentItems = new ObservableCollection<ShipmentItem>();
        private readonly string _connectionString = @"Data Source=DESKTOP-01A3CCI\SQLEXPRESS;Initial Catalog=jewelry;Integrated Security=True";

        public Shipments()
        {
            InitializeComponent();
            LoadDataFromDatabase();
        }

        private void LoadDataFromDatabase()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    con.Open();
                    string query = "SELECT investment_no, buying_date, buying_rate, weight, status, selling_date, selling_rate, customer_id FROM investments";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            _shipmentItems.Add(new ShipmentItem
                            {
                                InvestmentNo = Convert.ToInt32(reader["investment_no"]),
                                BuyingDate = Convert.ToDateTime(reader["buying_date"]),
                                BuyingRate = Convert.ToDecimal(reader["buying_rate"]),
                                Weight = Convert.ToDouble(reader["weight"]),
                                Status = reader["status"].ToString(),
                                SellingDate = reader.IsDBNull(reader.GetOrdinal("selling_date")) ? (DateTime?)null : Convert.ToDateTime(reader["selling_date"]),
                                SellingRate = reader.IsDBNull(reader.GetOrdinal("selling_rate")) ? (decimal?)null : Convert.ToDecimal(reader["selling_rate"]),
                                CustomerId = reader.IsDBNull(reader.GetOrdinal("customer_id")) ? (int?)null : Convert.ToInt32(reader["customer_id"])
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            dataGrid.ItemsSource = _shipmentItems;
        }

        private void FilterData()
        {
            string statusQuery = GetStatusQuery();

            try
            {
                _shipmentItems.Clear();
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    con.Open();
                    string query = $"SELECT investment_no, buying_date, buying_rate, weight, status, selling_date, selling_rate, customer_id FROM investments WHERE 1=1{statusQuery}";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            _shipmentItems.Add(new ShipmentItem
                            {
                                InvestmentNo = Convert.ToInt32(reader["investment_no"]),
                                BuyingDate = Convert.ToDateTime(reader["buying_date"]),
                                BuyingRate = Convert.ToDecimal(reader["buying_rate"]),
                                Weight = Convert.ToDouble(reader["weight"]),
                                Status = reader["status"].ToString(),
                                SellingDate = reader.IsDBNull(reader.GetOrdinal("selling_date")) ? (DateTime?)null : Convert.ToDateTime(reader["selling_date"]),
                                SellingRate = reader.IsDBNull(reader.GetOrdinal("selling_rate")) ? (decimal?)null : Convert.ToDecimal(reader["selling_rate"]),
                                CustomerId = reader.IsDBNull(reader.GetOrdinal("customer_id")) ? (int?)null : Convert.ToInt32(reader["customer_id"])
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            RefreshDataGrid();
        }

        private string GetStatusQuery()
        {
            string statusQuery = "";
            if (CompletedCheckBox.IsChecked == true && PendingCheckBox.IsChecked == true)
            {
                statusQuery = "";
            }
            else if (CompletedCheckBox.IsChecked == true)
            {
                statusQuery = " AND status = 'Completed'";
            }
            else if (PendingCheckBox.IsChecked == true)
            {
                statusQuery = " AND status = 'Pending'";
            }
            return statusQuery;
        }

        private void RefreshDataGrid()
        {
            ICollectionView view = CollectionViewSource.GetDefaultView(dataGrid.ItemsSource);
            view?.Refresh();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            FilterData();
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            FilterData();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Open the Window1 form
            Window1 window1 = new Window1(this); // Pass 'this' as the argument
            window1.ShowDialog();
        }

        public class ShipmentItem
        {
            public int InvestmentNo { get; set; }
            public DateTime BuyingDate { get; set; }
            public decimal BuyingRate { get; set; }
            public double Weight { get; set; }
            public string Status { get; set; }
            public DateTime? SellingDate { get; set; }
            public decimal? SellingRate { get; set; }
            public int? CustomerId { get; set; }
        }
    }
}
