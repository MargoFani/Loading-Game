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
            new ShopItem(100, "��������", "� ������ ��������� ��������, ���� ��������� ������. �������� �������� ��������� �� 20 Mb. ���� ����� �� ���������.", -1),
            new ShopItem(150, "����", "��� �� ������, ���� = �������. ������ �� ������ �������� � 2 ���� �� 30 ������.", 20),
            new ShopItem(250, "�������", "��� ��������� ������ � ������, ����� ������ �� ������ ��� ��������. �������� �������� ��������� �� 10 Mb � �� ����������� � ������� 30 ������.", 30),
            new ShopItem(300, "����� ����", "����� - ���� �������������. �� �� ������ ������ �� �������� � ������� 30 ������.", 30),
            new ShopItem(350, "������", "����� � �������� �����������������. �������� �� ����� ������ � ������� 30 ������.", 30)
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
