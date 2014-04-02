using System;
using System.Collections.Generic;
using System.Text;

namespace DeckManager.Extensions
{
    public static class ListExtensions
    {
        public static string ToSingleString<T>(this List<T> input)
        {
            var ret = new StringBuilder();
            foreach (var item in input)
            {
                ret.Append(item);
                ret.Append(" ");
            }
            return ret.ToString().Trim();
        }

        public static void Shuffle<T>(this IList<T> list)
        {
            var rng = new Random();
            var n = list.Count;
            while (n > 1)
            {
                n--;
                var k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
