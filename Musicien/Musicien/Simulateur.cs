using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Musicien
{
    internal class Simulateur
    {
        public Musicien Musicien { get; set; }
        public InstrumentACorde[] InstrumentACordes { get; set; }
        public List<Piece> Pieces { get; set; }
        static readonly Random rand = new Random();
        public Simulateur()
        {
            Musicien = new Musicien("Ouma");
            InstrumentACordes = new InstrumentACorde[5];
            AjouterInstrument();
            for (int i = 0; i < InstrumentACordes.Length - 1; i++)
            {
                if (InstrumentACordes.Length > 1)
                {
                    Musicien.Instrument = DeterminerMeilleurInstrument(InstrumentACordes[i], InstrumentACordes[i + 1]);
                }

            }
            Pieces = new List<Piece>(); 
            for(int i = 0; i < 10; i++)
            {
                Pieces.Add(new Piece());
            }
        }
        //public Simulateur
        public InstrumentACorde DeterminerMeilleurInstrument(InstrumentACorde I1, InstrumentACorde I2)
        {
            InstrumentACorde meilleur = null;
            if (I1 > I2)
            {
                meilleur = I1;
            }
            else
            {
                meilleur = I2;
            }
            Console.WriteLine($"La meilleur instrument est:{meilleur.Nom} d'une resistance de {meilleur.Corde.GetResistance()}");
            return meilleur;
        }

        private void AjouterInstrument()
        {
            InstrumentACordes[0] = (new Guitare("Bil", 200, new Corde(), 6));
            InstrumentACordes[1] = (new Guitare("Bol", 300, new Corde(), 6));
            InstrumentACordes[2] = (new Violon("", 200, new Corde(), 4));
            InstrumentACordes[3] = (new Violon("", 200, new Corde(), 4));
            InstrumentACordes[4] = (new Guitare("Lary", 200, new Corde(), 6));
        }
        public void Simulation()
        {
            Depart();
            Console.WriteLine($"Vous n'avez pas d'instrument!\n");
            Console.WriteLine("Appuyer sur une touche pour commencer votre aventure");
            Console.ReadLine();
            bool continuer=true;
            do
            {
                string choix;
                const string VOIR_STATUT = "V";
                const string JOUER = "J";
                const string REPARER_INSTRUMENT = "R";
                const string ACHETER_PIECE = "A";
                const string PRATIQUER = "P";
                const string QUITTER = "Q";
                Console.WriteLine(
                    $"****************************************************************" + Environment.NewLine +
                    $"* Bienvenue dans votre menu.Que voulez vous faire?             *" + Environment.NewLine +
                    $"* [{VOIR_STATUT}] (V)OIR STATUT MUSICIEN                                   *" + Environment.NewLine +
                    $"* [{PRATIQUER}] (P)RATIQUER        *" + Environment.NewLine +
                    $"* [{REPARER_INSTRUMENT}]  (R)éparer un instrument          *" + Environment.NewLine +
                    $"* [{ACHETER_PIECE}] (A)cheter nouvelle piece        *" + Environment.NewLine +
                    $"* [{JOUER}] (J)OUER                                               *" + Environment.NewLine +
                    $"* [{QUITTER}] (J)OUER                                               *" + Environment.NewLine +
                    $"****************************************************************");

                choix = Console.ReadLine().ToUpper();
                switch (choix.ToUpper())
                {
                    case VOIR_STATUT:
                        Console.WriteLine($"{Musicien}");
                        break;
                    case PRATIQUER:
                        Afficher();
                        try
                        {
                            Pratiquer();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case REPARER_INSTRUMENT:
                        Musicien.Instrument.Corde.Durabilite = Musicien.Instrument.Corde.RemettreDurabilite();
                        Console.WriteLine($"la nouvelle durabilité de votre instrument est :{Musicien.Instrument.Corde.Durabilite}");
                        break;

                    case ACHETER_PIECE:
                        for(int i = 0; i < 3; i++)
                        {
                           Console.WriteLine( Pieces[i]);
                        }
                        

                        break;
                    case JOUER:


                        break;
                    case QUITTER:
                        continuer = false;
                        break;
                    default:
                        Console.WriteLine($"\"{choix}\" N'est pas une option.");
                        break;

                }

            }while (continuer==true);
        }

        public void Pratiquer()
        {
            Piece piece = Pieces[rand.Next(0, Pieces.Count() - 1)];
            if (Musicien.Instrument.Corde.Durabilite > 0)
            {
                Musicien.Experience += piece.QuantiteExperience;
                Musicien.Instrument.Corde.Durabilite -=1;
                Console.WriteLine($"la nouvelle experience de votre musicien est :{Musicien.Experience}");
            }
            else
            {
                throw new Exception($"Le client {Musicien.Instrument} n'a plus de durabilité\n");
            }
        }
        public void Afficher()
        {
            foreach (Piece piece in Pieces)
            {
                Console.WriteLine(piece);
            }
        }
      
        public string Depart()
        {
            string info = "Bienvenue à la simulation de votre nouvelle carriére de musicien\n";
            info += $"{Musicien}\n";
            info += $"Vous n'avez pas d'instrument!\n";
            return info;
        }
        public override string ToString()
        {
            string info = "Bienvenue à la simulation de votre nouvelle carriére de musicien\n";
            info += $"{Musicien}\n";
            info += $"\n";
            return info;
        }
    }
}
