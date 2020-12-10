using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonCrawler.Data.Models
{
	public class Hero : Entity
	{
		public Hero()
		{
			Level = 1;
		}
		public string Name { get; set; }
		public int Level { get; set; }

		public void LevelUp()
		{
			if (Experience < 1000)
				return;

			

		}
	}
}
