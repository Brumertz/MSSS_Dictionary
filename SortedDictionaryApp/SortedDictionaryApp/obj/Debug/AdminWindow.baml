   M S B A M L   `   `   `  ����N  JSortedDictionaryApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:SortedDictionaryAppSortedDictionaryApp  5   	   %    SortedDictionaryApp.AdminWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:SortedDictionaryApp     5   	     � Title$  AdminWindow��5   	   $	��210��6   $	��323��6*   .��5	      � $��10q�6   .+�5   
   �� $��	Staff ID:��6   $
��Left=�6$   $	��Top=�6?   $��	10,10,0,0q�6W   �� 5   
   -   5         ��Name$ txtAdminStaffID��5      $
��Left=�6+   $��	80,10,0,0q�6F   $	��Top=�6Y   $	��200��6q    �� 
IsReadOnly . 6}   �� 5   
   $��Staff Name:��6   $
��Left=�6&   $	��Top=�6A   $��	10,50,0,0q�6Y   �� 5   
   -   5        $ txtAdminStaffName��5      $
��Left=�6-   $��	80,50,0,0q�6H   $	��Top=�6[   $	��200��6s   �� 5   
   -   5         ��Name$ 	btnCreate��5      $��Create��6$   $
��Left=�65   $��
10,100,0,0q�6P   $	��Top=�6d   $��75��6|   6�   �� 5   
   -   5        $ 	btnUpdate��5      $��Update��6$   $
��Left=�65   $��100,100,0,0q�6P   $	��Top=�6e   $��75��6}   6�   �� 5   
   -   5        $ 	btnDelete��5      $��Delete��6$   $
��Left=�65   $��190,100,0,0q�6P   $	��Top=�6e   $��75��6}   6�   �� 5   
   $��Bottom=�6   $��22��6/   .@�5      �� -   5         ��Name$ statusMessage��5      $��Ready��63   5      5       J� InputBindings 5      �� 5   
   %   SortedDictionaryApp.AdminWindow   CloseAdminWindowCommand �� Command# Z 6   
 �� Key$ L��6T   	 �� 	Modifiers$		 Altf�6\   5       