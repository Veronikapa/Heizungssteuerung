   M S B A M L   `   `   `  ���� L  HHeizungssteuerung, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:Heizungssteuerung.UIElementeHeizungssteuerung.UIElemente  ,    &Heizungssteuerung.ZeitplanNeuEditieren   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     9my*clr-namespace:Heizungssteuerung.UIElemente     -     �Name$  ZeitplanNeuUserControl��$	��600��$	��420�� � WindowStartupLocation$ CenterScreen=�.��� .+���  �� Orientation$ Vertical=�.+��� $��Wohneinheit��$��0,5,0,0q�
�������
����d�.��� .+��� $ 
Horizontal=�.+�	� -   $��rdb_Gebaeude��$��Gebäude��$
��Left=�$��	10,10,0,0q�$	��Top=� d� 	IsChecked$
 TrueY�	� -   $��rdb_Stockwerk��$��	Stockwerk��$
��Left=�$��	90,10,0,0q�$	��Top=�$ FalseY�	� -   $��rdb_Raum��$
��Raum��$
��Left=�$��	90,10,0,0q�$	��Top=�$ FalseY��� $��	10,40,0,0q�$	��Top=�$ 
Horizontal=�.+��� $ 
Horizontal=�.+�4   .Heizungssteuerung.UIElemente.Prev_Next_Element  -     Name$ GebaeudeElement��   IstStringListe . $	��100��$	��100��   StringListe �� *GebaeudeListe+ �� ElementName$ ZeitplanNeuUserControl�� �� Mode$ TwoWay=�	 �� UpdateSourceTrigger$	 PropertyChanged=�
 �� NotifyOnSourceUpdated
 .   -   $ StockwerkElement�� . $	��100��$	��100��$��
-100,0,0,0q� �� *StockwerkListe+$ ZeitplanNeuUserControl��$ TwoWay=�$	 PropertyChanged=�
 .   -   $ RaumElement�� . $	��100��$	��100�� �� *	RaumListe+$ ZeitplanNeuUserControl��$ TwoWay=�  -   $ TemperaturElement��   IstTemperatur .    AktuellerWert$ 25��$	��100��$	��100��   MinWert$ 0��   MaxWert$ 35���� $��
Wochentage��
����d�
�������.���� $ 
Horizontal=�.+�;   5Heizungssteuerung.UIElemente.WochentageAuswahlElement  -	     Name$ 
Wochentage��$
��Left=�$��	10,10,0,0q�$	��Top=��� -
    ��Name$ chb_Ganztags��$ FalseY�$��	70,10,0,0q�$��Ganztags���� $��Uhrzeit��$��0,10,0,0q�
����d�
�������.���� $��	10,10,0,0q�$	��Top=�$ 
Horizontal=�.+�  -   $ StundeVonElement��   
IstUhrzeit .    	IstMinute .  $ 0��$ 0��$ 23��$	��100��$��50���� $	�� : ��$��Center=�$��Center=�$��16(�  -   $ MinuteVonElement�� .  . $ 0��$ 0��$ 59��$	��100��$��50���� $��          - ��$��Center=�$��Center=�$��16(�$	��100��  -   $ StundeBisElement�� .  .  $ 0��$ 0��$ 23��$	��100��$��50���� $	�� : ��$��Center=�$��Center=�$��16(�  -   $ MinuteBisElement�� .  . $ 0��$ 0��$ 59��$	��100��$��50���� $��Informationen��
����d�
�������.���� $��	10,10,0,0q�$	��100��.+��� -    ��Name$ lbl_UhrzeitInvalid��$y�Hidden=�
���  ��$��0��.���� .,'Uhrzeit von' muss vor 'Uhrzeit bis' liegen.�� A?Bitte Korrigieren Sie die Uhrzeiten und bestätigen Sie erneut!�� -   $ lbl_ElementInvalid��$y�Hidden=�
���  ��$��0��.���� B@'Dieser Zeitplan überschneidet sich mit einem aktiven Zeitplan.�� :8Bitte Korrigieren Sie den Zeitplan oder deaktivieren Sie�� überschneidende Zeitpläne.�� $��35��$ 
Horizontal=�$��Bottom=�
�������$��0,10,0,0q�.+��� -   $��25��$
��Left=�$��Center=�$��10,5,0,5q�$	��100��
�������$��	Speichern���� -   $��25��$
��Left=�$��Center=�$��45,5,0,5q�$	��100��
�������$��Löschen���� -   $��25��$��Right=�$��Center=�$��45,5,0,5q�$	��100��
�������$��	Abbrechen��