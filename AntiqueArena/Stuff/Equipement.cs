using System;
using AntiqueArena.Character;
namespace AntiqueArena.Stuff
{
	public abstract class Equipement
	{
		public int Points { get; protected set; }
		public string Name { get; protected set; }
		public double Malus { get; protected set; }
        public int MaxUses { get; protected set; }
        private int _NbOfUses; 
        public int NbOfUses {
            get
            {
                return _NbOfUses;
            }
            set
            {
                _NbOfUses = value;
                if (value == 0)
                    IsAvailable = true;
                else if (MaxUses != 0 &&_NbOfUses >= MaxUses)
                    IsAvailable = false;
            }
        }
        public bool IsAvailable { get; set; } = true;
		public WeaponBehavior WeaponBehav { get; protected set; }
		public ArmorBehavior ArmorBehav { get; protected set; }
		public Gladiator Owner { get; set; }
	}
}
