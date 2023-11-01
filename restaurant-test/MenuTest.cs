using restaurant.Metier;

namespace restaurant_test;

public class MenuTest
{
    public string[] months = {"Janvier", "Février", "Mars",
        "Avril","Mai","Juin","Juillet","Aout","Septembre","Octobre",
        "Novembre","Décembre"
    };

    [Fact]
    public void GetShouldReturnMenuOfTheMonth()
    {
        int index = DateTime.Now.Month;
        var menuRepository = new MenuLocalRepository();
        var menu = menuRepository.GetMenuOfTheMonth();
        Assert.Equal($"Menu de {months[index -1]}", menu.Nom);
    }
}