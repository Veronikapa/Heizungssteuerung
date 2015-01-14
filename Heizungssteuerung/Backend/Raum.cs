using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heizungssteuerung.Backend
{
    public class Raum: Wohneinheit
    {
        private Stockwerk stockwerk;
        private string raumId;
        private List<Fenster> fensterListe;

        public string RaumId
        {
            get
            {
                return raumId;
            }
        }

        public List<Fenster> FensterListe
        {
            get
            {
                return fensterListe;
            }
        }

        public Raum(string raumId, int aktuelleTemperatur, List<Fenster> fensterListe, Stockwerk stock)
        {
            this.wohneinheitId = raumId;

            this.stockwerk = stock;
            this.raumId = raumId;
            this.aktuelleTemperatur = aktuelleTemperatur;
            this.letzteTemperatur = aktuelleTemperatur;
            this.zielTemperatur = aktuelleTemperatur;
            this.fensterListe = fensterListe;
        }

        public override void ZielTemperaturErhoehen()
        {
            zielTemperatur++;

            stockwerk.ZielTemperaturAnpassen();
        }

        public override void ZielTemperaturVerringern()
        {
            zielTemperatur--;

            stockwerk.ZielTemperaturAnpassen();
        }

        //TODO Dominik: Aktuelle Temperatur bei Aufruf von Dialog "Temperatur einstellen" auf Zieltemperatur setzen
        //TODO Dominik: Letzte Temperatur bei Aufruf von Dialog "Temperatur einstellen" auf Zieltemperatur setzen
        public override int AnzahlGeschlosseneFenster()
        {
            int anzahl = 0;

            foreach (Fenster f in fensterListe)
            {
                if (f.Geschlossen)
                    anzahl++;
            }

            return anzahl;
        }

        public override int AnzahlFenster()
        {
            return fensterListe.Count;
        }
        // TODO Dominik: Methode die Anzahl der geschlossenen Fenster zurückgibt - DONE

    }
}
