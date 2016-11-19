using System;
using System.Collections.Generic;
using AntiqueArena.Stuff;
namespace AntiqueArena.Character
{
	public class Gladiator
	{
		public string Name { get; set; }
		private List<Equipement> gear = new List<Equipement>();
		public int MaxStuff = 10;
		public int MaxWeaponInGear = 2;
		private double _Penalty = 1;
		public int NbWin { get; set; }
		public int NbPlayed { get; set; }

		public List<Equipement> Gear
		{
			get
			{
				return gear;
			}

			set
			{
				gear = value;
			}
		}

		public double Penalty
		{
			get
			{
				return _Penalty;
			}

			set
			{
				_Penalty = value;
			}
		}

		public Gladiator()
		{
			
		}

		public decimal VictoryPerCent()
		{
            if (NbPlayed != 0)
                return Math.Round((100 * (decimal)NbWin) / (decimal)NbPlayed); 
            else
                return 100;
		}

		public int NbLost()
		{
			return NbPlayed - NbWin;
		}

		public int AddEquipement(Equipement equipement)
		{
			
			if (CountGearPoint() + equipement.Points <= this.MaxStuff)
			{
				if (equipement.WeaponBehav is IsWeapon && CountWeaponInGear() >= MaxWeaponInGear)
				{
					return 1;
				}
				this.Gear.Add(equipement);
				equipement.Owner = this;
				return 0;
			}
			else
			{
				return 2;
			}
		}

		public int CountGearPoint()
		{
			int somme = 0;
			foreach (var equipement in this.Gear)
			{
				somme += equipement.Points;
			}
			return somme;
		}

		public int CountWeaponInGear()
		{
			int somme = 0;
			foreach (var equipement in this.Gear)
			{
				if (equipement.WeaponBehav is IsWeapon)
				{
					somme++;
				}
			}
			return somme;

		}
        
		public List<Equipement> GetWeapons()
		{
			return Gear.FindAll(
				delegate (Equipement eq)
			  {
				  return eq.WeaponBehav is IsWeapon;
			  }
			  );
		}

		public List<Equipement> GetArmors()
		{
			return Gear.FindAll(
				delegate (Equipement eq)
			  {
				  return eq.ArmorBehav is IsArmor;
			  }
			  );

		}
        public bool IsValidWarrior()
        {
            //Vérifie que le gladiateur possède bien au moins une arme pour tuer
            List<Equipement> weapons = this.GetWeapons();
            foreach(Equipement weapon in weapons)
            {
                if (weapon.WeaponBehav.IsLethal)
                    return true;
            }
            return false;
        }

	}
}
