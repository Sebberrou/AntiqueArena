using System;
namespace AntiqueArena.Stuff

{
	public class Dagger : Equipement
	{
		public Dagger()
		{
			Name = "dague";
			Points = 2;
			WeaponBehav = new IsWeapon(this);
			ArmorBehav = new NotArmor();
			WeaponBehav.Accuracy = 60;
			WeaponBehav.Initiative = 4;
		}

	}
}
