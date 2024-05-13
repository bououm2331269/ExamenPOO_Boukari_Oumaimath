using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musicien
{
    internal class Corde
    {
        static readonly Random rand = new Random();
        int resistance;
        public int Durabilite { get; set; }
        public Corde(int resistance,int durabilite)
        {
            this.resistance = resistance;
            Durabilite = durabilite;
        }
        public Corde()
        {
            DeterminerResistance();
            DeterminerDurabilite();
        }
        public void DeterminerResistance()
        {
            resistance = rand.Next(1, 11);
        }
        public void DeterminerDurabilite()
        {
            Durabilite = resistance * 2;
        }
        public int GetResistance()
        {
            return resistance;
        }
        public int RemettreDurabilite()
        {
            int nouvelleDurabilite= 0;
           return nouvelleDurabilite = resistance * 2;
        }
        public override string ToString()
        {
            string info = "INFO CORDE\n";
            info += $"Resistance: {GetResistance()}\n";
            info += $"Durabilite: {Durabilite}\n";
            return info;
        }
    }
}
