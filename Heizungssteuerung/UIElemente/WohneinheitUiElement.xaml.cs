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

        public static readonly DependencyProperty FeuerFensterProperty =
            DependencyProperty.Register(
                "FeuerFenster",
                typeof(BitmapImage),
                typeof(WohneinheitUiElement),
                new FrameworkPropertyMetadata(null));

        public static readonly DependencyProperty FrostFensterProperty =
            DependencyProperty.Register(
                "FrostFenster",
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

        public static readonly DependencyProperty ForegroundColorProperty =
            DependencyProperty.Register(
                "ForegroundColor",
                typeof(Brush),
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

        public BitmapImage FeuerFenster
        {
            get
            {
                return (BitmapImage)GetValue(FeuerFensterProperty);
            }
            set
            {
                SetValue(FeuerFensterProperty, value);
            }
        }

        public BitmapImage FrostFenster
        {
            get
            {
                return (BitmapImage)GetValue(FrostFensterProperty);
            }
            set
            {
                SetValue(FrostFensterProperty, value);
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

        public Brush ForegroundColor
        {
            get
            {
                return (Brush)GetValue(ForegroundColorProperty);
            }
            set
            {
                SetValue(ForegroundColorProperty, value);
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
            FrostFensterIcon.Visibility = Visibility.Hidden;
            FrostIcon.Visibility = Visibility.Hidden;
            FensterIcon.Visibility = Visibility.Hidden;
            FeuerIcon.Visibility = Visibility.Hidden;
            FeuerFensterIcon.Visibility = Visibility.Hidden;


            bool fensterOffen = this.WohneinheitElement.AnzahlFenster() > this.WohneinheitElement.AnzahlGeschlosseneFenster();

            if (this.WohneinheitElement.GetType().Equals(typeof(Raum)))
            {
                if (this.WohneinheitElement.AktuelleTemperatur >= Wohneinheit.GRENZE_FEUER)
                {
                    if (fensterOffen)
                    {
                        FeuerFensterIcon.Visibility = Visibility.Visible;
                    
                    }
                    else
                    {
                        FeuerIcon.Visibility = Visibility.Visible;
                    }

                    return;
                }

                if (this.WohneinheitElement.AktuelleTemperatur <= Wohneinheit.GRENZE_FROST)
                {
                    if (fensterOffen)
                    {
                        FrostFensterIcon.Visibility = Visibility.Visible;

                    }
                    else
                    {
                        FrostIcon.Visibility = Visibility.Visible;
                    }

                    return;
                }

                if (fensterOffen)
                {
                    FensterIcon.Visibility = Visibility.Visible;
                }
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
