using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musicien
{
    internal class Violon:InstrumentACorde
    {
        static readonly Random rand = new Random();
        static string[] Noms =
        {
            "ViolonGuarneri","ViolonStradivarius","ViolonAmati","ViolonGuisepe"
        };
        public Violon(string nom, int prix, Corde corde, int nbreCord) : base( nom, prix, corde,  nbreCord)
        {
           NbreCorde = 4;
           Nom = Noms[rand.Next(0, Noms.Length)];
        }
        public override string ToString()
        {
            string info = "";
            info += $"Instrument: Nom:{Nom}\n";
            info += $"{Corde}\n";
            return info;
        }
    }
}
