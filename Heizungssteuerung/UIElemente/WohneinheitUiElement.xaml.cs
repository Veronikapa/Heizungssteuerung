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
        public static readonly DependencyProperty WohneinheitElementProperty = DependencyProperty.Register("WohneinheitElement", typeof(Wohneinheit), typeof(WohneinheitUiElement), new FrameworkPropertyMetadata(OnAvailableItemsChanged) 
        {
            BindsTwoWayByDefault =true
        });       

        public WohneinheitUiElement()
        {
            //this.DataContext = WohneinheitUiElementUserControl;

            InitializeComponent();

            this.Loaded += WohneinheitUiElement_Loaded;
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

        public static void OnAvailableItemsChanged(
           DependencyObject sender,
           DependencyPropertyChangedEventArgs e)
        {
            // Breakpoint here to see if the new value is being set
            var newValue = e.NewValue;
        }

        void WohneinheitUiElement_Loaded(object sender, RoutedEventArgs e)
        {
            bool frostIconVisible = false;
            bool feuerIconVisible = false;
            bool fensterIconVisible = false;
            bool stoerIconVisible = false;
            bool mehrereIconsVisible = false;

            MultipleIcon.Visibility = Visibility.Hidden;
            FrostIcon.Visibility = Visibility.Hidden;
            FensterIcon.Visibility = Visibility.Hidden;
            FeuerIcon.Visibility = Visibility.Hidden;
            StoerIcon.Visibility = Visibility.Hidden;

            if (this.WohneinheitElement.AktuelleTemperatur >= 35)
            {
                feuerIconVisible = true;

                if (fensterIconVisible || frostIconVisible || stoerIconVisible)
                {
                    mehrereIconsVisible = true;
                }
            }

            if (this.WohneinheitElement.AktuelleTemperatur <= 5 && this.WohneinheitElement.AktuelleTemperatur != 999)
            {
                frostIconVisible = true;

                if (feuerIconVisible || fensterIconVisible || stoerIconVisible)
                {
                    mehrereIconsVisible = true;
                }
            }

            if (this.WohneinheitElement.AnzahlFenster() > this.WohneinheitElement.AnzahlGeschlosseneFenster())
            {
                fensterIconVisible = true;

                if (feuerIconVisible || frostIconVisible || stoerIconVisible)
                {
                    mehrereIconsVisible = true;
                }
            }

            if (this.WohneinheitElement.AktuelleTemperatur == -999)
            {
                stoerIconVisible = true;

                if (feuerIconVisible || frostIconVisible || fensterIconVisible)
                {
                    mehrereIconsVisible = true;
                }
            }

            if (mehrereIconsVisible)
            {
                MultipleIcon.Visibility = Visibility.Visible;
            }
            else if (frostIconVisible)
            {
                FrostIcon.Visibility = Visibility.Visible;
            }
            else if (fensterIconVisible)
            {
                FensterIcon.Visibility = Visibility.Visible;
            }
            else if (feuerIconVisible)
            {
                FeuerIcon.Visibility = Visibility.Visible;
            }
            else if (stoerIconVisible)
            {
                StoerIcon.Visibility = Visibility.Visible;
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
