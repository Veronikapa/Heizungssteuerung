using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heizungssteuerung.Backend
{
    public abstract class Wohneinheit
    {
        private static int GRENZE_FROST = 0;
        private static int GRENZE_FEUER = 40;

        protected int aktuelleTemperatur;
        protected int letzteTemperatur; // Temperatur vor Zeitplan
        protected int zielTemperatur;

        protected string wohneinheitId;

        //TODO Dominik: Icon- Werte für Frost, Feuer etc. definieren

        public string WohneinheitId
        {
            get
            {
                return wohneinheitId;
            }
            set
            {
                wohneinheitId = value;
            }
        }

        public int AktuelleTemperatur
        {
            get
            {
                return aktuelleTemperatur;
            }
            set
            {
                aktuelleTemperatur = value;
            }
        }

        public int LetzteTemperatur
        {
            get
            {
                return letzteTemperatur;
            }
            set
            {
                letzteTemperatur = value;
            }
        }

        public virtual int ZielTemperatur
        {
            get
            {
                return zielTemperatur;
            }
            set
            {
                zielTemperatur = value;
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

        public virtual void TemperaturenAktualisieren()
        {
            letzteTemperatur = aktuelleTemperatur;
            aktuelleTemperatur = zielTemperatur;
        }

        public abstract int AnzahlGeschlosseneFenster();

        public abstract int AnzahlFenster();
    }
}
