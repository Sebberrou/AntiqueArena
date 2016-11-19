using System;
namespace AntiqueArena.Stuff
{
	public class Helmet : Equipement
	{
		
		public Helmet()
		{
			this.Name = "casque";
			this.Points = 2;
			this.WeaponBehav = new NotWeapon();
			this.ArmorBehav = new IsArmor();
			this.ArmorBehav.Evasion = 10;
		}
	}
}
