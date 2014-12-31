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
        Gebaeude gebauede;

        public MainWindow()
        {
            InitializeComponent();
            InitialisiereGebeaude();
        }

        private void InitialisiereGebeaude()
        {
            List<Stockwerk> stockwerkListe = new List<Stockwerk>();
            stockwerkListe.Add(new Stockwerk("Stockwerk1",25,InitialisiereRaumListeStockwerk1()));
            stockwerkListe.Add(new Stockwerk("Stockwerk2", 25, InitialisiereRaumListeStockwerk2()));

            gebauede = new Gebaeude("Haus", 25, stockwerkListe);
        }

        #region InitialisiereRaumListeStockwerk1
        private List<Raum> InitialisiereRaumListeStockwerk1()
        {
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

            List<Raum> raumListeStockwerk1 = new List<Raum>();
            raumListeStockwerk1.Add(new Raum("Bad1", 25, fensterListeBad1));
            raumListeStockwerk1.Add(new Raum("Vorraum1", 25, fensterListeVorraum1));
            raumListeStockwerk1.Add(new Raum("Kueche", 25, fensterListeKueche));
            raumListeStockwerk1.Add(new Raum("Wohnzimmer", 25, fensterListeWohnzimmer));
            raumListeStockwerk1.Add(new Raum("Bueor", 25, fensterListeBuero));

            return raumListeStockwerk1;
        }
        #endregion InitialisiereRaumListeStockwerk1

        #region InitialisiereRaumListeStockwerk2
        private List<Raum> InitialisiereRaumListeStockwerk2()
        {
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

            List<Raum> raumListeStockwerk2 = new List<Raum>();
            raumListeStockwerk2.Add(new Raum("Bad2", 25, fensterListeBad2));
            raumListeStockwerk2.Add(new Raum("Vorraum2", 25, fensterListeBad2));
            raumListeStockwerk2.Add(new Raum("Schlafzimmer1", 25, fensterListeSchlafzimmer1));
            raumListeStockwerk2.Add(new Raum("Schlafzimmer2", 25, fensterListeSchlafzimmer2));
            raumListeStockwerk2.Add(new Raum("Schlafzimmer3", 25, fensterListeSchlafzimmer3));

            return raumListeStockwerk2;
        }
        #endregion InitialisiereRaumListeStockwerk1
    }
}
