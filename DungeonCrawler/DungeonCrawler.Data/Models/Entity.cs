namespace DungeonCrawler.Data.Models
{
	public class Entity
	{
		public Entity()
		{
			Experience = 0;
		}

		public int MaxHealth { get; set; }
		public int Health { get; set; }
		public int Damage { get; set; }
		public int Experience { get; set; }
	}
}
