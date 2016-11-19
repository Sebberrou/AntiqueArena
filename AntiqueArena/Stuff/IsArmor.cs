using System;
namespace AntiqueArena
{
	public class IsArmor : ArmorBehavior
	{

		public int Evasion { get; set; }

		public IsArmor()
		{
		}
		public bool Block()
		{
			Random rnd = new Random();
			return Evasion > rnd.Next(0, 100);
		}
	}
}
