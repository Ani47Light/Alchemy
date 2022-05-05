using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SellPotion : MonoBehaviour
{
    public GameObject Coin;
    public GameObject UI;
    int price = 0;

    private void Update()
    {
        for (int i = 0; i < 7; i++)
        {
            transform.GetChild(i).transform.GetChild(2).gameObject.GetComponent<Text>().text = UI.GetComponent<ChangePotion>().count[i].ToString();
        }
    }

    public void Sell(int type)
    {
        if (type == 5 || type == 6 || type == 7) price = 50;
        if (type == 8 || type == 11) price = 100;
        if (type == 9 || type == 10) price = 150;
        if (UI.GetComponent<ChangePotion>().count[type-5] > 0)
        {
            Coin.GetComponent<Coin>().AddCoin(price);
            UI.GetComponent<ChangePotion>().SubPotion(type-1);
        }
    }
}
