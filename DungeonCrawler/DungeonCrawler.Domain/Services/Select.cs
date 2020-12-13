using System;
using DungeonCrawler.Data.Enums;
using DungeonCrawler.Data.Models;
using DungeonCrawler.Domain.Helpers;

namespace DungeonCrawler.Domain.Services
{
	public static class Select
	{
		public static Hero SelectHeroClass()
		{
			Hero hero;
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

		public static void SetHeroStasts(Hero hero)
		{
			Console.WriteLine($"Health points: {hero.Health}\nDamage: {hero.Damage}\nExperience: {hero.Experience}\nLevel: {hero.Level}");
			if (InputUtility.ConfirmAction("Do you want change your default stats?"))
			{
				hero.Health = InputUtility.InputNumber("Enter your hero's health points: ");
				hero.MaxHealth = hero.Health;
				hero.Damage = InputUtility.InputNumber("Enter your hero's damage: ");
				hero.Experience = InputUtility.InputNumber("Enter your hero's experience points: ");

				if (hero is Mage mage)
				{
					mage.Mana = InputUtility.InputNumber("Enter your hero's mana points: ");
					mage.MaxMana = mage.Mana;
				}
				return;
			}

			return;
		}
	}
}
