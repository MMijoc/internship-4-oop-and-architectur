using System;
using System.Collections.Generic;

namespace DungeonCrawler.Data.Models
{
	public class Witch : Monster
	{
		public Witch()
		{
			var rnd = new Random();
			Health = GameConfig.witchDefaultHealth + rnd.Next(-GameConfig.witchHealthModifier, GameConfig.witchHealthModifier);
			MaxHealth = Health;
			Damage = GameConfig.witchDefaultDamage + rnd.Next(-GameConfig.witchDamageModifier, GameConfig.witchDamageModifier);
			Experience = GameConfig.witchDefaultExperience + rnd.Next(-GameConfig.witchExperienceModifier, GameConfig.witchExperienceModifier);
			
			MonsterType = "Witch";
		}

		public void Attack(Hero hero)
		{
			hero.Health -= Damage;
		}

		public void Mayhem(Hero hero, List<Monster> enemyList)
		{
			var rnd = new Random();
			Health = rnd.Next(1, GameConfig.defaultHealth);
			hero.Health = rnd.Next(1, GameConfig.defaultHealth);
			foreach (var entity in enemyList)
			{
				if (entity.Health > 0)
					entity.Health = rnd.Next(1, GameConfig.defaultHealth);
			}
			Console.WriteLine("Witch casts mayhem spell! Hero's and every enemy's health points are randomized");

			return;
		}
	}
}