using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSwitch : MonoBehaviour
{
    private bool openMenu = false;
    public GameObject MenuPanel;

    public void Menu()
    {
        if (openMenu)
        {
            MenuPanel.transform.localScale = new Vector3(0f,1f,1f);
            openMenu = false;
        }
        else
        {
            MenuPanel.transform.localScale = new Vector3(1f,1f,1f);
             openMenu = true;
        }
    }

    public void Recipes()
    {
        MenuPanel.transform.GetChild(1).transform.localScale = new Vector3(1f,1f,1f);
        MenuPanel.transform.GetChild(2).transform.localScale = new Vector3(0f,1f,1f);
        MenuPanel.transform.GetChild(3).transform.localScale = new Vector3(0f,1f,1f);
    }

    public void Quests()
    {
        MenuPanel.transform.GetChild(1).transform.localScale = new Vector3(0f,1f,1f);
        MenuPanel.transform.GetChild(2).transform.localScale = new Vector3(1f,1f,1f);
        MenuPanel.transform.GetChild(3).transform.localScale = new Vector3(0f,1f,1f);
    }

    public void Trade()
    {
        MenuPanel.transform.GetChild(1).transform.localScale = new Vector3(0f,1f,1f);
        MenuPanel.transform.GetChild(2).transform.localScale = new Vector3(0f,1f,1f);
        MenuPanel.transform.GetChild(3).transform.localScale = new Vector3(1f,1f,1f);
    }
}
