using System;
using AntiqueArena.Stuff;
using System.Text;
using System.Diagnostics.Contracts;
using AntiqueArena.Character;
namespace AntiqueArena.Arena
{
	public class Exchange
	{
        // Un échange est un  coup porté par un attaquant et une parade potentiel du défenseur
		Gladiator Attacker { get; set; }
		Equipement Weapon { get; set; }
		Gladiator Receiver { get; set; }
		public enum ThrowStatus { Miss = 0, Sucess = 1, Disable = 2 };
		public enum BlockStatus { Miss = 1, Sucess = 0 };


		public Exchange(Gladiator attacker, Equipement weapon, Gladiator receiver)
		{
			Attacker = attacker;
			Weapon = weapon;
			Receiver = receiver;
		}

		public int Throw()
		{
			if (Weapon.WeaponBehav.Attack())
			{
                Console.WriteLine("Le coup porte.");
                if (!(Weapon.WeaponBehav.IsLethal))
				{
                    
					Receiver.Penalty = Weapon.Malus;
                    Console.WriteLine(Receiver.Name + " est destabilisé par le " + Weapon.Name+".");
					return (int)ThrowStatus.Disable;
				}
                return Defense();
			}
            Console.WriteLine("Le coup rate.");
            return (int)ThrowStatus.Miss;
		}

		private int Defense()
		{
			foreach (var armor in Receiver.GetArmors()) {
				if (armor.ArmorBehav.Block())
				{
                    Console.WriteLine("Le " + armor.Name + " de " + Receiver.Name + " bloque le coup.");
					return (int)BlockStatus.Sucess;
				}
			}
            Console.WriteLine( Receiver.Name + " n'arrive pas à bloquer le coup.");
            return (int)BlockStatus.Miss;
		}

	}
}
