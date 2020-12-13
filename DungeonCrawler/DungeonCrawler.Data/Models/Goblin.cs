using System;

namespace DungeonCrawler.Data.Models
{
	public class Goblin : Monster
	{
		public Goblin()
		{
			var rnd = new Random();
			Health = GameConfig.goblinDefaultHealth + rnd.Next(-GameConfig.goblinHealthModifier, GameConfig.goblinHealthModifier);
			MaxHealth = Health;
			Damage = GameConfig.goblinDefaultDamage + rnd.Next(-GameConfig.goblinDamageModifier, GameConfig.goblinDamageModifier);
			Experience = GameConfig.goblinDefaultExperience + rnd.Next(-GameConfig.goblinExperienceModifier, GameConfig.goblinExperienceModifier);

			MonsterType = "Goblin";
		}

		public void Attack(Hero hero)
		{
			hero.Health -= Damage;
		}
	}
}
