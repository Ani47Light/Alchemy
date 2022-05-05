using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangePotion : MonoBehaviour
{
    public Button[] ActiveChange;
    private int ActiveChangeInt;
    public GameObject ChangePanel;
    public GameObject ObjectManager;
    public int[] count = {0,0,0,0,0,0,0};

    public void SetActiveChange(int butint)
    {
        if(ChangePanel.transform.localScale.y == 0)
        {
            ChangePanel.transform.localScale = new Vector3(1f,1f,1f);
        }
        else if (ActiveChangeInt == butint)
        {
            ChangePanel.transform.localScale = new Vector3(1f,0f,1f);
        }
        ActiveChangeInt = butint;
    }

    public void SetChangePotion(int type)
    {
        if (count[type-5] > 0 && 
            ActiveChange[0].transform.GetChild(0).GetComponent<Text>().text != type.ToString() && 
            ActiveChange[1].transform.GetChild(0).GetComponent<Text>().text != type.ToString())
        {
            ObjectManager.GetComponent<ObjectManag>().newType[ActiveChangeInt] = type - 1;
            ActiveChange[ActiveChangeInt].transform.GetChild(0).GetComponent<Text>().text = type.ToString();
        }
        ChangePanel.transform.localScale = new Vector3(1f,0f,1f);
    }

    public void AddPotion(int type)
    {
        count[type-4]++;
        transform.GetChild(3).transform.GetChild(type-4).transform.GetChild(1).GetComponent<Text>().text = count[type-4].ToString();
    }

    public void SubPotion(int type)
    {
        int active;
        count[type-4]--;
        transform.GetChild(3).transform.GetChild(type-4).transform.GetChild(1).GetComponent<Text>().text = count[type-4].ToString();
        if (count[type-4] == 0)
        {
            if (ActiveChange[0].transform.GetChild(0).GetComponent<Text>().text == (type+1).ToString()) active = 0;
            else active = 1;
            ActiveChange[active].transform.GetChild(0).GetComponent<Text>().text = "";
            ObjectManager.GetComponent<ObjectManag>().newType[active] = 11;
        }
    }
}
