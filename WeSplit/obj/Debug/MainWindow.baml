   M S B A M L   `   `   `  ����B  >WeSplit, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:WeSplit.UserControlWeSplitWeSplit.UserControlWeSplit  5   	   !clr-namespace:WeSplitWeSplit  5   	       WeSplit.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   :userControl(clr-namespace:WeSplit.UserControlWeSplit  5   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5	   	   !localclr-namespace:WeSplit  5   	   -   5        $��
mainWindow��5   	      MaterialDesignBody#���   5   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	     MainViewModel � DataContext# [ 5   	    � 
ResizeMode$ NoResize=�5   	    � WindowStyle$
 None=�5   	    � WindowStartupLocation$ CenterScreen=�5   	    � Title$ Main Window��5   	   $	��600��6   $
��1000��6*   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5       $
��Auto �6   �� 5!      $��* �6   .+�5$   
   � $��0��6   .+�5&      -   'WeSplit.UserControlWeSplit.ControlBarUC  
 � Tag 6'   �� *	IsShowScr+5(      � 5)   
   $��1��6   .+�5+      �� 	 �� Orientation$	 
Horizontal=�6   $��4q�62   .+�5,      	� -   5           MaterialDesignTabRadioButton#��[ 5,   4   $��4q�5-      
 d� 	IsChecked$

 TrueY�6)   $��Trang chủ��6:   	� 5.      -   5        #��[ 5.   :   $��4q�5/      $
 FalseY�6)   $��Tạo mới chuyến đi��6;   	� 50      -   5        #��[ 50   8   $��4q�51      $
 FalseY�6)   $��Tạo mới địa danh��6;   	� 52      -   5        #��[ 52   6   $��4q�53      $
 FalseY�6)   $��Thành viên��6;   	� 54      #��[ 6   $��4q�55      $
 FalseY�6)   $��Về chúng tôi��6;   56      58      -   'WeSplit.UserControlWeSplit.AddJourneyUC  5H   
   -   5          Name$ NewJourneyUC��5H   K   $��2��6a   y�6#   �� *IsInAddJourneyUC+5I      )   #WeSplit.UserControlWeSplit.DetailUC  5J   
   -   5          Name$ DetailJourneyUC��5J   D   $��2��6]   y�6   �� *IsInDetailUC+5K      0   *WeSplit.UserControlWeSplit.ManagerMemberUC  5L   
   -   5          Name$ ManagerMemberUC��5L   Q   $��2��6j   y�6&   �� *IsInManagerMemberUC+5M      )   #WeSplit.UserControlWeSplit.AddPlace  5N   
   -	   5          Name$ 
NewPlaceUC��5N   C   $��2��6W   y�6   �� *IsInAddPlace+5O      ,   &WeSplit.UserControlWeSplit.AddMemberUC  5P   
   -
   5          Name$ NewMemberUC��5P   I   $��2��6^   y�6"   �� *IsInAddMemberUC+5Q      .   (WeSplit.UserControlWeSplit.HomeContentUC  5R   
   -   5          Name$ HomeUC��5R   K   $��2��6[   y�6$   �� *IsInHomeContent+5S      -	   'WeSplit.UserControlWeSplit.EditMemberUC	  5T   
   -   5         	 Name$ EditMemberUC��5T   I   $��2��6_   y�6#   �� *IsInEditMember+5U      5W      5X      