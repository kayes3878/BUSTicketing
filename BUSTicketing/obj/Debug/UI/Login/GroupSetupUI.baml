   M S B A M L   `   `   `  ����  BUSTicketing(    "BUSTicketing.UI.Login.GroupSetupUI   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Group Setup��5   	   $	��407��6   $	��481��6*    � ShowInTaskbar .   � 
ResizeMode$ CanMinimize=�6M    � WindowStartupLocation$ CenterScreen=�6f      	GrayWhite#��[  6�   .��5      � .+�5   
   �� -   5        $��	groupBox1��5   Q   $��List Of Group Name��6   $	��171��6/   $��40,141,36,0q�6<   $	��Top=�6b   .��5      � .+�5      �� -   5        $��lvUserGroup��5   U   $	��139��6   $
��Left=�6)   $��1,5,0,0q�6D   $	��Top=�6h   $	��367��6�      alternatingListViewItemStyle#��[ 6�    �� AlternationCount$ 2��6�    � ContextMenu 5	      �� 5
       �� 	StaysOpen . 
������� J� BitmapEffect 5      �� 5   "   .@�5      m� -   5        $��EditUserGroup��5   5   $
��Edit��6'   6J   m� 5      -   5        $��RemoveUserGroup��5   7   $��Remove��6'   6N   5       �� View 5      �� 5      .P�5      �� $��
Group Name��6-   	 �� Width$		 330��6q   
 �� DisplayMemberBinding
 6A   ��  �� Path$ 	GroupName�6   5      5      5      5      �� 5   
   -   5        $��	groupBox2��5   K   $��Type Group Name��6   $��80��6,   $��	37,55,0,0q�68   $	��Top=�6\   $
��Left=�6t   $	��386��6�   .��5      � .+�5      �� -   5        $��txtUserGroupName��5   T   $��23��6   $
��Left=�6&   $��	66,15,0,0q�6A   $	��Top=�6l   $	��205��6�     GraywithBlueBorderTextBox#��[ 6�   �� 5      -   5        $��btnAddUserGroup��5   z   ���	#00000000$	��Add��61   $��23��6?   $
��Left=�6K   $��
286,14,0,0q�6f   $	��Top=�6�   $��75��6�   6�   �� 5      -   5        $��label1��5   a   $
��Name��6   $��28��6'   $
��Left=�63   $��	26,13,0,0q�6N   $	��Top=�6o   5      5       �� 5!   
   -	   5        $��label2��5!   �   $��Group Setup��6   $��LeftToRight=�6&   $��18(�6B   $
��Bold"�6P   $��33��6b   $��173,3,161,0q�6n   $	��Top=�6�   �� 5"   
   -
   5        $��groupClosebutton��5"   u   ���	#00000000$��Close��6)   $��23��69   $
��Left=�6E   $��348,333,0,0q�6`   $	��Top=�6�   $��75��6�   6�   5#      5$      