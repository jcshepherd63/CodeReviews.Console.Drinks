using DrinksInfoApp.DTOs;
using DrinksInfoApp.Models;
using System.Net.Http.Json;

namespace DrinksInfoApp.Controllers;

internal class DrinkCategoryController
{

    public static async Task<List<DrinkCategory>> GetDrinkCategories(HttpClient client)
    {
        List<DrinkCategory> categoryList = new();
        try
        {
            using HttpResponseMessage response = await client.GetAsync("https://www.thecocktaildb.com/api/json/v1/1/list.php?c=list");
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadFromJsonAsync<DrinkCategoryResponse>();

            foreach(var drinkCategory in responseBody.drinks)
            {
                categoryList.Add(drinkCategory);
            }

        }
        catch(HttpRequestException e)
        {
            Console.WriteLine(e.Message);
        }

        return categoryList;
    }
}
