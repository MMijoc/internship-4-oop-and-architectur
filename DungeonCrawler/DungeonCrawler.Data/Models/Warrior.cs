namespace DungeonCrawler.Data.Models
{
	public class Warrior : Hero
	{
		public Warrior()
		{
			Health = GameConfig.warriorDefaultHealth;
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

	}
}
