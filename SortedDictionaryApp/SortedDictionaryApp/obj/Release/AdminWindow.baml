   M S B A M L   `   `   `  ���� N  JSortedDictionaryApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:SortedDictionaryAppSortedDictionaryApp  %    SortedDictionaryApp.AdminWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     3local!clr-namespace:SortedDictionaryApp       � Title$  AdminWindow��$	��210��$	��323��.��� $��10q�.+��� $��	Staff ID:��$
��Left=�$	��Top=�$��	10,10,0,0q��� -    ��Name$ txtAdminStaffID��$
��Left=�$��	80,10,0,0q�$	��Top=�$	��200�� �� 
IsReadOnly . �� $��Staff Name:��$
��Left=�$	��Top=�$��	10,50,0,0q��� -   $ txtAdminStaffName��$
��Left=�$��	80,50,0,0q�$	��Top=�$	��200���� -    ��Name$ 	btnCreate��$��Create��$
��Left=�$��
10,100,0,0q�$	��Top=�$��75���� -   $ 	btnUpdate��$��Update��$
��Left=�$��100,100,0,0q�$	��Top=�$��75���� -   $ 	btnDelete��$��Delete��$
��Left=�$��190,100,0,0q�$	��Top=�$��75���� $��Bottom=�$��22��.@��� -    ��Name$ statusMessage��$��Ready�� J� InputBindings �� %   SortedDictionaryApp.AdminWindow   CloseAdminWindowCommand �� Command# Z 
 �� Key$ L��	 �� 	Modifiers$		 Altf�