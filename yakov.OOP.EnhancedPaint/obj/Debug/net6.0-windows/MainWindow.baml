   M S B A M L   `   `   `  ����R  Nyakov.OOP.EnhancedPaint, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:yakov.OOP.EnhancedPaintyakov.OOP.EnhancedPaint  5   	   (    "yakov.OOP.EnhancedPaint.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:yakov.OOP.EnhancedPaint     5   	   P LHaley.WPF, Version=3.0.0.0, Culture=neutral, PublicKeyToken=9b5f4902d3fea17a+hw"http://schemas.hpod9.com/haley/wpf  5   	   _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5   	   _ [MaterialDesignThemes.Wpf, Version=4.4.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  
MainWindow��5
   	   $	��650��6   $
��1100��6)      MaterialDesignBody#���   5   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5   	      TextRenderingMode$
 Auto=�5   	   
������   MaterialDesignFont#���  5   	    � 
ResizeMode$ CanResizeWithGrip=�5   	    � WindowStartupLocation$ CenterScreen=�5   	    � WindowStyle$
 None=�5   	    � AllowsTransparency$
 True��5   	   .��5      ��    MaterialDesignDarkBackground#��[ 6    �� CornerRadius$ 5��5      $��Stretch=�5      $��Stretch=�5      ._�5   
   �  � RowDefinitions 5      �� 5      $��25 �6    �� 5       $��50 �6    �� 5!      $��* �6    	 � ColumnDefinitions	 5$      �� 5%      $
��auto �6#   �� 5&      $��* �6#   .+�5)      �� -   5        $ 5,5,0,0��5)      $
��auto��6,     MaterialDesignShadowBrush#���  69   $��0��6r   $��2��6   $��Stretch=�5*      $��Stretch=�63   ._�5,      ]� .+�5-      �� $
��Left=�6   $�� ��62   $��12(�6=   $��Center=�6K   $��10,0,0,0q�6f   $
��auto��6x   �� 5/      -   5        
 ��Name$
 buttonClose��5/      $��Right=�62   $
��Auto��6I   $��24��6W   $��Right=�6b    & "MaterialDesignToolForegroundButton#��[ 6~   $��0,0,0,0q�50      .��51      �� $��/Close_32px.png��6    $��24��69   52      �� 54      -   5        $
 buttonMaximize��54      $��Right=�65   $
��Auto��6L   $��24��6Z   $��Right=�6e   #��[ 6�   $��0,0,0,0q�55      .��56      �� $��/maximize_button_32px.png��6    $��24��6C   57      �� 59      -   5        $
 buttonMinimize��59      $��Right=�65   $
��auto��6L   $��24��6Z   $��Right=�6e   #��[ 6�   $��0,0,0,0q�5:      .��5;      �� $��/subtract_32px.png��6    $��24��6<   5<      5=      5>      �� 5@         MaterialDesignCardBackground#���  6   $��1��6Q   $��1��6a   ._�5A      � .+�5B      ��  �� Orientation$ 
Horizontal=�6!   .+�5C      *  $Haley.WPF.Controls.ColorPickerButton  $	��110��6/   $��35��6;   
������  ! PrimaryHueDarkForegroundBrush#��[ 6`   $
��10,0q�5D   /   $��
Main color��6=   $��Comic Sans MS, Verdana)�6R   $��Medium"�5E   �      SelectedBrush 6/   �� *BorderColor+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�6�     5G      $	��110��6/   $��35��6;   
������ #��[ 6`   $
��10,0q�5H   /   $��
Fill color��6=   $��Comic Sans MS, Verdana)�6R   $��Medium"�5I   �    6/   �� *	FillColor+$ TwoWay=�$ PropertyChanged=�6�   �� 5K      $
��20,0q�6"   $	��100��60   $��35��6<   $��Center=�6H   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Pen size��5L   "   $��Center=�5M   "   $��Center=�6F   $��16(�5N   "   $��Comic Sans MS, Verdana)�60   ��5O   "   �� *BorderWidth+$ TwoWay=�$ PropertyChanged=��� 5Q      $��Clear canvas��6!   $��	20,0,10,0q�68   $��16(�5R   !   $��Comic Sans MS, Verdana)�6/    $  MaterialDesignFlatAccentBgButton#��[ 5S   !   ��5T   !   �� *ClearDrawspace+�� 5U      $��Load figures��6!   $
��10,0q�68   $��16(�5V   !   $��Comic Sans MS, Verdana)�6/    ) %MaterialDesignOutlinedSecondaryButton#��[ 5W   !   ��5X   !   �� *LoadFigures+�� 5Y      $��Save figures��6!   $
��10,0q�68   $��16(�5Z   !   $��Comic Sans MS, Verdana)�6/   #��[ 5[   !   ��5\   !   �� *SaveFigures+5]      �� 5_      $��	20,8,50,0q�6    $	��Top=�63   $��Right=�6K   $��14(�5`   "   $��width: ��60   $��Comic Sans MS, Verdana)�6?   �� 5a      $��	20,8,10,0q�6    $	��Top=�63   $��Right=�6K   $��14(�5b   "   $��Comic Sans MS, Verdana)�6S   ��60   �� *ChosedFigureWidth+6S   �� 5c      $��	20,0,50,8q�6    $��Bottom=�63   $��Right=�6N   $��14(�5d   "   $��height: ��60   $��Comic Sans MS, Verdana)�6@   �� 5e      $��	20,0,10,8q�6    $��Bottom=�63   $��Right=�6N   $��14(�5f   "   $��Comic Sans MS, Verdana)�6T   ��60   �� *ChosedFigureHeight+6T   5g      5h      �� 5j      -   5         ��Name$ borderToolsMenu��5j       	 AttentionToActionBrush#��� 	 5k      $��0��6K   $��1��6[   $��2��6h   $��50��5l      $��Stretch=�6    ._�5n      �  5p      �� 5q      $��50 �6(   �� 5r      $
��auto �6(   .+�5u      d� -   5         d�Name$ 
buttonMenu��5u   #    '
 #MaterialDesignHamburgerToggleButton#��[
 5v   #   $��35��5w   #   $��35��6.   
�������$��Right=�5x   #   $��7.5,0q�6?    � Triggers 5z      :� 5|       :� RoutedEvent$ ToggleButton.Checked��6+   [�5}   "   �� 5~   &   .��5   *   �� .��5�   .   W�  �� TargetProperty$ Width�6>    �� 
TargetName$ borderToolsMenu��6`   	 W� To 1755�   B    g� AutoReverse$ False��5�   B    g� Duration$ 0:0:0.5D�5�   B    W� EasingFunction 5�   2   0  *System.Windows.Media.Animation.QuarticEase  5�   6   7  1System.Windows.Media.Animation.EasingFunctionBase   
EasingMode$ 	EaseInOut=�6B   5�   /   �� 5�   .   $ Foreground.Color�6=   $ 
buttonMenu��6j   	 �� To
 Purple5�   A   $ 0:0:1D�6M   $
 True��6^    g� RepeatBehavior$ Forever��5�   A   5�   +   5�   '   5�      :� 5�      $ ToggleButton.Unchecked��6+   [�5�   "   �� 5�   &   .��5�   *   �� .��5�   .   W� $ Width�6>   $ borderToolsMenu��6`    505�   B   $ False��5�   B   $ 0:0:0.5D�5�   B    5�   2     5�   6   $ 	EaseInOut=�6B   5�   /   �� 5�   .   $ Foreground.Color�6=   $ 
buttonMenu��6j   	 White5�   A   $ 0:0:0.5D�6L   5�   +   5�   '   5�      5�      �� 5�      $��Bottom=�6    $��0q�6;   �� 5�      $��1��6!   .+�5�      �� $	��Top=�6#   $��0q�6;   $��0q�6F    + 'MaterialDesignToolVerticalToggleListBox#��[ 5�       �� SelectionMode$ Single=�5�       �� SelectedIndex 65   �� *	ToolIndex+$ PropertyChanged=�$ TwoWay=�.@�5�      �� $��50��6'   $��Right=�63   $��0q�6V   $��Center=�6b   .��5�      �� $ 
Horizontal=�6)   $��7.5,0q�6B   $��Right=�6Q   .+�5�   "   �� $��Pointer��6,   $��Comic Sans MS, Verdana)�6;   $��17(�6_   $��Center=�6n   $
��10,0q�6�   '  !MaterialDesignThemes.Wpf.PackIcon  5�   "   $��35��6:   $��35��6E      Kind$ CursorPointer=�6Q   5�      5�      �� 5�      $��50��6'   $��Right=�63   $��0q�6V   $��Center=�6b   .��5�      �� $ 
Horizontal=�6)   $��7.5,0q�6B   $��Right=�6Q   .+�5�   "   �� $
��Line��6,   $��Comic Sans MS, Verdana)�68   $��17(�6\   $��Center=�6k   $
��10,0q�6�     5�   "   $��35��6:   $��35��6E   $ Divide=�6Q   5�      5�      �� 5�      $��50��6'   $��Right=�63   $��0q�6V   $��Center=�6b   .��5�      �� $ 
Horizontal=�6)   $��7.5,0q�6B   $��Right=�6Q   .+�5�   "   �� $��	Rectangle��6,   $��Comic Sans MS, Verdana)�6=   $��17(�6a   $��Center=�6p   $
��10,0q�6�     5�   "   $��35��6:   $��35��6E   $ 	Rectangle=�6Q   5�      5�      �� 5�      $��50��6'   $��Right=�63   $��0q�6V   $��Center=�6b   .��5�      �� $ 
Horizontal=�6)   $��7.5,0q�6B   $��Right=�6Q   .+�5�   "   �� $��Rounded rect��6,   $��Comic Sans MS, Verdana)�6@   $��17(�6d   $��Center=�6s   $
��10,0q�6�     5�   "   $��35��6:   $��35��6E   $ SquareRounded=�6Q   5�      5�      �� 5�      $��50��6'   $��Right=�63   $��0q�6V   $��Center=�6b   .��5�      �� $ 
Horizontal=�6)   $��7.5,0q�6B   $��Right=�6Q   .+�5�   "   �� $��Square��6,   $��Comic Sans MS, Verdana)�6:   $��17(�6^   $��Center=�6m   $
��10,0q�6�     5�   "   $��35��6:   $��35��6E   $ Square=�6Q   5�      5�      �� 5�      $��50��6'   $��Right=�63   $��0q�6V   $��Center=�6b   .��5�      �� $ 
Horizontal=�6)   $��7.5,0q�6B   $��Right=�6Q   .+�5�   "   �� $��Ellipse��6,   $��Comic Sans MS, Verdana)�6;   $��17(�6_   $��Center=�6n   $
��10,0q�6�     5�   "   $��35��6:   $��35��6E   $ Ellipse=�6Q   5�      5�      �� 5�      $��50��6'   $��Right=�63   $��0q�6V   $��Center=�6b   $��0,0,0,0q�6�   .��5�      �� $ 
Horizontal=�6)   $��7.5,0q�6B   $��Right=�6Q   .+�5�   "   �� $��Circle��6,   $��Comic Sans MS, Verdana)�6:   $��17(�6^   $��Center=�6m   $
��10,0q�6�     5�   "   $��35��6:   $��35��6E   $ Circle=�6Q   5�      5�      �� 5�      $��50��6'   $��Right=�63   $��0q�6V   $��Center=�6b   .��5�      �� $ 
Horizontal=�6)   $��7.5,0q�6B   $��Right=�6Q   .+�5�   "   �� $��Eraser��6,   $��Comic Sans MS, Verdana)�6:   $��17(�6^   $��Center=�6m   $
��10,0q�6�     5�   "   $��35��6:   $��35��6E   $ Eraser=�6Q   5�      5�      5�      �� 5�      $��0q�6$   $��Bottom=�6/   �� 5�      $ 
Horizontal=�6%   $��7.5,10q�6>   $��Right=�6N   .+�5�      �� $��	Archiving��6(   $��Comic Sans MS, Verdana)�69   $��17(�6]   $��Center=�5�   (   $
��10,0q�6C     SecondaryHueMidBrush#��[ 5�   (   d� 5�       * &MaterialDesignSwitchAccentToggleButton#��[ 6+     d� 	IsChecked  5�   +   �� *IsArchiving+5�      �� 5�      $ 
Horizontal=�6%   $��7.5,10q�6>   $��Right=�6N   .+�5�      �� $��Crypting��6(   $��Comic Sans MS, Verdana)�68   $��17(�6\   $��Center=�5�   (   $
��10,0q�6C   #��[ 5�   (   d� 5�      #��[ 6+     5�   +   �� *
IsCrypting+5�      5�      5�      5�      �� 5�      $��1��6   $��2��6%   ._�5�      �� -   5        ! ��Name$! 	drawspace��5�      
�������*  $Microsoft.Xaml.Behaviors.Interaction"   Triggers" 5�      +  %Microsoft.Xaml.Behaviors.EventTrigger  5�      #   	EventName$# MouseLeftButtonDown��6)   *	  $Microsoft.Xaml.Behaviors.TriggerBase$ 	  Actions.$ 5�      2
  ,Microsoft.Xaml.Behaviors.InvokeCommandAction
  % 
  Command% 64   �� *LeftButtonDown+5�        5      $# MouseLeftButtonUp��6)   .$ 5     
  % 64   �� *LeftButtonUp+5       5     $# 	MouseMove��6)   .$ 5     
  % 64   �� *LeftButtonDrag+5       5     $# 
MouseEnter��6)   .$ 5     
  % 64   �� *MouseCanvasEnter+5     5
     5     5     5     5     