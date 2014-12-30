using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heizungssteuerung.Backend
{
    public class Raum: Wohneinheit
    {
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

        public Raum(string raumId, int aktuelleTemperatur, List<Fenster> fensterListe)
        {
            this.raumId = raumId;
            this.aktuelleTemperatur = aktuelleTemperatur;
            this.letzteTemperatur = aktuelleTemperatur;
            this.zielTemperatur = aktuelleTemperatur;
            this.fensterListe = fensterListe;
        }

        public override void ZielTemperaturErhoehen()
        {
            zielTemperatur++;
        }

        public override void ZielTemperaturVerringern()
        {
            zielTemperatur--;
        }

        //TODO Dominik: Aktuelle Temperatur bei Aufruf von Dialog "Temperatur einstellen" auf Zieltemperatur setzen
        //TODO Dominik: Letzte Temperatur bei Aufruf von Dialog "Temperatur einstellen" auf Zieltemperatur setzen
        public void TemperaturenAnpassen()
        {
            letzteTemperatur = aktuelleTemperatur;
            aktuelleTemperatur = zielTemperatur;
        }

        // TODO Dominik: Methode die Anzahl der geschlossenen Fenster zurückgibt

    }
}
