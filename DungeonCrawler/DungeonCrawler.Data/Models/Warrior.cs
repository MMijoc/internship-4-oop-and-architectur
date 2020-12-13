using System;

namespace DungeonCrawler.Data.Models
{
	public class Warrior : Hero
	{
		public Warrior()
		{
			Health = GameConfig.warriorDefaultHealth;
			MaxHealth = GameConfig.warriorDefaultHealth;
			Damage = GameConfig.warriorDefaultDamage;
			Experience = GameConfig.heroDefaultExperience;
		}

		public bool Attack(Monster monster)
		{
			monster.Health -= Damage;
			return true;
		}

		public bool RageAttack(Monster monster)
		{
			int abilityHealthCost = (int)(GameConfig.warriorRageHealthCostModifier * MaxHealth);
			if (Health - abilityHealthCost <= 0)
			{
				Console.WriteLine("Using Rage attack at this time would kill you!");
				return false;

			}
			Console.WriteLine($"{Name} loses {abilityHealthCost} points of health and deals {(int)(Damage * GameConfig.warriroRageDamageModifier)} points of damage to the enemy");
			Health -= abilityHealthCost;
			monster.Health -= (int)(Damage * GameConfig.warriroRageDamageModifier);
			return true;
		}

		public void LevelUp()
		{
			if (Experience >= GameConfig.defaultExperienceToLevelUp)
			{
				Console.WriteLine("You have gained a new level");
				Experience -= GameConfig.defaultExperienceToLevelUp;
				MaxHealth += GameConfig.warriorLevelUpHealthIncrease;
				Health = MaxHealth;
				Damage += GameConfig.warriorLevelUpDamageIncrease;
				return;
			}
			else
			{
				return;
			}


		}

	}
}
