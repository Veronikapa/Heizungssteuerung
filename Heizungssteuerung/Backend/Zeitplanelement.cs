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
        private bool[] wochentage;
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
        }

        public int Zieltemperatur
        {
            get
            {
                return zieltemperatur;
            }
        }

        public bool[] Wochentage
        {
            get
            {
                return wochentage;
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
        #endregion getter/setter

        public Zeitplanelement(int zeitplanId, bool aktiviert, string gebaeudeId, string stockwerkId, string raumId)
        {
            this.zeitplanId = zeitplanId;
            this.aktiviert = aktiviert;
            this.zieltemperatur = 25;
            this.wochentage = new bool[7] { false, false, false, false, false, false, false};
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
