using DrinksInfoApp.Controllers;
using Spectre.Console;
using DrinksInfoApp.Models;

namespace DrinksInfoApp.Views;

internal class DrinkSelectionMenu
{
    public static async Task<string> DrinkSelection(HttpClient client, string selectionString)
    {
        var drinkList = await DrinkController.GetDrinksByCategory(client, selectionString);

        var drinkSelection = AnsiConsole.Prompt<DrinkList>(
            new SelectionPrompt<DrinkList>()
            .Title("Which drink would you like more information on?")
            .AddChoices(drinkList));

        string drinkString = drinkSelection.ToString();

        if (drinkString.Contains(" "))
        {
            drinkString = drinkString.Replace(" ", "_");
        }
        return drinkString;
    }
}
