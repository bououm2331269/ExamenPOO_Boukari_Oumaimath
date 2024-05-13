using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Musicien
{
    enum NiveauDifficulte
    {
        Facile,
        Moyen,
        Difficile
    }
    internal class Piece
    {
        static string[] Noms =
        {
            "EmmaBras","Alice","Léa","Sophia","Mia","Charlie","Amélia","Florence","Charlotte","Liam","Noah","William","Thomas","Logan","Jacob","Nathan","Édouard","Léo","Félix","Gil","Abdellah", "Abdallah", "Abdoullah","Abdeldjalil","Abdelali","Abdelalim","Abdelatif","Abdelazi","Abdelbassir","Abed"

        };
        static readonly Random rand = new Random();
        public string Nom { get; set; }
        public NiveauDifficulte NiveauDifficulte { get; set; }
        public int QuantiteExperience { get; set; }
        public int NiveauMin {  get; set; }
        public int Prix { get; set; }

        public Piece(string nom,NiveauDifficulte niveau,int experience,int niveauMax,int prix)
        {
            Nom = nom;
            NiveauDifficulte = niveau;
            QuantiteExperience = experience;
            NiveauMin = niveauMax;
            Prix = prix;
        }

        public Piece()
        {
            DeterminerNom();
            DeterminerNiveau();
            DeterminerExperince();
            DeterminerNiveauMin();
            DeterminerPrix();
        }
        public void DeterminerNom()
        {
            Nom = Noms[rand.Next(0, Noms.Length)];
        }
        public void DeterminerNiveau()
        {
            int proba = rand.Next(0, 3);
            if (proba == 0)
            {
                NiveauDifficulte= NiveauDifficulte.Facile;
            }
            if (proba == 1)
            {
                NiveauDifficulte = NiveauDifficulte.Moyen; 
            }
            if (proba == 2)
            {
                NiveauDifficulte = NiveauDifficulte.Difficile;
            }
        }
        public void DeterminerExperince()
        {
            if(NiveauDifficulte == NiveauDifficulte.Facile)
            {
                QuantiteExperience = rand.Next(10, 31);
            }
            if (NiveauDifficulte == NiveauDifficulte.Moyen)
            {
                QuantiteExperience = rand.Next(60, 81);
            }
            if (NiveauDifficulte == NiveauDifficulte.Difficile)
            {
                QuantiteExperience = rand.Next(100, 151);
            }
        }
        public void DeterminerNiveauMin()
        {
            if (NiveauDifficulte == NiveauDifficulte.Facile)
            {
                NiveauMin = 1;
            }
            if (NiveauDifficulte == NiveauDifficulte.Moyen)
            {
                NiveauMin = rand.Next(2, 4);
            }
            if (NiveauDifficulte == NiveauDifficulte.Difficile)
            {
                NiveauMin = rand.Next(4, 5);
            }
        }

        public void DeterminerPrix()
        {
            if (NiveauDifficulte == NiveauDifficulte.Facile)
            {
                Prix = 200;
            }
            if (NiveauDifficulte == NiveauDifficulte.Moyen)
            {
                Prix = 400;
            }
            if (NiveauDifficulte == NiveauDifficulte.Difficile)
            {
                Prix = 600;
            }
        }

        public override string ToString()
        {
            string info = "";
            info += $"Nom: {Nom}\n  Niveau:{NiveauDifficulte} Prix:{Prix}\n";
            return info;
        }
    }
}
