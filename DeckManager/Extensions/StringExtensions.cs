using System;
using System.ComponentModel;

namespace DeckManager.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Parses the string as the given type using Convert.ChangeType
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="input">The input.</param>
        /// <param name="throwOnError">if set to <c>true</c> [throw on error].</param>
        /// <param name="customException">The custom exception to be thrown if there is an error.</param>
        /// <returns></returns>
        public static T ParseAs<T>(this string input, bool throwOnError = false, Exception customException = null)
        {
            try
            {
                var converter = TypeDescriptor.GetConverter(typeof(T));
                return (T)converter.ConvertFrom(input);
            }
            catch (Exception)
            {
                if (throwOnError == false)
                    return default(T);
                if (customException == null)
                    throw;
                throw customException;
            }
        }
    }
}
