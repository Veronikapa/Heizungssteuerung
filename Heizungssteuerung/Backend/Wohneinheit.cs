using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heizungssteuerung.Backend
{
    public abstract class Wohneinheit
    {
        protected int aktuelleTemperatur;
        protected int letzteTemperatur; // Temperatur vor Zeitplan
        protected int zielTemperatur;

        //TODO Dominik: Icon- Werte für Frost, Feuer etc. definieren

        public int AktuelleTemperatur
        {
            get
            {
                return aktuelleTemperatur;
            }
        }

        public int LetzteTemperatur
        {
            get
            {
                return letzteTemperatur;
            }
        }

        public int ZielTemperatur
        {
            get
            {
                return zielTemperatur;
            }
        }

        public virtual void ZielTemperaturErhoehen()
        {
            zielTemperatur++;
        }

        public virtual void ZielTemperaturVerringern()
        {
            zielTemperatur--;
        }
    }
}
