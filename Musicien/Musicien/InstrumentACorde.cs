using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musicien
{
    internal class InstrumentACorde
    {
        public string Nom { get; set; }
        public int PrixAchat { get; set; }
        public Corde Corde { get; set; }
        public int NbreCorde { get; set; }
        public InstrumentACorde(string nom, int prix, Corde corde, int nbreCorde)
        {
            Nom = nom;
            Corde = new Corde();
            PrixAchat = Corde.GetResistance()*200;
            NbreCorde = nbreCorde;
        }

        public static bool operator <(InstrumentACorde p1, InstrumentACorde p2)
        {
            return p1.Corde.GetResistance() < p2.Corde.GetResistance();
        }
        public static bool operator >(InstrumentACorde p1, InstrumentACorde p2)
        {
            return p1.Corde.GetResistance() > p2.Corde.GetResistance();
        }

        
    }
}
