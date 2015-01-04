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
using System.Windows.Interop;
using System.Runtime.InteropServices;
using System.Windows.Shapes;
using Heizungssteuerung.UIElemente;
using System.Drawing;
using System.Windows.Interactivity;
using Heizungssteuerung.Backend;

namespace Heizungssteuerung
{
    /// <summary>
    /// Interaktionslogik für MainZeitplan.xaml
    /// </summary>
    public partial class MainZeitplan : Window
    {
        private Gebaeude gebauede;

        public Zeitplanelement ZeitplanElementMain
        {
            get;
            set;
        }

        public MainZeitplan(Gebaeude gebauede)
        {
            InitializeComponent();
            this.gebauede = gebauede;
            //Disable window header buttons
            this.SourceInitialized += (x, y) =>
            {
                WindowExtensions.DisableButtons(this);
            };

            this.Loaded += MainZeitplan_Loaded;

            //Set back icon
            //Uri iconUri = new Uri("pack://application:,,,/Icons/Zurueck_Icon.gif", UriKind.RelativeOrAbsolute);
            //this.Icon = BitmapFrame.Create(iconUri);
        }

        void MainZeitplan_Loaded(object sender, RoutedEventArgs e)
        {
            ListeLaden();
        }

        void ico_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Neu_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var zeitplanNeuElement = new ZeitplanNeu(this.gebauede);
            zeitplanNeuElement.Closed+=zeitplanNeuElement_Closed;
            this.Visibility = Visibility.Hidden;
            zeitplanNeuElement.Show();
        }

        private void zeitplanNeuElement_Closed(object sender, EventArgs e)
        {
            this.Visibility = Visibility.Visible;
            ListeLaden();
        }

        private void ListeLaden()
        {
            foreach (var zeitplanElement in this.gebauede.ZeitplanElementListe)
            {
                var zeitplanUiElement = new ZeitplanUiElement();
                zeitplanUiElement.ZeitplanElement = zeitplanElement;
                zeitplanUiElement.Height = 50;
                zeitplanUiElement.Background = Brushes.GhostWhite;
                ZeitplanPanel.Children.Add(zeitplanUiElement);

                var line = new Line();
                line.StrokeThickness = 1;
                line.Stroke = Brushes.LightGray;
                ZeitplanPanel.Children.Add(line);
            } 
        }
    }
}