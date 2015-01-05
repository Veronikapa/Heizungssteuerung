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
        private bool ganztags;
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
            
            set
            {
                zieltemperatur = value;
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
            set
            {
                stundeVon = value;
            }
        }

        public int StundeBis
        {
            get
            {
                return stundeBis;
            }
            set
            {
                stundeBis = value;
            }
        }

        public int MinuteVon
        {
            get
            {
                return minuteVon;
            }

            set
            {
                minuteVon = value;
            }
        }

        public int MinuteBis
        {
            get
            {
                return minuteBis;
            }
            set
            {
                minuteBis = value;
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
            set
            {
                stockwerkId = value;
            }
        }

        public string RaumId
        {
            get
            {
                return raumId;
            }
            set
            {
                raumId = value;
            }
        }

        public string WohneinheitText
        {
            get
            {
                if (!raumId.Equals(String.Empty))
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
                if (ganztags)
                    return "Ganztags";

                string stundeVonString = stundeVon < 10 ? "0" + stundeVon.ToString() : stundeVon.ToString();
                string minuteVonString = minuteVon < 10 ? "0" + minuteVon.ToString() : minuteVon.ToString();
                string stundeBisString = stundeBis < 10 ? "0" + stundeBis.ToString() : stundeBis.ToString();
                string minuteBisString = minuteBis < 10 ? "0" + minuteBis.ToString() : minuteBis.ToString();

                return stundeVonString + ":" + minuteVonString + " - " + stundeBisString + ":" + minuteBisString;
            }
        }

        public bool Ganztags
        { 
            get
            {
                return ganztags;
            }

            set
            {
                ganztags = value;
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
            this.ganztags = false;
        }
        
        //Überprüfung das sich aktivierte Zeitpläne nicht überschneiden
        public bool AktiveZeitplaeneValidierung(List<Zeitplanelement> zeitplanElemente)
        {
            if (!this.aktiviert)
                return true;

            var aktiveZeitplanElemente = zeitplanElemente.Where(z => z.aktiviert).ToList();

            if (aktiveZeitplanElemente.Count == 0)
                return true;

            foreach (var element in aktiveZeitplanElemente)
            {
                if (element != this)
                {
                    if (!WohneinheitGleich(element))
                        return true;

                    if (UeberpruefeZeitUeberschneidung(element))
                        return false;
                }
            }
            return true;
        }

        private bool WohneinheitGleich(Zeitplanelement element)
        {
            //Eines der Elemente ist auf Stockwerk Ebene --> Validierung notwendig
            if (element.stockwerkId == String.Empty || this.stockwerkId == String.Empty)
                return true;

            //Die Elemente sind im selben Stockwerk
            if (this.stockwerkId == element.stockwerkId)
            {
                //Die Elemente sind im selben Raum
                if (this.raumId == element.raumId)
                    return true;

                //Eines der Elemente ist auf Stockwerk Ebene --> Validierung notwendig
                else if (this.raumId == String.Empty && element.raumId != String.Empty)
                    return true;

                else if (element.raumId == String.Empty && this.raumId != String.Empty)
                    return true;
            }
            return false;
        }

        private bool UeberpruefeZeitUeberschneidung(Zeitplanelement element)
        {
            if (ZeitUeberschneidung(element.montagAktiv, this.montagAktiv, element))
                return true;

            else if (ZeitUeberschneidung(element.dienstagAktiv, this.dienstagAktiv, element))
                return true;

            else if (ZeitUeberschneidung(element.mittwochAktiv, this.mittwochAktiv, element))
                return true;

            else if (ZeitUeberschneidung(element.donnerstagAktiv, this.donnerstagAktiv, element))
                return true;

            else if (ZeitUeberschneidung(element.freitagAktiv, this.freitagAktiv, element))
                return true;

            else if (ZeitUeberschneidung(element.samstagAktiv, this.samstagAktiv, element))
                return true;

            else if (ZeitUeberschneidung(element.sonntagAktiv, this.sonntagAktiv, element))
                return true;

            else
                return false;
        }

        private bool ZeitUeberschneidung(bool tagElementAktiv, bool tagThisAktiv, Zeitplanelement element)
        {
            if (tagElementAktiv && tagThisAktiv)
            {
                if (element.Ganztags || this.ganztags)
                    return true;

                var zeitVonElement = new DateTime(1, 1, 1, element.stundeVon, element.minuteVon, 0);
                var zeitBisElement = new DateTime(1, 1, 1, element.stundeBis, element.minuteBis, 0);
                var zeitVonThis = new DateTime(1, 1, 1, this.stundeVon, this.minuteVon, 0);
                var zeitBisThis = new DateTime(1, 1, 1, this.stundeBis, this.minuteBis, 0);

                //this Zeit zwischen Element Zeit
                if (ZeitZwischenStartEnde(zeitVonThis.TimeOfDay, zeitVonElement.TimeOfDay, zeitBisElement.TimeOfDay))
                    return true;

                else if (ZeitZwischenStartEnde(zeitBisThis.TimeOfDay, zeitVonElement.TimeOfDay, zeitBisElement.TimeOfDay))
                    return true;

               //Element Zeit zwischen this Zeit
                else if (ZeitZwischenStartEnde(zeitVonElement.TimeOfDay, zeitVonThis.TimeOfDay, zeitBisThis.TimeOfDay))
                    return true;

                else if (ZeitZwischenStartEnde(zeitBisElement.TimeOfDay, zeitVonThis.TimeOfDay, zeitBisThis.TimeOfDay))
                    return true;
            }
            return false;
        }

        private bool ZeitZwischenStartEnde(TimeSpan timeToCheck, TimeSpan start, TimeSpan end)
        {
            // see if start comes before end
            if (start < end)
                return start <= timeToCheck && timeToCheck <= end;
            // start is after end, so do the inverse comparison
            return !(end < timeToCheck && timeToCheck < start);
        }
    }
}