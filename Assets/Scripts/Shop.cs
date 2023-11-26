using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    private EventHandler OnShopBuy;
    [SerializeField] private Game game;

    private ShopItem[] shopItems = new ShopItem[] {
            new ShopItem(100, "отвертка", "у соседка отклюился интернет, тебе дсталось больше. скорость загрузки увеличена на 10 Mb на 30 секунд. пока сосед не опомнился.", 30),
            new ShopItem(350, "кофе", "тут всё просто, кофе = энергия. эффект от кликов увеличен в 2 раза на 20 секунд.", 20),
            new ShopItem(120, "чемодан", "все домачадцы уехали в отпуск, никто больше неворует ваш интернет. скорость загрузки увеличена на 10 Mb на 30 секунд.", 30),
            new ShopItem(440, "бокал вина", "время дело относительное. скорость уменьшена на 10 Mb на 30 секунд.", 30),
            new ShopItem(110, "гвоздь", "забил и скорость стабилизировалась. скорость не будет падать в течении 30 секунд.", 30)
        };

    [SerializeField] Button[] shopButtons;
    [SerializeField] Text[] shopPrices;
    [SerializeField] Sprite[] shopIcons;
    void Start()
    {
        for(int i = 0; i<shopItems.Length; i++)
        {
            shopPrices[i].text = shopItems[i].Price.ToString();
        }
    }


    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < shopItems.Length; i++)
        {
            if (shopItems[i].Price > game.PlayerPoints)
            {
                shopButtons[i].interactable = false;

            }else shopButtons[i].interactable = true;
        }
    }

    public void BuyEffect(int effectNumber)
    {
        game.PlayerPoints -= shopItems[effectNumber].Price;
        game.SetEffectInfo(shopIcons[effectNumber], shopItems[effectNumber].Description);

    }
}
