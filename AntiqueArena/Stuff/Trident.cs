using System;
namespace AntiqueArena.Stuff
{
	public class Trident : Equipement
	{
		public Trident()
		{
			Name = "trident";
			Points = 7;
			WeaponBehav = new IsWeapon(this);
			ArmorBehav = new IsArmor();
			ArmorBehav.Evasion = 10;
			WeaponBehav.Accuracy = 40;
			WeaponBehav.Initiative = 2;



		}
	}
}
