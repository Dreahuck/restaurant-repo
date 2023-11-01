using System;
using restaurant.Extensions;

namespace restaurant_test
{
	public class ExtensionTest
	{
		[Theory]
		[InlineData("01/01/2023", 1, 1, 2023)]
        [InlineData("01/01/2024", 1, 1, 2024)]
        [InlineData("01/05/2023", 1, 5, 2023)]
        [InlineData("05/01/2023", 5, 1, 2023)]
        [InlineData("31/01/2023", 31, 1, 2023)]
        public void ShouldReturnCorrectDate(string strDate, int expDay, int expMonth, int expYear)
		{
			DateTime date = strDate.ToDateTime();

			Assert.Equal(expDay, date.Day);
			Assert.Equal(expMonth, date.Month);
			Assert.Equal(expYear, date.Year);
		}
	}
}

