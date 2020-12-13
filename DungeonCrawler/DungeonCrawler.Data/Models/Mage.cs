using System;

namespace DungeonCrawler.Data.Models
{
	public class Mage : Hero
	{
		public Mage()
		{
			Health = GameConfig.mageDefaultHealth;
			Damage = GameConfig.mageDefaultDamage;
			Experience = GameConfig.heroDefaultExperience;
			Mana = GameConfig.mageDefaultMana;
			HasAvoidedDeath = false;
		}
		public int Mana { get; set; }

		public bool HasAvoidedDeath { get; set; }

		public bool Attack(Monster monster)
		{
			if (Mana < GameConfig.mageAttackManaCost)
			{
				Console.WriteLine("Insufficient mana to cast this spell!");
				return false;
			}

			monster.Health -= Damage;
			Mana -= GameConfig.mageAttackManaCost;

			return true;
		}

		public bool HealSpell()
		{
			if (Mana < GameConfig.mageHealManaCost)
			{
				Console.WriteLine("Insufficient mana to cast this spell!");
				return false;
			}

			Console.WriteLine($"Hell spell restores {GameConfig.mageHealMagnitude} health points");
			Health += GameConfig.mageHealMagnitude;
			return true;
		}

		public void RegenerateMana()
		{
			Console.WriteLine($"Mana full restored to {GameConfig.mageDefaultMana} points");
			Health += GameConfig.mageHealMagnitude;
			return;
		}

		public bool AvoidDeath()
		{
			if (HasAvoidedDeath) 
				return false;

			Mana = GameConfig.mageDefaultMana / 2;
			Health = GameConfig.mageDefaultHealth;
			HasAvoidedDeath = true;
			return true;
		}

	}
}
