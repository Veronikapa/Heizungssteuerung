   M S B A M L   `   `   `  ���� L  HHeizungssteuerung, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:Heizungssteuerung.UIElementeHeizungssteuerung.UIElemente  7    1Heizungssteuerung.UIElemente.WohneinheitUiElement   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     9my*clr-namespace:Heizungssteuerung.UIElemente     -     >�Name$%  WohneinheitUiElementUserControl��.��� .+��� $
��Bold"�$��14(�$��25��$
��Left=�$��0,48,0,0q�$	��Top=�$	��112������  �� Path$&  WohneinheitElement.WohneinheitId� �� ElementName$% WohneinheitUiElementUserControl���� $
��Bold"�$��14(�$��25��$
��Left=�$��
149,48,0,0q�$	��Top=�$��50������ $+ %WohneinheitElement.AktuelleTemperatur�$% WohneinheitUiElementUserControl�� �� Mode$ TwoWay=��� $
��Bold"�$��14(�$��25��$
��Left=�$��
260,48,0,0q�$	��Top=�$��50������ $' !WohneinheitElement.ZielTemperatur�$% WohneinheitUiElementUserControl���� -   $��25��$��30��$
��Left=�
������ $��0q�$��260,10,0,86q�.���� $8��2pack://application:,,,/Icons/Prev_Schwarz_Icon.gif��$��15��$��20���� -   $��25��$��30��$
��Left=�
������ $��0q�$��260,86,0,10q�.���� $8��2pack://application:,,,/Icons/Next_Schwarz_Icon.gif��$��15��$��20���� $2��,pack://application:,,,/Icons/Thermometer.gif��$
��Left=�$��60��$��
117,30,0,0q�$	��Top=�$��27�� J� RenderTransformOrigin$ 
6.938,1.31&��� $2��,pack://application:,,,/Icons/Thermometer.gif��$
��Left=�$��60��$��
215,30,0,0q�$	��Top=�$��25��$ 
6.938,1.31&��� -    ��Name$ 	FeuerIcon��$y�Hidden=�$-��'pack://application:,,,/Icons/Flamme.gif��$
��Left=�$��50��$��
315,35,0,0q�$	��Top=�$��50��$ 
6.938,1.31&��� -   $ 	FrostIcon��$y�Hidden=�$3��-pack://application:,,,/Icons/Schneeflocke.gif��$
��Left=�$��50��$��
315,35,0,0q�$	��Top=�$��50��$ 
6.938,1.31&��� -   $ FensterIcon��$y�Hidden=�$2��,pack://application:,,,/Icons/FensterIcon.gif��$
��Left=�$��50��$��
315,35,0,0q�$	��Top=�$��50��$ 
6.938,1.31&��� -   $ 	StoerIcon��$y�Hidden=�$0��*pack://application:,,,/Icons/StoerIcon.gif��$
��Left=�$��50��$��
315,35,0,0q�$	��Top=�$��50��$ 
6.938,1.31&��� -   $ MultipleIcon��$y�Hidden=�$3��-pack://application:,,,/Icons/MultipleIcon.gif��$
��Left=�$��50��$��
315,35,0,0q�$	��Top=�$��50��$ 
6.938,1.31&��� $��Aktuell��$
��Left=�$��	106,4,0,0q�$	��Top=��� $
��Ziel��$
��Left=�$��	210,4,0,0q�$	��Top=�