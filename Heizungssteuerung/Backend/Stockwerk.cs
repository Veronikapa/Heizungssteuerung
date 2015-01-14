using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heizungssteuerung.Backend
{
    public class Stockwerk:Wohneinheit
    {
        private Gebaeude gebaeude;
        private string stockwerkId;
        private List<Raum> raumListe;
        private List<string> raumIdListe;

       public string StockwerkId
        {
            get
            {
                return stockwerkId;
            }
        }

        public List<Raum> RaumListe
        {
            get
            {
                return raumListe;
            }
        }

        public List<string> RaumIdListe
        {
            get
            {
                return raumIdListe;
            }
        }

        public override int ZielTemperatur
        {
            get
            {
                return zielTemperatur;
            }
            set
            {
                zielTemperatur = value;
                ZielTemperaturChanged();
            }
        }

        public Stockwerk(string stockwerkId, int aktuelleTemperatur, Gebaeude gebaeude)
        {
            this.wohneinheitId = stockwerkId;

            this.gebaeude = gebaeude;
            this.stockwerkId = stockwerkId;
            this.aktuelleTemperatur = aktuelleTemperatur;
            this.letzteTemperatur = aktuelleTemperatur;
            this.zielTemperatur = aktuelleTemperatur;

            this.raumListe = new List<Raum>();
            this.raumIdListe = new List<string>();
        }

        public void RaumHinzufuegen(Raum r)
        {
            this.raumListe.Add(r);
            this.raumIdListe.Add(r.RaumId);
        }

        public override void ZielTemperaturErhoehen()
        {
            zielTemperatur++;

            ZielTemperaturChanged();
        }

        public override void ZielTemperaturVerringern()
        {
            zielTemperatur--;

            ZielTemperaturChanged();
        }

        public void ZielTemperaturChanged()
        {
            foreach (Raum r in RaumListe)
            {
                r.ZielTemperatur = zielTemperatur;
            }

            gebaeude.ZielTemperaturAnpassen();
        }

        public void ZielTemperaturAnpassen()
        {
            int neueZielTemperatur = 0;

            foreach (Raum r in raumListe)
            {
                neueZielTemperatur += r.ZielTemperatur;
            }

            neueZielTemperatur = (int)neueZielTemperatur / RaumListe.Count;
            zielTemperatur = neueZielTemperatur;

            gebaeude.ZielTemperaturAnpassen();
        }

        public override void TemperaturenAktualisieren()
        {
            base.TemperaturenAktualisieren();

            foreach (Raum r in raumListe)
            {
                r.TemperaturenAktualisieren();
            }
        }

        public override int AnzahlFenster()
        {
            int anzahl = 0;

            foreach (Raum r in raumListe)
            {
                anzahl = anzahl + r.AnzahlFenster();
            }

            return anzahl;
        }

        public override int AnzahlGeschlosseneFenster()
        {
            int anzahl = 0;

            foreach (Raum r in raumListe)
            {
                anzahl = anzahl + r.AnzahlGeschlosseneFenster();
            }

            return anzahl;
        }
    
    }
}
