using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Potion : MonoBehaviour
{
    public int type;
    public int temp;

    public void SetType(int T)
    {
        type = T;
        transform.GetChild(type).gameObject.SetActive(true);
    }

    public void SetUpTemp(int t)
    {
        if (t > temp)
        {
            temp = t;
        }
        transform.GetChild(type).transform.GetChild(2).gameObject.GetComponent<TextMeshPro>().SetText("Temp: " + temp.ToString());
    }

    public void SetDownTemp(int t)
    {
        if (t < temp)
        {
            temp = t;
        }
        transform.GetChild(type).transform.GetChild(2).gameObject.GetComponent<TextMeshPro>().SetText("Temp: " + temp.ToString());
    }
}
