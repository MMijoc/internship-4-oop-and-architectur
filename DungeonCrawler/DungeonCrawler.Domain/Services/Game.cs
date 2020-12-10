using DungeonCrawler.Data;
using DungeonCrawler.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonCrawler.Domain.Services
{
	public static class Game
	{
		public static void NewGame()
		{
			//var hero = Select.SelectHeroClass();
			int G = 0;
			int B = 0;
			int W = 0;
			for (var i = 1; i <= GameData.numberOfEnemies; i++)
			{
				Console.Write($"{i}: ");
				var n= GenerateMoster();
				switch(n)
				{
					case 3:
						W++;
						break;
					case 2:
						B++;
						break;
					case 1:
						G++;
						break;
				}
			}
			Console.WriteLine($"G: {G}\nB: {B}\nW: {W}");

			//if (hero is Mage) {
			//	Console.WriteLine("He is a mage!!! run!!!");
			//}
			//if (hero is Warrior)
			//{
			//	Console.WriteLine("He is a Warrior!!! We cant defeat him!!!");
			//}
			//if (hero is Ranger)
			//{
			//	Console.WriteLine("He is a Ranger!!! Hide behind a wall!!!");
			//}


		}


		public static int GenerateMoster()
		{
			Random rand = new Random();

			while (true)
			{
				var chance = rand.NextDouble();
				if (0 < chance && chance <= GameData.witchSpawningChance)
				{
					Console.WriteLine("Witch");
					return 3;
				}
				else if (GameData.witchSpawningChance < chance && chance <= GameData.bruteSpawningChance)
				{
					Console.WriteLine("Brute");
					return 2;
				}
				else if (GameData.bruteSpawningChance < chance && chance > GameData.goblinSpawningChance)
				{
					Console.WriteLine("Goblin");
					return 1;
				}
				else
				{
					continue;
				}


			}
		}
	}
}
