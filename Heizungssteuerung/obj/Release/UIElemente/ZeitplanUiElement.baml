   M S B A M L   `   `   `  ���� L  HHeizungssteuerung, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:Heizungssteuerung.UIElementeHeizungssteuerung.UIElemente  4    .Heizungssteuerung.UIElemente.ZeitplanUiElement   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     9my*clr-namespace:Heizungssteuerung.UIElemente     -     >�Name$"  ZeitplanUiElementUserControl��.��� .+��� $
��Bold"�$��14(�$��25��$
��Left=�$��5,0,0,0q�$	��Top=�$	��200������  �� Path$% ZeitplanElement.WohneinheitText� �� ElementName$" ZeitplanUiElementUserControl���� $
��Bold"�$��14(�$��25��$
��Left=�$��	200,0,0,0q�$	��Top=�$	��150������ $( "ZeitplanElement.ZieltemperaturText�$" ZeitplanUiElementUserControl��;   5Heizungssteuerung.UIElemente.WochentageAuswahlElement  $��	10,30,0,0q�   ZeitplanElement �� $ ZeitplanElement�$" ZeitplanUiElementUserControl�� �� Mode$ TwoWay=��� $��14(�$
��Auto��$
��Left=�$��
200,20,0,0q�$	��Top=�$	��150������ $! ZeitplanElement.UhrzeitText�$" ZeitplanUiElementUserControl���� -   $��
370,10,0,0q�$��25��$��25��
�������
����ح�$y�Visible=� d� 	IsChecked �� $ ZeitplanElement.Aktiviert�$" ZeitplanUiElementUserControl�� � LayoutTransform ��  �� ScaleX$ 2Q� �� ScaleY$ 2Q�