   M S B A M L   `   `   `  ����@  <Diary, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Diary.ViewsDiary.Views  5      +clr-namespace:Diary.ModelsDiary.Models  5          Diary.Views.ListBroker   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      +localclr-namespace:Diary.Views     5      -Modelsclr-namespace:Diary.Models     5      -   5          N� Title$  
ListBroker��5
       � 	Resources 5         brokerViewSource��%   &	        �� 5   
   6   5      .��5      �� $
��Auto=�6   .��5   
   �  � DataContext# [  6    � ColumnDefinitions 5      �� 5      $��20 �6#   �� 5      $��* �6#   �� 5      $��* �6#   �� 5      $��20 �6#    � RowDefinitions 5      �� 5      $��20 �6    �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5       $��20 �6    ��5$      �� 5%       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5&      �  � Color$ 	#FF9CA7CD��6#    � Offset$ 0Q�65   � 5'      $ 	#FF06289C��6#   $ 1Q�65   5(      .+�5,      �� $��1��6   $��1��6(   $��2��65   $��Center=�6I   $��36(�5-      $��Liste des courtiers��6&   $��Segoe Print)�6A   $
��Bold"�5.      &   System.Windows.Controls.DataGrid  51      -   5        	  Name$	 brokerDataGrid��51      
   RowDetailsVisibilityMode$
 VisibleWhenSelected=�6/   $��1��52      $��2��6'   $��2��64      EnableRowVirtualization .    AutoGenerateColumns .  ��6H   ��    Columns 54      0  *System.Windows.Controls.DataGridTextColumn  55      -   5        firstNameColumn��,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$
 auto 55   B      Header$ Prénom��56   )   1  +System.Windows.Controls.DataGridBoundColumn   Binding 69   �� *	firstName+  57      -   5        lastNameColumn��$
 auto 57   A   $ Nom de famille��58   )    6A   �� *
lastName+  59      -   5        
mailColumn��$
 auto 59   =   $ Adresse Mail��5:   )    6?   �� *mail+  5;      -   5        phoneNumberColumn��$
 auto 5;   D   $ Numéro de télephone��5<   )    6F   �� *phoneNumber+5>      �� 5A      -   5        $��idBrokerTextBlock��5B   ,   $y�Hidden=�6   ��5A      ��  �� ElementName$ brokerDataGrid�� �� Path$ SelectedItem.idBroker�5B   ,   �� 5F      $��1��6   $��2��6(   $��3��6<   $��Modifications��6I   $��Center=�5G      $��Center=�65   $��20(�6P   $��Segoe Print)�5H      $
��Bold"�61   �� 5K      $��1��6   $��4��6)   $��5q�66   .+�5L      �� $��Nom de famille��6   $��Center=�61   �� 5M      -   5        $��lastNameTextBox��5N      $��3��5M      $��1��6'   $	��300��67   ��5N   )   �� $ brokerDataGrid��$ SelectedItem.lastName�6q   �� 5O      -	   5        $��LastNameErrorMessage��5O      $��Center=�68   $��Center=�5P      
���  ��67   5Q      �� 5S      $��2��6   $��4��6)   $��5q�66   .+�5T      �� $��Prénom��6   $��Center=�6)   �� 5U      -
   5        $��firstNameTextBox��5U   C   $��3��6   $��1��6'   $	��300��67   ��5V      �� $ brokerDataGrid��$ SelectedItem.firstName�6c   �� 5W      -   5        $��FirstNameErrorMessage��5W      $��Center=�69   $��Center=�5X      
���  ��67   5Y      �� 5[      $��1��6   $��5��6)   $��5q�66   .+�5\      �� $��Adresse Mail��6   $��Center=�6/   �� 5]      -   5        $��mailTextBox��5]   C   $��3��6   $��1��6'   $	��300��67   ��5^      �� $ brokerDataGrid��$ SelectedItem.mail�6^   �� 5_      -   5        $��MailErrorMessage��5_      $��Center=�64   $��Center=�5`      
���  ��67   5a      �� 5c      $��2��6   $��5��6)   $��5q�66   .+�5d      �� $��Numéro de télephone��6   $��Center=�66   �� 5e      -   5        $��phoneNumberTextBox��5e   C   $��3��6   $��1��6'   $	��300��67   ��5f      �� $ brokerDataGrid��$ SelectedItem.phoneNumber�6e   �� 5g      -   5        $��PhoneNumberErrorMessage��5g      $��Center=�6;   $��Center=�5h      
���  ��67   5i      �� 5l      -   5        $��1��5l      $��6��6%   $
��15,5q�62   $��Enregistrer��6@   $	��150��5m      $��35��6   ���	#FF63E0286C   �� 5n      -   5        $��2��5n      $��6��6%   $
��15,5q�62   $��	Supprimer��6@   $	��150��5o      $��35��6   ���	#FFF02B2B6C   5q      5r      5s      