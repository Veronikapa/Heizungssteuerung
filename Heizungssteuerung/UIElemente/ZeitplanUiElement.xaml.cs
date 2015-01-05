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
    /// Interaktionslogik für ZeitplanUiElement.xaml
    /// </summary>
    public partial class ZeitplanUiElement : UserControl
    {
        public static readonly DependencyProperty ZeitplanElementProperty = DependencyProperty.Register("ZeitplanElement", typeof(Zeitplanelement), typeof(ZeitplanUiElement), new FrameworkPropertyMetadata((Zeitplanelement)null,FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

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

        public MouseButtonEventHandler ZeitplanUiElementMouseDownEvent;
        public EventHandler ZeitplanUiElementAktiviertEvent;

        public ZeitplanUiElement()
        {
            this.DataContext = ZeitplanUiElementUserControl;

            InitializeComponent();
        }

        private void ZeitplanUiElementUserControl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(ZeitplanUiElementMouseDownEvent!=null)
                ZeitplanUiElementMouseDownEvent(sender, e);
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if(ZeitplanUiElementAktiviertEvent!=null)
                ZeitplanUiElementAktiviertEvent(sender, e);
        }
    }
}
