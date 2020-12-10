using System.ComponentModel;

namespace DungeonCrawler.Data.Enums
{
	public enum HeroClassOptions
	{
		[Description("Warrior - \n\tHigh HP, weak attack, Berserker rage")] Warrior,
		[Description("Mage")] Mage,
		[Description("Ranger")] Ranger,
	}
}
