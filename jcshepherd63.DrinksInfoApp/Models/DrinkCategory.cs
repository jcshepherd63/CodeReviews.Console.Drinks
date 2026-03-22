using System.Text.Json.Serialization;

namespace DrinksInfoApp.Models;

internal class DrinkCategory
{
    [JsonPropertyName("strCategory")]
    public string category { get; set; }

    public override string ToString()
    {
        return category;
    }
}