   M S B A M L   `   `   `  ���� L  HHeizungssteuerung, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:Heizungssteuerung.BackendHeizungssteuerung.Backend  0    *Heizungssteuerung.MainFensterstatusPruefen   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     9local'clr-namespace:Heizungssteuerung.Backend     -     �Name$$  MainFensterStatusPruefenWindow�� � Title$ Fensterstatus prüfen��$	��700��$	��500��.��� .+��� $��25��$	��Top=� �� Orientation$ 
Horizontal=�
�������.+��� -   $��25��$��30��$
��Left=�
������ $��0q�.���� $3��-pack://application:,,,/Icons/Zurueck_Icon.gif���� -    ��Name$ FensterstatusPanel��$��0,25,0,0q�$ Vertical=�.+�� $
��Left=�$��57��$	��492��
�������.+�	� -    	�Name$ rdbtbn_alle��$
��Left=�$��	18,11,0,7q�$	��109��
������� J� RenderTransformOrigin$ 0.5,0.5&� d� 	IsChecked$
 TrueY�.���� -    ��Name$ alleFenster��$
��Wrap=� �� TextAlignment$ Center=�$��38��$��87��$��Center=�$��Center=��� $�Alle Fenster ���� �� $�Anzeigen��	� -   $ rdbtn_offen��$
��Left=�$��37��$��
171,13,0,0q�$	��Top=�$	��146��.���� $
��Wrap=�$ Center=�$��37��$��97���� $�Offene Fenster ���� �� $�anzeigen��	� -   $ rdbtn_zu��$
��Left=�$��34��$��
335,13,0,0q�$	��Top=�$	��147��.���� $#��Geschlossene Fenster anzeigen��$
��Wrap=�$ Center=�$	��128��� $
��Left=�$	��586��$	��472��$��10,0,0,0q�	 � 	Resources	 -  'Heizungssteuerung.Backend.BoolConverter   BoolConverter
   Reverse  BoolConverterReverse��%,   &	        &	        
 .    
 . .+�R� -    R�Name$ fensterStatus��$	��566��$��0,0,0,10q�$��Bottom=����� *GebaeudeListe+ �� ElementName$$ MainFensterStatusPruefenWindow�� �� Mode$ TwoWay=�����  �� ItemsSource �� *StockwerkListe+.R��� $��18(�$
��Bold"����	#FF1B2085
����������� *
GebaeudeId+ �� ItemTemplate ��  �� *	RaumListe+.R��� $��16(����	#FFD4E9FB���� *StockwerkId+ ��  �� *FensterListe+.R��� $��14(����	#FFE8ECFD���� *RaumId+ �� .R��� ���� *	FensterId+����  �� Triggers ��  �� Binding �� *	IsChecked+$ rdbtn_zu�� �� Value True.a���  �� Property � y� �� Value ��  �� Path$ Geschlossen� �� 	Converter# [  ��  �� *	IsChecked+$ rdbtn_offen�� True.a���  � y� �� $ Geschlossen�# [ ��  �� *	IsChecked+$ 
rdbtn_alle�� True.a���  � y�$ Visible=�����  �� 
TargetType" Q�.���  �@Q�
IsExpanded .  ��  �� *Geschlossen+	 False.a���  � �� �	#FFF7D7D7��  �� *Geschlossen+ True.a���  � �� �	#FFDFFBB4