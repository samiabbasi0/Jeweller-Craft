using System;
using System.Windows;
using System.Data.SqlClient;

namespace Page_Navigation_App.View
{
    public partial class Window1 : Window
    {
        private readonly Shipments parentShipments;
        string connectionString = @"Data Source=DESKTOP-01A3CCI\SQLEXPRESS;Initial Catalog=jewelry;Integrated Security=True";



        public Window1(Shipments parentShipments)
        {
            InitializeComponent();
            this.parentShipments = parentShipments;

            // Set DataContext to the newItem to bind the controls to it
            DataContext = new Shipments.ShipmentItem();
            HideSellingControls();
        }

        private void HideSellingControls()
        {
            txtSellingRate.Visibility = Visibility.Collapsed;
            datePickerSellingDate.Visibility = Visibility.Collapsed;
        }

        private void ShowSellingControls()
        {
            txtSellingRate.Visibility = Visibility.Visible;
            datePickerSellingDate.Visibility = Visibility.Visible;
        }

        private void Button_Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Validate user input
                if (!int.TryParse(txtInvestmentNumber.Text, out int investmentNo) || investmentNo < 0)
                {
                    MessageBox.Show("Please enter a valid investment number.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtCustomerName.Text))
                {
                    MessageBox.Show("Please enter customer name.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (!DateTime.TryParse(datePicker.Text, out DateTime buyingDate))
                {
                    MessageBox.Show("Please select a valid buying date.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (!float.TryParse(txtBuyingRate.Text, out float buyingRate) || buyingRate < 0)
                {
                    MessageBox.Show("Please enter a valid buying rate.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (!float.TryParse(txtWeight.Text, out float weight) || weight < 0)
                {
                    MessageBox.Show("Please enter a valid weight.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                string status = chkCompleted.IsChecked == true ? "Completed" : "Pending";
                DateTime? sellingDate = null;
                float? sellingRate = null;

                if (chkCompleted.IsChecked == true)
                {
                    // Show and validate selling rate
                    if (!float.TryParse(txtSellingRate.Text, out float sellingRateValue) || sellingRateValue < 0)
                    {
                        MessageBox.Show("Please enter a valid selling rate.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    sellingRate = sellingRateValue;
                    sellingDate = datePickerSellingDate.SelectedDate;
                }

                // Insert data into the database
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO investments (investment_no, buying_date, buying_rate, weight, status, selling_date, selling_rate, customer_id) " +
                                   "VALUES (@InvestmentNo, @BuyingDate, @BuyingRate, @Weight, @Status, @SellingDate, @SellingRate, @CustomerId)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@InvestmentNo", investmentNo);
                        command.Parameters.AddWithValue("@BuyingDate", buyingDate);
                        command.Parameters.AddWithValue("@BuyingRate", buyingRate);
                        command.Parameters.AddWithValue("@Weight", weight);
                        command.Parameters.AddWithValue("@Status", status);
                        command.Parameters.AddWithValue("@SellingDate", (object)sellingDate ?? DBNull.Value);
                        command.Parameters.AddWithValue("@SellingRate", (object)sellingRate ?? DBNull.Value);
                        command.Parameters.AddWithValue("@CustomerId", txtCustomerName.Text);

                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Data inserted successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        else
                        {
                            MessageBox.Show("Failed to insert data.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }

                // Close the Window
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void chkCompleted_Checked(object sender, RoutedEventArgs e)
        {
            ShowSellingControls();
        }

        private void chkCompleted_Unchecked(object sender, RoutedEventArgs e)
        {
            HideSellingControls();
        }
    }
}
