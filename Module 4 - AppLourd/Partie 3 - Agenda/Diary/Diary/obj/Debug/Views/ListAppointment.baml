   M S B A M L   `   `   `  ����@  <Diary, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Diary.ViewsDiary.Views  5      +clr-namespace:Diary.ModelsDiary.Models  5      !    Diary.Views.ListAppointment   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      +localclr-namespace:Diary.Views     5      -Modelsclr-namespace:Diary.Models     5      -   5          N� Title$  ListAppointment��5
       � 	Resources 5         appointmentViewSource��%   &	        �� 5   
   6   5      .��5      �� $
��Auto=�6   .��5   
   �  � DataContext# [  6   ��5      �� 5       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5      �  � Color$ 	#FF9CA7CD��6#    � Offset$ 0Q�65   � 5      $ 	#FF06289C��6#   $ 1Q�65   5       � ColumnDefinitions 5      �� 5      $��20 �6#   �� 5      $��* �6#   �� 5      $��* �6#   �� 5      $��20 �6#    � RowDefinitions 5       �� 5!      $��20 �6    �� 5"      $��80 �6    �� 5#      $
��auto �6    �� 5$      $
��auto �6    �� 5%      $
��auto �6    �� 5&      $
��auto �6    �� 5'      $
��auto �6    �� 5(      $
��auto �6    �� 5)      $
��auto �6    �� 5*      $��20 �6    .+�5.      �� -   5        $��idAppointmentTextBlock��5/      $y�Hidden=�66   ��5.      �� 	 �� ElementName$	 appointmentDataGrid��
 �� Path$!
 SelectedValue.idAppointment�5/   6   (� 52      $��1��6   $��2��6&   $��1��6:   .��53      �� $��Liste des rendez-vous��6   $��Center=�69   $��Center=�54      $��Segoe Print)�63   $
��Bold"�55      56      &   System.Windows.Controls.DataGrid  58      -   5          Name$ appointmentDataGrid��58         AutoGenerateColumns .  $��2��59      $��1��6'      EnableRowVirtualization . $��2��5:   +      RowDetailsVisibilityMode$ VisibleWhenSelected=�5;      ��5:      ��    Columns 5<      4  .System.Windows.Controls.DataGridTemplateColumn  5=      -   5        datHourColumn��,  &System.Windows.Controls.DataGridColumn   Header$
 Date��5=   D      Width5  /System.Windows.Controls.DataGridLengthConverter$
 auto 6R      CellTemplate 5>      �� 5?      .R�5@   "   (  "System.Windows.Controls.DatePicker  $��
datePicker��5A   -      SelectedDate 5@   -   �� *	datHour+ �� Mode$ TwoWay=� �� NotifyOnValidationError .  �� ValidatesOnExceptions . 5A   -   5B      5D      0  *System.Windows.Controls.DataGridTextColumn  5E      -   5        timeSlotHourColumn��$ Heure��5E   E   $
 auto 5F   )   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5E   T   �� *timeSlotHour+5F   )     5G      -   5        timeSlotMinuteColumn��$ Minutes��5G   G   $
 auto 5H   )    5G   X   �� *timeSlotMinute+5H   )     5I      -   5        brokerColumn��$ Courtier��5J   %   $
 auto 67    5I   ?   �� *broker.fullName+5J   7     5K      -   5        customerColumn��$ Client��5L   %   $
 auto 65    5K   A   �� *customer.fullName+5L   5     5M      -	   5        subjectColumn��$ Sujet��5N   %   $
 auto 64    5M   @   �� *	subject+5N   4   5P      �� 5T      $��1��6   $��2��6(   $��3��6<   $��Modification��6I   $��Center=�5U      $��20(�61   $��Segoe Print)�6?   $
��Bold"�5V      �� 5X      $��1��6   $��4��6)   $��Center=�66   $
��15,0q�6Q   .+�5Y      �� $��Choisissez un courtier��6   $��Center=�69   �� 5Z      -
   5        $��BrokerComboBox��5Z       �� DisplayMemberPath$ fullName��6I   ��61   ��  �� SelectedValue 5[      �� $	 appointmentDataGrid��$
 SelectedValue.idBroker��� 5\      -   5        $��idBrokerErrorMessage��5\      
���  �� �� TextAlignment$ Center=�6I   5]      �� 5_      $��2��6   $��4��6)   $��Center=�66   $
��15,0q�6Q   .+�5`      �� $��Choisissez un client��6   $��Center=�67   �� 5a      -   5        $��CustomerComboBox��5a      $ fullName��6K   ��63   ��  5b      �� $	 appointmentDataGrid��$
 SelectedValue.idCustomer��� 5c      -   5        $��idCustomerErrorMessage��5c      
���  ��$ Center=�6K   5d      �� 5f      $��1��6   $��2��6)   $��5��6=   $��Center=�6J   .+�5g        -   5        $��
DatePicker��5g      $��200,0q�60    5h      �� $	 appointmentDataGrid��$
 SelectedValue.datHour�5i      �� 5j      -   5        $��datePickerErrorMessage��5j      
���  ��$ Center=�6K   5k      �� 5m      $��1��6   $��6��6)   $
��15,0q�66   $��Center=�6D   .+�5n      �� $��Choisissez une heure��6   $��Center=�67   �� 5o      -   5        $��HoursTextBox��5o      ��6.   �� $	 appointmentDataGrid��$ 
 SelectedValue.timeSlotHour�$ OneWay=�5p      �� 5q      -   5        $��hoursErrorMessage��5q      
���  ��$ Center=�6F   5r      �� 5t      $��2��6   $��6��6)   $
��15,0q�66   $��Center=�6D   .+�5u      �� $��Choisissez les minutes��6   $��Center=�69   �� 5v      -   5        $��MinutesTextBox��5v      ��60   �� $	 appointmentDataGrid��$"
 SelectedValue.timeSlotMinute�$ OneWay=�5w      �� 5x      -   5        $��minutesErrorMessage��5x      
���  ��$ Center=�6H   5y      �� 5{      $��1��6   $��2��6*   $��7��6>   $��15,10q�6K   .+�5|      �� $��Sujet du rendez vous��6   $��Center=�67   $��Center=�5}      �� 5~      -   5        $��SubjectTextBox��5~      ��60   �� $	 appointmentDataGrid��$
 SelectedValue.subject��� 5      -   5        $��subjectErrorMessage��5      
���  ��$ Center=�6H   5�      �� 5�      -   5        $��Sauvegarder��5�      $��1��6+   $��8��6;   $��Center=�6H   $��Center=�5�      
��� � �6C   �� 5�      -   5        $��	Supprimer��5�      $��2��6)   $��8��69   $��Center=�6F   $��Center=�5�      
���  ��6A   5�      5�      5�      