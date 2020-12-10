using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonCrawler.Data.Models
{
	public class Warrior : Hero
	{
		public Warrior()
		{
			Health = GameData.warriorDefaultHealth;
			Damage = GameData.warriorDefaultHealth;
			//Experience = GameData.witchDefaultExperience;
		}

	}
}
