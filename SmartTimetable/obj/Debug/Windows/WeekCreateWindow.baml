   M S B A M L   `   `   `  ����I  ESmartTimetable, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:SmartTimetable.WindowsSmartTimetable.Windows  5   	   E'clr-namespace:SmartTimetable.ViewModelsSmartTimetable.ViewModels  6<   -    'SmartTimetable.Windows.WeekCreateWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:SmartTimetable.Windows     5   	   >
viewmodels'clr-namespace:SmartTimetable.ViewModels     6<     � Title$  WeekCreateWindow��5   	   $	��150��6"   $	��300��6/    � 
ResizeMode$ NoResize=�6;    � DataContext 5	      2  ,SmartTimetable.ViewModels.WeekCreateWindowVM  5
   
   6*    � 	Resources 5         ttt �� 
TargetType&   System.Windows.Controls.Calendar �� Property �� Value��%�   &	        �� 5   
   "  6   .�5      ��  �@ SelectionMode$ 
SingleDate=�6.   �� 5       �@ DisplayMode$ Decade=�6,   �� 5       �@ DisplayDate$  ��6,   5      5      .��5      � .+�5   
   (  "System.Windows.Controls.DatePicker  $��Center=�6      CalendarStyle# [  62   $��Center=�6X      IsTodayHighlighted . 	   FirstDayOfWeek$	 Monday=�6�   
   SelectedDate
 6s   �� *
dateFrom+6�   �� 5   
     bAdd#���  6   $��Bottom=�62   $��Center=�6M   $��0,0,0,10q�6j   $��75��6|   ��6�   �� *	AddWeek+�� 5   
     WeekAddingDesc#���  6   $	��Top=�6<   $��Center=�6T   5      5      