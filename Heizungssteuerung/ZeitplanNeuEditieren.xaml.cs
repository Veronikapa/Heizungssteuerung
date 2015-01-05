using System;
using System.Collections.Generic;
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
using Heizungssteuerung.Backend;
using System.Windows.Shapes;
using Heizungssteuerung.UIElemente;
using System.ComponentModel;

namespace Heizungssteuerung
{
    /// <summary>
    /// Interaktionslogik für ZeitplanNeuEditieren.xaml
    /// </summary>
    public partial class ZeitplanNeuEditieren : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        private Gebaeude gebaeude;
        private List<string> gebaeudeListe;
        private List<string> stockwerkListe;
        private List<string> raumListe;
        private Zeitplanelement zeitplanelement;

        public List<string> StockwerkListe
        {
            get
            {
                return stockwerkListe;
            }

            set
            {
                stockwerkListe = value;
                OnPropertyChanged("StockwerkListe");
            }
        }

        public List<string> GebaeudeListe
        {
            get
            {
                return gebaeudeListe;
            }

            set
            {
                gebaeudeListe = value;
                OnPropertyChanged("GebaeudeListe");
            }
        }

        public List<string> RaumListe
        {
            get
            {
                return raumListe;
            }

            set
            {
                raumListe = value;
                OnPropertyChanged("RaumListe");
            }
        }

        private bool addModus = true;

        public ZeitplanNeuEditieren(Gebaeude g)
        {
            InitializeComponent();
            this.gebaeude = g;
            this.Loaded += ZeitplanNeu_Loaded;
        }

        public ZeitplanNeuEditieren(Gebaeude g, Zeitplanelement zeitplanElement)
        {
            InitializeComponent();
            this.gebaeude = g;
            this.zeitplanelement = zeitplanElement;
            this.addModus = false;
            this.Loaded += ZeitplanNeu_Loaded;
            //Disable window header buttons
            this.SourceInitialized += (x, y) =>
            {
                WindowExtensions.DisableButtons(this);
            };
        }

        void ZeitplanNeu_Loaded(object sender, RoutedEventArgs e)
        {

            //Nur im Add-Modus neues Element initialisieren
            if(addModus)
            {
                zeitplanelement = new Zeitplanelement(this.gebaeude.ZeitplanElementListe.Count, true, this.gebaeude.GebaeudeId, String.Empty, string.Empty);
                InitialisiereGebaeudeListe();
            }

            else
            {
                if (!zeitplanelement.RaumId.Equals(String.Empty))
                {
                    rdb_Raum.IsChecked = true;
                    StockwerkElement.InitialisierAnzuzeigendenWert(zeitplanelement.StockwerkId);
                    RaumElement.InitialisierAnzuzeigendenWert(zeitplanelement.RaumId);
                }

                else if (!zeitplanelement.StockwerkId.Equals(String.Empty))
                {
                    rdb_Stockwerk.IsChecked = true;
                    StockwerkElement.InitialisierAnzuzeigendenWert(zeitplanelement.StockwerkId);
                }

                else
                    InitialisiereGebaeudeListe();

                InitZeitplanEditWerte();
            }
            
            this.Wochentage.ZeitplanElement = zeitplanelement;

            StockwerkElement.NotifyPropertyChanged += StockwerkElement_NotifyPropertyChanged;
        }

        private void InitZeitplanEditWerte()
        {
            StundeVonElement.AktuellerWert = zeitplanelement.StundeVon;
            MinuteVonElement.AktuellerWert = zeitplanelement.MinuteVon;
            StundeBisElement.AktuellerWert = zeitplanelement.StundeBis;
            MinuteBisElement.AktuellerWert = zeitplanelement.MinuteBis;
            chb_Ganztags.IsChecked = zeitplanelement.Ganztags;
            TemperaturElement.AktuellerWert = zeitplanelement.Zieltemperatur;
            Wochentage.Montag.IsEnabled = zeitplanelement.MontagAktiv;
            Wochentage.Dienstag.IsEnabled = zeitplanelement.DienstagAktiv;
            Wochentage.Mittwoch.IsEnabled = zeitplanelement.MittwochAktiv;
            Wochentage.Donnerstag.IsEnabled = zeitplanelement.DonnerstagAktiv;
            Wochentage.Freitag.IsEnabled = zeitplanelement.FreitagAktiv;
            Wochentage.Samstag.IsEnabled = zeitplanelement.SamstagAktiv;
            Wochentage.Sonntag.IsEnabled = zeitplanelement.SonntagAktiv;
        }

        void StockwerkElement_NotifyPropertyChanged(object sender, EventArgs e)
        {
            var obj = sender as Prev_Next_Element;

            //Raumliste aktualisieren, wenn Stockwerk geändert wird
            if(obj!=null && obj.Equals(StockwerkElement))
            {
                if (rdb_Raum.IsChecked == true)
                {
                    var stockwerkId = StockwerkElement.AnzuzeigenderWert;

                    var stockwerk = this.gebaeude.StockwerkListe.Where(g => g.StockwerkId.Equals(stockwerkId)).FirstOrDefault();

                    if (stockwerk != null)
                    {
                        RaumListe = stockwerk.RaumIdListe;
                        RaumElement.Visibility = Visibility.Visible;
                        StockwerkElement.InitialisierAnzuzeigendenWert();
                        RaumElement.InitialisierAnzuzeigendenWert();
                    }
                }
            }  
        }

        private void InitialisiereGebaeudeListe()
        {
            if (gebaeude == null)
                return;

            StockwerkElement.Visibility = Visibility.Hidden;
            GebaeudeElement.Visibility = Visibility.Visible;

            GebaeudeListe = new List<string> { gebaeude.GebaeudeId };
            if(RaumListe!=null)
                RaumListe.Clear();

            if(RaumElement!=null)
                RaumElement.Visibility = Visibility.Hidden;
        }

        private void rdb_Gebaeude_Checked(object sender, RoutedEventArgs e)
        {
            InitialisiereGebaeudeListe();
        }

        private void rdb_Stockwerk_Checked(object sender, RoutedEventArgs e)
        {
            if (gebaeude == null)
                return;

            StockwerkElement.Visibility = Visibility.Visible;
            GebaeudeElement.Visibility = Visibility.Hidden;

            StockwerkListe = gebaeude.StockwerkIDListe;

            if(raumListe!=null)
                raumListe.Clear();

            RaumElement.Visibility = Visibility.Hidden;
            StockwerkElement.InitialisierAnzuzeigendenWert();
        }

        private void rdb_Raum_Checked(object sender, RoutedEventArgs e)
        {
            if (gebaeude == null)
                return;

            StockwerkElement.Visibility = Visibility.Visible;
            GebaeudeElement.Visibility = Visibility.Hidden;

            if(StockwerkElement.AnzuzeigenderWert.Equals(String.Empty))
            {
                StockwerkListe = gebaeude.StockwerkIDListe;                
                StockwerkElement.InitialisierAnzuzeigendenWert();
            }

            var stockwerkId = StockwerkElement.AnzuzeigenderWert;

            var stockwerk = this.gebaeude.StockwerkListe.Where(g => g.StockwerkId.Equals(stockwerkId)).FirstOrDefault();

            if(stockwerk!=null)
            {
                RaumListe = stockwerk.RaumIdListe;
                RaumElement.Visibility = Visibility.Visible;
                RaumElement.InitialisierAnzuzeigendenWert();
            }
        }

        private void Speichern_Click(object sender, RoutedEventArgs e)
        {
            var stockwerkId = String.Empty;
            var raumId = String.Empty;

            if (rdb_Stockwerk.IsChecked==true)
                stockwerkId = StockwerkElement.AnzuzeigenderWert;


            else if(rdb_Raum.IsChecked==true)
            {
                stockwerkId = GebaeudeElement.AnzuzeigenderWert;
                raumId = RaumElement.AnzuzeigenderWert;

            }
            zeitplanelement.StockwerkId = stockwerkId;
            zeitplanelement.RaumId = raumId;
            zeitplanelement.Zieltemperatur = TemperaturElement.AktuellerWert;
            zeitplanelement.MontagAktiv = Wochentage.Montag.IsEnabled;
            zeitplanelement.DienstagAktiv = Wochentage.Dienstag.IsEnabled;
            zeitplanelement.MittwochAktiv = Wochentage.Mittwoch.IsEnabled;
            zeitplanelement.DonnerstagAktiv = Wochentage.Donnerstag.IsEnabled;
            zeitplanelement.FreitagAktiv = Wochentage.Freitag.IsEnabled;
            zeitplanelement.SamstagAktiv = Wochentage.Samstag.IsEnabled;
            zeitplanelement.SonntagAktiv = Wochentage.Sonntag.IsEnabled;

            if (!UhrzeitValidierung())
                return;

            zeitplanelement.Ganztags = chb_Ganztags.IsChecked==true ? true:false;

            zeitplanelement.StundeVon = StundeVonElement.AktuellerWert;
            zeitplanelement.MinuteVon = MinuteVonElement.AktuellerWert;
            zeitplanelement.StundeBis = StundeBisElement.AktuellerWert;
            zeitplanelement.MinuteBis = MinuteBisElement.AktuellerWert;

            if (!AktivierteElementeValidierung())
                return;

            if(addModus)
                this.gebaeude.ZeitplanElementListe.Add(zeitplanelement);

            else
            {
                var elementIndex = this.gebaeude.ZeitplanElementListe.IndexOf(this.gebaeude.ZeitplanElementListe.Where(z => z.ZeitplanId == zeitplanelement.ZeitplanId).FirstOrDefault());
                this.gebaeude.ZeitplanElementListe[elementIndex] = zeitplanelement;
            }
            this.Close();
        }

        private bool AktivierteElementeValidierung()
        {
            var valide = zeitplanelement.AktiveZeitplaeneValidierung(this.gebaeude.ZeitplanElementListe);

            if (valide)
            {
                lbl_ElementInvalid.Visibility = Visibility.Hidden;
                lbl_ElementInvalid.Height = 0;
                return true;
            }

            else
            {
                lbl_ElementInvalid.Visibility = Visibility.Visible;
                lbl_ElementInvalid.Height = 80;
                return false;
            }
        }

        private bool UhrzeitValidierung()
        {
            if (StundeVonElement.AktuellerWert < StundeBisElement.AktuellerWert)
            {
                lbl_UhrzeitInvalid.Visibility = Visibility.Hidden;
                lbl_UhrzeitInvalid.Height = 0;
                return true;
            }

            else if (StundeVonElement.AktuellerWert == StundeBisElement.AktuellerWert && MinuteBisElement.AktuellerWert >= MinuteVonElement.AktuellerWert)
            {
                lbl_UhrzeitInvalid.Visibility = Visibility.Hidden;
                lbl_UhrzeitInvalid.Height = 0;
                return true;
            }

            else
            {
                lbl_UhrzeitInvalid.Visibility = Visibility.Visible;
                lbl_UhrzeitInvalid.Height = 80;
                return false;
            }
        }

        private void Abbrechen_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void chb_Ganztags_Checked(object sender, RoutedEventArgs e)
        {
            if (chb_Ganztags.IsChecked == true)
            {
                StundeVonElement.AnzuzeigenderWert = "00";
                StundeBisElement.AnzuzeigenderWert = "00";
                MinuteVonElement.AnzuzeigenderWert = "00";
                MinuteBisElement.AnzuzeigenderWert = "00";
                StundeVonElement.AktuellerWert = 0;
                StundeBisElement.AktuellerWert = 0;
                MinuteVonElement.AktuellerWert = 0;
                MinuteBisElement.AktuellerWert = 0;
                StundeVonElement.IsEnabled = false;
                StundeBisElement.IsEnabled = false;
                MinuteBisElement.IsEnabled = false;
                MinuteVonElement.IsEnabled = false;
            }
        }

        private void chb_Ganztags_Unchecked(object sender, RoutedEventArgs e)
        {
            StundeVonElement.IsEnabled = true;
            StundeBisElement.IsEnabled = true;
            MinuteBisElement.IsEnabled = true;
            MinuteVonElement.IsEnabled = true;
        }

        private void Löschen_Click(object sender, RoutedEventArgs e)
        {
            var index = this.gebaeude.ZeitplanElementListe.IndexOf(this.gebaeude.ZeitplanElementListe.Where(z => z.ZeitplanId == this.zeitplanelement.ZeitplanId).FirstOrDefault());

            if (index >= 0)
                this.gebaeude.ZeitplanElementListe.RemoveAt(index);

            this.Close();
        }
    }
}
