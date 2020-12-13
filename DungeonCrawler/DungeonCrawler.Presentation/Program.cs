﻿using System;
using System.Text;
using DungeonCrawler.Data.Enums;
using DungeonCrawler.Data.Models;
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
				var hero = new Entity();

				switch (select)
				{
					case (int)MainMenuOptions.NewGame:
						var newGame = new Game();
						Console.Clear();
						newGame.NewGame();
						break;
					case (int)MainMenuOptions.Help:
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
