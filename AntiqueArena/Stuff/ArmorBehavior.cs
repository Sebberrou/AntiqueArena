using System;
namespace AntiqueArena
{
	public interface ArmorBehavior
	{
		int Evasion { get; set; }
		bool Block();
	}

}
