   M S B A M L   `   `   `  ����   блокнотик в впф     DailyPlannerWPF.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Ежедневник��5   	   $	��450��6   $	��932��6)   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��Center=�6"    �� Orientation$ 
Horizontal=�6?   $
��0 10q�6X   .+�5      �� $��Название:��6   �� 5      -   5         ��Name$ TitleTextBox��5      $	��200��6,   $
��10 0q�68   �� 5      $��Описание:��6   �� 5      -   5        $ DescriptionTextBox��5      $	��200��62   $
��10 0q�6>   �� 5      $$��Дата выполнения:��6   (  "System.Windows.Controls.DatePicker  5      -   5          Name$ 
DatePicker��5      $
��10 0q�6-   �� 5      -   5        $��Добавить��5      6(   5      �� 5   
   -   5         ��Name$ NotesListBox��5      $��1��6(   $��	20,0,0,10q�65    �� DisplayMemberPath$ Title��6H    �� SelectionMode$ Single=�5      $��Stretch=�6)   6N   �� 5   
   $��1��6   $��Right=�6"   $	��Top=�6>   $
��0 10q�6V   .+�5      �� -   5         ��Name$ NotesCountLabel��5      �� 5      -   5        $��Удалить��5      $��24��6:   5      5      5      