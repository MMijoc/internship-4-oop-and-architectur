using System;

namespace DungeonCrawler.Data.Models
{
	public class Mage : Hero
	{
		public Mage()
		{
			Health = GameConfig.mageDefaultHealth;
			MaxHealth = GameConfig.mageDefaultHealth;
			Damage = GameConfig.mageDefaultDamage;
			Experience = GameConfig.heroDefaultExperience;
			Mana = GameConfig.mageDefaultMana;
			MaxMana = GameConfig.mageDefaultMana; ;
			HasAvoidedDeath = false;
		}
		public int Mana { get; set; }

		public int MaxMana { get; set; }

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

			if (Health >= MaxHealth)
			{
				Console.WriteLine("Health already at maximum!");
				return false;
			}

			Console.WriteLine($"Hell spell restores {GameConfig.mageHealMagnitude} health points");
			Health += GameConfig.mageHealMagnitude;
			Mana -= GameConfig.mageHealManaCost;
			return true;
		}

		public bool RegenerateMana()
		{
			if (Mana >= MaxMana)
			{
				Console.WriteLine("Mana is already at maximum value");
				return false;
			}

			Console.WriteLine($"Mana full restored!");
			Mana = MaxMana;
			return true; ;
		}

		public bool AvoidDeath()
		{
			if (HasAvoidedDeath) 
				return false;

			Mana = MaxMana;
			Health = MaxHealth;
			HasAvoidedDeath = true;
			return true;
		}

		public void LevelUp()
		{
			if (Experience >= GameConfig.defaultExperienceToLevelUp)
			{
				Console.WriteLine("You have gained a new level");
				Experience -= GameConfig.defaultExperienceToLevelUp;
				MaxHealth += GameConfig.mageLevelUpHealthIncrease;
				Health = MaxHealth;
				Damage += GameConfig.mageLevelUpDamageIncrease;
				MaxMana += GameConfig.mageLevelUpManaIncrease;
				Mana = MaxMana;

				return;
			}
			else
			{
				return;
			}


		}

		public override string ToString()
		{
			return $"Hero name: {Name}\n\tHealth: {Health}/{MaxHealth}\n\tMana: {Mana}/{MaxMana}\n\tExperience: {Experience}\n\tLevel: {Level}";

		}
	}
}
