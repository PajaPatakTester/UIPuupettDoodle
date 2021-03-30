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

        // Convert from comma separated strings to list of objects of type T
        public static List<T> StringToObjectsList<T>(string stringOfEnums) where T : struct, IConvertible
        {
            var newList = StringToList(stringOfEnums);
            return StringsToObjects<T>(newList);
        }

        // Convert comma separated strings to list of strings
        private static List<string> StringToList(string listAsString)
        {

            List<string> listOfStrings = new List<string>(listAsString.Split(','));
            return listOfStrings;
        }

        // Create list of objects from list of strings
        private static List<T> StringsToObjects<T>(List<string> stringOfEnums) where T : struct, IConvertible
        {
            Type t = typeof(T);

            List<T> enumList = new List<T>();

            foreach (var en in stringOfEnums)
            {
                enumList.Add((T)Enum.Parse(typeof(T), en));
            }

            return enumList;
        }

        public static Dictionary<string, string> TableToDictionary(Table table)
        {
            var dictionary = new Dictionary<string, string>();
            foreach (var row in table.Rows)
            {
                dictionary.Add(row[0], row[1]);
            }
            return dictionary;
        }
    }
}
