using System;

namespace DungeonCrawler.Data.Models
{
	public class Brute : Monster
	{
		public Brute()
		{
			var rnd = new Random();
			Health = GameConfig.bruteDefaultHealth + rnd.Next(-GameConfig.bruteHealthModifier, GameConfig.bruteHealthModifier);
			MaxHealth = Health;
			Damage = GameConfig.bruteDefaultDamage + rnd.Next(-GameConfig.bruteDamageModifier, GameConfig.bruteDamageModifier);
			Experience = GameConfig.bruteDefaultExperience + rnd.Next(-GameConfig.bruteExperienceModifier, GameConfig.bruteExperienceModifier);

			MonsterType = "Brute";
		}

		public void Attack(Hero hero)
		{
			hero.Health -= Damage;
			Console.WriteLine($"{MonsterType} deals {Damage} points of damage!");

		}

		public void BruteAttack(Hero hero)
		{
			int rageAttackDamage = (int)(GameConfig.bruteBruteAttackModifier * hero.MaxHealth);
			hero.Health -= rageAttackDamage;
			Console.WriteLine($"{MonsterType} attack with rage and deals {rageAttackDamage} points of damage ({string.Format("{0:n3}", GameConfig.bruteBruteAttackModifier)}% of hero's max health)");

			return;
		}
	}
}
