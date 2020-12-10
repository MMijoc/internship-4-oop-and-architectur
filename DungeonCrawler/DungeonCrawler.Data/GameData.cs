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
	}
}