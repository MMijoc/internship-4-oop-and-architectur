using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonCrawler.Data.Models
{
	public class Mage : Hero
	{
		public Mage()
		{
			Health = GameData.mageDefaultHealth;
			Damage = GameData.mageDefaultHealth;
			//Experience = GameData.witchDefaultExperience;
		}
		public int Mana { get; set; }

		public void Heal() 
		{
			if (Mana < 10) //HealManaCost
				return;//insufficient mana to use this ability

			Mana -= 10;
			return;
		
		}

	}
}
