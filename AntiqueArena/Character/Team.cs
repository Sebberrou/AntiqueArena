using System;
using System.Collections.Generic;

namespace AntiqueArena.Character
{
	public class Team
	{

		public string Name { get; set; }
		public string Description { get; set; }
		public int NbWin { get; set; }
		public int NbPlayed { get; set; }

        public List<Gladiator> Gladiators { get; set; } = new List<Gladiator>();

		private int MaxNbGladiator = 3;

		public Team()
		{

		}

		public decimal VictoryPerCent()
		{
            return Math.Round((100 * (decimal)NbWin) / (decimal)NbPlayed);
        }

		public int NbLost()
		{
			return NbPlayed - NbWin;
		}
		public int AddGladiator(Gladiator gladiator)
		{
			if (Gladiators.Count < this.MaxNbGladiator)
			{
				this.Gladiators.Add(gladiator);
                Console.WriteLine("Le gladiateur " + gladiator.Name + " a été ajouté à l'équipe " + Name);
                return 1;
            }
			else {
                Console.WriteLine("Le gladiateur " + gladiator.Name + " n'a pas été crée, vous avez atteint le maximum de gladiateur pour l'équipe " + Name);
				return 0;
			}
		}

	}
}
