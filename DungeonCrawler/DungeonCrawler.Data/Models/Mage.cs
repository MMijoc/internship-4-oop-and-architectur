using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonCrawler.Data.Models
{
	public class Mage : Hero
	{
		public int Mana { get; set; }
		bool AvoidedDeath = false;
		public void Heal() 
		{
			if (Mana < 10) //HealManaCost
				return;//insufficient mana to use this ability

			Mana -= 10;
			return;
		
		}

	}
}
