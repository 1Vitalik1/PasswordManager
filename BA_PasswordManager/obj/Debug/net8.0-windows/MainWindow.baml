   M S B A M L   `   `   `  ����M  IBA_PasswordManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:BA_PasswordManagerBA_PasswordManager  5   	   #    BA_PasswordManager.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:BA_PasswordManager     5   	     � Title$  
MainWindow��5   	   $	��720��6   $
��1280��6)   
������  � AllowsTransparency$
 True��5	   "    � WindowStyle$
 None=�6<    � WindowStartupLocation$ CenterScreen=�6O   .��5
      �� -   5        ���#1D2028 �� CornerRadius$ 5��5
   "   $��5q�63    J� Effect 5   
   3  -System.Windows.Media.Effects.DropShadowEffect  5         Color$ #366EC0��6      ShadowDepth$ 0Q�6/      
BlurRadius$ 15Q�6?   5      ._�5   
   � .+�5      �� -   5        	 ��Name$	 windowsButtonStack��5      $��Right=�65   $	��Top=�6Q   $��25q�6i   
 �� Orientation$
 
Horizontal=�6u    � 	Resources 5       �� 
TargetType �� Property �� Value��%�  '��       '�� �     �� 5      " ��6   .�5      ��  � ��$ 32��62   6?   �� 5       � ��$ 32��63   6@   �� 5       � ��$ 5q�63   6?   �� 5       � �� �#3232326I   �� 5       �@��CornerRadius$ 5��69   6E   5      �� 5      " ��6   .�5      ��  � ��
 �����6G   �� 5       � ��$ Center=�6@   6Q   �� 5       � ��$ Center=�6>   6O   �� 5       � ��$ 20(�65   6B   5      5      .+�5       �� -   5         ��Name$ 	btn_minim��5       ._�5!      �� ⚪6#   5"      �� 5#      -   5        $ 	btn_state��5#      $y�	Collapsed=�6,   ._�5$      �� 🔳6$   5%      �� 5&      -   5        $ btn_exit��5&      ._�5'      �� 💠6$   5(      5)       � 5*      -   5          �Name$ frame��5*        � Source$% /MyPages/SwitchAccountPage.xaml?�6#     � NavigationUIVisibility$ Hidden=�6L   6n   5+      5,      5-      