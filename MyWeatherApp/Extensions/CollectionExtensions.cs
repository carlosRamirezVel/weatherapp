using System;
using System.Collections;
using System.Collections.Generic;

namespace MyWeatherApp.Extensions
{
    public static class CollectionExtensions
    {
        /// <summary>
        /// add a new collection of items to the current list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="currentList"></param>
        /// <param name="items"></param>
        public static void AddRange<T>(this IList<T> currentList, IList<T> items)
        {
            if (currentList != null && items != null)
            {
                foreach (var item in items)
                {
                    currentList.Add(item);
                }
            }
        }

        /// <summary>
        /// clear and add a new range of items
        /// to current list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="currentList"></param>
        /// <param name="items"></param>
        public static void Restart<T>(this IList<T> currentList, IList<T> items)
        {
            if (currentList != null && items != null)
            {
                currentList.Clear();
                foreach (var item in items)
                {
                    currentList.Add(item);
                }
            }
        }
    }
}
