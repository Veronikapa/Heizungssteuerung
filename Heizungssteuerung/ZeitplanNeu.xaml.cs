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
using System.ComponentModel;

namespace Heizungssteuerung
{
    /// <summary>
    /// Interaktionslogik für ZeitplanNeu.xaml
    /// </summary>
    public partial class ZeitplanNeu : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        private Gebaeude gebaeude;
        private List<string> stockwerkListe;
        private List<string> raumListe;
        private int aktuelleTemperatur;
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

        public ZeitplanNeu(Gebaeude g)
        {
            InitializeComponent();
            this.gebaeude = g;
            this.Loaded += ZeitplanNeu_Loaded;
        }

        void ZeitplanNeu_Loaded(object sender, RoutedEventArgs e)
        {
            InitialisiereGebaeudeListe();
            zeitplanelement = new Zeitplanelement(this.gebaeude.ZeitplanElementListe.Count, true, this.gebaeude.GebaeudeId, String.Empty, string.Empty);
            this.Wochentage.ZeitplanElement = zeitplanelement;
        }

        private void InitialisiereGebaeudeListe()
        {
            if (gebaeude == null)
                return;
            
            StockwerkListe = new List<string> { gebaeude.GebaeudeId };
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

            StockwerkListe = gebaeude.StockwerkIDListe;
            if(raumListe!=null)
                raumListe.Clear();
            RaumElement.Visibility = Visibility.Hidden;
        }

        private void rdb_Raum_Checked(object sender, RoutedEventArgs e)
        {
            if (gebaeude == null)
                return;

            var stockwerkId = GebaeudeElement.AnzuzeigenderWert;

            var stockwerk = this.gebaeude.StockwerkListe.Where(g => g.StockwerkId.Equals(stockwerkId)).FirstOrDefault();

            if(stockwerk!=null)
            {
                raumListe = stockwerk.RaumIdListe;
                RaumElement.Visibility = Visibility.Visible;
            }
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            var stockwerkId = String.Empty;
            var raumId = String.Empty;

            if (rdb_Stockwerk.IsChecked==true)
                stockwerkId = GebaeudeElement.AnzuzeigenderWert;


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

            zeitplanelement.StundeVon = Convert.ToInt32(StundeVonElement.AnzuzeigenderWert);
            zeitplanelement.MinuteVon = Convert.ToInt32(MinuteVonElement.AnzuzeigenderWert);
            zeitplanelement.StundeBis = Convert.ToInt32(StundeBisElement.AnzuzeigenderWert);
            zeitplanelement.MinuteBis = Convert.ToInt32(MinuteBisElement.AnzuzeigenderWert);

            this.gebaeude.ZeitplanElementListe.Add(zeitplanelement);
            this.Close();
        }

        private void Abbrechen_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
