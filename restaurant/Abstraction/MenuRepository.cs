using System;
using restaurant.Metier;

namespace restaurant.Abstraction
{
	public abstract class MenuRepository
	{
		public abstract Menu GetMenuOfTheMonth();
	}
}

