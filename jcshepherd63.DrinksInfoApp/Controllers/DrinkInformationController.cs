using DrinksInfoApp.DTOs;
using DrinksInfoApp.Models;
using System.Net.Http.Json;


namespace DrinksInfoApp.Controllers;

internal class DrinkInformationController
{
    public static async Task<List<Drink>> InformationByDrink(HttpClient client, string drinkName)
    {
        try
        {
            using HttpResponseMessage response = await client.GetAsync($"https://www.thecocktaildb.com/api/json/v1/1/search.php?s={drinkName}");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<DrinkInformationResponse>();

            return result.drinks ?? new List<Drink>();
        }
        catch(HttpRequestException e)
        {
            Console.WriteLine(e.Message);
        }

        return new List<Drink>();
    }
}
