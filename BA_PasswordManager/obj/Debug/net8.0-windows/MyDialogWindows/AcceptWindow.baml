   M S B A M L   `   `   `  ����M  IBA_PasswordManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullW0clr-namespace:BA_PasswordManager.MyDialogWindows"BA_PasswordManager.MyDialogWindows  5   	   5    /BA_PasswordManager.MyDialogWindows.AcceptWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Blocal0clr-namespace:BA_PasswordManager.MyDialogWindows     5   	     � Title$  AcceptWindow��5   	   $	��200��6   $	��400��6+    � WindowStartupLocation$ CenterScreen=�67    � WindowStyle$
 None=�6\    � AllowsTransparency$
 True��6o   
������ .��5	      �� ���#2B2E37 �� CornerRadius$ 5��6"   $��5q�63    J� Effect 5
   
   3  -System.Windows.Media.Effects.DropShadowEffect  5      ._�5   
   �  � RowDefinitions 5      �� 5      $	��70* �6    �� 5      $	��80* �6    �� 5      $	��90* �6    .+�5      (� $��0��6   $��
15,15,0,10q�6#   $
��Left=�67   .��5      �� 
������� 5        5         
BlurRadius$ 0Q�6+      ShadowDepth$ 1Q�6:   )'Подтвердите удаление5   +   5      (� 5      $��1��6   $��
15,15,0,10q�6#   $��Center=�67   .��5      �� -   5        	 ��Name$	 textBlock_accountName��5      
������� 5        5      $ 0Q�6+   $ 1Q�6:   AccountName5   "   5       �� 5!      
 �� Orientation$
 
Horizontal=�6   $��Right=�62   $��Center=�6N   $��2��6i   .+�5"      �� -   5         ��Name$ button_cancle��5"      $��32��61   $	��128��6=   $��5q�6I   ���#DC3E3E._�5#      (� .��5$      �� 
������� 5%        5&   "   $ 0Q�63   $ 1Q�6B   Отменить5(   '   5)      5*      �� 5+      -   5        $ button_accept��5+      $��32��60   $	��128��6<   $��5q�6H   ���#60D34E._�5,      (� .��5-      �� 
������� 5.        5/   "   $ 0Q�63   $ 1Q�6B   Удалить51   &   52      53      54      55      56      57      