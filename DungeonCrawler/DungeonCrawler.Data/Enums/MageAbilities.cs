using System.ComponentModel;

namespace DungeonCrawler.Data.Enums
{
	public enum MageAbilities
	{
		[Description("Cast destructive spell - damages enemy health by amount of your damage, uses mana")] RegularAttack = 1,
		[Description("Cast heal spell - restores health, uses mana")] HealSpell,
		[Description("Regenerate mana - restores all mana")] RegenerateMana
	}
}
