using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonCrawler.Data.Models
{
	public class Monster : Entity
	{
		public string MonsterType { get; set; }
		public bool IsStuned { get; set; }


		public override string ToString()
		{
			return $"{MonsterType}'s {Health}";
		}
	}

}
