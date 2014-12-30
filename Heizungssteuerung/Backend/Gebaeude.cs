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

        public Gebaeude(string gebaeudeId, int aktuelleTemperatur, List<Stockwerk> stockwerkListe)
        {
            this.gebaeudeId = gebaeudeId;
            this.aktuelleTemperatur = aktuelleTemperatur;
            this.letzteTemperatur = aktuelleTemperatur;
            this.zielTemperatur = aktuelleTemperatur;
            this.stockwerkListe = stockwerkListe;
        }
    }
}
