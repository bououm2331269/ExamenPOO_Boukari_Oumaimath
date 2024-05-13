using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Musicien
{
    internal class Musicien
    {
        static readonly Random rand = new Random();
        public string Nom { get; set; }
        public InstrumentACorde Instrument { get; set; }
        public int Niveau { get; set; }
        public int Experience { get; set; }
        public int Montant { get; set; }
        public Piece PieceFacile { get; set; }  
        public Musicien(string nom,int niveau,int experience,int montant,Piece piece)
        {
            Nom = nom;
            Instrument = new Guitare("Guitare",1000,new Corde(),6);
            Niveau = niveau;
            Experience =experience;
            Montant = montant;
            PieceFacile = piece;   
        }
        public Musicien(string nom)
        {
            Nom = nom;
            Instrument = new Guitare("Guitare", 1000, new Corde(), 6);
            Niveau = 1;
            Experience = 0;
            DeterminerMontant();
            PieceFacile = new Piece();
        }
        public void ChangerNiveau()
        {
            /*if (Experience > 100)
            {
                int nouveauNiveau = Niveau * Experience;
            }*/

        }
        public void DeterminerMontant()
        {
            Montant = rand.Next(12000, 50000);
        }
        public override string ToString()
        {
            string info = "INFO MUSICIEN\n";
            info += $"Nom: {Nom}\n  Niveau:{Niveau}  Exp:{Experience}$\n";
            info += $"Vous posseder présentement {Montant}\n";
            info += $" {Instrument}\n";
            return info;
        }

    }
}
