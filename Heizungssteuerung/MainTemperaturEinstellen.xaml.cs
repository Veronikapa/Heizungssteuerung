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
using System.Windows.Shapes;

using Heizungssteuerung.Backend;
using Heizungssteuerung.UIElemente;

namespace Heizungssteuerung
{
    /// <summary>
    /// Interaktionslogik für MainTemperaturEinstellen.xaml
    /// </summary>
    public partial class MainTemperaturEinstellen : Window
    {
        private Gebaeude gebaeude;

        public Wohneinheit WohneinheitMain
        {
            get;
            set;
        }

        public MainTemperaturEinstellen(Gebaeude gebaeude)
        {
            InitializeComponent();
            this.gebaeude = gebaeude;

            //Disable window header buttons
            this.SourceInitialized += (x, y) =>
            {
                WindowExtensions.DisableButtons(this);
            };

            this.Loaded += MainTemperaturEinstellen_Loaded;
        }
      


        void MainTemperaturEinstellen_Loaded(object sender, RoutedEventArgs e)
        {
            ListeLaden();
        }
        
        private void ListeLaden()
        {
            temperaturPanel.Items.Clear();

            var whiteValue = true;

            WohneinheitUiElement gebaeudeUi = new WohneinheitUiElement();
            gebaeudeUi.WohneinheitElement = this.gebaeude;
            gebaeudeUi.Background = Brushes.AliceBlue;
            gebaeudeUi.WohneinheitUiElementZielTemperaturVeraendert = this.WohneinheitUiElementZielTemperaturVeraendertEvent;
            temperaturPanel.Items.Add(gebaeudeUi);
            
            whiteValue = false;

            foreach (var stockwerk in this.gebaeude.StockwerkListe)
            {
                var stockwerkUiElement = new WohneinheitUiElement();
                stockwerkUiElement.WohneinheitElement = stockwerk;
                stockwerkUiElement.Background = whiteValue ? Brushes.AliceBlue : Brushes.GhostWhite;
                stockwerkUiElement.WohneinheitUiElementZielTemperaturVeraendert = this.WohneinheitUiElementZielTemperaturVeraendertEvent;
                temperaturPanel.Items.Add(stockwerkUiElement);

                whiteValue = !whiteValue;

                foreach (var raum in stockwerk.RaumListe)
                {
                    var raumUiElement = new WohneinheitUiElement();
                    raumUiElement.WohneinheitElement = raum;
                    raumUiElement.Background = whiteValue ? Brushes.AliceBlue : Brushes.GhostWhite;
                    raumUiElement.WohneinheitUiElementZielTemperaturVeraendert = this.WohneinheitUiElementZielTemperaturVeraendertEvent;
                    temperaturPanel.Items.Add(raumUiElement);

                    whiteValue = !whiteValue;
                }
            }

            /*
             *       
            
            /*
            HierarchicalDataTemplate stockwerkDataTemplate = new HierarchicalDataTemplate();
            stockwerkDataTemplate.ItemsSource = new Binding("StockwerkListe");

            HierarchicalDataTemplate raumDataTemplate = new HierarchicalDataTemplate();
            raumDataTemplate.ItemsSource = new Binding("RaumListe");

            foreach (Stockwerk s in gebaeude.StockwerkListe)
            {
                WohneinheitUiElement stockwerkUi = new WohneinheitUiElement();

                foreach (Raum r in s.RaumListe)
                {
                    WohneinheitUiElement raumUi = new WohneinheitUiElement();
                }
            }
            WohneinheitUiElement eins = new WohneinheitUiElement();
            WohneinheitUiElement zwei = new WohneinheitUiElement();
            WohneinheitUiElement drei = new WohneinheitUiElement();*/
        }

        private void WohneinheitUiElementZielTemperaturVeraendertEvent(object sender,EventArgs e)
        {
            ListeLaden();
        }

        private void Zurück_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
    }
}
