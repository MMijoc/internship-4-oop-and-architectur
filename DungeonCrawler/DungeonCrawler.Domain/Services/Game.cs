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

			PlayerHero = Select.SelectHeroClass();
			Console.Clear();
			Select.SetHeroStasts(PlayerHero);
			Console.WriteLine(PlayerHero);
			Thread.Sleep(1500);
			LevelUpHero();
			Console.Clear();

			for (int i = 0; i < GameConfig.numberOfEnemies; i++)
				GenerateMoster();

			for (var i = 0; i < EnemyList.Count; i++)
			{
				var enemy = EnemyList[i];	

				EnemyMonster = enemy;
				Console.WriteLine($"\t\t\t\tAn enemy {EnemyMonster.MonsterType} approaches");
				while (PlayerHero.Health > 0 && enemy.Health > 0)
				{

					if (!EnemyMonster.IsStuned)
					{

						ShowHud();
						MiniGame.NewMiniGame();
						Console.Clear();
					}
					else
					{
						MiniGame.PlayerWonRound = true;
						EnemyMonster.IsStuned = false;
					}

					ShowHud();
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
					Thread.Sleep(2000);
					Console.Clear();


				}

				if (CheckGame() == (int)GameState.Lose)
					return;
			}

			Console.WriteLine($"You have killed in total {EnemyList.Count} monsters\nYou have defeated all enemies! Congratulations!!!");
			EnemyList.Clear();
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

		public void UseHeroAbility()
		{

			if (PlayerHero is Warrior warrior)
			{
				EnumUtility.PrintMenu(new WarriroAbilities());
				bool canUseAbility = false;


				while (!canUseAbility)
				{
					int action = InputUtility.InputNumber("Choose action: ");
					switch (action)
					{
						case (int)WarriroAbilities.RegularAttack:
							canUseAbility =  warrior.Attack(EnemyMonster);
							break;
						case (int)WarriroAbilities.RageAttack:
							canUseAbility = warrior.RageAttack(EnemyMonster);
							break;
						default:
							break;
					} 
				}


			}
			else if (PlayerHero is Mage mage)
			{
				EnumUtility.PrintMenu(new MageAbilities());
				bool canUseAbility = false;

				while (!canUseAbility)
				{
					int action = InputUtility.InputNumber("Choose action: ");
					switch (action)
					{
						case (int)MageAbilities.RegularAttack:
							canUseAbility = mage.Attack(EnemyMonster);
							break;
						case (int)MageAbilities.HealSpell:
							canUseAbility = mage.HealSpell();
							break;
						case (int)MageAbilities.RegenerateMana:
							canUseAbility = mage.RegenerateMana();
							break;
						default:
							break;
					} 
				}

			}
			else if (PlayerHero is Ranger ranger)
			{
				ranger.RangerAttack(EnemyMonster);
			}

			return;
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

		public void LevelUpHero()
		{
			if (PlayerHero.Experience >= GameConfig.defaultExperienceToLevelUp)
			{
				if (PlayerHero is Warrior warrior)
				{
					warrior.LevelUp();

				}
				else if (PlayerHero is Mage mage)
				{
					mage.LevelUp();

				}
				else if (PlayerHero is Ranger ranger)
				{
					ranger.LevelUp();
				}
			}

			return;
		}

		public int CheckGame()
		{
			if (PlayerHero.Health < 0)
			{
				Console.WriteLine($"You have been defeated by {EnemyMonster.MonsterType}\nGame over.");
				EnemyList.Clear();
				return (int)GameState.Lose;
			}

			if (EnemyMonster.Health < 0)
			{
				if (EnemyMonster is Witch)
				{
					Console.WriteLine("With dying breath witch summons two more enemies");
					GenerateMoster();
					GenerateMoster();
				}
				Console.WriteLine($"You have defeated a {EnemyMonster.MonsterType} and gained {EnemyMonster.Experience} experience points");
				PlayerHero.Experience += EnemyMonster.Experience;

				LevelUpHero();

				PlayerHero.Health += (int)(0.25 * PlayerHero.MaxHealth);
				if (PlayerHero.Health > PlayerHero.MaxHealth)
				{
					PlayerHero.Health = PlayerHero.MaxHealth;
				}
				else
				{

					if (InputUtility.ConfirmAction($"Do you want to spend half of your current experience ({PlayerHero.Experience/2}) to fully restore your health?"))
					{
						PlayerHero.Experience = PlayerHero.Experience / 2;
						PlayerHero.Health = PlayerHero.MaxHealth;
					}
				}

			}

			return (int)GameState.Play;

		}

		public void ShowHud()
		{
			Console.ForegroundColor = ConsoleColor.Blue;
			Console.Write($"Hero name: {PlayerHero.Name}");
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine("{0, 64}", $"Enemy type: {EnemyMonster.MonsterType}");


			Console.ForegroundColor = ConsoleColor.Blue;
			Console.Write("\t{0, -67}", $"Health: {PlayerHero.Health}/{PlayerHero.MaxHealth}");
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine($"Health: {EnemyMonster.Health}/{EnemyMonster.MaxHealth}");

			Console.ForegroundColor = ConsoleColor.Blue;
			Console.Write("\t{0,-67}", $"Damage: { PlayerHero.Damage}");
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine($"Damage: {EnemyMonster.Damage}");

			Console.ForegroundColor = ConsoleColor.Blue;
			Console.Write("\t{0,-67}", $"Experience: {PlayerHero.Experience}");
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine($"Experience: {EnemyMonster.Experience}");

			if (PlayerHero is Mage mage)
			{
				Console.ForegroundColor = ConsoleColor.Blue;
				Console.WriteLine($"\tMana: {mage.Mana}/{mage.MaxMana}");
			}

			if (PlayerHero is Ranger ranger)
			{
				Console.ForegroundColor = ConsoleColor.Blue;
				Console.Write($"\tCritical hit chance: ");
				Console.WriteLine(string.Format("{0:n3}", ranger.CriticalChance));
				Console.Write($"\tStun Chance: ");
				Console.WriteLine(string.Format("{0:n3}", ranger.StunChance));

			}

			Console.Write("\n");
			Console.ResetColor();
			return;

		}

	}
}
