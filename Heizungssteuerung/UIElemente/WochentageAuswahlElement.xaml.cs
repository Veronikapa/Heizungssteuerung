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
            AddHandler(FrameworkElement.MouseDownEvent, new MouseButtonEventHandler(MouseDownHandler), true);
        }

        private void MouseDownHandler(object sender, MouseButtonEventArgs e)
        {
            if (Montag.IsMouseOver)
                Montag.IsEnabled = !ZeitplanElement.MontagAktiv;

            if (Dienstag.IsSelectionActive)
                Dienstag.IsEnabled = !ZeitplanElement.DienstagAktiv;
        } 
    }
}
