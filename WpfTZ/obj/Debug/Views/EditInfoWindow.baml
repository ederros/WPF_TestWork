   M S B A M L   `   `   `  ����@  <WpfTZ, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:WpfTZ.ViewsWpfTZ.Views  5   	        WpfTZ.Views.EditInfoWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:WpfTZ.Views     5   	   -   5          �Name$  EditInfoWin��5	        � WindowStyle$
 None=�5   	    � Title$ EditInfoWindow��5	   	   $	��140��65   $	��300��6B    � 
ResizeMode$ NoResize=�6N   ��5
      �� 5   
    �� EndPoint$ 0.5,1&�6    �� 
StartPoint$ 0.5,0&�6/   .��5      �  � Color$ 	#FF44475A��6    � Offset$ 0Q�6-   � 5      $ 	#FF282A36��6   $ 1Q�6-   5      .��5      �  � ColumnDefinitions 5   
   �� 5      �� 5      	 � RowDefinitions	 5   
   �� 5      $��20 �6   �� 5      �� 5      �� 5      �� 5      �� 5      .+�5   
   �� -   5        
 ��Name$
 WindowHeader��5   9    K� ZIndex$ 1��6   $��2��6O   ��5       �� 5!      $	 0,0&�6&   $	 0,1&�67   .��5"      � $ 	#FF44475A��6#   $ 0Q�66   � 5#      $ #6272a4��6#   $ 1Q�63   5$      5&      �� 5'   
   $��Center=�6   $��Center=�6-   $��2��5(      ���#f8f8f2.��5)   %   Choose user:5+      �� 5,   
   $��Center=�6   $��Center=�6-   $��1��5-      ���#f8f8f2.��5.   %   	Write id:50      �� 51   
   $��Center=�6   $��Center=�6-   $��3��52      ���#f8f8f2.��53   %   Choose application:55      �� 56   
   $��Center=�6   $��Center=�6-   $��4��57      ���#f8f8f2.��58   %   Write comment:5:      �� 5;   
   -   5         ��Name$ IdBox��5;   /   $��1��6   $��1��6"   $��Center=�6>   .��6z   5=      �� 5>   
   -   5         ��Name$ userNameBox��5>   #   $��1��6   $��2��68   5@      �� 5A   
   -   5        $ 
appNameBox��5A   0   $��1��6   $��3��6#   5C      �� 5E   
   -   5        $ 
commentBox��5E   /   $��1��6   $��4��6"   $��Center=�6C   .��6e   5G      �� 5I   
   $��5��6   $��0��6   $
��Edit��6.      DefaultButton#��[  5K      ��5I   =   �� *
EditInfo+��5J      ��  �� ElementName$ EditInfoWin��5K      �� 5L   
   $��5��6   $��1��6   $��Cancel��6.   #��[  5N      ��5L   ?   �� *CancelBtnClick+��5M      �� $ EditInfoWin��5N      5O      5P      