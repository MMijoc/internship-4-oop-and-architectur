using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonCrawler.Data.Models
{
	public class Witch : Monster
	{
		public Witch()
		{
			var rnd = new Random();
			Health = GameData.witchDefaultHealth + rnd.Next(-GameData.witchHealthModifer, GameData.witchHealthModifer);
			Damage = GameData.witchDefaultDamage + rnd.Next(-GameData.witchDamageModifer, GameData.witchDamageModifer); ;
			Experience = GameData.witchDefaultExperience + rnd.Next(-GameData.witchExperienceModifer, GameData.witchExperienceModifer);
		}
	}
}