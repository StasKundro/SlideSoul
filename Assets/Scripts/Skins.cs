using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skins : MonoBehaviour
{
    public int skinNum;
    public GameObject[] skin;
    public GameObject shop;
    private int x;
    public int coins;
    public int price;

    void Start()
    {
        skinNum = PlayerPrefs.GetInt("SkinNum", skinNum);
        skin[skinNum].SetActive(true);
    }

    public void OpenShop()
    {
        if(x == 0)
        {
            x++;
            shop.SetActive(true);
        }
        else
        {
            x = 0;
            shop.SetActive(false);
        }
    }

    public void Buy1()
    {
        x = 0;
        shop.SetActive(false);

        coins = PlayerPrefs.GetInt("Coins", coins);
        if (coins >= price)
        {
            coins -= price;
            PlayerPrefs.SetInt("Coins", coins);
            skin[0].SetActive(true);
            skin[1].SetActive(false);
            skin[2].SetActive(false);
        }
    }
    public void Buy2()
    {
        x = 0;
        shop.SetActive(false);

        coins = PlayerPrefs.GetInt("Coins", coins);
        if (coins >= price)
        {
            coins -= price;
            PlayerPrefs.SetInt("Coins", coins);
            skin[0].SetActive(false);
            skin[1].SetActive(true);
            skin[2].SetActive(false);
        }
    }
    public void Buy3()
    {
        x = 0;
        shop.SetActive(false);

        coins = PlayerPrefs.GetInt("Coins", coins);
        if (coins >= price)
        {
            coins -= price;
            PlayerPrefs.SetInt("Coins", coins);
            skin[0].SetActive(false);
            skin[1].SetActive(false);
            skin[2].SetActive(true);
        }
    }

}
