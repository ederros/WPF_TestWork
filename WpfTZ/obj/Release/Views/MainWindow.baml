   M S B A M L   `   `   `  ���� @  <WpfTZ, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:WpfTZ.ViewsWpfTZ.Views      WpfTZ.Views.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     +localclr-namespace:WpfTZ.Views     -     �Name$  MainWin�� � AllowsTransparency .  � WindowStyle$
 None=� � 
ResizeMode$ NoResize=� � Title$ 
MainWindow��$	��400��$	��600��$	��600��$	��300������  �� EndPoint$ 0.5,1&� �� 
StartPoint$ 0.5,0&�.���  � Color$ 	#FF282A36�� � Offset$ 0Q�� $ 	#FF44475A��$ 1Q�.��� ���	#00000000	 � RowDefinitions	 �� $��20 ��� .+��� -   
 ��Name$
 WindowHeader�� K� ZIndex$ 1������ $	 0,0&�$	 0,1&�.��� $ 	#FF44475A��$ 0Q�� $ #6272a4��$ 1Q�._���  �� Orientation$ 
Horizontal=�$��Right=�.+��� $��20�����#ff5555$��Center=�$��Right=����� *CancelBtnClick+����  �� ElementName$ MainWin��.��X�� $��0��$��1��$��1,1,0,0q����	#00000000.@��� $��Users��.���  � ColumnDefinitions �� $	��154 ��� $	��1.2 ��� $��244.4 ��� .+�&   System.Windows.Controls.DataGrid     HeadersVisibility$ Column=�$��3��   
IsReadOnly . ���#44475a$��0,0,0.2,-0.2q����� *
AllUsers+�� $ Vertical=�$
��Left=�$��
0,0,0,-0.2q�.+��� $��80��$��30��   DefaultButton#��[  ���� *OpenAddUserWindow+.��
Add user�� $��80��$��30��#��[  ���� *OpenSubUserWindow+.��
Sub user�� $��Applications��.���  �� $	��400 ��� .+�  $ Column=�$��1��$��1�� . ���#44475a���� *	AllApps+�� $ Vertical=�$
��Left=�.+��� $��80��$��30��#��[  ���� *OpenAddAppWindow+.��	Add App�� $��80��$��30��#��[  ���� *OpenSubAppWindow+.��	Sub App�� $��Information��.���  �� $
��66.1 ��� $��133.9 ��� .+�  $ Column=�$��2�� . ���#44475a$��0,0,0.2,-0.2q����� *	AllInfo+�� $ Vertical=�$
��Left=�$��2��$��
0,0,0,-0.2q�.+��� $��80��$��30��#��[  ���� *OpenAddInfoWindow+.��
Add info�� $��80��$��30��#��[  ���� *OpenSubInfoWindow+.��
Sub info�� $��80��$��30��#��[  ���� *OpenEditInfoWindow+.��	Edit info�� -    ��Name$ MessagePopup��$��1��$��2��$��0��$	��300��$��60�����	#a8ffb86c$ 10��$��Center=�$��Bottom=�$	��Top=�$��Center=�.��	message � Triggers :�  :� RoutedEvent$ Loaded��.[��� .���� .��W�  g� Duration$ 0:0:1D� �� TargetProperty$ Opacity� W� From$ 0X�	 W� To$ 1X�