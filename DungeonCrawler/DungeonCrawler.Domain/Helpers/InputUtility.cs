using System;

namespace DungeonCrawler.Domain.Helpers
{
	public static class InputUtility
	{
		public static int InputNumber(string message)
		{
			while (true)
			{
				if (!string.IsNullOrEmpty(message))
					Console.Write(message);
				bool isNumber = int.TryParse(Console.ReadLine(), out int number);

				if (isNumber)
					return number;
				else
					Console.WriteLine("Invalid input!");
			}
		}

		public static string InputString(string message)
		{
			string input;
			while (true)
			{
				if (!string.IsNullOrEmpty(message))
					Console.Write(message);

				input = Console.ReadLine();
				input = input.Trim();

				if (!string.IsNullOrEmpty(input))
					break;
				else
					Console.WriteLine("Can not enter empty string!");
			}

			return input;
		}
		public static bool ConfirmAction(string message)
		{
			if (!string.IsNullOrEmpty(message))
				Console.Write(message);
			Console.WriteLine("\n\tYes - accept \n\tNo - cancel (press any key to cancel)");
			var input = Console.ReadLine();

			return input.Equals("yes", StringComparison.OrdinalIgnoreCase);
		}
	}
}
