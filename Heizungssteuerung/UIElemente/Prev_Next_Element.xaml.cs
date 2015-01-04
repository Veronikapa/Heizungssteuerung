﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Heizungssteuerung.UIElemente
{
    /// <summary>
    /// Interaktionslogik für Prev_Next_Element.xaml
    /// </summary>
    public partial class Prev_Next_Element : UserControl,INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        private string anzuzeigenderWert = String.Empty;
        public string AnzuzeigenderWert
        {
            get
            { return anzuzeigenderWert; }

            set
            {
                anzuzeigenderWert = value;
                OnPropertyChanged("AnzuzeigenderWert");
            }
        }

        private int aktuellerIntWert = 0;
        private int aktuellerStringIndex = 0;

        public static readonly DependencyProperty StringListeProperty = DependencyProperty.Register("StringListe", typeof(List<string>), typeof(Prev_Next_Element), new FrameworkPropertyMetadata((List<string>)null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        public List<string> StringListe
        {
            get
            {
                return (List<string>)GetValue(StringListeProperty);
            }
            set
            {
                SetValue(StringListeProperty, value);
            }
        }

        public static readonly DependencyProperty AktuellerWertProperty = DependencyProperty.Register("AktuellerWert", typeof(int), typeof(Prev_Next_Element), new FrameworkPropertyMetadata((int)25, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        public int AktuellerWert
        {
            get
            {
                return (int)GetValue(AktuellerWertProperty);
            }
            set
            {
                SetValue(AktuellerWertProperty, value);
            }
        }

        public static readonly DependencyProperty MaxWertProperty = DependencyProperty.Register("MaxWert", typeof(int), typeof(Prev_Next_Element), new FrameworkPropertyMetadata((int)35, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        public int MaxWert
        {
            get
            {
                return (int)GetValue(MaxWertProperty);
            }
            set
            {
                SetValue(MaxWertProperty, value);
            }
        }

        public static readonly DependencyProperty MinWertProperty = DependencyProperty.Register("MinWert", typeof(int), typeof(Prev_Next_Element), new FrameworkPropertyMetadata((int)0, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        public int MinWert
        {
            get
            {
                return (int)GetValue(MinWertProperty);
            }
            set
            {
                SetValue(MinWertProperty, value);
            }
        }

        public static readonly DependencyProperty istUhrzeitProperty = DependencyProperty.Register("istUhrzeit", typeof(bool), typeof(Prev_Next_Element), new FrameworkPropertyMetadata((bool)false, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        public bool IstUhrzeit
        {
            get
            {
                return (bool)GetValue(istUhrzeitProperty);
            }
            set
            {
                SetValue(istUhrzeitProperty, value);
            }
        }

        public static readonly DependencyProperty istMinuteProperty = DependencyProperty.Register("istMinute", typeof(bool), typeof(Prev_Next_Element), new FrameworkPropertyMetadata((bool)false, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        public bool IstMinute
        {
            get
            {
                return (bool)GetValue(istMinuteProperty);
            }
            set
            {
                SetValue(istMinuteProperty, value);
            }
        }

        public static readonly DependencyProperty istTemperaturProperty = DependencyProperty.Register("istTemperatur", typeof(bool), typeof(Prev_Next_Element), new FrameworkPropertyMetadata((bool)false, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        public bool IstTemperatur
        {
            get
            {
                return (bool)GetValue(istTemperaturProperty);
            }
            set
            {
                SetValue(istTemperaturProperty, value);
            }
        }

        public static readonly DependencyProperty istStringListeProperty = DependencyProperty.Register("istStringListe", typeof(bool), typeof(Prev_Next_Element), new FrameworkPropertyMetadata((bool)false, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        public bool IstStringListe
        {
            get
            {
                return (bool)GetValue(istStringListeProperty);
            }
            set
            {
                SetValue(istStringListeProperty, value);
            }
        }

        public Prev_Next_Element()
        {
            InitializeComponent();
            (this.Content as FrameworkElement).DataContext = this;
            this.Loaded += Prev_Next_Element_Loaded;
        }

        void Prev_Next_Element_Loaded(object sender, RoutedEventArgs e)
        {
            InitialisierAnzuzeigendenWert();
        }

        private void InitialisierAnzuzeigendenWert()
        {
            if (IstStringListe)
                SetzeStringListeText();

            else if (IstTemperatur)
                InitialisiereTemperatur();

            else if (IstUhrzeit)
                InitialisiereUhrzeit();
        }

        private void InitialisiereUhrzeit()
        {
            aktuellerIntWert = AktuellerWert;

            SetzeUhrzeitText();
        }

        private void SetzeUhrzeitText()
        {
            if (aktuellerIntWert < MinWert || aktuellerIntWert > MaxWert)
                aktuellerIntWert = MinWert;

            btn_Prev.IsEnabled = aktuellerIntWert != MinWert;
            btn_Next.IsEnabled = aktuellerIntWert != MaxWert;

            if (aktuellerIntWert < 10)
                AnzuzeigenderWert = "0" + aktuellerIntWert.ToString();

            else
                AnzuzeigenderWert = aktuellerIntWert.ToString();
        }

        private void InitialisiereTemperatur()
        {
            aktuellerIntWert = AktuellerWert;

            SetzeTemperaturText();
        }

        private void SetzeTemperaturText()
        {
            if (aktuellerIntWert < MinWert || aktuellerIntWert > MaxWert)
                aktuellerIntWert = MinWert;

            btn_Prev.IsEnabled = aktuellerIntWert != MinWert;
            btn_Next.IsEnabled = aktuellerIntWert != MaxWert;
            AnzuzeigenderWert = aktuellerIntWert.ToString() + "° C";
        }

        private void SetzeStringListeText()
        {
            if (StringListe == null)
            {
                AnzuzeigenderWert = String.Empty;
                return;
            }

            if (aktuellerStringIndex < 0 || aktuellerStringIndex > StringListe.Count() - 1)
                aktuellerStringIndex = 0;

            AnzuzeigenderWert = StringListe[aktuellerStringIndex].ToString();

            btn_Prev.IsEnabled = aktuellerStringIndex != 0;
            btn_Next.IsEnabled = aktuellerStringIndex != StringListe.Count() - 1;

            if (StringListe != null && StringListe.Count() == 1)
            {
                btn_Next.IsEnabled = false;
                btn_Prev.IsEnabled = false;
            }
        }

        private void btn_Prev_Click(object sender, RoutedEventArgs e)
        {
            if(IstStringListe)
            {
                aktuellerStringIndex--;
                SetzeStringListeText();
            }

            else if(IstTemperatur)
            {
                aktuellerIntWert--;
                SetzeTemperaturText();
            }

            else if(IstUhrzeit)
            {
                aktuellerIntWert = IstMinute ? aktuellerIntWert - 5 : aktuellerIntWert-1;
                SetzeUhrzeitText();
            }
        }

        private void btn_Next_Click(object sender, RoutedEventArgs e)
        {
            if (IstStringListe)
            {
                aktuellerStringIndex++;
                SetzeStringListeText();
            }

            else if (IstTemperatur)
            {
                aktuellerIntWert++;
                SetzeTemperaturText();
            }

            else if (IstUhrzeit)
            {
                aktuellerIntWert = IstMinute ? aktuellerIntWert + 5 : aktuellerIntWert+1;
                SetzeUhrzeitText();
            }
        }
    }
}
