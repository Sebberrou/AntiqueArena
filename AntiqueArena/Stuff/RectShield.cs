using System;
namespace AntiqueArena.Stuff
{
	public class RectShield : Equipement
	{
		public RectShield()
		{
			this.Name = "bouclier rectangulaire";
			this.Points = 8;
			this.WeaponBehav = new NotWeapon();
			this.ArmorBehav = new IsArmor();
			this.ArmorBehav.Evasion = 30;
		}
	}
}
