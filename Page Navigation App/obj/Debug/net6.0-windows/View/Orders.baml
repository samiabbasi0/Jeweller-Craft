   M S B A M L   `   `   `  ����U  QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf  5      N JPage Navigation App, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:Page_Navigation_App.ViewModelPage_Navigation_App.ViewModel 5      %   Page_Navigation_App.View.Orders   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Dlvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf     5      :vm+clr-namespace:Page_Navigation_App.ViewModel     5      ���#909ea9   
Page_Style#��[  5        � DataContext  5      +  %Page_Navigation_App.ViewModel.OrderVM  5   
   .��5      � $��15q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   $��78.78��6*   �� 5      $
��Auto �6   $��44��6*   �� 5      $
��Auto �6   $	��172��6*   �� 5      .+�5   
   �� $��Reports��6   $��24(�5      $
��Left=�5      $��	8,48,0,10q�5      $	��108��6'   $��	Bodoni MT)�63   $
��Bold"�6J   �� 5"   
   $��1��6    �� Orientation$ 
Horizontal=�6"   $��Center=�6;   $��	0,10,0,10q�6X   $	��577��6k   .+�5#      �� $��
From Date:��6   $��Center=�6*   $��0 0 10 0q�6E   $��Century Schoolbook)�6W   $
��Bold"�6w   $��71��6�   (  "System.Windows.Controls.DatePicker  5$      -   5          Name$ fromDatePicker��5$      $��0 0 20 0q�6S      SelectedDate 61   �� *
FromDate+6S   �� 5%      $��To Date:��6   $��Center=�6(   $��0 0 10 0q�6C   $
��Bold"�6U   $��Century Schoolbook)�6g     5&      -   5        $ toDatePicker��5&      $��0 0 10 0q�60   $	��103��6b    6B   �� *ToDate+6b   �� 5'      -   5        $��Generate Report��5'      $��0 0 20 0q�6L   $��	Bodoni MT)�6^   $
��Bold"�6u   ���	#FFF1EE96$��89��6�   �� 5(      -   5        $��Clear��5(      $��0 0 20 0q�69   $��	Bodoni MT)�6K   $
��Bold"�6b   ���	#FFF1EE96$��89��6�   5)      �� 5+   
   -   5         ��Name$ txtTotalOrders��5+      $��Total Orders: ��6-    �� Padding$ 8q�6C   $��14(�6O   $
��Bold"�6]   ���	#FFCABE37$��8,7,476,132q�6�   $��	Bodoni MT)�6�   $��2��6�   �� 5,   
   -   5        $ txtInvestmentsMade��5,      $��Investments Made: ��61   $ 8q�6K   $��14(�6W   $
��Bold"�6e   ���	#FFCABE37$��286,7,167,132q�6�   $��	Bodoni MT)�6�   $��2��6�   �� 5-   
   -   5        $ txtTotalSales��5-      $��Total Sales: ��6,   $ 8q�6A   $��14(�6M   $
��Bold"�6[   ���	#FFCABE37$��121,7,311,132q�6�   $��	Bodoni MT)�6�   $��2��6�   �� 5.   
   -   5        $ txtInvestmentsReturned��5.      $��Investments Returned: ��65   $ 8q�6S   $��14(�6_   $
��Bold"�6m   ���	#FFCABE37$��430,7,1,132q�6�   $��	Bodoni MT)�6�   $��2��6�   &   System.Windows.Controls.DataGrid  51   
   -	   5          Name$ top_customers��51      $��2��6*      AutoGenerateColumns$ False��67   $��10,70,309,228q�6S   $��2��6j   $��12(�52      	   GridLinesVisibility$		 All=�53      
   HeadersVisibility$
 Column=�54         CanUserResizeColumns$
 True��55         CanUserResizeRows$ False��56         CanUserReorderColumns$ False��57         SelectionMode$ Extended=�58         SelectionUnit$ FullRow=�59      ���	#FFF8F6E3
���   ����	#FF020202   AlternatingRowBackground �	#FFBDECEF   Columns 5?      0  *System.Windows.Controls.DataGridTextColumn  5@      ,  &System.Windows.Controls.DataGridColumn   Header$ Customer ID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 80 6:   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6E   �� *customer_id+  5A      $ Customer Name��6%   $ 97 6<    6G   �� *customer_name+  5B      $ Total Sales��6%   $ * 6:    6D   �� *Total_sales+5D        5G   
   -
   5        $ top_products��5G      $��2��6)   $��336,70,0,228q�67   $��2��6M   $��12(�5H      $ False��5I      $		 All=�5J      $
 Column=�5K      $
 True��5L      $ False��5M      $ False��5N      $ Extended=�5O      $ FullRow=�5P      ���	#FFF8F6E3
���   ����	#FF020202 �	#FFBDECEF 5V        5W      $ 
Tag Number��6%   $ 85 69    6D   �� *
tag_number+  5X      $ Category��6%   $ 85 67    6B   �� *
category+  5Y      $ Quantity��6%   $ * 67    6A   �� *
Quantity+5[      �� 5^   
   $��Top Customers:��6   $
��Left=�6)   $��	10,44,0,0q�6D   $��2��6W   $	��Top=�6d   $	��171��6|   $��Century Schoolbook)�6�   $
��Bold"�6�   $��24��6�   �� 5_   
   $��Top Products:��6   $
��Left=�6(   $��
333,44,0,0q�6C   $��2��6W   $	��Top=�6d   $	��165��6|   $��Century Schoolbook)�6�   $
��Bold"�6�   $��24��6�   #   LiveCharts.Wpf.CartesianChart  5b   
   -   5          Name$ categoryChart��5b      $��3��64   $��10,46,10,10q�6A   &	    LiveCharts.Wpf.Charts.Base.Chart 	  LegendLocation$ Right=�6V    	  ScrollBarFill
 �  ��$
��Bold"�5c   l    	  Series 6   �� *SalesByCategory+ 	  AxisX 5f      
   LiveCharts.Wpf.Axis
   
  Title$ Category��6    
  
Foreground
 �   � 
  
FontWeight$
 Bold"�6?    
  Labels 6Q   �� *CategoryLabels+ 	  AxisY 5i      
  $ Sales��6   
 �   �$
 Bold"�6<   5j   2   5k      5l      