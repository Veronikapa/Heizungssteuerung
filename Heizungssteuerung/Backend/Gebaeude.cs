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

        public Gebaeude(string gebaeudeId, int aktuelleTemperatur, List<Stockwerk> stockwerkListe)
        {
            this.gebaeudeId = gebaeudeId;
            this.aktuelleTemperatur = aktuelleTemperatur;
            this.letzteTemperatur = aktuelleTemperatur;
            this.zielTemperatur = aktuelleTemperatur;
            this.stockwerkListe = stockwerkListe;

            this.stockwerkIDListe = new List<string>();
            this.stockwerkListe.ForEach(s => stockwerkIDListe.Add(s.StockwerkId));
            this.zeitplanElementListe = new List<Zeitplanelement>();
        }
    }
}
