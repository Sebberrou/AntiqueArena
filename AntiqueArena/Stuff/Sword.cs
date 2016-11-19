using System;
namespace AntiqueArena.Stuff
{
	public class Sword: Equipement
	{
        public Sword()
        {
            Name = "épée";
            Points = 5;
            WeaponBehav = new IsWeapon(this);
            ArmorBehav = new NotArmor();
            WeaponBehav.Accuracy = 70;
            WeaponBehav.Initiative = 3;
        }
	}
}
