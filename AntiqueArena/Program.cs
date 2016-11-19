using System;
using System.Collections.Generic;
using AntiqueArena.Stuff;
using AntiqueArena.Character;
using AntiqueArena.Arena;
namespace AntiqueArena
{
	class MainClass
	{

        public static void Main(string[] args)
		{
            //Création des joueurs
            List<Player> Players = new List<Player>();
			Players.Add(new Player("Serge","Labourre","XxNarutoxX"));
			Players.Add(new Player("Sarah", "Croche", "EmoGirlDu72"));
			Players.Add(new Player("Marie", "Tamitsouko", "Joséphine" ));
            Players.Add(new Player("Lorie", "Chirac", "PJ"));
            //Création des équipes, une par joueur
            Players[0].AddTeam("Roxxor", "Pas pour les noobs");
            Players[1].AddTeam("La communauté de l'anneau", "Au delà des différences");
            Players[2].AddTeam("C", "Alphabet à la rescousse");
            Players[3].AddTeam("D", "La réponse");

            //Création des gladiateurs et ajout à une équipe
            Gladiator g;
            g = new Gladiator() { Name = "Eric" };
            g.AddEquipement(new Net());
            g.AddEquipement(new Helmet());
            g.AddEquipement(new Sword());
            Players[0].Teams[0].AddGladiator(g);

            g = new Gladiator() { Name = "Thomas" };
            g.AddEquipement(new SmallShield());
            g.AddEquipement(new Sword());
            Players[0].Teams[0].AddGladiator(g);

            g = new Gladiator() { Name = "Laure" };
            g.AddEquipement(new Dagger());
            g.AddEquipement(new RectShield());
            Players[0].Teams[0].AddGladiator(g);

            g = new Gladiator() { Name = "Sarah" };
            g.AddEquipement(new Dagger());
            g.AddEquipement(new Sword());
            Players[0].Teams[0].AddGladiator(g);


            g = new Gladiator() { Name = "Gimli" };
            g.AddEquipement(new Helmet());
            g.AddEquipement(new Spear());
            Players[1].Teams[0].AddGladiator(g);

            g = new Gladiator() { Name = "Legolas" };
            g.AddEquipement(new Dagger());
            g.AddEquipement(new SmallShield());
            g.AddEquipement(new Net());
            Players[1].Teams[0].AddGladiator(g);

            g = new Gladiator() { Name = "Soron" };
            g.AddEquipement(new SmallShield());
            g.AddEquipement(new Sword());
            Players[1].Teams[0].AddGladiator(g);

            g = new Gladiator() { Name = "Gandalf" };
            g.AddEquipement(new SmallShield());
            g.AddEquipement(new Net());
            g.AddEquipement(new Dagger());
            Players[1].Teams[0].AddGladiator(g);

            g = new Gladiator() { Name = "Smaug" };
            g.AddEquipement(new Trident());
            g.AddEquipement(new Helmet());
            Players[2].Teams[0].AddGladiator(g);

            g = new Gladiator() { Name = "Nessie" };
            g.AddEquipement(new Spear());
            g.AddEquipement(new Net());
            Players[2].Teams[0].AddGladiator(g);

            g = new Gladiator() { Name = "Graoully" };
            g.AddEquipement(new SmallShield());
            g.AddEquipement(new Sword());
            Players[2].Teams[0].AddGladiator(g);

            g = new Gladiator() { Name = "A" };
            g.AddEquipement(new Dagger());
            g.AddEquipement(new Spear());
            Players[3].Teams[0].AddGladiator(g);

            g = new Gladiator() { Name = "B" };
            g.AddEquipement(new Trident());
            g.AddEquipement(new Net());
            Players[3].Teams[0].AddGladiator(g);

            g = new Gladiator() { Name = "C" };
            g.AddEquipement(new SmallShield());
            g.AddEquipement(new Sword());
            Players[3].Teams[0].AddGladiator(g);

            // Création du tournoi et ajout des joueurs
            Tournament myTournament = new Tournament();
            myTournament.AddPlayer(Players[0]);
            myTournament.AddPlayer(Players[1]);
            myTournament.AddPlayer(Players[2]);
            myTournament.AddPlayer(Players[3]);
            //Début du tournoi
            myTournament.StartTournament();

        }
	}
}
