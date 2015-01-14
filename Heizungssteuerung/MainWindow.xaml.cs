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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Heizungssteuerung.Backend;

namespace Heizungssteuerung
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Gebaeude gebaeude;

        public MainWindow()
        {
            InitializeComponent();
            InitialisiereGebeaude();
        }

        private void InitialisiereGebeaude()
        {
            gebaeude = new Gebaeude("Haus", 25);

            gebaeude.StockwerkHinzufuegen(InitialisiereRaumListeStockwerk1(gebaeude));
            gebaeude.StockwerkHinzufuegen(InitialisiereRaumListeStockwerk2(gebaeude));
        }

        #region InitialisiereRaumListeStockwerk1
        private Stockwerk InitialisiereRaumListeStockwerk1(Gebaeude gebaeude)
        {
            Stockwerk stock = new Stockwerk("Stockwerk1", 25, gebaeude);

            List<Fenster> fensterListeBad1 = new List<Fenster>();
            fensterListeBad1.Add(new Fenster("Fenster1", true));

            List<Fenster> fensterListeVorraum1 = new List<Fenster>();
            fensterListeVorraum1.Add(new Fenster("Fenster1", true));
            fensterListeVorraum1.Add(new Fenster("Fenster2", false));

            List<Fenster> fensterListeKueche = new List<Fenster>();
            fensterListeKueche.Add(new Fenster("Fenster1", true));
            fensterListeKueche.Add(new Fenster("Fenster2", false));

            List<Fenster> fensterListeWohnzimmer = new List<Fenster>();
            fensterListeWohnzimmer.Add(new Fenster("Fenster1", true));
            fensterListeWohnzimmer.Add(new Fenster("Fenster2", true));
            fensterListeWohnzimmer.Add(new Fenster("Fenster3", true));
            fensterListeWohnzimmer.Add(new Fenster("Fenster4", true));

            List<Fenster> fensterListeBuero = new List<Fenster>();
            fensterListeBuero.Add(new Fenster("Fenster1", true));

            stock.RaumHinzufuegen(new Raum("Bad1", 25, fensterListeBad1, stock));
            stock.RaumHinzufuegen(new Raum("Vorraum1", 25, fensterListeVorraum1, stock));
            stock.RaumHinzufuegen(new Raum("Küche", 25, fensterListeKueche, stock));
            stock.RaumHinzufuegen(new Raum("Wohnzimmer", 25, fensterListeWohnzimmer, stock));
            stock.RaumHinzufuegen(new Raum("Büro", 25, fensterListeBuero, stock));

            return stock;
        }
        #endregion InitialisiereRaumListeStockwerk1

        #region InitialisiereRaumListeStockwerk2
        private Stockwerk InitialisiereRaumListeStockwerk2(Gebaeude gebaeude)
        {
            Stockwerk stock = new Stockwerk("Stockwerk2", 25, gebaeude);

            List<Fenster> fensterListeBad2 = new List<Fenster>();
            fensterListeBad2.Add(new Fenster("Fenster1", true));
            fensterListeBad2.Add(new Fenster("Fenster2", false));

            List<Fenster> fensterListeVorraum2 = new List<Fenster>();
            fensterListeVorraum2.Add(new Fenster("Fenster1", true));
            fensterListeVorraum2.Add(new Fenster("Fenster2", false));
            fensterListeVorraum2.Add(new Fenster("Fenster3", false));

            List<Fenster> fensterListeSchlafzimmer1 = new List<Fenster>();
            fensterListeSchlafzimmer1.Add(new Fenster("Fenster1", true));
            fensterListeSchlafzimmer1.Add(new Fenster("Fenster2", false));

            List<Fenster> fensterListeSchlafzimmer2 = new List<Fenster>();
            fensterListeSchlafzimmer2.Add(new Fenster("Fenster1", true));

            List<Fenster> fensterListeSchlafzimmer3 = new List<Fenster>();
            fensterListeSchlafzimmer3.Add(new Fenster("Fenster1", true));
            fensterListeSchlafzimmer3.Add(new Fenster("Fenster2", false));

            stock.RaumHinzufuegen(new Raum("Bad2", 25, fensterListeBad2, stock));
            stock.RaumHinzufuegen(new Raum("Vorraum2", 25, fensterListeBad2, stock));
            stock.RaumHinzufuegen(new Raum("Schlafzimmer1", 25, fensterListeSchlafzimmer1, stock));
            stock.RaumHinzufuegen(new Raum("Schlafzimmer2", 25, fensterListeSchlafzimmer2, stock));
            stock.RaumHinzufuegen(new Raum("Schlafzimmer3", 25, fensterListeSchlafzimmer3, stock));

            return stock;
        }
        #endregion InitialisiereRaumListeStockwerk1

        private void Zeitplan_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = System.Windows.Visibility.Hidden;
            MainZeitplan zeitplan = new MainZeitplan(gebaeude);
            zeitplan.Closed += zeitplan_Closed;
            zeitplan.Show();
        }

        void zeitplan_Closed(object sender, EventArgs e)
        {
            this.Visibility = System.Windows.Visibility.Visible;
        }

        private void Temperatur_Click(object sender, RoutedEventArgs e)
        {
            gebaeude.TemperaturenAktualisieren();

            this.Visibility = System.Windows.Visibility.Hidden;
            MainTemperaturEinstellen temperatur = new MainTemperaturEinstellen(gebaeude);
            temperatur.Closed += temperatur_Closed;
            temperatur.Show();
        }

        void temperatur_Closed(object sender, EventArgs e)
        {
            this.Visibility = System.Windows.Visibility.Visible;
        }
    }
}
