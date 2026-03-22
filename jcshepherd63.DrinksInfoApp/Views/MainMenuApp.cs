using DrinksInfoApp.Controllers;
using Spectre.Console;
using DrinksInfoApp.Models;

namespace DrinksInfoApp.Views;
internal class MainMenuApp
{
    public static async Task<string> MainMenu(HttpClient client) {
    
        var categoryList = await DrinkCategoryController.GetDrinkCategories(client);

        var selection = AnsiConsole.Prompt<DrinkCategory>(
            new SelectionPrompt<DrinkCategory>()
            .Title("Which category would you like to select from?")
            .AddChoices(categoryList));

        var selectionString = selection.ToString();

        Console.Clear();

        if (selectionString.Contains(" / "))
        {
            selectionString = selectionString.Replace(" ", "%20");
        }
        else if (selectionString.Contains(" "))
        {
            selectionString = selectionString.Replace(" ", "_");
        }

        return selectionString;

    }

}
