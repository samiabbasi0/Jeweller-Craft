   M S B A M L   `   `   `  ����N  JPage Navigation App, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:Page_Navigation_App.ViewModelPage_Navigation_App.ViewModel  5      '    !Page_Navigation_App.View.Products   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :vm+clr-namespace:Page_Navigation_App.ViewModel     5      -   5          >�Name$  inventory_grid��5         
Page_Style#��[  5
       � DataContext 5      -  'Page_Navigation_App.ViewModel.ProductVM  5   
   .��5      � $��15q�6   ���#909ea9.+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ datagrid��5      $��18,163,18,94q�5      $��12(�5         AutoGenerateColumns$ False��5         GridLinesVisibility$	 All=�5         HeadersVisibility$ Column=�5         CanUserResizeColumns$
 True��5         CanUserResizeRows$ False��5         CanUserReorderColumns$ False��5      	   SelectionMode$	 Single=�5      
   SelectionUnit$
 CellOrRowHeader=�5      ���	#FFF8F6E3
���   ����	#FF020202   AlternatingRowBackground �	#FFBDECEF   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Category��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 67   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6A   �� *Name+  5      $ 
Tag Number��6%   $ * 69    6C   �� *	TagNumber+  5       $ Weight��6%   $ * 65    6?   �� *Weight+  5!      $ Labour Cost��6%   $ * 6:    6D   �� *
LabourCost+  5"      $ Quantity��6%   $ * 67    6A   �� *
Quantity+5$      �� 5%   
   $��	Inventory��6   $
��Left=�6$   $��	18,39,0,0q�6?   $	��Top=�6R   $
��Bold"�6j   $��22(�6|   $��	Bodoni MT)�6�   �� 5&   
   -   5        $��Add Item��5&      $
��Left=�6$   $��479,124,0,0q�6?   $	��Top=�6T   $��28��6l   $��95��6x   
��� ���$
��Bold"�6�   $��Century Schoolbook)�6�   ��5'      �� 5(       �� 
TargetType" ��6"   .R�5)      ��  ��Name$ border��6    �� CornerRadius$ 15��6-   #��z��6?   ._�5*      �� $��Center=�6+   $��Center=�6H   5+       �� Triggers 5,      P� 5-       P� Property �@J�IsMouseOver P� Value$
 True��69   . �5.      ��  �� 
TargetName$ border��6%    �� Property � �� �� Value
 �����6O   5/      51      53      �� 55   
    �� Orientation$ 
Horizontal=�6   ���	#FFEFE5BF$��18,89,283,451q�6F    J� RenderTransformOrigin$ 0.5,0.5&�6]   z�56      V� 57      .~�58      �� �� 59       �� AngleY$ 0Q�6$   �� 5:      T� 5;       T� Y$ 0Q�6)   5<      .+�5>      �� $��Enter Category:��6   ���	#FFC6D29A$��0,0,5,0q�6E   $��93��6V   $	��1,5q�6a   �� 5?      -   5         ��Name$ 	txtSearch��5?      $	��104��6)   ���#EEEEEE$��0,0,5,0q�6J   6[   �� 5@      -   5        $��Search��5@      ���#EEEEEE$��84��6S   5A      �� 5B   
   -   5        $��Clear Search��5B      $
��Left=�6(   $��
18,124,0,0q�6C   $	��Top=�6W   $��28��6o   $	��106��6{   
��� ���$
��Bold"�6�   $��Century Schoolbook)�6�   ��5C      �� 5D      " ��6"   .R�5E      �� $ border��6   $ 15��6-   #��z��6?   ._�5F      �� $��Center=�6+   $��Center=�6H   5G       5H      P� 5I       �@J�IsMouseOver$
 True��69   . �5J      �� $ border��6%    � ��
 �����6O   5K      5M      5O      5R      5S      