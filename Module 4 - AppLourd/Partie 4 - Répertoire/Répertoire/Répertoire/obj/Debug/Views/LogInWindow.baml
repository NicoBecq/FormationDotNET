   M S B A M L   `   `   `  ����F  BRépertoire, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Répertoire.ViewsRépertoire.Views  5   	   #    Répertoire.Views.LogInWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:Répertoire.Views     5   	     � Title$  LogInWindow��5   	   $	��450��6   $	��800��6*   .��5	      � ��5
   
   �� 5       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5      �  � Color$ 	#FF0A002B��6    � Offset$ 1Q�61   � 5      $ 	#FF3212A0��6   5       � ColumnDefinitions 5   
   �� 5      $	��225 �6   �� 5      $��* �6   �� 5      $	��225 �6    � RowDefinitions 5   
   �� 5      $��30 �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��30 �6   .+�5   
   �� 
�������
������� �� CornerRadius$ 15��5!      $��1��5"      $��1��5#      $��5��5$      �� 5'   
   $��	Connexion��6   $��1��6%   $��1��65   $��Center=�6B   $	��Top=�5(      $��30(�6,   �� 5)   
   -   5        $��logInErrorMessage��5)      $��1��6-   $��1��6=   $��Bottom=�6J   $��Center=�5*      
���  ��61   �� 5,   
   $��1��6   $��2��6%   $��	30,0,30,0q�62   .+�5-      �� $��Adresse Mail��6   �� 5.      -   5        $��mailTextBox��5.      �� 5/      -   5        $��mailErrorMessage��5/      
���  ��60   50      �� 52   
   $��1��6   $��3��6%   $��	30,0,30,0q�62   .+�53      �� $��Mot de passe��6   G� 54      -   5        $��passwordTextBox��54      �� 55      -   5        $��passwordErrorMessage��55      
���  ��64   56      �� 58   
   -   5        $��Center=�58      $��Center=�6.   $��22��6I   $	��200��59      $��1��6   $��4��6-   $��	Connexion��6:   5:      �� 5<   
   -   5        $��Center=�5<      $��Center=�6.   $��22��6I   $	��200��5=      $��1��6   $��5��6-   $��Inscription��6:   5>      5?      5@      