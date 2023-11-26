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
            new ShopItem(100, "��������", "� ������� ��������� ��������, ���� �������� ������. �������� �������� ��������� �� 10 Mb �� 30 ������. ���� ����� �� ���������.", 30),
            new ShopItem(350, "����", "��� �� ������, ���� = �������. ������ �� ������ �������� � 2 ���� �� 20 ������.", 20),
            new ShopItem(120, "�������", "��� ��������� ������ � ������, ����� ������ �������� ��� ��������. �������� �������� ��������� �� 10 Mb �� 30 ������.", 30),
            new ShopItem(440, "����� ����", "����� ���� �������������. �������� ��������� �� 10 Mb �� 30 ������.", 30),
            new ShopItem(110, "������", "����� � �������� �����������������. �������� �� ����� ������ � ������� 30 ������.", 30)
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
