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
			//postavit izbor za rucno postavaljanje HP, XP-a i Levela
			//generate monsters
			for (int i = 0; i < GameData.numberOfEnemies; i++)
			{
				GenerateMoster();
			}


			MiniGame.NewMiniGame();
			if (MiniGame.PlayerWonRound())
				Console.WriteLine("Hurray I have won");


		}

		public static void HelpGenerateMoster()
		{
			int G = 0;
			int B = 0;
			int W = 0;
			foreach (var mosnter in GameData.EnemyList)
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
					GameData.EnemyList.Add(new Witch());

				}
				else if (GameData.witchSpawningChance < chance && chance <= GameData.bruteSpawningChance)
				{
					GameData.EnemyList.Add(new Brute());
				}
				else if (GameData.bruteSpawningChance < chance && chance > GameData.goblinSpawningChance)
				{
					GameData.EnemyList.Add(new Goblin());
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
