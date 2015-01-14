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
    /// Interaktionslogik für WohneinheitUiElement.xaml
    /// </summary>
    public partial class WohneinheitUiElement : UserControl
    {
        public static readonly DependencyProperty WohneinheitElementProperty = DependencyProperty.Register("WohneinheitElement", typeof(Wohneinheit), typeof(WohneinheitUiElement), new FrameworkPropertyMetadata((Wohneinheit)null,FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));


        public WohneinheitUiElement()
        {
            this.DataContext = WohneinheitUiElementUserControl;

            InitializeComponent();
        }


        public EventHandler WohneinheitUiElementZielTemperaturVeraendert;

        public Wohneinheit WohneinheitElement
        {
            get
            {
                return (Wohneinheit)GetValue(WohneinheitElementProperty);
            }
            set
            {
                SetValue(WohneinheitElementProperty, value);
            }
        }

        private void ZielTemperaturErhoehen_Click(object sender, RoutedEventArgs e)
        {
            this.WohneinheitElement.ZielTemperaturErhoehen();

            if (WohneinheitUiElementZielTemperaturVeraendert != null)
                WohneinheitUiElementZielTemperaturVeraendert(sender, e);
        }

        private void ZielTemperaturVerringern_Click(object sender, RoutedEventArgs e)
        {
            this.WohneinheitElement.ZielTemperaturVerringern();

            if (WohneinheitUiElementZielTemperaturVeraendert != null)
                WohneinheitUiElementZielTemperaturVeraendert(sender, e);
        }
    }
}
