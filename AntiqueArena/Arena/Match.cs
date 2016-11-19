using AntiqueArena.Character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntiqueArena.Arena
{
    class Match
    {
        // Un match est une suite de duels 
        public Team team1 { get; set;}
        public Team team2 { get; set;}

        public Match(Team t1, Team t2)
        {
            t1.NbPlayed++;
            t2.NbPlayed++;
            team1 = t1;
            team2 = t2;
            
        }

        public Team StartMatch()
        {
            int i = 0;
            int j = 0;
            int nb = 1;
            Duel duel;
            Gladiator winner;
            //On compte les morts de chaque équipe, si ce nombre dépasse le nombre de gladiateur alors le match prend fin
            while ( i < team1.Gladiators.Count &&  j < team2.Gladiators.Count)
            {
                Console.WriteLine("\t Duel n°" + nb + " :");
                Console.WriteLine("Le gladiateur " + team1.Gladiators[i].Name + " de l'équipe " + team1.Name + " contre le gladiateur " + team2.Gladiators[j].Name + " de l'équipe " + team2.Name + ".");
                duel = new Duel(team1.Gladiators[i], team2.Gladiators[j]);
                winner = duel.Figth();
                //On raisonne à l'inverse, ainsi on peut prendre en compte le match nul, on aura true pour les 2 if
                // et les 2 équipes verront l'autre nombres de morts s'incrémenter
                if (!winner.Equals(team1.Gladiators[i]))
                    i++;
                if (!winner.Equals(team2.Gladiators[j]))
                    j++;
                nb++;
            }
            if (i < team1.Gladiators.Count)
            {
                team1.NbWin++;
                return team1;
            }
            else if (j < team2.Gladiators.Count)
            {
                team2.NbWin++;
                return team2;
            }
            else
            {
                //Encore une fois pour gérer le match nul on renvoi un objet vide
                return new Team();
            }
        }

    }
}
