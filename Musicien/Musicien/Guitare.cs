using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musicien
{
    enum TypeG
    {
        Acoustique,
        Basse,
        Electrique
    }

    internal class Guitare : InstrumentACorde
    {
        public TypeG TypeG { get; set; }
        static readonly Random rand = new Random();
        public Guitare(string nom, int prix, Corde corde, int nbreCord) : base(nom, prix, corde, nbreCord)
        {
            NbreCorde = 6;
            DeterminerTypeG();
        }
        public void DeterminerTypeG()
        {
            int proba = rand.Next(0, 3);
            if (proba == 0)
            {
                TypeG = TypeG.Acoustique;
            }
            if (proba == 1)
            {
                TypeG = TypeG.Basse;
            }
            if(proba == 2)
            {
                TypeG= TypeG.Electrique;    
            }
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
