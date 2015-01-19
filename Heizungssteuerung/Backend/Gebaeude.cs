using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heizungssteuerung.Backend
{
    public class Gebaeude : Wohneinheit
    {
        private string gebaeudeId;
        private List<Stockwerk> stockwerkListe;
        private List<string> stockwerkIDListe;
        private List<Zeitplanelement> zeitplanElementListe;

        public string GebaeudeId
        {
            get
            {
                return gebaeudeId;
            }
        }

        public List<Stockwerk> StockwerkListe
        {
            get
            {
                return stockwerkListe;
            }
        }

        public List<string> StockwerkIDListe
        {
            get
            {
                return stockwerkIDListe;
            }
        }

        public List<Zeitplanelement> ZeitplanElementListe
        {
            get
            {
                return zeitplanElementListe;
            }
        }

        public Gebaeude(string gebaeudeId, int aktuelleTemperatur)
        {
            this.wohneinheitId = gebaeudeId;

            this.gebaeudeId = gebaeudeId;
            this.aktuelleTemperatur = aktuelleTemperatur;
            this.letzteTemperatur = aktuelleTemperatur;
            this.zielTemperatur = aktuelleTemperatur;

            this.stockwerkListe = new List<Stockwerk>();
            this.stockwerkIDListe = new List<string>();
            this.zeitplanElementListe = new List<Zeitplanelement>();
        }

        public void StockwerkHinzufuegen(Stockwerk stock)
        {
            this.stockwerkListe.Add(stock);
            this.stockwerkIDListe.Add(stock.StockwerkId);
        }

        public void ZielTemperaturAnpassen()
        {
            int neueZielTemperatur = 0;

            foreach (Stockwerk s in stockwerkListe)
            {
                neueZielTemperatur += s.ZielTemperatur;
            }

            neueZielTemperatur = (int)neueZielTemperatur / stockwerkListe.Count;
            zielTemperatur = neueZielTemperatur;
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

        private void ZielTemperaturChanged()
        {
            foreach (Stockwerk s in stockwerkListe)
            {
                s.ZielTemperatur = zielTemperatur;
            }
        }

        public override void TemperaturenAktualisieren()
        {
            base.TemperaturenAktualisieren();

            foreach (Stockwerk s in stockwerkListe)
            {
                s.TemperaturenAktualisieren();
            }
        }

        public override int AnzahlFenster()
        {
            int anzahl = 0;

            foreach (Stockwerk s in stockwerkListe)
            {
                anzahl = anzahl + s.AnzahlFenster();
            }

            return anzahl;
        }

        public override int AnzahlGeschlosseneFenster()
        {
            int anzahl = 0;

            foreach (Stockwerk s in stockwerkListe)
            {
                anzahl = anzahl + s.AnzahlFenster();
            }

            return anzahl;
        }
        
        }


    }
