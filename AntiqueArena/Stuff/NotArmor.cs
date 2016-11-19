using System;
namespace AntiqueArena.Stuff
{
	public class NotArmor : ArmorBehavior
	{
		public int Evasion { get; set; }
		public NotArmor()
		{
		}

		public bool Dodge()
		{
			return false;
		}

        public bool Block()
        {
            return false;
        }
    }
}
