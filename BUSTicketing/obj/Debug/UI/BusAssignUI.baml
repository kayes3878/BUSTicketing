   M S B A M L   `   `   `  ����  BUSTicketing!    BUSTicketing.UI.BusAssignUI   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   ` \Xceed.Wpf.Toolkit, Version=2.9.15603.14400, Culture=neutral, PublicKeyToken=ba83ff368b7563c64xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	     � Title$  BusAssignUI��5   	   $��459.701��6   $��637.314��6.    � WindowStartupLocation$ CenterScreen=�6>   .��5      � .+�5   
   �� $��Bus Assign Info��6   $
��Left=�6,   $��	90,29,0,0q�6G   $	��Top=�6Z   $	��162��6r   $	��453��6   .��5	      � .+�5      �� $
��Date��6   $
��Left=�6'   $��11,4,0,0q�6B   $	��Top=�6T   �� 5      $
��Time��6   $
��Left=�6'   $��	10,34,0,0q�6B   $	��Top=�6U   �� 5      $
��Sift��6   $
��Left=�6'   $��
228,34,0,0q�6B   $	��Top=�6V   (  "System.Windows.Controls.DatePicker  5      -   5        $��DepartureDateDatepicker��5      $
��Left=�6<   $��	102,6,0,0q�6W   $	��Top=�6j   $	��120��6�   �� 5      -   5        $��BusTypeComBox��5      $
��Left=�60   $��	318,7,0,0q�6K   $	��Top=�6^   $	��120��6v   �� 5      $��Ac / Non-Ac��6   $
��Left=�6.   $��	228,5,0,0q�6I   $	��Top=�6\   �� 5      $��Ticket Price��6   $
��Left=�6/   $��	10,86,0,0q�6J   $	��Top=�6]   �� 5      $��Ticket Counter��6   $
��Left=�61   $��
228,61,0,0q�6L   $	��Top=�6`   �� 5      -   5        $��SiftComboBox��5      $
��Left=�6/   $��
318,34,0,0q�6J   $	��Top=�6^   $	��120��6v   �� 5      -   5        $��ticketPriceTextBox��5      $
��Left=�6k   $��23��6�   $��
102,86,0,0q�6�    �� TextWrapping$
 Wrap=�6�   $�� ��6�   $	��Top=�6�   $	��120��6�   �� 5      -   5        $��TicketCounterCombobox��5      $
��Left=�68   $��
318,61,0,0q�6S   $	��Top=�6g   $	��120��6   "  Xceed.Wpf.Toolkit.TimePicker  5      -   5        $��
TimeCmbBox��5   "   $��
0,35,219,0q�6V   $��23��6j   $	��Top=�6v   $��Right=�6�   $	��120��6�   �  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.DateTime, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   Value 64   �� *CurrentDateTime+6�   �� 5      $��Reporting Time��6   $
��Left=�61   $��	10,57,0,0q�6L   $	��Top=�6_   �� 5      $��BUS No��6   $
��Left=�6)   $��
228,87,0,0q�6D   $	��Top=�6X   �� 5      -   5        $��
savebutton��5   {   $
��Save��6   $
��Left=�6(   $��363,115,0,0q�6C   $	��Top=�6X   $��75��6p   6�   �� 5      $��Clear��6   $
��Left=�6)   $��283,115,0,0q�6D   $	��Top=�6Y   $��75��6q   �� 5      -   5         ��Name$ busNumberComboBox��5      $
��Left=�66   $��
318,88,0,0q�6Q   $	��Top=�6e   $	��120��6}   �� 5       $��	Last Stop��6   $
��Left=�6,   $��
10,113,0,0q�6G   $	��Top=�6[   �� 5!      -	   5        $ lastStopCmbBox��5!      $
��Left=�63   $��102,114,0,0q�6N   $	��Top=�6c   $	��120��6{     5"      -
   5          Name$ reportintgTimeCombobox��5"   "   $��
0,61,219,0q�6d   $��22��6x   $	��Top=�6�   $��Right=�6�   $	��120��6�    6B   �� *CurrentDateTime+6�   5#      5$      �� 5'   
   -   5         ��Name$ AllBusAssignListView��5'      $
��Left=�61   $	��169��6L   $��
90,196,0,0q�6Y   $	��Top=�6m   $	��453��6�    � ContextMenu 5)      �� 5*      -   5        $��ticketPurchageDetailsList��5*       �� 	StaysOpen . 
�������	 J� BitmapEffect	 5+      �� 5,      .@�5.      m� -   5        $��
removeSeat��5.   4   $��Seat Delete��6   64   5/      
 �� View
 51      �� 52      .P�53      �� $��Id��6J    �� Width$
 Auto��6V    �� DisplayMemberBinding 6%   �� *ID+6V   �� 54      $��TimeOfDiparture��6V   $
 Auto��6o    6%   �� *TimeOfDiparture+6o   �� 55      $��DateOfDiparture��6V   $
 Auto��6o    6%   �� *DateOfDiparture+6o   �� 56      $
��Sift��6K   $
 Auto��6Y    6%   �� *Sift+6Y   �� 57      $��	AC/Non-AC��6K   $
 Auto��6^    6%   �� *Type+6^   �� 58      $��
Bus Number��6P   $
 Auto��6d    6%   �� *	BusNumber+6d   �� 59      $��Ticket Price��6R   $
 Auto��6h    6%   �� *TicketPrice+6h   �� 5:      $��Counter Name��6S   $
 Auto��6i    6%   �� *CounterName+6i   5=      5?      9� 5@   
   $��Expander��6   $
��Left=�6%   $��	14,70,0,0q�6@   $	��Top=�6S    J� RenderTransformOrigin$ 0.5,0.5&�6k   z�5A      V� 5B      .~�5C      �� �� 5D      �� 5E       �� Angle$ 90Q�6&   T� 5F      5G      .��5I      �� $��10,4,0,0q�6   .+�5J      �� $��4q�6   $��Option 1��6&   �� 5K      $��4q�6   $��Option 2��6&   �� 5L      $��4q�6   $��Option 3��6&   5M      5O      5Q      5R      