   M S B A M L   `   `   `  ���� H  DDictionaryApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:DictionaryAppDictionaryApp      DictionaryApp.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     -localclr-namespace:DictionaryApp       � Title$  
MainWindow��$	��450��$	��800��.��� $��0,3,0,-3q�.+��� -    ��Name$ listBoxAllItems��$
��Left=�$	��200��$	��Top=�$	��184�� J� IsHitTestVisible .  $��
49,169,0,0q�{�.  �� -    ��Name$ txtStaffNameFilter��$
��Left=�$��	41,65,0,0q�$	��Top=�$	��200���� $��Staff Name Filter:��$
��Left=�$��	41,23,0,0q�$	��Top=��� -   $ txtStaffIDFilter��$
��Left=�$��
41,125,0,0q�$	��Top=�$	��200���� $��Staff ID Filter:��$
��Left=�$��	41,88,0,0q�$	��Top=��� -   $ listBoxFilteredResults��$
��Left=�$	��328��$��
279,41,0,0q�$	��Top=�$	��184���� -   $ txtSelectedStaffName��$
��Left=�$��
538,65,0,0q�$	��Top=�$	��200��{�.  �� $��
Staff Name��$
��Left=�$��
538,31,0,0q�$	��Top=��� -   $ txtSelectedStaffID��$
��Left=�$��538,125,0,0q�$	��Top=�$	��200��{�.  �� $��	Staff ID ��$
��Left=�$��
538,96,0,0q�$	��Top=��� -    ��Name$ btnSaveData��$��	Save Data��$
��Left=�$	��Top=�$	��100��$��588,314,0,0q��� $
��Left=�$��Bottom=�$��538,0,0,125q�$
��Wrap=�$	��104��$	��200���� $�
Shortcuts:���� �� $�Open Admin GUI: Alt + A���� �� $'�!Clear Staff Name Filter: Ctrl + N���� �� $%�Clear Staff ID Filter: Ctrl + I���� �� $�Save Data: Ctrl + S�� J� InputBindings ��    DictionaryApp.MainWindow"   ClearStaffNameFilterCommand �� Command# Z 
 �� Key$ N��	 �� 	Modifiers$	 Controlf���  
   ClearStaffIDFilterCommand# Z
 $ I��$	 Controlf���    OpenAdminCommand# Z $ A��$		 Altf���    SaveDataCommand# Z $ S��$	 Controlf�