using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heizungssteuerung.Backend
{
    public class Stockwerk:Wohneinheit
    {
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

        public Stockwerk(string stockwerkId, int aktuelleTemperatur, List<Raum> raumListe)
        {
            this.stockwerkId = stockwerkId;
            this.aktuelleTemperatur = aktuelleTemperatur;
            this.letzteTemperatur = aktuelleTemperatur;
            this.zielTemperatur = aktuelleTemperatur;
            this.raumListe = raumListe;
            this.raumIdListe = new List<string>();
            this.raumListe.ForEach(r => raumIdListe.Add(r.RaumId));
        }
    }
}
