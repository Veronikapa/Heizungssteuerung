   M S B A M L   `   `   `  ����L  HHeizungssteuerung, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:Heizungssteuerung.UIElementeHeizungssteuerung.UIElemente  5      7    1Heizungssteuerung.UIElemente.WohneinheitUiElement   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9my*clr-namespace:Heizungssteuerung.UIElemente     5      -   5          >�Name$%  WohneinheitUiElementUserControl��5   #   .��5	      � .+�5
   
   �� $
��Bold"�6�   $��14(�6�   $��25��6�   $
��Left=�6�   $��0,48,0,0q�6�   $	��Top=�6�   $	��112��6�   ��6   ��  �� Path$&  WohneinheitElement.WohneinheitId� �� ElementName$% WohneinheitUiElementUserControl�� �� Mode$ TwoWay=���6  �� $ ForegroundColor�$% WohneinheitUiElementUserControl���� 5   
   $
��Bold"�6�   $��14(�6�   $��25��6�   $
��Left=�6�   $	��Top=�6  $��50��67  ��6   �� $+ %WohneinheitElement.AktuelleTemperatur�$% WohneinheitUiElementUserControl��$ TwoWay=���6�   �� $ 	MarginOne�$% WohneinheitUiElementUserControl����6B  �� $ ForegroundColor�$% WohneinheitUiElementUserControl���� 5   
   $
��Bold"�6x   $��14(�6�   $��25��6�   $
��Left=�6�   $	��Top=�6  $��50��6&  ��6   �� $' !WohneinheitElement.ZielTemperatur�$% WohneinheitUiElementUserControl����6�   �� $ 	MarginTwo�$% WohneinheitUiElementUserControl����61  �� $ ForegroundColor�$% WohneinheitUiElementUserControl���� 5   
   -   5        $��25��5      $��30��6   $
��Left=�6(   
�������$��0q�6Z   ��6n   �� $ MarginThree�$% WohneinheitUiElementUserControl��.��5      �� $<��6pack://application:,,,/Icons/Increase_Schwarz_Icon.gif��6   $��15��6T   $��20��6`   5      �� 5   
   -   5        $��25��5      $��30��6   $
��Left=�6(   
�������$��0q�6Z   ��6n   �� $ 
MarginFour�$% WohneinheitUiElementUserControl��.��5      �� $<��6pack://application:,,,/Icons/Decrease_Schwarz_Icon.gif��6   $��15��6T   $��20��6`   5      �� 5   
   -   5         ��Name$ 	FeuerIcon��5      $y�Hidden=�6#   $��Right=�6�   $��50��6�   $	��Top=�6�   $��50��6   J� RenderTransformOrigin$ 
6.938,1.31&�6  ��67   �� $ Feuer�$% WohneinheitUiElementUserControl����6�   �� $ 
MarginFive�$% WohneinheitUiElementUserControl��6  �� 5   
   -   5        $ 	FrostIcon��5      $y�Hidden=�6#   $��Right=�6�   $��50��6�   $	��Top=�6�   $��50��6  $ 
6.938,1.31&�6  ��67   �� $ Frost�$% WohneinheitUiElementUserControl����6�   �� $ 
MarginFive�$% WohneinheitUiElementUserControl��6  �� 5   
   -   5        $ FensterIcon��5      $y�Hidden=�6%   $��Right=�6�   $��50��6�   $	��Top=�6�   $��50��6  $ 
6.938,1.31&�6!  ��69   �� $ Fenster�$% WohneinheitUiElementUserControl����6�   �� $ 
MarginFive�$% WohneinheitUiElementUserControl��6!  �� 5   
   -   5        $ FeuerFensterIcon��5      $y�Hidden=�6*   $��Right=�6�   $��50��6�   $	��Top=�6  $��50��6   $ 
6.938,1.31&�6+  ��6>   �� $ FeuerFenster�$% WohneinheitUiElementUserControl����6�   �� $ 
MarginFive�$% WohneinheitUiElementUserControl��6+  �� 5   
   -   5        $ FrostFensterIcon��5      $y�Hidden=�6*   $��Right=�6�   $��50��6�   $	��Top=�6  $��50��6   $ 
6.938,1.31&�6+  ��6>   �� $ FrostFenster�$% WohneinheitUiElementUserControl����6�   �� $ 
MarginFive�$% WohneinheitUiElementUserControl��6+  �� 5   
   ���	#FFF4F4F5$��Stretch=�6%   $��1��6C   $��	0,119,0,0q�6N   
���   �$	��Top=�6p   5      5      