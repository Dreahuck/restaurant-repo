using System.Globalization;
using restaurant.Abstraction;
using restaurant.Extensions;

namespace restaurant.Metier
{
    public class MenuLocalRepository : MenuRepository
    {
        public static List<Menu> _menus = new List<Menu>
        {
            new Menu("Menu de Janvier",  "01/01/2023".ToDateTime(),  "31/01/2023".ToDateTime() ),
            new Menu("Menu de Février",  "01/02/2023".ToDateTime(),  "28/02/2023".ToDateTime() ),
            new Menu("Menu de Mars",     "01/03/2023".ToDateTime(),  "31/03/2023".ToDateTime() ),
            new Menu("Menu d'Avril",     "01/04/2023".ToDateTime(),  "30/04/2023".ToDateTime() ),
            new Menu("Menu de Mai",      "01/05/2023".ToDateTime(),  "31/05/2023".ToDateTime() ),
            new Menu("Menu de Juin",     "01/06/2023".ToDateTime(),  "30/06/2023".ToDateTime() ),
            new Menu("Menu de Juillet",  "01/07/2023".ToDateTime(),  "31/07/2023".ToDateTime() ),
            new Menu("Menu d'Août",      "01/08/2023".ToDateTime(),  "31/08/2023".ToDateTime() ),
            new Menu("Menu de Septembre","01/09/2023".ToDateTime(),  "30/09/2023".ToDateTime() ),
            new Menu("Menu d'Octobre",   "01/10/2023".ToDateTime(),  "31/10/2023".ToDateTime() ),
            new Menu("Menu de Novembre", "01/11/2023".ToDateTime(),  "30/11/2023".ToDateTime() ),
            new Menu("Menu de Décembre", "01/12/2023".ToDateTime(),  "31/12/2023".ToDateTime() )
        };

        public override Menu GetMenuOfTheMonth()
        {
            DateTime today = DateTime.Now;
            var menu = _menus.First((menu) =>
                menu.DateMin.Month <= today.Month && menu.DateMax.Month >= today.Month);
            return menu;
        }
    }
}

