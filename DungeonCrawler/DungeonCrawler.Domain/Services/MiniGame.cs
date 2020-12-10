using DungeonCrawler.Data.Enums;
using DungeonCrawler.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DungeonCrawler.Domain.Services
{
	public static class MiniGame
	{
		static bool _playerWonRound;
		static bool _isADraw;


		public static void NewMiniGame()
		{
			while (true)
			{
				var rnd = new Random();
				int playerSelect = PlayerSelect();
				int enemySelect = rnd.Next() % 3;

				CompareOptions(playerSelect, enemySelect);

				Console.ForegroundColor = ConsoleColor.Blue;
				Console.Write($"{EnumUtility.GetDescription((RoundMiniGameOptions)playerSelect)}");
				Console.ResetColor(); Console.Write(" vs ");
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine($"{EnumUtility.GetDescription((RoundMiniGameOptions)enemySelect)}");
				Console.ResetColor();

				if (IsADraw())
				{
					Console.WriteLine("It's a Draw");
					Thread.Sleep(1500);
					continue;
				}

				if (PlayerWonRound())
				{
					Console.ForegroundColor = ConsoleColor.Blue;
					Console.WriteLine("PLAYER WON!");
					break;
				}
				else
				{
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine("Enemy won");
					break;

				}
			}

			Console.ResetColor();
			Thread.Sleep(1000);
			return;

		}

		public static int PlayerSelect()
		{
			int playerSelect;

			while (true)
			{
				Console.Clear();
				EnumUtility.PrintMenu(new RoundMiniGameOptions());
				var input = InputUtility.InputNumber("Enter an option: ");
				playerSelect = ChooseOption(input);
				if (playerSelect != (int)RoundMiniGameOptions.InvalidOption)
					break;
			}

			return playerSelect;
		}

		public static int ChooseOption(int optionNumber)
		{
			int select;

			switch (optionNumber)
			{
				case (int)RoundMiniGameOptions.Rock:
					select = (int)RoundMiniGameOptions.Rock;
					break;
				case (int)RoundMiniGameOptions.Paper:
					select = (int)RoundMiniGameOptions.Paper;
					break;
				case (int)RoundMiniGameOptions.Scissors:
					select = (int)RoundMiniGameOptions.Scissors;
					break;
				default:
					return (int)RoundMiniGameOptions.InvalidOption;
			}

			return select;
		}

		public static void CompareOptions(int playerSelect, int enemySelect)
		{
			if (playerSelect == enemySelect)
			{
				_isADraw = true;
				return;
			}

			if (playerSelect == (int)RoundMiniGameOptions.Rock)
			{ 
				if (enemySelect == (int)RoundMiniGameOptions.Scissors)
				{
					_isADraw = false;
					_playerWonRound = true;
					return;
				}
				else
				{
					_isADraw = false;
					_playerWonRound = false;
					return;
				}
			}
			else if (playerSelect == (int)RoundMiniGameOptions.Paper)
			{
				if (enemySelect == (int)RoundMiniGameOptions.Rock)
				{
					_isADraw = false;
					_playerWonRound = true;
					return;
				}
				else
				{
					_isADraw = false;
					_playerWonRound = false;
					return;
				}
			}
			else if (playerSelect == (int)RoundMiniGameOptions.Scissors)
			{
				if (enemySelect == (int)RoundMiniGameOptions.Paper)
				{
					_isADraw = false;
					_playerWonRound = true;
					return;
				}
				else
				{
					_isADraw = false;
					_playerWonRound = false;
					return;
				}
			}
		}

		public static bool PlayerWonRound()
		{
			if (_playerWonRound)
				return true;
			else
				return false;
		}

		public static bool IsADraw()
		{
			if (_isADraw)
				return true;
			else
				return false;
		}

	}
}
