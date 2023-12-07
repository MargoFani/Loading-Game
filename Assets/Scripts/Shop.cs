using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [SerializeField] private Game game;

    [SerializeField] private AudioSource effectIsActiveSound;

    private ShopItem[] shopItems = new ShopItem[] {
            new ShopItem(100, "отвертка", "у соседа отклюился интернет, тебе досталось больше. скорость загрузки увеличена на 20 Mb. пока сосед не опомнился.", -1),
            new ShopItem(150, "кофе", "тут всё просто, кофе = энергия. эффект от кликов увеличен в 2 раза на 30 секунд.", 20),
            new ShopItem(250, "чемодан", "все домачадцы уехали в отпуск, никто больше не ворует ваш интернет. скорость загрузки увеличена на 10 Mb и не уменьшается в течение 30 секунд.", 30),
            new ShopItem(300, "бокал вина", "время - дело относительное. вы не можете влиять на скорость в течение 30 секунд.", 30),
            new ShopItem(350, "гвоздь", "забил и скорость стабилизировалась. скорость не будет падать в течение 30 секунд.", 30)
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
            if (game.IsEffectActive || shopItems[i].Price > game.PlayerPoints)
            {
                shopButtons[i].interactable = false;

            }else shopButtons[i].interactable = true;
        }

    }

    public void BuyEffect(int effectNumber)
    {
        effectIsActiveSound.Play();
        Debug.Log("BuyEffect: " + effectNumber);
        game.PlayerPoints -= shopItems[effectNumber].Price;
        game.SetEffectInfo(shopIcons[effectNumber], shopItems[effectNumber].Description);
        game.StartEffect(effectNumber);

    }
}
