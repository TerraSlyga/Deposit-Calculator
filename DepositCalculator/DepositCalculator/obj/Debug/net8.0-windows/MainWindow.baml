   M S B A M L   `   `   `  ����L  HDepositCalculator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:DepositCalculatorDepositCalculator  5   	   "    DepositCalculator.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:DepositCalculator     5   	     � Title$  DepositCalculator��5   	   $	��245��6#   $	��699��60   ���#102026 � 
ResizeMode$ NoResize=�5
   	    � DataContext 5      (  "DepositCalculator.DepositViewModel  5   
   .��5      � ��5   
   �� 5       �� 
StartPoint$	 0,0&�6"    �� EndPoint$	 1,1&�63   .��5      �  � Color$ #4EA68D��6    � Offset$ 0Q�6/   � 5      $ #1A2A3A��6   $ 1Q�6/   5      ��5   
   u� 5       u� Left$ 10Q�6   
 u� Top$ 10Q�6"   	 u� Right$	 10Q�6+   
 u� Bottom$
 10Q�66    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5       $
��Auto �6   �� 5!      $
��Auto �6   �� 5"      $��* �6   .+�5&   
   �� $��0��6    �� Orientation$ 
Horizontal=�6"   .+�5'      �� $��Deposit Amount��6   $��20(�6.   6>   �� 5(      $��20,0,0,0q�5)      $	��150��5*      
������ $��20(�5-      $��Center=�5.      ��5+      �� *DepositAmount+ �� UpdateSourceTrigger$ PropertyChanged=�5/      �� 50      $��20,0,0,0q�51      $	��150��52      
������ $��20(�56      ��53      �� *ListOfCurrencies+ �� SelectedItem 54      �� *SelectedCurrency+ �� Mode$ TwoWay=�$ PropertyChanged=�57      58      �� 5;   
   $��1��6   $ 
Horizontal=�6"   $��0,20,0,0q�6;   .+�5<      �� $��DepositPeriod��6   $��20(�6.   6>   �� 5=      -   5         ��Name$ periodSlider��5>      $��20,0,0,0q�5?      $	��300��5@       �� AutoToolTipPlacement$ TopLeft=�5B       � Maximum$ 24Q�5C       �� Ticks$ 3,6,9,12,24R�5D       �� IsSnapToTickEnabled$
 True��5E       �� TickPlacement$ BottomRight=�5F       � Value 5A      �� *DepositPeriod+$ PropertyChanged=�5G      5H      �� 5K   
   $��2��6   $ 
Horizontal=�6"   $��0,20,0,0q�6;   .+�5L      �� $��Payment method��6   $��20(�6.   6>   	� 5M      $��20,0,0,0q�5N      $��20(�5O       	� 	GroupName$ PaymentMethod��5P      $��End of term��5Q       d� 	IsChecked 5S      ��  �� Path$ PaymentMethod[0]�$ TwoWay=�$ PropertyChanged=�5T      	� 5U      $��20,0,0,0q�5V      $��20(�5W      $ PaymentMethod��5X      $��Monthly��5Y       5Z      �� $ PaymentMethod[1]�$ TwoWay=�$ PropertyChanged=�5[      5\      �� 5_   
   $��4��6   $ 
Horizontal=�6"   $��0,20,0,0q�6;   .+�5`      �� $��Result��6   $��20(�6&   66   �� 5a      $��20,0,0,0q�5b      $��20(�5c      $	��592��5d       �� TextWrapping$
 Wrap=�5e      " �� VerticalScrollBarVisibility$
 Auto=�5f      
������ ��5g      �� *Result+$ OneWay=�.��5h   *   5i      5j      5k      5l      