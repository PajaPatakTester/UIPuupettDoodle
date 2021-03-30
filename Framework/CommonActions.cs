using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace Framework
{
    public static class CommonActions
    {
        public static DateTime ConvertToDateTime(string dateString)
        {
            return DateTime.Parse(dateString);
        }

        public static Dictionary<int, string> TableToDictionary(Table table)
        {
            var dictionary = new Dictionary<int, string>();
            foreach (var row in table.Rows)
            {
                dictionary.Add(Int32.Parse(row[0]), row[1]);
            }
            return dictionary;
        }
    }
}
