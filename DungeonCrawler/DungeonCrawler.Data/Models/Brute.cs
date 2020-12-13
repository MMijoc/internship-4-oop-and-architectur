using System;

namespace DungeonCrawler.Data.Models
{
	public class Brute : Monster
	{
		public Brute()
		{
			var rnd = new Random();
			Health = GameConfig.bruteDefaultHealth + rnd.Next(-GameConfig.bruteHealthModifier, GameConfig.bruteHealthModifier);
			Damage = GameConfig.bruteDefaultDamage + rnd.Next(-GameConfig.bruteDamageModifier, GameConfig.bruteDamageModifier);
			Experience = GameConfig.bruteDefaultExperience + rnd.Next(-GameConfig.bruteExperienceModifier, GameConfig.bruteExperienceModifier);

			MonsterType = "Brute";
		}

		public void Attack(Hero hero)
		{
			hero.Health -= Damage;
		}

		public void BruteAttack(Hero hero)
		{
			hero.Health -= (int)(GameConfig.bruteBruteAttackModifier * hero.Health);
			Console.WriteLine($"Brute attack: {GameConfig.bruteBruteAttackModifier}% of hero's current health damaged");

			return;
		}
	}
}
