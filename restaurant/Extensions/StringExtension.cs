using System;
using System.Globalization;

namespace restaurant.Extensions
{
	public static class StringExtension
	{

		public static DateTime ToDateTime(this string date)
		{
            return DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
        }
    }
}

