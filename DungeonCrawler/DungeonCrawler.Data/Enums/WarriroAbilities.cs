using System.ComponentModel;

namespace DungeonCrawler.Data.Enums
{
	public enum WarriroAbilities
	{
		[Description("Regular attack - damages enemy health by amount of your damage")] RegularAttack = 1,
		[Description("Rage attack - lose portion of your health to deal double damage")] RageAttack,
	}
}
