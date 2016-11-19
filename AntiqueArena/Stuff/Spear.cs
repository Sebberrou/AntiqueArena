using System;
namespace AntiqueArena.Stuff
{
	public class Spear : Equipement
	{
		public Spear()
		{
			this.Name = "lance";
			this.Points = 7;
			this.WeaponBehav = new IsWeapon(this);
			this.ArmorBehav = new NotArmor();
			this.WeaponBehav.Accuracy = 50;
			this.WeaponBehav.Initiative = 1;

		}
	}
}
