using System;
namespace AntiqueArena.Stuff
{
	public class NotWeapon : WeaponBehavior
	{
		public int Accuracy { get; set; }
		public int Initiative { get; set; }
        public bool IsLethal { get; set; }
		public NotWeapon()
		{
		}
		public bool Attack()
		{
			return false;
		}

	}
}
