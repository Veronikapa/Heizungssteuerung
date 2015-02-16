using System;
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


        //Event ist zu werfen wenn benutzendes User Control über Property Änderung notifiziert werden soll.
        //Z.B. Stockwerk ändert sich --> Raumliste aktualisieren
        public event EventHandler NotifyPropertyChanged;

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

        public void InitialisierAnzuzeigendenWert()
        {
            if (IstStringListe)
                SetzeStringListeText();

            else if (IstTemperatur)
                SetzeTemperaturText();

            else if (IstUhrzeit)
                SetzeUhrzeitText();
        }

        public void InitialisierAnzuzeigendenWert(string valueToSet)
        {
            aktuellerStringIndex = StringListe.IndexOf(valueToSet);

            if (IstStringListe)
                SetzeStringListeText();
        }

        private void SetzeUhrzeitText()
        {
            if (AktuellerWert < MinWert || AktuellerWert > MaxWert)
                AktuellerWert = MinWert;

            btn_Increase.IsEnabled = AktuellerWert != MaxWert;
            btn_Decrease.IsEnabled = AktuellerWert != MinWert;

            if (AktuellerWert < 10)
                AnzuzeigenderWert = "0" + AktuellerWert.ToString();

            else
                AnzuzeigenderWert = AktuellerWert.ToString();
        }

        private void SetzeTemperaturText()
        {
            if (AktuellerWert < MinWert || AktuellerWert > MaxWert)
                AktuellerWert = MinWert;

            btn_Increase.IsEnabled = AktuellerWert != MaxWert;
            btn_Decrease.IsEnabled = AktuellerWert != MinWert;
            AnzuzeigenderWert = AktuellerWert.ToString() + "° C";
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

            btn_Decrease.IsEnabled = aktuellerStringIndex != 0;
            btn_Increase.IsEnabled = aktuellerStringIndex != StringListe.Count() - 1;

            if (StringListe != null && StringListe.Count() == 1)
            {
                btn_Decrease.IsEnabled = false;
                btn_Increase.IsEnabled = false;
            }
        }

        private void btn_Increase_Click(object sender, RoutedEventArgs e)
        {
            if(IstStringListe)
            {
                aktuellerStringIndex++;
                SetzeStringListeText();

                if (NotifyPropertyChanged != null)
                    NotifyPropertyChanged(this, e);
            }

            else if(IstTemperatur)
            {
                AktuellerWert++;
                SetzeTemperaturText();
            }

            else if(IstUhrzeit)
            {
                AktuellerWert = IstMinute ? AktuellerWert + 5 : AktuellerWert + 1;
                SetzeUhrzeitText();
            }
        }

        private void btn_Decrease_Click(object sender, RoutedEventArgs e)
        {
            if (IstStringListe)
            {
                aktuellerStringIndex--;
                SetzeStringListeText();

                if(NotifyPropertyChanged!=null)
                    NotifyPropertyChanged(this, e);
            }

            else if (IstTemperatur)
            {
                AktuellerWert--;
                SetzeTemperaturText();
            }

            else if (IstUhrzeit)
            {
                AktuellerWert = IstMinute ? AktuellerWert - 5 : AktuellerWert - 1;
                SetzeUhrzeitText();
            }
        }
    }
}
