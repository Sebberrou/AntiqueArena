using System;
namespace AntiqueArena.Stuff
{
	public interface WeaponBehavior
	{
		int Accuracy { get; set; }
		int Initiative { get; set;}
        bool IsLethal { get; set; }
        bool Attack();

	}
}
