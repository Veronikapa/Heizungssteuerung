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

namespace Heizungssteuerung.UIElemente
{
    /// <summary>
    /// Interaktionslogik für WochentageAuswahlElement.xaml
    /// </summary>
    public partial class WochentageAuswahlElement : UserControl
    {
        public static readonly DependencyProperty ZeitplanElementProperty = DependencyProperty.Register("ZeitplanElement", typeof(Zeitplanelement), typeof(WochentageAuswahlElement), new FrameworkPropertyMetadata((Zeitplanelement)null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public Zeitplanelement ZeitplanElement
        {
            get
            {
                return (Zeitplanelement)GetValue(ZeitplanElementProperty);
            }
            set
            {
                SetValue(ZeitplanElementProperty, value);
            }
        }

        public WochentageAuswahlElement()
        {

            InitializeComponent();
        }

        private void Montag_MouseDownHandler(object sender, MouseButtonEventArgs e)
        {
            ZeitplanElement.MontagAktiv = !ZeitplanElement.MontagAktiv;
            Montag.IsEnabled = !ZeitplanElement.MontagAktiv;
        }

        private void Dienstag_MouseDownHandler(object sender, MouseButtonEventArgs e)
        {
            ZeitplanElement.DienstagAktiv = !ZeitplanElement.DienstagAktiv;
            Dienstag.IsEnabled = !ZeitplanElement.DienstagAktiv;
        }

        private void Mittwoch_MouseDownHandler(object sender, MouseButtonEventArgs e)
        {
            ZeitplanElement.MittwochAktiv = !ZeitplanElement.MittwochAktiv;
            Mittwoch.IsEnabled = !ZeitplanElement.MittwochAktiv;
        }

        private void Donnerstag_MouseDownHandler(object sender, MouseButtonEventArgs e)
        {
            ZeitplanElement.DonnerstagAktiv = !ZeitplanElement.DonnerstagAktiv;
            Donnerstag.IsEnabled = ZeitplanElement.DonnerstagAktiv;
        }

        private void Freitag_MouseDownHandler(object sender, MouseButtonEventArgs e)
        {
            ZeitplanElement.FreitagAktiv = !ZeitplanElement.FreitagAktiv;
            Freitag.IsEnabled = ZeitplanElement.FreitagAktiv;
        }

        private void Samstag_MouseDownHandler(object sender, MouseButtonEventArgs e)
        {
            ZeitplanElement.SamstagAktiv = !ZeitplanElement.SamstagAktiv;
            Samstag.IsEnabled = ZeitplanElement.SamstagAktiv;
        }

        private void Sonntag_MouseDownHandler(object sender, MouseButtonEventArgs e)
        {
            ZeitplanElement.SonntagAktiv = !ZeitplanElement.SonntagAktiv;
            Sonntag.IsEnabled = !ZeitplanElement.SonntagAktiv;
        }
    }
}
