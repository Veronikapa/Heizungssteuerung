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
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Forms;


namespace Heizungssteuerung
{
    /// <summary>
    /// Interaction logic for MainFensterstatusPruefen.xaml
    /// </summary>
    /// 
    //Genau INotifyPropertyChanged hat gefehlt
    public partial class MainFensterstatusPruefen : Window, INotifyPropertyChanged
    {
        private Gebaeude Gebaeude;
        private IEnumerable<Gebaeude> gebaeudeListe;


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }



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


        public MainFensterstatusPruefen(Gebaeude g)
        {
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
    }
}
   
