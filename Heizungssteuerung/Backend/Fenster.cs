using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heizungssteuerung.Backend
{
    public class Fenster
    {
        private string fensterId;
        private bool geschlossen;

        public string FensterID
        {
            get
            {
                return fensterId;
            }
        }

        public bool Geschlossen
        {
            get
            {
                return geschlossen;
            }
        }

        public Fenster(string fensterId, bool geschlossen)
        {
            this.fensterId = fensterId;
            this.geschlossen = geschlossen;
        }
    }
}
