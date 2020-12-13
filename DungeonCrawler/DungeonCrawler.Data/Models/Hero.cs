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

		public override string ToString()
		{
			return $"Hero name: {Name}\n\tHealth: {Health}/{MaxHealth}\n\tExperience: {Experience}\n\tLevel: {Level}";
		}
	}
}
