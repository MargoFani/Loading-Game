using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New ShopItemData", menuName = "Shop Item Data", order = 10)]
public class ShopItemData : ScriptableObject
{
    [SerializeField]
    private int _price;
    public int Price => _price;
    [SerializeField]
    private string _name;
    public string Name => _name;
    [SerializeField]
    private List<ShopItemEffectData> _itemEffects;
    public List<ShopItemEffectData> ItemEffects => _itemEffects;

    public ShopItemData(int price, string name, List<ShopItemEffectData> effects)
    {
        _price = price;
        _name = name;
        _itemEffects = effects;
    }
}
