   M S B A M L   `   `   `  ����I  ESmartTimetable, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:SmartTimetableSmartTimetable  5   	   E'clr-namespace:SmartTimetable.ViewModelsSmartTimetable.ViewModels  5   	       SmartTimetable.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:SmartTimetable     5   	   >
viewmodels'clr-namespace:SmartTimetable.ViewModels     5   	   Ishell9http://schemas.microsoft.com/netfx/2009/xaml/presentation    5   	     � Title$  
MainWindow��5
   	   $	��450��6   $	��800��6)    � 
ResizeMode$ CanResizeWithGrip=�65   
���  �����	#FF8F8F8F$��1q�6}   $��Center=�6�   $��Center=�6�    � AllowsTransparency .   � WindowStyle$
 None=�6�    J� SnapsToDevicePixels .  ��5      �� 5   
    �� 
TargetType" �6   .�5      �� '  !System.Windows.Shell.WindowChrome �� Property �@ WindowChrome �� Value 5        5         CaptionHeight$ 0Q�6)   	   CornerRadius$	 0��5   )   
   GlassFrameThickness$
 0,0,0,0q�5   )      NonClientFrameEdges$
 None=�5   )      ResizeBorderThickness$ 5q�5   )      UseAeroCaptionButtons .  5   )   5      5       � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5!      �� 5"      $= 7/Resources/Templates/MainWindow/NavButtonAnimation.xaml?�6%   �� 5#      $' !/Resources/Colors/MainColors.xaml?�6%   �� 5$      $ /Resources/Icons.xaml?�6%   �� 5%      $4 ./Resources/Templates/WindowControlButtons.xaml?�6%   �� 5&      $8 2/Resources/Templates/MainWindow/SettingButton.xaml?�6%   �� 5'      $/ )/Resources/Templates/WeekListButtons.xaml?�6%   %    5)       � DataContext 5-      -  'SmartTimetable.ViewModels.MainViewModel  5.   
   6%   .��51      � 
�������.+�52   
   ]� ��. $��0,0,0,0q�6)   .+�53      � $	��Top=�6   $��30��6(   $	��Top=�64      Color_MainWindow#���   6L   .+�54      ��   ProgramName#���  6    # Color_ProgramNameLaberForecolor#���  6@   $��10,0,0,0q�6�   $
��Left=�6�   $��Center=�6�   $��12(�6�   �� 55      -   5        $��pb_Logo��55   s   $
��Left=�6   $��30��63   $��30��6?   $��2,0,0,0q�6J   $	��Top=�6[   6s   �� 57      $��50��6   $��30��6K   $��0,0,0,0q�6W   $��Right=�6h   $	��Top=�6�     
ExitButton#���  6�   ��6$   �� *CloseWindowCommand+6�   �� 58      $��50��6   $��30��6N   $��0,0,50,0q�6Z   $��Right=�6l   $	��Top=�6�     MaximizeButton#���  6�   ��6$   �� *MaximizeWindowCommand+6�   �� 59      $��50��6   $��30��6N   $��	0,0,100,0q�6Z   $��Right=�6m   $	��Top=�6�     MinimizeButton#���  6�   ��6$   �� *MinimizeWindowCommand+6�   �� 5:      $��30��6   $��30��6$   $��	0,0,155,0q�60   $��Right=�6C   $	��Top=�6_     SettingButton#���  6w   5;      �� 5<      $	��Top=�6   $��40��6.   $	��Top=�6:   #���   6R    �� Orientation$ 
Horizontal=�6�   .+�5=      	� -   5        $��b_Timetable��5=        MainNavigationButtonAnim#���  6D     WithoutBackgroundAnim#���  6w   $��10,0,0,0q�6�   $
��Left=�6�    	 
bTimetable#��� 	 6�   $��20(�6   
 Color_MainNavButtons#��� 
 6!   	� 	GroupName$ NavButtonGoup��6U  ��6   �� *GoToTimetablePage+6U  	� 5>      -   5        $��
b_Subjects��5>     #���  6F   #���  6z   $��25,0,0,0q�6�   $
��Left=�6�     	bSubjects#���  6�   $��20(�6  #��� 
 6"  $ NavButtonGoup��6V  ��6   �� *GoToSubjectPagePage+6V  	� 5?      -   5        $��
b_Teachers��5?   �   #���  6@   #���  6u   $��25,0,0,0q�6�   $
��Left=�6�     	bTeachers#���  6�   $��20(�6  #��� 
 6  $ NavButtonGoup��6P  ��6   �� *GoToStuffPage+6P  	� 5@      -   5        $��b_Groups��5@   �   #���  6@   #���  6u   $��25,0,0,0q�6�   $
��Left=�6�     bGroups#���  6�   $��20(�6
  #��� 
 6  $ NavButtonGoup��6L  ��6   �� *GoToGroupPage+6L  	� 5A      -   5        $��	b_Courses��5A   �   #���  6A   #���  6v   $��25,0,0,0q�6�   $
��Left=�6�     bCourses#���  6�   $��20(�6  #��� 
 6  $ NavButtonGoup��6O  ��6   �� *GoToCoursePage+6O  5B      �� 5C      	 �� X1$ 0��6   	 �� Y1$ 0��6   	 �� Y2$ 0��6!    ! Color_MainNavButtonsUnderline#���  6(   $	��Top=�6a   $��3��6v   	 �� X2$	 860��6�    �� Stretch$ UniformToFill=�6�   $��0,0,0,0q�6�    �� StrokeDashCap$ Square=�6�    �� StrokeDashArray$	 0 0R�6�    � 5D      $��Bottom=�6   
���   �  � NavigationUIVisibility$ Hidden=�6_   ��6?   �� *CurrentPage+6_   5F      5H      5I      