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

		public void Attack(Monster monster)
		{
			monster.Health -= Damage;
		}

		public void RageAttack(Monster monster)
		{
			int abilityHealthCost = (int)(GameConfig.warriorRageHealthCostModifier * Health);
			Health -= abilityHealthCost;
			monster.Health -= (int)(Damage * GameConfig.warriroRageDamageModifier);
		}

		public void LevelUp()
		{
			if (Experience >= GameConfig.defaultExperienceToLevelUp)
			{
				Console.WriteLine("You have gained a new level");
				Experience -= GameConfig.defaultExperienceToLevelUp;
				MaxHealth += GameConfig.warriorLevelUpHealthIncrease;
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
