using DungeonCrawler.Data.Enums;
using DungeonCrawler.Data.Models;
using DungeonCrawler.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Text;


namespace DungeonCrawler.Domain.Services
{
	public static class Select
	{
	
		public static Entity SelectHeroClass()
		{

			var hero = new Hero();
			while (true)
			{
				Console.Clear();
				EnumUtility.PrintMenu(new HeroClassOptions());
				var select = InputUtility.InputNumber("Select hero class: ");
				switch (select)
				{
					case (int)HeroClassOptions.Warrior:
						hero = new Warrior();
						break;
					case (int)HeroClassOptions.Mage:
						hero = new Mage();
						break;
					case (int)HeroClassOptions.Ranger:
						hero = new Ranger();
						break;
					default:
						continue;
				}
				string name = InputUtility.InputString("Name your character: ");
				if (InputUtility.ConfirmAction($"Are you sure that you want to continue as a {(HeroClassOptions)select} named {name}?"))
				{
					hero.Name = name;
					return hero;
				}

			}


		}
	
	}
}
