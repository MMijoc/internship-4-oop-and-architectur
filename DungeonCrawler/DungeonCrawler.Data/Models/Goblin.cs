using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonCrawler.Data.Models
{
	public class Goblin : Monster
	{
		public Goblin()
		{
			var rnd = new Random();
			Health = GameData.goblinDefaultHealth + rnd.Next(-GameData.goblinHealthModifer, GameData.goblinHealthModifer);
			Damage = GameData.goblinDefaultDamage + rnd.Next(-GameData.goblinDamageModifer, GameData.goblinDamageModifer); ;
			Experience = GameData.goblinDefaultExperience + rnd.Next(-GameData.goblinExperienceModifer, GameData.goblinExperienceModifer);
		}
	}
}
