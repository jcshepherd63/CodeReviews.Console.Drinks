using DrinksInfoApp.Controllers;
using DrinksInfoApp.Views;

namespace DrinksInfoApp;

internal class App
{

    private static HttpClient client = new();
    public static async Task run()
    {
        var selection = await MainMenuApp.MainMenu(client);
        var drink = await DrinkSelectionMenu.DrinkSelection(client, selection);
        await DrinkInformationMenu.DisplayDrinkInformation(client, drink);

    }
}
