using System;
namespace AntiqueArena.Stuff
{
	public class SmallShield : Equipement
	{
		public SmallShield()
		{
			this.Name = "petit bouclier";
			this.Points = 5;
			this.WeaponBehav = new NotWeapon();
			this.ArmorBehav = new IsArmor();
			this.ArmorBehav.Evasion = 20;

		}
	}
}
