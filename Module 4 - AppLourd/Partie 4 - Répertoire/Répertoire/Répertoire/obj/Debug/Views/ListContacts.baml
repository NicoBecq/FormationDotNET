   M S B A M L   `   `   `  ����F  BRépertoire, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Répertoire.ViewsRépertoire.Views  5   	   $    Répertoire.Views.ListContacts   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:Répertoire.Views     5   	   -   5          � Title$  ListContacts��5   	   $	��450��6   $	��800��6+   .��5
      � ��5   
   �� 5       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5      �  � Color$ 	#FF0A002B��6    � Offset$ 1Q�61   � 5      $ 	#FF3212A0��6   5       � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $	��600 �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��30 �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��30 �6   .+�5   
   �� ���	#FF474646 �� CornerRadius$ 15��5       $��1��5!      $��1��5"      $��4��5#      ��5$      �� 5%       �� Color$ 	#FF404040��6"   	 �� Opacity$		 0.9Q�64   5'      �� 5*   
   $��Liste des contacts��6   $��1��6.   $��1��6>   $��30(�6K   $��Center=�5+      &   System.Windows.Controls.DataGrid  5-   
   -   5        $��contactDataGrid��5-      $��1��6*   $��2��6:   $��2��6G   $
��30,0q�5.      
   AutoGenerateColumns
 .  ��6!   ��    Columns 5/      0  *System.Windows.Controls.DataGridTextColumn  50      -   5        firstNameColumn��,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$
 auto 50   >      Header$ Prénom��51   )   1  +System.Windows.Controls.DataGridBoundColumn   Binding 69   �� *	firstName+  52      -   5        lastNameColumn��$
 auto 52   =   $ Nom de famille��53   )    6A   �� *
lastName+  54      -   5        
mailColumn��$
 auto 54   9   $ Adresse Mail��55   )    6?   �� *mail+  56      -   5        phoneNumberColumn��$
 auto 56   @   $ Numéro de télephone��57   )    6F   �� *phoneNumber+  58      -   5        addressColumn��$
 auto 58   <   $ Adresse��6I    59   %   �� *	address+5;      �� 5=   
   -   5        $��Retour à votre profil��5=      $��1��61   $��4��6A   $��Center=�5>      $��Center=�6.   $��22��6I   $	��200��5?      6   5@      5A      