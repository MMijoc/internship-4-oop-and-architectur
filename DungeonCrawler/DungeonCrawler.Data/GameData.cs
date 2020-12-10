using DungeonCrawler.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonCrawler.Data
{
	public static class GameData
	{
		public static List<Monster> EnemyList { get; set; } = new List<Monster>();

		public static int numberOfEnemies = 10;
		public static int defaultHealth = 500;
		public static int defaultDamage = 100;

		public static double goblinSpawningChance = 0.5;
		public static double bruteSpawningChance = 0.25;
		public static double witchSpawningChance = 0.125;


		public static int goblinDefaultHealth = 100;
		public static int bruteDefaultHealth = 500;
		public static int witchDefaultHealth = 200;

		public static int goblinDefaultDamage = 50;
		public static int bruteDefaultDamage = 150;
		public static int witchDefaultDamage = 100;

		public static int goblinDefaultExperience = 250;
		public static int bruteDefaultExperience = 500;
		public static int witchDefaultExperience = 1000;

		public static int goblinHealthModifer = (int)(goblinDefaultHealth * 0.25);
		public static int bruteHealthModifer = (int)(bruteDefaultHealth * 0.25);
		public static int witchHealthModifer = (int)(witchDefaultHealth * 0.25);

		public static int goblinExperienceModifer = (int)(goblinDefaultExperience * 0.25);
		public static int bruteExperienceModifer = (int)(bruteDefaultExperience * 0.25);
		public static int witchExperienceModifer = (int)(witchDefaultExperience * 0.25);

		public static int goblinDamageModifer = (int)(goblinDefaultDamage * 0.25);
		public static int bruteDamageModifer = (int)(bruteDefaultDamage * 0.25);
		public static int witchDamageModifer = (int)(witchDefaultDamage * 0.25);

		//public static int monsterDamageModifer = 0.1;



	}
}