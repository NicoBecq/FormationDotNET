   M S B A M L   `   `   `  ����@  <Diary, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Diary.ViewsDiary.Views  5           Diary.Views.AddAppointment   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      +localclr-namespace:Diary.Views     5        N� Title$  AddAppointment��5	      .��5      � ��5   
   �� 5       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5      �  � Color$ 	#FF9CA7CD��6    � Offset$ 0Q�61   � 5      $ 	#FF06289C��6   $ 1Q�61   5       � ColumnDefinitions 5   
   �� 5      $��20 �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��20 �6    � RowDefinitions 5   
   �� 5      $��20 �6   �� 5      $��80 �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5       $��* �6   �� 5!      $��* �6   �� 5"      $��20 �6   .+�5&   
   (� $��1��6   $��2��6"   $��1��66   .��5'      �� $��Ajouter un rendez-vous.��6   $��Center=�67   $��Center=�5(      $��Segoe Print)�63   $
��Bold"�5)      5*      �� 5-   
   $��1��6   $��2��6%   $��Center=�62   $
��15,0q�6M   .+�5.      �� $��Choisissez un courtier��6   $��Center=�65   �� 5/      -   5        $��BrokerComboBox��5/       �� DisplayMemberPath$ fullName��6E   ��6-   �� 6E   �� 50      -   5        $��idBrokerErrorMessage��50      
���  �� �� TextAlignment$ Center=�6E   51      �� 53   
   $��2��6   $��2��6%   $��Center=�62   $
��15,0q�6M   .+�54      �� $��Choisissez un client��6   $��Center=�63   �� 55      -   5        $��CustomerComboBox��55      $ fullName��6G   ��6/   �� 6G   �� 56      -   5        $��idCustomerErrorMessage��56      
���  ��$ Center=�6G   57      �� 59   
   $��1��6   $��2��6%   $��3��69   $��Center=�6F   .+�5:      (  "System.Windows.Controls.DatePicker  -   5        $��
DatePicker��5:      $��200,0q�6,   6;   �� 5;      -   5        $��datePickerErrorMessage��5;      
���  ��$ Center=�6G   5<      �� 5>   
   $��1��6   $��4��6%   $
��15,0q�62   $��Center=�6@   .+�5?      �� $��Choisissez une heure��6   $��Center=�63   �� 5@      -   5        $��HoursTextBox��5@      6*   �� 5A      -   5        $��hoursErrorMessage��5A      
���  ��$ Center=�6B   5B      �� 5D   
   $��2��6   $��4��6%   $
��15,0q�62   $��Center=�6@   .+�5E      �� $��Choisissez les minutes��6   $��Center=�65   �� 5F      -	   5        $��MinutesTextBox��5F      6,   �� 5G      -
   5        $��minutesErrorMessage��5G      
���  ��$ Center=�6D   5H      �� 5J   
   $��1��6   $��2��6&   $��5��6:   $��15,10q�6G   .+�5K      �� $��Sujet du rendez vous��6   $��Center=�63   $��Center=�5L      �� 5M      -   5        $��SubjectTextBox��5M      �� 5N      -   5        $��subjectErrorMessage��5N      
���  ��$ Center=�6D   5O      �� 5Q   
   -   5        $��Sauvegarder��5Q      $��1��6'   $��2��67   $��6��6K   $��Center=�5R      $��Center=�6.   6I   5S      5T      