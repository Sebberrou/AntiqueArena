using System;
using AntiqueArena.Character;
using AntiqueArena.Stuff;
using System.Collections.Generic;
using System.Linq;

namespace AntiqueArena.Arena
{
	public class Duel
	{
        // Un duel est un affrontement entre 2 gladiateurs, le combat se fait suivant l'initiative des armes
		private List<Gladiator> Gladiators {get;set;} = new List<Gladiator>();
        private List<Equipement>[] Order;
		
		public Duel(Gladiator g1, Gladiator g2)
		{
            g1.NbPlayed++;
            g2.NbPlayed++;
            Gladiators.Add(g1);
            Gladiators.Add(g2);            
            SetIni();
		}

        private void SetIni()
        {
            Order = new List<Equipement>[5];
            foreach (var gladiator in Gladiators)
            {
                foreach (Equipement weapon in gladiator.GetWeapons())
                {
                    if (weapon.IsAvailable)
                    {
                        Order[weapon.WeaponBehav.Initiative] = new List<Equipement>();
                        Order[weapon.WeaponBehav.Initiative].Add(weapon);
                    }
                }
            }
            Order = Order.Where(x => !(x==null)).ToArray();
        }

        public Gladiator Figth()
        {
            List<Gladiator> result = new List<Gladiator>();
            Gladiator winner = new Gladiator();
            foreach (var turn in Order)
            {
                //On récupère les armes de même initiative
                result = Turn(turn);
                //Le résultat peux contenir soit un combattant ( le gagnant ) ou les 2
                if (result.Count > 1)
                {
                    Console.WriteLine("Les deux gladiateurs ont porté leurs coup en même temps, c'est match nul.");
                    //On réinitialise les combattants
                    ResetFigthers();
                    //On renvoie un Gladiator vide en cas de match nul
                    return winner;
                }
                else if (result.Count == 1)
                {
                    Gladiator dead = GetReceiver(result[0]);
                    Console.WriteLine(dead.Name + " est hors combat.");
                    //On réinitialise les combattants
                    ResetFigthers();
                    return result[0];
                }
            }
            SetIni();
            return Figth();                                    
        }
        private List<Gladiator> Turn(List<Equipement> weapons)
        {
            List<Gladiator> winner = new List<Gladiator>();
            foreach (Equipement weapon in weapons)
            {
                //On fait attaquer toutes les armes de même initiative
                Gladiator receiver = this.GetReceiver(weapon.Owner);
                Exchange thisExchange =  new Exchange(weapon.Owner, weapon, receiver );
                Console.WriteLine(weapon.Owner.Name + " donne un coup de " + weapon.Name + " à " + receiver.Name+".");
                if (thisExchange.Throw() == (int)Exchange.ThrowStatus.Sucess)
                {
                    weapon.Owner.NbWin++;
                    winner.Add(weapon.Owner);
                    //On récupère le combattant gagnant dans un tableau, on peux ainsi récupèrer les 2 en cas de match nul
                }
                weapon.NbOfUses++;          
            }

            return winner;


        }

        private Gladiator GetReceiver(Gladiator attacker)
        {
            return Gladiators.Find(x => x.Name != attacker.Name);            
        }

        private void ResetFigthers()
        {
            foreach (var gladiator in Gladiators)
            {
                gladiator.GetWeapons().ForEach(x => x.NbOfUses = 0);
                gladiator.Penalty = 1;
            }

        }
	}
}
