   M S B A M L   `   `   `  ����@  <WpfTZ, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:WpfTZ.ViewsWpfTZ.Views  5   	       WpfTZ.Views.SubInfoWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:WpfTZ.Views     5   	   -   5          �Name$  
SubInfoWin��5	       � WindowStyle$
 None=�5   	    � Title$ SubInfoWindow��5	   	   $��70��63   $	��300��6?    � 
ResizeMode$ NoResize=�6K   ��5
      �� 5   
    �� EndPoint$ 0.5,1&�6    �� 
StartPoint$ 0.5,0&�6/   .��5      �  � Color$ 	#FF44475A��6    � Offset$ 0Q�6-   � 5      $ 	#FF282A36��6   $ 1Q�6-   5      .��5      �  � ColumnDefinitions 5   
   �� 5      �� 5      	 � RowDefinitions	 5   
   �� 5      $��20 �6   �� 5      �� 5      .+�5   
   �� -   5        
 ��Name$
 WindowHeader��5   9    K� ZIndex$ 1��6   $��2��6O   ��5      �� 5      $	 0,0&�6&   $	 0,1&�67   .��5      � $ 	#FF44475A��6#   $ 0Q�66   � 5       $ #6272a4��6#   $ 1Q�63   5!      5#      �� 5$   
   $��Center=�6   $��Center=�6-   $��1��5%      $ ��Enter a id of information:��5&      ���#f8f8f25'      �� 5)   
   -   5         ��Name$ NameBox��5)      $��1��5*      $��1��6"   $��Center=�5+      �� 5-   
   $��2��6   $��0��6   $��Remove��5.         DefaultButton#��[  51      ��5/      �� *	SubInfo+��50      ��  �� ElementName$ 
SubInfoWin��51      �� 52   
   $��2��6   $��1��6   $��Cancel��53      #��[  56      ��54      �� *CancelBtnClick+��55      �� $ 
SubInfoWin��56      57      58      