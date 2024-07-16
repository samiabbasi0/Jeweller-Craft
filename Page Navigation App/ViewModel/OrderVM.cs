using System;
using System.Collections.Generic;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;

namespace Page_Navigation_App.ViewModel
{
    public class OrderVM
    {
        public OrderVM()
        {
            // Initialize sample data
            InitializeSampleData();
        }

        // Sample data properties
        public SeriesCollection SalesByCategory { get; set; }
        public Func<double, string> SalesByCategoryLabel { get; set; }
        public List<string> CategoryLabels { get; set; }

        // Initialize sample data method
        private void InitializeSampleData()
        {
            // Sample category labels
            CategoryLabels = new List<string> { "Category A", "Category B", "Category C", "Category D", "Category E" };

            // Sample sales data for each category
            var salesData = new ChartValues<ObservableValue>
            {
                new ObservableValue(1000),
                new ObservableValue(1500),
                new ObservableValue(800),
                new ObservableValue(2000),
                new ObservableValue(1200)
            };

            // Populate the SeriesCollection with the sales data
            SalesByCategory = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Sales",
                    Values = salesData
                }
            };

            // Function to format labels
            SalesByCategoryLabel = value => value.ToString("N0");
        }
    }
}
