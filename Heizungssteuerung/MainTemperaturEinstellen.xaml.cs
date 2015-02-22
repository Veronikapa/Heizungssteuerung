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
using System.ComponentModel;

using Heizungssteuerung.Backend;
using Heizungssteuerung.UIElemente;

namespace Heizungssteuerung
{
    public partial class MainTemperaturEinstellen : Window, INotifyPropertyChanged
    {
        #region Thickness Helper Properties

        int gebOffset = 38;
        int stwOffset = 19;


        public Thickness MarginGebaeudeValOne
        {
            get
            {
                return new Thickness(149 + gebOffset, 48, 0, 0);
            }
        }

        public Thickness MarginGebaeudeValTwo
        {
            get
            {
                return new Thickness(260 + gebOffset, 48, 0, 0);
            }
        }

        public Thickness MarginGebaeudeValThree
        {
            get
            {
                return new Thickness(260 + gebOffset, 10, 0, 86);
            }
        }

        public Thickness MarginGebaeudeValFour
        {
            get
            {
                return new Thickness(260 + gebOffset, 86, 0, 10);
            }
        }

        public Thickness MarginGebaeudeValFive
        {
            get
            {
                return new Thickness(340 + gebOffset, 35, 30, 0);
            }
        }

        public Thickness MarginStockwerkValOne
        {
            get
            {
                return new Thickness(149 + stwOffset, 48, 0, 0);
            }
        }

        public Thickness MarginStockwerkValTwo
        {
            get
            {
                return new Thickness(260 + stwOffset, 48, 0, 0);
            }
        }

        public Thickness MarginStockwerkValThree
        {
            get
            {
                return new Thickness(260 + stwOffset, 10, 0, 86);
            }
        }

        public Thickness MarginStockwerkValFour
        {
            get
            {
                return new Thickness(260 + stwOffset, 86, 0, 10);
            }
        }

        public Thickness MarginStockwerkValFive
        {
            get
            {
                return new Thickness(340 + stwOffset, 35, 30, 0);
            }
        }

        public Thickness MarginRaumValOne
        {
            get
            {
                return new Thickness(149, 48, 0, 0);
            }
        }

        public Thickness MarginRaumValTwo
        {
            get
            {
                return new Thickness(260, 48, 0, 0);
            }
        }

        public Thickness MarginRaumValThree
        {
            get
            {
                return new Thickness(260, 10, 0, 86);
            }
        }

        public Thickness MarginRaumValFour
        {
            get
            {
                return new Thickness(260, 86, 0, 10);
            }
        }

        public Thickness MarginRaumValFive
        {
            get
            {
                return new Thickness(340, 40, 30, 0);
            }
        }

        #endregion

        private Gebaeude Gebaeude;

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        private IEnumerable<Gebaeude> gebaeudeListe;
        public IEnumerable<Gebaeude> GebaeudeListe
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

        public TreeView MainTreeView
        {
            get
            {
                return this.temperaturTree;
            }
            set
            {
                this.temperaturTree = value;
            }
        }

        public MainTemperaturEinstellen(Gebaeude g)
        {
            DataContext = this;

            InitializeComponent();
            this.Loaded += MainFensterstatusPruefen_Loaded;
            this.Gebaeude = g;

            //Disable window header buttons
            this.SourceInitialized += (x, y) =>
            {
                WindowExtensions.DisableButtons(this);
            };
            
        }
        void MainFensterstatusPruefen_Loaded(object sender, RoutedEventArgs e)
        {
            GebaeudeListe = new List<Gebaeude>() { Gebaeude };
        }

        private void Zurück_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        /*
        private Gebaeude gebaeude;

        public Wohneinheit WohneinheitMain
        {
            get;
            set;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        private IEnumerable<Gebaeude> gebaeudeListe;
        public IEnumerable<Gebaeude> GebaeudeListe
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
            GebaeudeListe = new List<Gebaeude>() { gebaeude };
            //ListeLaden();
        }*/
        
        private void ListeLaden()
        {

            temperaturTree.Items.Clear();

            var whiteValue = true;

            WohneinheitUiElement gebaeudeUi = new WohneinheitUiElement();
            gebaeudeUi.WohneinheitElement = this.Gebaeude;
            gebaeudeUi.Background = Brushes.AliceBlue;
            gebaeudeUi.WohneinheitUiElementZielTemperaturVeraendert = this.WohneinheitUiElementZielTemperaturVeraendertEvent;
            temperaturTree.Items.Add(gebaeudeUi);
            
            whiteValue = false;

            foreach (var stockwerk in this.Gebaeude.StockwerkListe)
            {
                var stockwerkUiElement = new WohneinheitUiElement();
                stockwerkUiElement.WohneinheitElement = stockwerk;
                stockwerkUiElement.Background = whiteValue ? Brushes.AliceBlue : Brushes.GhostWhite;
                stockwerkUiElement.WohneinheitUiElementZielTemperaturVeraendert = this.WohneinheitUiElementZielTemperaturVeraendertEvent;
                temperaturTree.Items.Add(stockwerkUiElement);

                whiteValue = !whiteValue;

                foreach (var raum in stockwerk.RaumListe)
                {
                    var raumUiElement = new WohneinheitUiElement();
                    raumUiElement.WohneinheitElement = raum;
                    raumUiElement.Background = whiteValue ? Brushes.AliceBlue : Brushes.GhostWhite;
                    raumUiElement.WohneinheitUiElementZielTemperaturVeraendert = this.WohneinheitUiElementZielTemperaturVeraendertEvent;
                    temperaturTree.Items.Add(raumUiElement);

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
        /*
        private void Zurück_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }*/
    }
}
