   M S B A M L   `   `   `  ����E  ASellbidule, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:Sellbidule.ViewsSellbidule.Views  5      5clr-namespace:Sellbidule.ModelsSellbidule.Models  5      (    "Sellbidule.Views.ProfilArticlePage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:Sellbidule.Views     5      2Modelsclr-namespace:Sellbidule.Models     5      -   5          N� Title$  ProfilArticlePage��5
       � 	Resources 5         articleViewSource��%   &	        �� 5   
   6   5      .��5      �  � DataContext# [  6    � ColumnDefinitions 5   
   �� 5      $��20 �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��20 �6    � RowDefinitions 5   
   �� 5      $��40 �6   �� 5      $��50 �6   �� 5      �� 5      $��20 �6   .+�5!   
   �� -   5         ��Name$ AllCategoryButton��5"      $��1��5!      $��1��6!   $��Tous les articles��6.   $��30,10q�6J   
���2͚�5"   L   �� 5#   
   -   5        $ NatureCategoryButton��5$      $��2��5#      $��1��6!   $��Nature��6.   $��30,10q�6?   
���2͚�5$   R   �� 5%   
   -   5        $ HouseCategoryButton��5&      $��3��5%      $��1��6!   $��Maison��6.   $��30,10q�6?   
���2͚�5&   P   �� 5'   
   -   5        $ ComputerHardwareButton��5(      $��4��5'      $��1��6!   $��Informatique��6.   $��30,10q�6E   
���2͚�5(   V   �� 5+   
   -   5         ��Name$ CategoryTittleTextBlock��5+      $��6��65   $	��Top=�6I    �� TextAlignment$ Center=�5,      $��28(�6,   $��Tous nos articles��6:   ���#4FC031$��40��6h   
�������$
��Bold"�6�   �� 5.   
   $��1��6   $��4��6"   $��2��66   $��20(�6[   ��6C   �� ��5/      �� 50      .R�51      � .+�52      �� $	��170��6?   $	��170��6K   $��0,0,10,0q�6X   ��6    �� *fullPicture+6X   �� 53      $��Center=�6%   .+�54      �� $
��Bold"�6>   $��25(�6P   ��6(   �� *name+6P   �� 55      $��18(�6E   ��6(   �� *description+6E   � 56      .+�57   "   �� ��6,   �� *price+�� 58   "   $
�� €��6,   59      � 5:      .+�5;   "   �� $��Réf : ��6,   �� 5<   "   ��6,   �� *	reference+5=      5>      5?      5@      5B      5C      5D      