using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heizungssteuerung.Backend
{
    public class Zeitplanelement
    {
        #region private
        private int zeitplanId;
        private bool aktiviert;
        private int zieltemperatur;
        private bool montagAktiv;
        private bool dienstagAktiv;
        private bool mittwochAktiv;
        private bool donnerstagAktiv;
        private bool freitagAktiv;
        private bool samstagAktiv;
        private bool sonntagAktiv;
        private int stundeVon;
        private int stundeBis;
        private int minuteVon;
        private int minuteBis;
        private string gebaeudeId;
        private string stockwerkId;
        private string raumId;
        #endregion private

        #region getter/setter
        public int ZeitplanId
        {
            get
            {
                return zeitplanId;
            }
        }

        public bool Aktiviert
        {
            get
            {
                return aktiviert;
            }

            set
            {
                aktiviert = value;
            }
        }

        public int Zieltemperatur
        {
            get
            {
                return zieltemperatur;
            }
        }

        public bool MontagAktiv
        {
            get
            {
                return montagAktiv;
            }

            set
            {
                montagAktiv = value;
            }
        }

        public bool DienstagAktiv
        {
            get
            {
                return dienstagAktiv;
            }

            set
            {
                dienstagAktiv = value;
            }
        }

        public bool MittwochAktiv
        {
            get
            {
                return mittwochAktiv;
            }

            set
            {
                mittwochAktiv = value;
            }
        }

        public bool DonnerstagAktiv
        {
            get
            {
                return donnerstagAktiv;
            }

            set
            {
                donnerstagAktiv = value;
            }
        }

        public bool FreitagAktiv
        {
            get
            {
                return freitagAktiv;
            }

            set
            {
                freitagAktiv = value;
            }
        }

        public bool SamstagAktiv
        {
            get
            {
                return samstagAktiv;
            }

            set
            {
                samstagAktiv = value;
            }
        }

        public bool SonntagAktiv
        {
            get
            {
                return sonntagAktiv;
            }

            set
            {
                sonntagAktiv = value;
            }
        }

        public int StundeVon
        {
            get
            {
                return stundeVon;
            }
        }

        public int StundeBis
        {
            get
            {
                return stundeBis;
            }
        }

        public int MinuteVon
        {
            get
            {
                return minuteVon;
            }
        }

        public int MinuteBis
        {
            get
            {
                return minuteBis;
            }
        }

        public string GebaeudeId
        {
            get
            {
                return gebaeudeId;
            }
        }

        public string StockwerkId
        {
            get
            {
                return stockwerkId;
            }
        }

        public string RaumId
        {
            get
            {
                return raumId;
            }
        }

        public string WohneinheitText
        {
            get
            {
                if (raumId.Equals(String.Empty))
                    return raumId;

                else if (!stockwerkId.Equals(String.Empty))
                    return stockwerkId;

                else
                    return gebaeudeId;
            }
        }

        public string ZieltemperaturText
        {
            get
            {
                return zieltemperatur.ToString() + "° C";
            }
        }

        public string UhrzeitText
        {
            get
            {
                string stundeVonString = stundeVon < 10 ? "0" + stundeVon.ToString() : stundeVon.ToString();
                string minuteVonString = minuteVon < 10 ? "0" + minuteVon.ToString() : minuteVon.ToString();
                string stundeBisString = stundeBis < 10 ? "0" + stundeBis.ToString() : stundeBis.ToString();
                string minuteBisString = minuteBis < 10 ? "0" + minuteBis.ToString() : minuteBis.ToString();

                return stundeVonString + ":" + minuteVonString + " - " + stundeBisString + ":" + minuteBisString;
            }
        }
        #endregion getter/setter

        public Zeitplanelement(int zeitplanId, bool aktiviert, string gebaeudeId, string stockwerkId, string raumId)
        {
            this.zeitplanId = zeitplanId;
            this.aktiviert = aktiviert;
            this.zieltemperatur = 25;
            this.stundeVon = 0;
            this.stundeBis = 0;
            this.minuteVon = 0;
            this.minuteBis = 0;
            this.gebaeudeId = gebaeudeId;
            this.stockwerkId = stockwerkId;
            this.raumId = raumId;
        }

        //TODO Veronika: Überprüfung das sich aktivierte Zeitpläne nicht überschneiden
    }
}