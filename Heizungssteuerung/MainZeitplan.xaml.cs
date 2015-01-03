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
using Heizungssteuerung.UIElemente;
using Heizungssteuerung.Backend;

namespace Heizungssteuerung
{
    /// <summary>
    /// Interaktionslogik für MainZeitplan.xaml
    /// </summary>
    public partial class MainZeitplan : Window
    {
        public Zeitplanelement ZeitplanElementMain
        {
            get;
            set;
        }

        public MainZeitplan()
        {
            ZeitplanElementMain = new Zeitplanelement(1, true, "Gebäude", "Stockwerk1", "Küche");
            InitializeComponent();
        }
    }
}
