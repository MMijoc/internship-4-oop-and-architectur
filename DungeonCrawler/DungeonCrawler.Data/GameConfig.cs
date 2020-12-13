namespace DungeonCrawler.Data
{
	public static class GameConfig
	{
		// General
		public static int numberOfEnemies = 2;
		public static int defaultHealth = 400;
		public static int defaultExperienceToLevelUp = 1000;
		public static string heroDefaultName = "Adventurer";
		public static int heroDefaultLevel = 1;

		// Default spawning chances
		public static double goblinSpawningChance = 0.5;
		public static double bruteSpawningChance = 0.25;
		public static double witchSpawningChance = 0.09;


		// Default health, damage and experience values
		public static int warriorDefaultHealth = 500;
		public static int mageDefaultHealth = 200;
		public static int rangerDefaultHealth = 300;
		public static int goblinDefaultHealth = 100;
		public static int bruteDefaultHealth = 500;
		public static int witchDefaultHealth = 250;

		public static int warriorDefaultDamage = 75;
		public static int mageDefaultDamage = 150;
		public static int rangerDefaultDamage = 100;
		public static int goblinDefaultDamage = 50;
		public static int bruteDefaultDamage = 125;
		public static int witchDefaultDamage = 100;

		public static int heroDefaultExperience = 0;
		public static int goblinDefaultExperience = 250;
		public static int bruteDefaultExperience = 500;
		public static int witchDefaultExperience = 1000;


		// Level up stats increase
		public static int warriorLevelUpHealthIncrease = 100;
		public static int warriorLevelUpDamageIncrease = 25;

		public static int mageLevelUpHealthIncrease = 25;
		public static int mageLevelUpDamageIncrease = 100;
		public static int mageLevelUpManaIncrease = 100;

		public static int rangerLevelUpHealthIncrease = 50;
		public static int rangerLevelUpDamageIncrease = 50;
		public static double rangerLevelUpCriticalChanceIncrease = 0.09;
		public static double rangerLevelUpStunChanceIncrease = 0.1;


		// Default health, damage and experience modifiers
		public static int goblinHealthModifier = (int)(goblinDefaultHealth * 0.25);
		public static int bruteHealthModifier = (int)(bruteDefaultHealth * 0.25);
		public static int witchHealthModifier = (int)(witchDefaultHealth * 0.25);

		public static int goblinExperienceModifier = (int)(goblinDefaultExperience * 0.25);
		public static int bruteExperienceModifier = (int)(bruteDefaultExperience * 0.25);
		public static int witchExperienceModifier = (int)(witchDefaultExperience * 0.25);

		public static int goblinDamageModifier = (int)(goblinDefaultDamage * 0.25);
		public static int bruteDamageModifier = (int)(bruteDefaultDamage * 0.25);
		public static int witchDamageModifier = (int)(witchDefaultDamage * 0.25);


		// Special abilities stats and modifiers 
		public static double warriroRageDamageModifier = 2.0;
		public static double warriorRageHealthCostModifier = 0.15;

		public static int mageDefaultMana = 500;
		public static int mageAttackManaCost = 50;
		public static int mageHealManaCost = 100;
		public static int mageHealMagnitude = 100;

		public static double rangerCriticalHitModifier = 2.0;
		public static double rangerDefaultCriticalChance = 0.1;
		public static double rangerDefaultStunChance = 0.3;

		public static double bruteBruteAttackModifier = 0.25;
		public static double bruteRavageChance = 0.33;

		public static double witchMayhemChance = 0.15;
	}
}