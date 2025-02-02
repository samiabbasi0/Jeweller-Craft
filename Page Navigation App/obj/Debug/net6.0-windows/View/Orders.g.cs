﻿#pragma checksum "..\..\..\..\View\Orders.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "C7EF40A003660629E44EBC830E4C111FCBC0CB9F"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using LiveCharts.Wpf;
using Page_Navigation_App.ViewModel;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace Page_Navigation_App.View {
    
    
    /// <summary>
    /// Orders
    /// </summary>
    public partial class Orders : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 36 "..\..\..\..\View\Orders.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker fromDatePicker;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\..\View\Orders.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker toDatePicker;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\..\View\Orders.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtTotalOrders;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\..\View\Orders.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtInvestmentsMade;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\..\View\Orders.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtTotalSales;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\..\View\Orders.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtInvestmentsReturned;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\..\View\Orders.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid top_customers;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\..\..\View\Orders.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid top_products;
        
        #line default
        #line hidden
        
        
        #line 98 "..\..\..\..\View\Orders.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal LiveCharts.Wpf.CartesianChart categoryChart;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.1.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Page Navigation App;component/view/orders.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\View\Orders.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.fromDatePicker = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 2:
            this.toDatePicker = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 3:
            
            #line 39 "..\..\..\..\View\Orders.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.GenerateReport_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 40 "..\..\..\..\View\Orders.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Clear_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.txtTotalOrders = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.txtInvestmentsMade = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.txtTotalSales = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 8:
            this.txtInvestmentsReturned = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 9:
            this.top_customers = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 10:
            this.top_products = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 11:
            this.categoryChart = ((LiveCharts.Wpf.CartesianChart)(target));
            
            #line 99 "..\..\..\..\View\Orders.xaml"
            this.categoryChart.Loaded += new System.Windows.RoutedEventHandler(this.CartesianChart_Loaded);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

