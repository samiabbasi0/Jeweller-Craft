   M S B A M L   `   `   `  ����N  JPage Navigation App, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:Page_Navigation_App.ViewModelPage_Navigation_App.ViewModel  5      (    "Page_Navigation_App.View.Shipments   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :vm+clr-namespace:Page_Navigation_App.ViewModel     5      ���#909ea9   
Page_Style#��[  5        � DataContext  5      .  (Page_Navigation_App.ViewModel.ShipmentVM  5   
   .��5      � $��12q�6   .+�5   
   ��  �� CornerRadius$ 29��6   
��� ���$
��Left=�65   $��
450,99,0,0q�6P   $	��Top=�6d   $��28��6|   $	��138��6�   ._�5      �� -   5        $��+  New Investment��5      $��Stretch=�6F   $��Stretch=�6d   #��[" �6�   $��	Bodoni MT)�6�   $��14(�6�   $
��Bold"�6�   ��5      �� 5       �� 
TargetType" ��6&   .R�5      �� #��z��6!   $ 29��6K   ._�5      �� $��Center=�6/   $��Center=�6L   5       �� Triggers 5      P� 5       P� Property �@J�IsMouseOver P� Value$
 True��6=   . �5   "   ��  �� Property � �� �� Value
 �����6?   5      5      5      5       &   System.Windows.Controls.DataGrid  5"   
   -   5          Name$ dataGrid��5"      $��10,132,10,144q�5$      $��12(�5%      	   AutoGenerateColumns$	 False��5&      
   GridLinesVisibility$	
 All=�5'         HeadersVisibility$ Column=�5(         CanUserResizeColumns$
 True��5)         CanUserResizeRows$ False��5*         CanUserReorderColumns$ False��5+         SelectionMode$ Single=�5,         SelectionUnit$ CellOrRowHeader=�5-      ���	#FFF8F6E3
���   ����	#FF020202   AlternatingRowBackground �	#FFBDECEF   Columns 5/      0  *System.Windows.Controls.DataGridTextColumn  50      ,  &System.Windows.Controls.DataGridColumn   Header$ Investment No��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6<   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6H   �� *InvestmentNo+  51      $ Buying Date��6%   $	 100 6:    6F   �� *
BuyingDate+ �� StringFormat$ d��  52      $ Buying Rate��6%   $	 100 6:    6F   �� *
BuyingRate+  53      $ Weight��6%   $	 100 65    6A   �� *Weight+  54      $ Status��6%   $	 100 65    6A   �� *Status+  55      $ Selling Date��6%   $	 100 6;    6G   �� *SellingDate+$ d��  56      $ Selling Rate��6%   $	 100 6;    6G   �� *SellingRate+  57      $ Customer ID��6%   $	 100 6:    6F   �� *
CustomerId+59      �� 5:   
   $��Investments��6   $
��Left=�6&   $��	10,38,0,0q�6A   $	��Top=�6T   $	��153��6l   $
��Bold"�6x   $��Century Schoolbook)�6�   $��22(�6�   �� 5;   
   -   5         ��Name$ CompletedCheckBox��5;      $��	Completed��6.   $
��Left=�6B   $��	10,87,0,0q�6]   $	��Top=�6p   ���	#FFF6FFC1 J� RenderTransformOrigin$ 0.497,0.066&�6�   $��16��6�   $��85��6�   ���	#FFB9AF46
���   �$��	Bodoni MT)�6  $��14(�6  6E  �� 5<   
   -   5        $ PendingCheckBox��5<      $��Pending��6,   $
��Left=�6>   $��
10,108,0,0q�6Y   $	��Top=�6m   ���	#FFF6FFC1$��93��6�   ���	#FFB9AF46
���   �$��	Bodoni MT)�6�   $��14(�6�   6  5=      5>      