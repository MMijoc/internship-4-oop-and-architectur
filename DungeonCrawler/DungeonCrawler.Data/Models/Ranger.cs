using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonCrawler.Data.Models
{
	public class Ranger : Hero
	{
		public Ranger()
		{
			Health = GameData.rangerDefaultHealth;
			Damage = GameData.rangerDefaultHealth;
			//Experience = GameData.witchDefaultExperience;
		}

		public int CriticalChance { get; set; }
	}
}
