   M S B A M L   `   `   `  ����N  JPage Navigation App, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:Page_Navigation_App.ViewPage_Navigation_App.View  5   	   (    "Page_Navigation_App.View.LoginPage   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:Page_Navigation_App.View     5   	     � Title$  	LoginPage��5   	   $	��450��6   $	��800��6(    � WindowStartupLocation$ CenterScreen=�64   .��5	      � ��5   
   �� 5       �� ImageSource$s mC:\Users\SAMI ABBASI\OneDrive\Desktop\idk\Page Navigation App\Page Navigation App\Images\gold background.jpeg��6    j� Stretch$ UniformToFill=�6�    �� Opacity$
 0.35Q�6�   .+�5   
   � $��10,10,10,10q�6    � RowDefinitions 5      �� 5      $
��Auto �6    $��75��6.   �� 5      $
��Auto �6    $��72.757��6.   �� 5      $
��Auto �6    $��43.28��6.   �� 5      $
��Auto �6    $��53.28��6.   �� 5      $
��Auto �6    $��26.62��6.   �� 5      $
��Auto �6    $	��126��6.   .+�5      �� $��1��6   $��Jewellers Craft��6%   $��Center=�6<   $��48(�6Y   $��0,0,0,20q�6g   $��Copperplate Gothic Bold)�5      $
��Bold"�6=   
���   �$	��460��6b   �� 5"      $��2��6    �� Orientation$ 
Horizontal=�6&   $��Center=�6?   $��0,0,0,10q�6\   $	��290��6n   .+�5#      �� $��Username��6   $��Center=�6+   $��18(�6M   $��Britannic Bold)�6\   $
��Bold"�6x   
���   �6�   �� 5$      -   5         ��Name$ txtUsername��5$      $��10 0 0 0q�6/   $	��200��6A   $��16(�6M   $��5q�6[   5%      �� 5(      $��3��6   $ 
Horizontal=�6&   $��Center=�6?   $��	0,10,0,10q�6\   $	��288��6o   .+�5)      �� $��Password��6   $��Center=�6+   
���   �$��Britannic Bold)�6`   $
��Bold"�6|   $��18(�6�   G� 5*      -   5         G�Name$ txtPassword��5*      $��10 0 0 0q�63   $	��200��6E   $��16(�6Q   $��5q�6_   5+      �� 5/      -   5        $��5��5/      $��Login��6"   $
��Left=�6F   $	��124��6a   $��	339,1,0,0q�6n   ���	#FFFAAF37$��46��6�   $	��Top=�6�   $��0q�6�   
������ $��Century Schoolbook)�6�   $��18(�6  $
��Bold"�6  ��51      �� 52      	 �� 
TargetType"	 ��6&   .R�53      � .+�54      A� 
 A�Name$
 ellipse��6&   #��z��68   �� 55      $��Center=�6/   $��Center=�6L   56       �� Triggers 57      P� 58       P� Property �@J�IsMouseOver P� Value$
 True��6=   . �59   "   ��  �� 
TargetName$ ellipse��6)    �� Property � �� �� Value
 �����6N   5:      5<      5>      �� 5A      -   5         ��Name$ txtError��5A      $��4��6*   
���  ��$y�Visible=�6H   $
��Left=�6]   $��	254,5,0,3q�5B      $��14(�6+   $	��288��69   5C      5D      5E      