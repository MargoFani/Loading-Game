using Assets.Scripts;
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

    [SerializeField]
    private ShopItemData[] shopItems;

    [SerializeField] Button[] shopButtons;
    [SerializeField] Text[] shopPrices;
    [SerializeField] Sprite[] shopIcons;

    [SerializeField] private ItemsEffectManager itemsEffectManager;
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
            if (itemsEffectManager.IsEffectActive || shopItems[i].Price > game.PlayerPoints)
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
        

        //рандомно выбираем из эффектов в предмете
        System.Random rnd = new System.Random();
        int effectId = rnd.Next(shopItems[effectNumber].ItemEffects.Count);

        itemsEffectManager.SetEffectInfo(shopIcons[effectNumber], shopItems[effectNumber].ItemEffects[effectId].Description);
        itemsEffectManager.StartEffect(shopItems[effectNumber].ItemEffects[effectId]);

    }
}
