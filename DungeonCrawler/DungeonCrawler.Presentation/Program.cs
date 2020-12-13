using System;
using DungeonCrawler.Data.Enums;
using DungeonCrawler.Domain.Helpers;
using DungeonCrawler.Domain.Services;

namespace DungeonCrawler.Presentation
{
	class Program
	{
		static void Main(string[] args)
		{
			while (true)
			{
				EnumUtility.PrintMenu(new MainMenuOptions());
				var select = InputUtility.InputNumber("Select: ");

				switch (select)
				{
					case (int)MainMenuOptions.NewGame:
						var newGame = new Game();
						Console.Clear();
						newGame.NewGame();
						break;
					case (int)MainMenuOptions.Help:
						HelpMenu.PrintMenu();
						Console.WriteLine("Pres any key to continue . . .");
						Console.ReadKey();
						Console.Clear();
						break;
					case (int)MainMenuOptions.ExitGame:
						return;
					default:
						Console.Clear();
						break;
				}
			}

		}
	}
}
