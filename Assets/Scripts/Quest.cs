using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quest : MonoBehaviour
{
    public GameObject Timer;
    private float time;
    private float minuts;
    private float seconds;
    public GameObject Type;
    private int type;
    public GameObject UI;
    public GameObject Coin;

    void Start()
    {
        time = 120;
        minuts = Mathf.FloorToInt(time / 60);
        seconds = Mathf.FloorToInt(time % 60);
        if (seconds < 10)
        {
            Timer.GetComponent<Text>().text = minuts.ToString()+":0"+seconds.ToString();
        }
        else
        {
            Timer.GetComponent<Text>().text = minuts.ToString()+":"+seconds.ToString();
        }
        type = Random.Range(5, 12);
        Type.GetComponent<Text>().text = type.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        TimerFunc();
    }

    private void TimerFunc()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
        }
        else
        {
            time = 120;
            type = Random.Range(5, 12);
            Type.GetComponent<Text>().text = type.ToString();
        }
        minuts = Mathf.FloorToInt(time / 60);
        seconds = Mathf.FloorToInt(time % 60);
        if (seconds < 10)
        {
            Timer.GetComponent<Text>().text = minuts.ToString()+":0"+seconds.ToString();
        }
        else
        {
            Timer.GetComponent<Text>().text = minuts.ToString()+":"+seconds.ToString();
        }
    }

    public void Done()
    {
        if (UI.GetComponent<ChangePotion>().count[type-5] > 0)
        {
            Coin.GetComponent<Coin>().AddCoin(200);
            time = 0;
            UI.GetComponent<ChangePotion>().SubPotion(type-1);
        }
    }
}
