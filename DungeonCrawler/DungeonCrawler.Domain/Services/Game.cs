using DungeonCrawler.Data;
using DungeonCrawler.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonCrawler.Domain.Services
{
	public class Game
	{
		public static List<Monster> EnemyList { get; set; } = new List<Monster>();

		public static void NewGame()
		{
			
			var hero = Select.SelectHeroClass();
			Console.Clear();
			Select.SetHeroStasts((Hero)hero);
			Console.WriteLine($"Health points: {hero.Health}\nDamage: {hero.Damage}\nExperience: {hero.Experience}\nLevel: {hero.Level}");

			for (int i = 0; i < GameData.numberOfEnemies; i++)
				GenerateMoster();


			//HelpGenerateMoster();


			//MiniGame.NewMiniGame();
			//if (MiniGame.PlayerWonRound())
			//	Console.WriteLine("Hurray I have won");


		}

		public static void HelpGenerateMoster()
		{
			int G = 0;
			int B = 0;
			int W = 0;
			foreach (var mosnter in EnemyList)
			{
				if (mosnter is Witch)
				{
					Console.Write("Witch: ");
					W++;
				}
				if (mosnter is Brute)
				{
					Console.Write("Brute: ");
					B++;
				}
				if (mosnter is Goblin)
				{
					Console.Write("Goblin: ");
					G++;
				}
				Console.WriteLine($"HP: {mosnter.Health} EXP: {mosnter.Experience} DMG: {mosnter.Damage}");
			}
			Console.WriteLine($"G: {G}\nB: {B}\nW: {W}");
		}

		public static void GenerateMoster()
		{
			Random rand = new Random();


			while (true)
			{
				var chance = rand.NextDouble();

				if (0 < chance && chance <= GameData.witchSpawningChance)
				{
					EnemyList.Add(new Witch());

				}
				else if (GameData.witchSpawningChance < chance && chance <= GameData.bruteSpawningChance)
				{
					EnemyList.Add(new Brute());
				}
				else if (GameData.bruteSpawningChance < chance && chance > GameData.goblinSpawningChance)
				{
					EnemyList.Add(new Goblin());
				}
				else
				{
					continue;
				}

				return;
			}
		}





	}
}
