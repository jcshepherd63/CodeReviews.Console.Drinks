using DrinksInfoApp.Controllers;
using DrinksInfoApp.Models;

namespace DrinksInfoApp.Views;

internal class DrinkInformationMenu
{
    public static async Task DisplayDrinkInformation(HttpClient client, string drinkName)
    {
        var drinkInfo = await DrinkInformationController.InformationByDrink(client, drinkName);

        var properties = typeof(Drink).GetProperties();

        foreach (var str in drinkInfo)
        {
            foreach (var detail in properties)
            {
                var info = detail.GetValue(str);

                if (info != null)
                {
                    if (detail.Name.Contains("Instructions"))
                    {
                        Console.WriteLine($"\n{detail.Name}: {info}\n");
                    }
                    else
                    {
                        Console.WriteLine($"{detail.Name}: {info}");
                    }
                }
            }
        }

    }
}
