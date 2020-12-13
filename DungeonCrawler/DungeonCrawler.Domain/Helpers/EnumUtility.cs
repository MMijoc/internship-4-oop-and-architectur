using System;
using System.Reflection;
using System.ComponentModel;

namespace DungeonCrawler.Domain.Helpers
{
	public static class EnumUtility
	{
        public static string GetDescription(this Enum value)
        {
            Type type = value.GetType();
            string name = Enum.GetName(type, value);
            if (name != null)
            {
                FieldInfo field = type.GetField(name);
                if (field != null)
                {
                    DescriptionAttribute attr = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;
                    if (attr != null)
                    {
                        return attr.Description;
                    }
                }
            }
            return null;
        }

        public static void PrintMenu(Enum MenuOptions)
        {
            var options = Enum.GetValues(MenuOptions.GetType());
            foreach (var value in options)
            {
                var description = EnumUtility.GetDescription((Enum)value);
                if (!string.IsNullOrEmpty(description))
                    Console.WriteLine($"{((int)value).ToString()} - {EnumUtility.GetDescription((Enum)value)}");
            }
        }

    }
}
