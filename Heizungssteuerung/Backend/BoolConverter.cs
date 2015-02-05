using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

// Der Bool Converter wird gebraucht, um die Fenster zu verstecken (Visiblity = Collapsed), basierend auf dem bool Wert von Geschlossen.

namespace Heizungssteuerung.Backend
{
    class BoolConverter:IValueConverter
    {
public BoolConverter() {}
// Der hat zusätzlich die Variable "Reverse", wird sie auf true gesetzt, werden !Geschlossen Elemente versteckt -> Effekt wird umgekehrt
       
        public bool Reverse { get; set; }

        public object Convert(object value, Type tartegtType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool bValue = (bool)value;
            if (bValue !=Reverse)
            {
                return Visibility.Visible;
            }
            else 
            {
                    return Visibility.Collapsed;
            }
        }


public object ConvertBack (object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Visibility visibility = (Visibility)value;

            if (visibility == Visibility.Visible)
                return !Reverse;
            else
                return Reverse;
        }

    }
    }

