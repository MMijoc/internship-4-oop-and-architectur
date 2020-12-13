using System;
using System.Threading;
using System.Collections.Generic;
using DungeonCrawler.Data;
using DungeonCrawler.Data.Enums;
using DungeonCrawler.Data.Models;
using DungeonCrawler.Domain.Helpers;

namespace DungeonCrawler.Domain.Services
{
	public class Game
	{
		public static List<Monster> EnemyList { get; set; } = new List<Monster>();
		public static bool EnemyIsStuned { get; set; }

		public static Hero PlayerHero { get; set; }

		public static Monster EnemyMonster { get; set; }
		public void NewGame()
		{
			PlayerHero = new Ranger();
			Console.WriteLine($"Health points: {PlayerHero.Health}\nDamage: {PlayerHero.Damage}\nExperience: {PlayerHero.Experience}\nLevel: {PlayerHero.Level}\n\n");
			for (int i = 0; i < GameConfig.numberOfEnemies; i++)
				GenerateMoster();
			HelpGenerateMoster();

			for (var i = 0; i < EnemyList.Count; i++)
			{
				var enemy = EnemyList[i];	

				EnemyMonster = enemy;
				Console.WriteLine("fighting a new enemy");
				Console.WriteLine($"{PlayerHero.Name}'s health: {PlayerHero.Health}\n{EnemyMonster}");
				while (PlayerHero.Health > 0 && enemy.Health > 0)
				{

					if (!EnemyMonster.IsStuned)
					{
						MiniGame.NewMiniGame();
						Console.Clear();
					}
					else
					{
						MiniGame.PlayerWonRound = true;
						EnemyMonster.IsStuned = false;
					}

					if (MiniGame.PlayerWonRound)
					{
						UseHeroAbility();
					}
					else
					{
						UseEnemyAbility();
					}

					if (PlayerHero.Health < 0 && PlayerHero is Mage mage)
					{
						if (!mage.AvoidDeath())
							break;

					}


					Console.WriteLine($"{PlayerHero.Name}'s health: {PlayerHero.Health}\n{EnemyMonster.MonsterType}'s health: {EnemyMonster.Health}\n");
					Thread.Sleep(1000);
				}

				if (PlayerHero.Health < 0)
				{
					Console.WriteLine($"You have been defeated by {EnemyMonster.MonsterType}\nGame over.");
					EnemyList.Clear();
					return;
				}

				if (EnemyMonster.Health < 0)
				{
					if (EnemyMonster is Witch) {
						GenerateMoster();
						GenerateMoster();
					}
					Console.WriteLine($"You have defeated a {EnemyMonster.MonsterType}");
				}
			}

			Console.WriteLine($"You have killed in total {EnemyList.Count} monsters\nYou have defeated all enemies! Congratulations!!!");
			EnemyList.Clear();


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

				if (0 < chance && chance <= GameConfig.witchSpawningChance)
				{
					EnemyList.Add(new Witch());

				}
				else if (GameConfig.witchSpawningChance < chance && chance <= GameConfig.bruteSpawningChance)
				{
					EnemyList.Add(new Brute());
				}
				else if (GameConfig.bruteSpawningChance < chance && chance > GameConfig.goblinSpawningChance)
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

		public int UseHeroAbility()
		{

			if (PlayerHero is Warrior warrior)
			{
				EnumUtility.PrintMenu(new WarriroAbilities());
				int action = InputUtility.InputNumber("Choose action: ");
				switch (action)
				{
					case (int)WarriroAbilities.RegularAttack:
						warrior.Attack(EnemyMonster);
						break;
					case (int)WarriroAbilities.RageAttack:
						warrior.RageAttack(EnemyMonster);
						break;
					default:
						break;
				}

			}
			else if (PlayerHero is Mage mage)
			{
				EnumUtility.PrintMenu(new MageAbilities());
				int action = InputUtility.InputNumber("Choose action: ");
				switch (action)
				{
					case (int)MageAbilities.RegularAttack:
						mage.Attack(EnemyMonster);
						break;
					case (int)MageAbilities.HealSpell:
						mage.HealSpell();
						break;
					case (int)MageAbilities.RegenerateMana:
						mage.RegenerateMana();
						break;
					default:
						break;
				}
			}
			else if (PlayerHero is Ranger ranger)
			{
				ranger.RangerAttack(EnemyMonster);
			}
			else
			{
				return -1;
			}









			//switch (heroClassCode)
			//{
			//	case (int)HeroClassOptions.Warrior:
			//		var warrior = PlayerHero as Warrior;
			//		warrior.Attack(EnemyMonster);
			//		break;
			//	case (int)HeroClassOptions.Mage:
			//		break;
			//	case (int)HeroClassOptions.Ranger:
			//		break;
			//	default:
			//		return -1;
			//}

			return 1;
		}

		public int UseEnemyAbility()
		{
			var rnd = new Random();
			var chance = rnd.NextDouble();

			if (EnemyMonster is Goblin goblin)
			{
				goblin.Attack(PlayerHero);
			}
			else if (EnemyMonster is Brute brute)
			{
				if (0 < chance && chance <= GameConfig.bruteRavageChance)
				{
					brute.BruteAttack(PlayerHero);
				}
				else
				{
					brute.Attack(PlayerHero);
				}
			}
			else if (EnemyMonster is Witch witch)
			{
				if (0 < chance && chance <= GameConfig.witchMayhemChance)
				{
					witch.Mayhem(PlayerHero, EnemyList);
				}
				else
				{
					witch.Attack(PlayerHero);
				}

			}
			else
			{
				return -1;
			}


			return 1;
		}

	}
}
