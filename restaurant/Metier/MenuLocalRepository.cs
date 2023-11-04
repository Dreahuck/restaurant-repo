using System.Globalization;
using restaurant.Abstraction;
using restaurant.Extensions;

namespace restaurant.Metier
{
    public class MenuLocalRepository : MenuRepository
    {
        public static List<Menu> _menus = new List<Menu>
        {
            new Menu("Menu de Janvier", "01/01/2023".ToDateTime(), "31/01/2023".ToDateTime()),
            new Menu("Menu de Mars", "01/03/2023".ToDateTime(), "31/03/2023".ToDateTime()),
            new Menu("Menu de Octobre", "01/10/2023".ToDateTime(), "31/10/2023".ToDateTime()),
            new Menu("Menu de Novembre : Spécial Halloween", "01/11/2023".ToDateTime(), "30/11/2023".ToDateTime()),
        };

        public override Menu GetMenuOfTheMonth()
        {
            DateTime today = DateTime.Now;
            var menu = _menus.First((menu) => menu.DateMin <= today && menu.DateMax >= today);
            return menu;
        }
    }
}

