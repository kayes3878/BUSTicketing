   M S B A M L   `   `   `  ����  BUSTicketing'    !BUSTicketing.UI.Login.UserSetUpUI   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  
User SetUp��5   
   $	��451��6   $	��638��6*    � ShowInTaskbar .   � 
ResizeMode$ CanMinimize=�6L    � WindowStartupLocation$ CenterScreen=�6e      	GrayWhite#��[  6�   .��5      � .+�5   
   �� -   5        $��	groupBox1��5   R   $��New User Information��6   $	��146��61   $��
37,44,38,0q�6>   $	��Top=�6c   .��5      � .+�5      �� -   5        $��txtUserName��5   T   $��23��6   $
��Left=�6&   $��	79,14,0,0q�6A     GraywithBlueBorderTextBox#��[ 6g   $	��Top=�6�   $	��178��6�   G� 5	      -   5        $��txtPassword��5	   l   
��� � �$��23��62   $
��Left=�6>   $��	79,47,0,0q�6Y   $	��Top=�6   $	��178��6�   G� 5
      -   5        $��txtConfirmPass��5
   l   
��� � �$��23��62   $
��Left=�6>   $��	79,80,0,0q�6Y   $	��Top=�6�   $	��178��6�   �� 5      -   5        $��cmbUserGroup��5   V   $��23��6   $
��Left=�6'   $��
328,14,0,0q�6B     ComboBoxBGYellowGreen#��[ 6j   $	��Top=�6�   $	��178��6�   �� 5      -   5        $��
btnAddUser��5   y   ���	#00000000$	��Add��60   $��23��6>   $
��Left=�6J   $��
350,80,0,0q�6e   $	��Top=�6�   $��75��6�   6�   �� 5      -   5        $��btnResetUser��5   {   ���	#00000000$��Reset��60   $��23��6@   $
��Left=�6L   $��
434,80,0,0q�6g   $	��Top=�6�   $��75��6�   �� 5      -   5        $��label1��5   f   $��	User name��6   $��28��6,   $
��Left=�68   $��	15,12,0,0q�6S   $	��Top=�6t   �� 5      -	   5        $��label2��5   d   $��Re type��6   $��28��6*   $
��Left=�66   $��	32,75,0,0q�6Q   $	��Top=�6r   �� 5      -
   5        $��label3��5   e   $��Password��6   $��28��6+   $
��Left=�67   $��	19,42,0,0q�6R   $	��Top=�6s   �� 5      -   5        $��label4��5   c   $��Group��6   $��28��6(   $
��Left=�64   $��
277,12,0,0q�6O   $	��Top=�6q   5      5      �� 5   
   -   5        $��	groupBox2��5   K   $��List Of User��6   $	��162��6)   $��37,196,38,0q�66   $	��Top=�6\   .��5      � .+�5      �� -   5        $��lvUser��5   T   $	��130��6   $
��Left=�6(   $��5,4,0,0q�6C   $	��Top=�6b   $	��520��6z      alternatingListViewItemStyle#��[ 6�    �� AlternationCount$ 2��6�    � ContextMenu 5      �� 5      
������� �� 	StaysOpen .  J� BitmapEffect 5      �� 5   "   .@�5      m� -   5        $��EditUser��5   K   $
��Edit��6=   6K   m� 5      -   5        $��
RemoveUser��5   O   $��Remove��6?   6O   5       �� View 5       �� 5!      .P�5"      �� $��	User Name��6\   	 �� Width$		 190��6o   
 �� DisplayMemberBinding
 6-   ��  �� Path$ UserName�6o   �� 5#      $��Password��6`   $		 120��6r   
 6-   �� $ UserPassword�6r   �� 5$      $��User Group Name��6a   $		 190��6z   
 6-   �� $ UserGroupName�6z   5%      5'      5(      5)      �� 5*   
   -   5        $��label5��5*   �   $��
User Setup��6   $��LeftToRight=�6%   $��18(�6A   $
��Bold"�6O   $��33��6a   $��240,0,251,0q�6m   $	��Top=�6�   �� 5+   
   -   5        $��button1��5+   t   ���	#00000000$��Close��6(   $��23��68   $
��Left=�6D   $��503,372,0,0q�6_   $	��Top=�6�   $��75��6�   6�   5,      5-      