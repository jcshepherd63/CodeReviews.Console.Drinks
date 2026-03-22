using System;
using System.Collections.Generic;
using System.Text;

namespace DrinksInfoApp.Models;

public class DrinkList
{
    public string strDrink { get; set; }
    public string strDrinkThumb { get; set; }
    public string idDrink { get; set; }

    public override string ToString()
    {
        return strDrink;
    }
}
