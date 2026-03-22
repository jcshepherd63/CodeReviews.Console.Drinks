using DrinksInfoApp.Models;
using DrinksInfoApp.DTOs;
using System.Net.Http.Json;

namespace DrinksInfoApp.Controllers;

internal class DrinkController
{

    public static async Task<List<DrinkList>> GetDrinksByCategory(HttpClient client, string drinkCategory)
    {
        try
        {
            using HttpResponseMessage response = await client.GetAsync($"https://www.thecocktaildb.com/api/json/v1/1/filter.php?c={drinkCategory}");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<DrinksResponse>();

            return result.drinks;
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine(e.Message);
        }

        return new List<DrinkList>();
    }
}
