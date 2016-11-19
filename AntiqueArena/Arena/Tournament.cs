using AntiqueArena.Character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntiqueArena.Arena
{
    
    class Tournament
    {
        public string Name { get; set; }
        public List<Player> Players { get; private set; }
        public List<Team> Teams { get; private set; }
        public Tournament()
        {
            Players = new List<Player>();
            Teams = new List<Team>();
        }

        public void AddPlayer(Player player)
        {
            foreach(Team team in player.Teams)
            {
                if (team.Gladiators.Any(g => g.IsValidWarrior() == false))
                {
                    Console.WriteLine(player.Name + " a dans son équipe " + team.Name + " un ou plusieurs gladiateur(s) qui n'ont pas d'armes.");
                    return;
                }
            }
            Players.Add(player);
            Teams.AddRange(player.Teams);
        }
        public void StartTournament()
        {
            // Le tournoi fait s'affronter les équipes 2 à 2, une seule fois
            Console.WriteLine("Le tournoi commence, les combats suivant vont avoir lieu :");
            Teams.OrderBy(x => x.VictoryPerCent());
            for (var i = 1; i < Teams.Count; i=i+2)
            {
                Console.WriteLine("L'équipe " + Teams[i-1].Name + " contre " + Teams[i].Name + ".");
            }
            Console.WriteLine("Commençons les combats");
            for (var i = 1; i < Teams.Count; i = i + 2)
            {
                Console.WriteLine("\n============= L'équipe " + Teams[i - 1].Name + " contre l'équipe " + Teams[i].Name +" ==============");
                Match match = new Match(Teams[i - 1], Teams[i]);
                Team teamWinner = match.StartMatch();
                if (string.IsNullOrEmpty(teamWinner.Name))
                    Console.WriteLine("\t============= C'est un match nul entre les 2 équipes ==============\n");
                else
                    Console.WriteLine("\t============= L'équipe " + teamWinner.Name + " est déclarée gagnante ==============\n");
            }
            ShowStats();
        }
        private void ShowStats()
        {
            foreach (Player player in Players)
            {
                Console.WriteLine("Les équipes du joueur " + player.Pseudo);
                foreach (Team team in Teams)
                {
                    Console.WriteLine("\t\t Les statistiques de l'équipe " + team.Name);
                    Console.WriteLine("\t" + team.NbWin.ToString() + " victoires pour " + team.NbPlayed + " matchs joués => " + team.VictoryPerCent() + "% de victoire(s)");
                    foreach(Gladiator gladiator in team.Gladiators)
                    {
                        Console.WriteLine("\t\t\t Les statistiques du Gladiateur " + gladiator.Name);
                        Console.WriteLine("\t\t" + gladiator.NbWin.ToString() + " victoires pour " + gladiator.NbPlayed.ToString()+ " duels engagés => " + gladiator.VictoryPerCent().ToString()+ "% de victoire(s)");
                    }
                }
            }
        }




    }
}
