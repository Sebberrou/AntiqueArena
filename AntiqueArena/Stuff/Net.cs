using System;
namespace AntiqueArena.Stuff
{
	public class Net : Equipement
	{
		public Net()
		{
			Name = "filet !!";
			Points = 3;
			Malus = 0.5;
            MaxUses = 1;
			WeaponBehav = new IsWeapon(this);
            WeaponBehav.IsLethal = false;
            ArmorBehav = new NotArmor();
			WeaponBehav.Accuracy = 30;
			WeaponBehav.Initiative = 0;

		}



	}
}
