using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItem
{
    
    public int Price { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public int Duration { get; private set; }
    public ShopItem(int price, string name, string description, int duration)
    {
        Price = price;
        Name = name;
        Description = description;
        Duration = duration;
    }
}
