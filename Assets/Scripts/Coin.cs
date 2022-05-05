using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    private int coin = 0;
    public GameObject TextLog;

    public void AddCoin(int add)
    {
        coin += add;
        gameObject.GetComponent<Text>().text = coin.ToString();
        if (coin > 500)
        {
            TextLog.GetComponent<Text>().text = "!!! WIN !!!";
        }
    }
}
