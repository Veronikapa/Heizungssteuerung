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
        #region Dependency Properties

        public static readonly DependencyProperty WohneinheitElementProperty = 
            DependencyProperty.Register(
                "WohneinheitElement", 
                typeof(Wohneinheit),
                typeof(WohneinheitUiElement), 
                new FrameworkPropertyMetadata(OnAvailableItemsChanged));

        public static readonly DependencyProperty TreeViewProperty =
            DependencyProperty.Register(
                "TreeViewReference",
                typeof(TreeView),
                typeof(WohneinheitUiElement),
                new FrameworkPropertyMetadata(null));

        public static readonly DependencyProperty FrostProperty =
            DependencyProperty.Register(
                "Frost",
                typeof(BitmapImage),
                typeof(WohneinheitUiElement),
                new FrameworkPropertyMetadata(null));

        public static readonly DependencyProperty FeuerProperty =
            DependencyProperty.Register(
                "Feuer",
                typeof(BitmapImage),
                typeof(WohneinheitUiElement),
                new FrameworkPropertyMetadata(null));

        public static readonly DependencyProperty FensterProperty =
            DependencyProperty.Register(
                "Fenster",
                typeof(BitmapImage),
                typeof(WohneinheitUiElement),
                new FrameworkPropertyMetadata(null));

        public static readonly DependencyProperty MultipleProperty =
            DependencyProperty.Register(
                "Multiple",
                typeof(BitmapImage),
                typeof(WohneinheitUiElement),
                new FrameworkPropertyMetadata(null));

        public static readonly DependencyProperty StoerProperty =
            DependencyProperty.Register(
                "Stoer",
                typeof(BitmapImage),
                typeof(WohneinheitUiElement),
                new FrameworkPropertyMetadata(null));

        public static readonly DependencyProperty MarginOneProperty =
            DependencyProperty.Register(
                "MarginOne",
                typeof(Thickness),
                typeof(WohneinheitUiElement),
                new FrameworkPropertyMetadata(null));

        public static readonly DependencyProperty MarginTwoProperty =
            DependencyProperty.Register(
                "MarginTwo",
                typeof(Thickness),
                typeof(WohneinheitUiElement),
                new FrameworkPropertyMetadata(null));

        public static readonly DependencyProperty MarginThreeProperty =
            DependencyProperty.Register(
                "MarginThree",
                typeof(Thickness),
                typeof(WohneinheitUiElement),
                new FrameworkPropertyMetadata(null));

        public static readonly DependencyProperty MarginFourProperty =
            DependencyProperty.Register(
                "MarginFour",
                typeof(Thickness),
                typeof(WohneinheitUiElement),
                new FrameworkPropertyMetadata(null));

        public static readonly DependencyProperty MarginFiveProperty =
            DependencyProperty.Register(
                "MarginFive",
                typeof(Thickness),
                typeof(WohneinheitUiElement),
                new FrameworkPropertyMetadata(null));

        #endregion

        public WohneinheitUiElement()
        {
            InitializeComponent();

            this.Loaded += WohneinheitUiElement_Loaded;
        }

        public EventHandler WohneinheitUiElementZielTemperaturVeraendert;

        #region Properties

        public TreeView TreeViewReference
        {
            get
            {
                return (TreeView)GetValue(TreeViewProperty);
            }
            set
            {
                SetValue(TreeViewProperty, value);
            }
        }

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

        public BitmapImage Frost
        {
            get
            {
                return (BitmapImage)GetValue(FrostProperty);
            }
            set
            {
                SetValue(FrostProperty, value);
            }
        }

        public BitmapImage Feuer
        {
            get
            {
                return (BitmapImage)GetValue(FeuerProperty);
            }
            set
            {
                SetValue(FeuerProperty, value);
            }
        }

        public BitmapImage Fenster
        {
            get
            {
                return (BitmapImage)GetValue(FensterProperty);
            }
            set
            {
                SetValue(FensterProperty, value);
            }
        }

        public BitmapImage Multiple
        {
            get
            {
                return (BitmapImage)GetValue(MultipleProperty);
            }
            set
            {
                SetValue(MultipleProperty, value);
            }
        }

        public BitmapImage Stoer
        {
            get
            {
                return (BitmapImage)GetValue(StoerProperty);
            }
            set
            {
                SetValue(StoerProperty, value);
            }
        }

        public Thickness MarginOne
        {
            get
            {
                return (Thickness)GetValue(MarginOneProperty);
            }
            set
            {
                SetValue(MarginOneProperty, value);
            }
        }

        public Thickness MarginTwo
        {
            get
            {
                return (Thickness)GetValue(MarginTwoProperty);
            }
            set
            {
                SetValue(MarginTwoProperty, value);
            }
        }

        public Thickness MarginThree
        {
            get
            {
                return (Thickness)GetValue(MarginThreeProperty);
            }
            set
            {
                SetValue(MarginThreeProperty, value);
            }
        }

        public Thickness MarginFour
        {
            get
            {
                return (Thickness)GetValue(MarginFourProperty);
            }
            set
            {
                SetValue(MarginFourProperty, value);
            }
        }

        public Thickness MarginFive
        {
            get
            {
                return (Thickness)GetValue(MarginFiveProperty);
            }
            set
            {
                SetValue(MarginFiveProperty, value);
            }
        }
        #endregion

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

            if (this.WohneinheitElement.AktuelleTemperatur >= Wohneinheit.GRENZE_FEUER)
            {
                feuerIconVisible = true;

                if (fensterIconVisible || frostIconVisible || stoerIconVisible)
                {
                    mehrereIconsVisible = true;
                }
            }

            if (this.WohneinheitElement.AktuelleTemperatur <= Wohneinheit.GRENZE_FROST && this.WohneinheitElement.AktuelleTemperatur != -999)
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
            this.TreeViewReference.Items.Refresh();
            this.TreeViewReference.UpdateLayout();
            
        }

        private void ZielTemperaturVerringern_Click(object sender, RoutedEventArgs e)
        {
            this.WohneinheitElement.ZielTemperaturVerringern();
            this.TreeViewReference.Items.Refresh();
            this.TreeViewReference.UpdateLayout();
        }
    }
}
