using System;
using System.Collections.Generic;

namespace AntiqueArena.Character
{
	public class Player
	{

		public string Name { get; private set; }
		public string FirstName { get; private set; }
		public string Pseudo { get; private set; }
		public DateTime InscriptionDate { get; private set; }

		public List<Team> Teams { get; set; } = new List<Team>();
		private int MaxNbTeam = 5;
        
		public Player(string name, string firstname, string pseudo)
		{
			Name = name;
			FirstName = firstname;
			Pseudo = pseudo;
			InscriptionDate = DateTime.Now;
		}

		public string AddTeam(string name, string description )
		{
			if (Teams.Count <= this.MaxNbTeam)
			{
				Team team = new Team() { Name = name, Description = description };
				Teams.Add(team);
				return "The team " + name + " was created.";
			}
			else {
				return "The team " + name + " was not created, you have reach the maximum number of team";
			}
		}
	}
}
