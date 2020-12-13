using System;

namespace DungeonCrawler.Data.Models
{
	public class Ranger : Hero
	{
		public Ranger()
		{
			Health = GameConfig.rangerDefaultHealth;
			MaxHealth = GameConfig.rangerDefaultHealth;
			Damage = GameConfig.rangerDefaultDamage;
			Experience = GameConfig.heroDefaultExperience;
			CriticalChance = GameConfig.rangerDefaultCriticalChance;
			StunChance = GameConfig.rangerDefaultStunChance;
		}

		public double CriticalChance { get; set; }
		public double StunChance  { get; set; }
		public object Game { get; private set; }

		public bool RangerAttack(Monster monster)
		{
			var rand = new Random();
			var chance = rand.NextDouble();

			if (0 < chance && chance <= CriticalChance)
			{
				Console.WriteLine("Critical hit!");
				Console.WriteLine($"{Name} deals {Damage * GameConfig.rangerCriticalHitModifier} points of damage");
				monster.Health -= (int)(Damage * GameConfig.rangerCriticalHitModifier);

			}
			else
			{
				Console.WriteLine($"{Name} deals {Damage} points of damage");
				monster.Health -= Damage;
			}

			chance = rand.NextDouble();
			if (0 < chance && chance <= StunChance)
			{
				Console.WriteLine($"Ranger's attack has stunned {monster.MonsterType}, {monster.MonsterType} will skip next turn");
				monster.IsStuned = true;
			}

			return true;
		}

		public void LevelUp()
		{
			while (Experience >= GameConfig.defaultExperienceToLevelUp)
			{
				Console.WriteLine("You have gained a new level");
				Experience -= GameConfig.defaultExperienceToLevelUp;
				MaxHealth += GameConfig.rangerLevelUpHealthIncrease;
				Health = MaxHealth;
				Damage += GameConfig.rangerLevelUpDamageIncrease;
				StunChance += GameConfig.rangerLevelUpStunChanceIncrease;
				CriticalChance += GameConfig.rangerLevelUpCriticalChanceIncrease;
				return;
			}

			return;
		}
	}
}
