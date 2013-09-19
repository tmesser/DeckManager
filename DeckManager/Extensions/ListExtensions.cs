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
    }
}
