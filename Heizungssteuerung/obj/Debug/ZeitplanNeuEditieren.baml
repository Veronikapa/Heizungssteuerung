   M S B A M L   `   `   `  ����L  HHeizungssteuerung, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:Heizungssteuerung.UIElementeHeizungssteuerung.UIElemente  5   	   ,    &Heizungssteuerung.ZeitplanNeuEditieren   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   9my*clr-namespace:Heizungssteuerung.UIElemente     5   	   -   5          �Name$  ZeitplanNeuUserControl��5   "   $	��600��6	   $	��420��6    � WindowStartupLocation$ CenterScreen=�6B   .��5      � .+�5   
   ��  �� Orientation$ Vertical=�6   .+�5	      �� $��Wohneinheit��6   $��0,5,0,0q�6,   
�������
����d�.��5
      � .+�5      �� $ 
Horizontal=�6!   .+�5      	� -   5        $��rdb_Gebaeude��5   &   $��Gebäude��6:   $
��Left=�6L   $��	10,10,0,0q�6g   $	��Top=�6z    d� 	IsChecked$
 TrueY�6�   6�   	� 5      -   5        $��rdb_Stockwerk��5   &   $��	Stockwerk��6;   $
��Left=�6O   $��	90,10,0,0q�6j   $	��Top=�6}   $ FalseY�6�   6�   	� 5      -   5        $��rdb_Raum��5   &   $
��Raum��66   $
��Left=�6E   $��	90,10,0,0q�6`   $	��Top=�6s   $ FalseY�6�   6�   5      �� 5      $��	10,40,0,0q�6!   $	��Top=�64   $ 
Horizontal=�6L   .+�5      �� $ 
Horizontal=�6%   .+�5      4   .Heizungssteuerung.UIElemente.Prev_Next_Element  -   5          Name$ GebaeudeElement��5   3      IstStringListe . $	��100��6�   $	��100��6     StringListe 6b   �� *GebaeudeListe+ �� ElementName$ ZeitplanNeuUserControl�� �� Mode$ TwoWay=�	 �� UpdateSourceTrigger$	 PropertyChanged=�
 �� NotifyOnSourceUpdated
 . 6    5      -   5        $ StockwerkElement��5   3    . $	��100��6�   $	��100��6	  $��
-100,0,0,0q�6   6c   �� *StockwerkListe+$ ZeitplanNeuUserControl��$ TwoWay=�$	 PropertyChanged=�
 . 6  5        5      -   5        $ RaumElement��5   /    . $	��100��6�   $	��100��6�    6Z   �� *	RaumListe+$ ZeitplanNeuUserControl��$ TwoWay=�6�     5      -   5        $ TemperaturElement��5   /      IstTemperatur .    AktuellerWert$ 25��6_   $	��100��6r   $	��100��6      MinWert$ 0��6�      MaxWert$ 35��6�   5      5      5      �� 5      $��
Wochentage��6   
����d�
�������.��5      �� $ 
Horizontal=�6   .+�5      ;   5Heizungssteuerung.UIElemente.WochentageAuswahlElement  -	   5          Name$ 
Wochentage��5   2   $
��Left=�6F   $��	10,10,0,0q�6a   $	��Top=�6t   �� 5      -
   5         ��Name$ chb_Ganztags��5      $ FalseY�65   $��	70,10,0,0q�6�   $��Ganztags��6�   5      5       �� 5"      $��Uhrzeit��6   $��0,10,0,0q�6(   
����d�
�������.��5#      �� $��	10,10,0,0q�6   $	��Top=�60   $ 
Horizontal=�6H   .+�5$        -   5        $ StundeVonElement��5$   +      
IstUhrzeit .    	IstMinute .  $ 0��6i   $ 0��6{   $ 23��6�   $	��100��6�   $��50��6�   �� 5%      $	�� : ��6   $��Center=�6+   $��Center=�6F   $��16(�6c     5&      -   5        $ MinuteVonElement��5&   +    .  . $ 0��6h   $ 0��6z   $ 59��6�   $	��100��6�   $��50��6�   �� 5'      $��          - ��6   $��Center=�64   $��Center=�6O   $��16(�6l   $	��100��6z     5(      -   5        $ StundeBisElement��5(   +    .  .  $ 0��6i   $ 0��6{   $ 23��6�   $	��100��6�   $��50��6�   �� 5)      $	�� : ��6   $��Center=�6+   $��Center=�6F   $��16(�6c     5*      -   5        $ MinuteBisElement��5*   +    .  . $ 0��6h   $ 0��6z   $ 59��6�   $	��100��6�   $��50��6�   5+      5,      �� 5.      $��Informationen��6   
����d�
�������.��5/      �� $��	10,10,0,0q�6   $	��100��60   .+�50      �� -   5         ��Name$ lbl_UhrzeitInvalid��50      $y�Hidden=�68   
���  ��$��0��6]   .��51      �� .,'Uhrzeit von' muss vor 'Uhrzeit bis' liegen.�� 6R   A?Bitte Korrigieren Sie die Uhrzeiten und bestätigen Sie erneut!6�   52      �� 53      -   5        $ lbl_ElementInvalid��53      $y�Hidden=�68   
���  ��$��0��6]   .��54      �� B@'Dieser Zeitplan überschneidet sich mit einem aktiven Zeitplan.�� 6e   :8Bitte Korrigieren Sie den Zeitplan oder deaktivieren Sie�� 6�   überschneidende Zeitpläne.6�   55      56      57      �� 59      $��35��6   $ 
Horizontal=�6%   $��Bottom=�6>   
�������$��0,10,0,0q�6q   .+�5:      �� -   5        $��25��5:      $
��Left=�6%   $��Center=�6@   $��10,5,0,5q�6[   $	��100��6m   
�������$��	Speichern��6�   6�   �� 5;      -   5        $��25��5;      $
��Left=�6%   $��Center=�6@   $��45,5,0,5q�6[   $	��100��6m   
�������$��Löschen��6�   6�   �� 5<      -   5        $��25��5<      $��Right=�6%   $��Center=�6A   $��45,5,0,5q�6\   $	��100��6n   
�������$��	Abbrechen��6�   6�   5=      5>      5?       � 	Resources 5A       �� MergedDictionaries �� Source�� 5B   
    5C      �� 5D      $F @/Heizungssteuerung;component/UIElemente/IncreaseButtonStyle.xaml?�6%   �� 5E      $F @/Heizungssteuerung;component/UIElemente/DecreaseButtonStyle.xaml?�6%   %    5H      5J      