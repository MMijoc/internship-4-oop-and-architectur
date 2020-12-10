using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonCrawler.Data.Models
{
	public class Brute : Monster
	{
		public Brute()
		{
			var rnd = new Random();
			Health = GameData.bruteDefaultHealth + rnd.Next(-GameData.bruteHealthModifer, GameData.bruteHealthModifer);
			Damage = GameData.bruteDefaultDamage + rnd.Next(-GameData.bruteDamageModifer, GameData.bruteDamageModifer); ;
			Experience = GameData.bruteDefaultExperience + rnd.Next(-GameData.bruteExperienceModifer, GameData.bruteExperienceModifer);
		}
	}
}
