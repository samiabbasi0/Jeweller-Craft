   M S B A M L   `   `   `  ����N  JPage Navigation App, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:Page_Navigation_App.ViewModelPage_Navigation_App.ViewModel  5      '    !Page_Navigation_App.View.Settings   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :vm+clr-namespace:Page_Navigation_App.ViewModel     5         
Page_Style#��[  5
      .��5      � $��15q�6   ���#909ea9.+�5   
   &   System.Windows.Controls.DataGrid  -   5           Name$  datagrid��5      $��18,165,18,30q�5      $��12(�5         AutoGenerateColumns$ False��5         GridLinesVisibility$	 All=�5         HeadersVisibility$ Column=�5         CanUserResizeColumns$
 True��5         CanUserResizeRows$ False��5         CanUserReorderColumns$ False��5         SelectionMode$ Extended=�5         SelectionUnit$ FullRow=�5      ���	#FFF8F6E3
���   ����	#FF020202	   AlternatingRowBackground	 �	#FFBDECEF
   Columns
 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Order Id��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 80 6T   1  +System.Windows.Controls.DataGridBoundColumn   Binding 68   �� *	OrderId+6T     5      $
 Date��6%   $ 75 6p    63   �� *	OrderDate+ �� StringFormat$ {0:MM/dd/yyyy}��6p     5      $ Customer Id��6%   $ 78 6Y    6:   �� *
CustomerId+6Y     5       $ Total Price��6%   $ 90 6Y    6:   �� *
TotalPrice+6Y     5!      $ Discount��6%   $ 85 6T    67   �� *
Discount+6T     5"      $ Advance Payment��6%   $	 105 6Z    6>   �� *	Advance+6Z     5#      $ Remaining Amount��6%   $	 113 6]    6?   �� *	Remaining+6]     5$      $ Status��6%   $ 80 6P      
IsReadOnly$ False��6[    65   �� *Status+6[   5&      �� 5'   
   $��Orders��6   $
��Left=�6!   $	��Top=�6<   $
��Bold"�6T   $��22(�6f   $��	Bodoni MT)�6t   $��	18,42,0,0q�6�   �� 5)   
    �� Orientation$ 
Horizontal=�6   ���	#FFEFE5BF$��18,84,4,457q�6E   .+�5*      �� $��Start Date:��6   ���	#FFC6D29A$��0,0,5,0q�6A   $��67��6R   $	��5,5q�6]   (  "System.Windows.Controls.DatePicker  5+      -   5          Name$ dpStartDate��5+      $	��120��6.   ���#EEEEEE$��0,0,5,0q�6O   �� 5,      $��	End Date:��6   ���	#FFC6D29A$��0,0,5,0q�6?   $��67��6P   $	��5,5q�6[     5-      -   5        $ 	dpEndDate��5-      $	��120��6,   ���#EEEEEE$��0,0,5,0q�6M   �� 5.      -   5        $��Search��5.      $��	Bodoni MT)�6&   $
��Bold"�6=   ���	#FFF1EE96$��0,0,5,0q�6~   $��88��6�   �� 5/      -   5        $��Clear��5/      $��	Bodoni MT)�6&   $
��Bold"�6=   ���	#FFF1EE96$��80��6}   50      �� 51   
   -   5        $��Update Status��51      
��� ���$��0q�6;   
������ $��Century Schoolbook)�6i   $��13(�6�   $
��Bold"�6�   $��449,125,18,410q�6�   ��52      �� 53       �� 
TargetType" ��6"   .R�54      � .+�55      A�  A�Name$ ellipse��6"   #��z��64   �� 56      $��Center=�6+   $��Center=�6H   57       �� Triggers 58      P� 59       P� Property �@J�IsMouseOver P� Value$
 True��69   . �5:      ��  �� 
TargetName$ ellipse��6%    �� Property � �� �� Value
 �����6J   5;      5=      5?      �� 5A   
   -   5         ��Name$ CompletedCheckBox��5A      $��	Completed��6.   $
��Left=�6B   $��
18,122,0,0q�6]   $	��Top=�6q   ���	#FFF6FFC1 J� RenderTransformOrigin$ 0.497,0.066&�6�   $��16��6�   $��85��6�   ���	#FFB9AF46
���   �$��	Bodoni MT)�6  $��14(�6  6F  �� 5B   
   -   5        $ PendingCheckBox��5B      $��Pending��6,   $
��Left=�6>   $��
18,142,0,0q�6Y   $	��Top=�6m   ���	#FFF6FFC1$��93��6�   ���	#FFB9AF46
���   �$��	Bodoni MT)�6�   $��14(�6�   6  5E      5F      