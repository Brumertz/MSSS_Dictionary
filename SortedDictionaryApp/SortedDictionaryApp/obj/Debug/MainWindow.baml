   M S B A M L   `   `   `  ����N  JSortedDictionaryApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:SortedDictionaryAppSortedDictionaryApp  5   	   $    SortedDictionaryApp.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:SortedDictionaryApp     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      � .+�5   
   �� -   5         ��Name$ listBoxAllItems��5      $
��Left=�6+   $	��200��6F   $	��Top=�6S   $	��184��6k    J� IsHitTestVisible .  $��
49,169,0,0q�6�   {�.  6�   �� 5   
   -   5         ��Name$ txtStaffNameFilter��5      $
��Left=�6.   $��	41,65,0,0q�6I   $	��Top=�6\   $	��200��6t   6�   �� 5   
   $��Staff Name Filter:��6   $
��Left=�6-   $��	41,23,0,0q�6H   $	��Top=�6[   �� 5   
   -   5        $ txtStaffIDFilter��5      $
��Left=�6,   $��
41,125,0,0q�6G   $	��Top=�6[   $	��200��6s   6   �� 5   
   $��Staff ID Filter:��6   $
��Left=�6+   $��	41,88,0,0q�6F   $	��Top=�6Y   �� 5   
   -   5        $ listBoxFilteredResults��5      $
��Left=�62   $	��328��6M   $��
279,41,0,0q�6Z   $	��Top=�6n   $	��184��6�   6�   �� 5   
   -   5        $ txtSelectedStaffName��5      $
��Left=�60   $��
538,65,0,0q�6K   $	��Top=�6_   $	��200��6w   {�.  6�   �� 5   
   $��
Staff Name��6   $
��Left=�6%   $��
538,31,0,0q�6@   $	��Top=�6T   �� 5   
   -   5        $ txtSelectedStaffID��5      $
��Left=�6.   $��538,125,0,0q�6I   $	��Top=�6^   $	��200��6v   {�.  6�   �� 5   
   $��	Staff ID ��6   $
��Left=�6$   $��
538,96,0,0q�6?   $	��Top=�6S   �� 5   
   -   5         ��Name$ btnSaveData��5      $��	Save Data��6&   $
��Left=�6:   $	��Top=�6U   $	��100��6m   $��572,320,0,0q�6y   6�   �� 5   
   $
��Left=�6   $��Bottom=�6/   $��555,0,0,149q�6J   $
��Wrap=�6_   �� 5       $�
Shortcuts:��6   �� 5!      �� 5"      $�Open Admin GUI: Alt + A��6   �� 5#      �� 5$      $'�!Clear Staff Name Filter: Ctrl + N��6   �� 5%      �� 5&      $%�Clear Staff ID Filter: Ctrl + I��6   �� 5'      �� 5(      $�Save Data: Ctrl + S��6   5)      5*       J� InputBindings 5,      �� 5-   
   $   SortedDictionaryApp.MainWindow"   ClearStaffNameFilterCommand �� Command# Z 6   
 �� Key$ N��6W   	 �� 	Modifiers$	 Controlf�6_   �� 5.   
    
   ClearStaffIDFilterCommand# Z
 6   $ I��6U   $	 Controlf�6]   �� 5/   
      OpenAdminCommand# Z 6   $ A��6L   $		 Altf�6T   �� 50   
      SaveDataCommand# Z 6   $ S��6K   $	 Controlf�6S   53      