
using System.ComponentModel;

namespace DungeonCrawler.Data.Enums
{
	public enum RoundMiniGameOptions
	{

		[Description("Direct attack")] Rock,
		[Description("Side attack")] Scissors,
		[Description("Counterstrike")] Paper,
		InvalidOption,
	}
}
