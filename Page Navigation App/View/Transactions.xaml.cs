using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows;
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Page_Navigation_App.View
{
    public partial class Transactions : UserControl
    {
        private List<Transaction> originalTransactions;
        string connectionString = @"Data Source=DESKTOP-01A3CCI\SQLEXPRESS;Initial Catalog=jewelry;Integrated Security=True";

        public Transactions()
        {
            InitializeComponent();

            // Initialize originalTransactions and DataContext properly
            originalTransactions = new List<Transaction>();
            DataContext = new SampleData { Transactions = originalTransactions };

            // Load data from the database asynchronously
            LoadDatafromDatabase();
        }

        public async void LoadDatafromDatabase()
        {
            try
            {
                var transactions = await Task.Run(() =>
                {
                    List<Transaction> transactionsList = new List<Transaction>();

                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        string query = "SELECT orders.order_date, transactions.order_id, transactions.tag_number, products.weight, transactions.gold_rate, products.labour_cost, transactions.quantity, transactions.price FROM transactions INNER JOIN products ON transactions.tag_number = products.tag_number INNER JOIN orders ON transactions.order_id = orders.order_id";
                        con.Open();
                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            SqlDataReader reader = cmd.ExecuteReader();
                            while (reader.Read())
                            {
                                transactionsList.Add(new Transaction
                                {
                                    OrderId = (int)reader["order_id"],
                                    Date = (DateTime)reader["order_date"],
                                    TagNumber = reader["tag_number"].ToString(),
                                    Weight = Convert.ToSingle(reader["weight"]),
                                    GoldRate = Convert.ToSingle(reader["gold_rate"]),
                                    LabourCost = Convert.ToSingle(reader["labour_cost"]),
                                    Quantity = (int)reader["quantity"],
                                    Price = Convert.ToSingle(reader["price"])
                                });
                            }
                        }
                    }
 
                    return transactionsList;
                });

                // Update the UI with the loaded data
                Dispatcher.Invoke(() =>
                {
                    originalTransactions.Clear();
                    originalTransactions.AddRange(transactions);
                    datagrid.ItemsSource = null; // Reset the ItemsSource to avoid inconsistency
                    datagrid.ItemsSource = originalTransactions;
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
                var filteredTransactions = originalTransactions
                                                         .Where(t => t.Date >= startDate && t.Date <= endDate)
                                                         .ToList();
                datagrid.ItemsSource = null; // Reset the ItemsSource to avoid inconsistency
                datagrid.ItemsSource = filteredTransactions;
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
            datagrid.ItemsSource = originalTransactions; // Reset to display all records
        }
    }

    // Define the Transaction class
    public class Transaction
    {
        public int OrderId { get; set; }
        public string TagNumber { get; set; }
        public DateTime Date { get; set; }
        public float LabourCost { get; set; }
        public float Weight { get; set; }
        public float GoldRate { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
    }

    // Define the SampleData class
    public class SampleData
    {
        public List<Transaction> Transactions { get; set; }
    }
}
