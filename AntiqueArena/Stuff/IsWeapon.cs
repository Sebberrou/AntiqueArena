using System;
using AntiqueArena.Character;
namespace AntiqueArena.Stuff
{
	public class IsWeapon : WeaponBehavior
	{
		
		public int Accuracy { get; set; }
		public int Initiative { get; set; }
        public bool IsLethal { get; set; }
        private Equipement Weapon;


        public IsWeapon(Equipement weapon)
		{
            IsLethal = true;
            //Permet de retrouver l'arme à partir de l'interface
            Weapon = weapon;
		}

		public bool Attack()
		{
			Random rnd = new Random();
			return rnd.Next(1, 100) <= (this.Accuracy * this.Weapon.Owner.Penalty);
		}
	}
}
