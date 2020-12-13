
namespace DungeonCrawler.Data.Models
{
	public class Hero : Entity
	{
		public Hero()
		{
			Name = GameConfig.heroDefaultName;
			Level = GameConfig.heroDefaultLevel;
		}
		public string Name { get; set; }
		public int Level { get; set; }

	}
}
