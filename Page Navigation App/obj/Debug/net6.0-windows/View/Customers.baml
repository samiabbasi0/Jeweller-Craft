   M S B A M L   `   `   `  ����N  JPage Navigation App, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:Page_Navigation_App.ViewModelPage_Navigation_App.ViewModel  5      (    "Page_Navigation_App.View.Customers   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :vm+clr-namespace:Page_Navigation_App.ViewModel     5         
Page_Style#��[  5
        � DataContext  5      .  (Page_Navigation_App.ViewModel.CustomerVM  5   
   .��5      � $��15q�6   ���#909ea9.+�5   
   �� $��	Customers��6   $
��Left=�6$   $��	10,70,0,0q�6?   $	��Top=�6R   $	��138��6j   $��22(�6v   $��Century Schoolbook)�6�   $
��Bold"�6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dataGrid��5      $��10,175,10,97q�6%   $��12(�5         AutoGenerateColumns$ False��5         GridLinesVisibility$	 All=�5         HeadersVisibility$ Column=�5         CanUserResizeColumns$
 True��5         CanUserResizeRows$ False��5         CanUserReorderColumns$ False��5         SelectionMode$ Single=�5      	   SelectionUnit$	 CellOrRowHeader=�5      ���	#FFF8F6E3
���   ����	#FF020202
   AlternatingRowBackground
 �	#FFBDECEF   Columns 5!      0  *System.Windows.Controls.DataGridTextColumn  5#      ,  &System.Windows.Controls.DataGridColumn   Header$
 Name��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6L      
FontWeight$ Normal"�6X   1  +System.Windows.Controls.DataGridBoundColumn   Binding 63   �� *Name+6X     5$      $ Customer ID��6%   $ 90 6Y    6:   �� *
CustomerID+6Y     5%      $ Phone Number��6%   $	 110 6[    6;   �� *PhoneNumber+6[     5&      $ Email��6%   $	 120 6N    64   �� *Email+6N     5'      $ CNIC Number��6%   $ * 6Y    6:   �� *
CNICNumber+6Y   5)      �� 5,   
   -   5        $��Add Customer��5,      $
��Left=�6(   $��477,133,0,0q�6C   $	��Top=�6X   $��30��6p   $	��105��6|   
��� ���$��0q�6�   
������ $��	Bodoni MT)�6�   $��14(�6�   ��5-      �� 5.       �� 
TargetType" ��6"   .R�5/      � .+�50      A�  A�Name$ ellipse��6"   #��z��63   �� 51      $��Center=�6+   $��Center=�6H   52       �� Triggers 53      P� 54       P� Property �@J�IsMouseOver P� Value$
 True��69   . �55      ��  �� 
TargetName$ ellipse��6%    �� Property � �� �� Value
 �����6J   56      58      5:      �� 5=   
   -   5        $��Clear Search��5=      $
��Left=�6(   $��256,135,0,0q�6C   $	��Top=�6X   $	��111��6p   
��� ���$��0q�6�   
������ $��26��6�   $��	Bodoni MT)�6�   $��14(�6�   ��5>      �� 5?      " ��6"   .R�5@      � .+�5A      A� $ ellipse��6"   #��z��63   �� 5B      $��Center=�6+   $��Center=�6H   5C       5D      P� 5E       �@J�IsMouseOver$
 True��69   . �5F      �� $ ellipse��6%    � ��
 �����6J   5G      5I      5K      �� 5N   
   -   5         ��Name$ 	txtSearch��5N      $
��Left=�6%   $��139,135,0,0q�6@    �� TextWrapping$
 Wrap=�6U   $	��Top=�6i   $	��112��6�   ���	#FFF9F6E4$��27��6�   �� 5O   
   $��Enter Customer Name:��6   $
��Left=�6/   $��
10,135,0,0q�6J   $	��Top=�6^   $	��126��6v   $��27��6�   ���	#FFE2D36E6�   5P      5Q      