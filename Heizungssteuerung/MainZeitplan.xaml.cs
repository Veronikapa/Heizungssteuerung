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
        }

        void MainZeitplan_Loaded(object sender, RoutedEventArgs e)
        {
            ListeLaden();
        }

        private void Zurück_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void Neu_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var zeitplanNeuElement = new ZeitplanNeuEditieren(this.gebauede);
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
            var whiteValue = true;
            ZeitplanPanel.Children.Clear();

            foreach (var zeitplanElement in this.gebauede.ZeitplanElementListe)
            {
                var zeitplanUiElement = new ZeitplanUiElement();
                zeitplanUiElement.ZeitplanElement = zeitplanElement;
                zeitplanUiElement.Background = whiteValue ? Brushes.AliceBlue: Brushes.GhostWhite;
                zeitplanUiElement.ZeitplanUiElementMouseDownEvent = this.ZeitplanUiElementMouseDownEvent;
                zeitplanUiElement.ZeitplanUiElementAktiviertEvent = this.ZeitplanUiElementAktiviertEvent;
                ZeitplanPanel.Children.Add(zeitplanUiElement);

                var line = new Line();
                line.StrokeThickness = 1;
                line.Stroke = Brushes.LightGray;
                ZeitplanPanel.Children.Add(line);
                whiteValue = !whiteValue;
            } 
        }

        private void ZeitplanUiElementMouseDownEvent(object sender, MouseEventArgs e)
        {
            //Öffne Edit-Fenster bei Klick auf Element
            var element = sender as ZeitplanUiElement;

            if (element != null)
            {
                var editDialog = new ZeitplanNeuEditieren(this.gebauede, element.ZeitplanElement);
                this.Visibility = Visibility.Hidden;
                editDialog.Closed += editDialog_Closed;
                editDialog.Show();
            }
        }

        private void ZeitplanUiElementAktiviertEvent(object sender, EventArgs e)
        {
            //Öffne Edit-Fenster bei Klick auf Element
            var element = sender as ZeitplanUiElement;

            if (element != null)
            {
                if(!element.ZeitplanElement.AktiveZeitplaeneValidierung(this.gebauede.ZeitplanElementListe))
                {
                    element.ZeitplanElement.Aktiviert = false;
                    MessageBox.Show("Dieser Zeitplan kann nicht aktiviert werden, da er sich mit einem anderen Zeitplan zeitlich überschneidet!", "Zeitplan-Überschneidung",MessageBoxButton.OK);
                }
            }
        }

        void editDialog_Closed(object sender, EventArgs e)
        {
            this.Visibility = Visibility.Visible;
            ListeLaden();
        }
    }
}