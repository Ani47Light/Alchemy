using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
public class Distance : MonoBehaviour
{
    private float dist;
    public GameObject newPotion;
    private GameObject addedPotion;
    private bool added;
    public ObjectManag ImageObjectManager;
    private string Type;
    private string Temp;
    private int setType;
    public GameObject UIPotion;

    // Start is called before the first frame update
    void Start()
    {
        UIPotion.transform.GetChild(4).GetComponent<Text>().text = "Mission 500 coin";
        addedPotion = Instantiate(newPotion, Vector3.zero, Quaternion.identity);
        addedPotion.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (ImageObjectManager.NumberOfTrackedImages() > 1){
        GameObject[] potions =  GameObject.FindGameObjectsWithTag("Potion");
        GameObject[] crystals = GameObject.FindGameObjectsWithTag("Crystal");
        if(potions.Length > 1)//ImageObjectManager.NumberOfTrackedImages() > 1)
        {
            dist = Vector3.Distance(potions[0].transform.position, potions[1].transform.position);
            if(dist <= 0.1f)
            {
                if (!added)
                {
                    int type1 = potions[0].GetComponent<Potion>().type;
                    int type2 = potions[1].GetComponent<Potion>().type;
                    int temp1 = potions[0].GetComponent<Potion>().temp;
                    int temp2 = potions[1].GetComponent<Potion>().temp;
                    if (type1 > type2)
                    {
                        Type = type2.ToString() + type1.ToString();
                        Temp = temp2.ToString() + temp1.ToString();
                    }
                    else
                    {
                        Type = type1.ToString() + type2.ToString();
                        Temp = temp1.ToString() + temp2.ToString();
                    }
                    if (Type == "01" && Temp == "00")
                    {
                        setType = 4;
                    }
                    else if (Type == "02" && Temp == "00")
                    {
                        setType = 5;
                    }
                    else if (Type == "12" && Temp == "00")
                    {
                        setType = 6;
                    }
                    else if (Type == "23" && Temp == "01")
                    {
                        setType = 7;
                    }
                    else if (Type == "35" && Temp == "20")
                    {
                        UIPotion.GetComponent<ChangePotion>().SubPotion(5);
                        setType = 8;
                    }
                    else if (Type == "46" && Temp == "00")
                    {
                        UIPotion.GetComponent<ChangePotion>().SubPotion(4);
                        UIPotion.GetComponent<ChangePotion>().SubPotion(6);
                        setType = 9;
                    }
                    else if (Type == "17" && Temp == "00")
                    {
                        UIPotion.GetComponent<ChangePotion>().SubPotion(7);
                        setType = 10;
                    }
                    else
                    {
                        if (type1 > 3)
                        {
                            UIPotion.GetComponent<ChangePotion>().SubPotion(type1);
                        }
                        if (type2 > 3)
                        {
                            UIPotion.GetComponent<ChangePotion>().SubPotion(type2);
                        }
                        setType = 11;
                    }
                    Transform[] allChildren = addedPotion.GetComponentsInChildren<Transform>();
                    foreach (Transform child in allChildren)
                    {
                        if (child.gameObject.tag == "Child")
                        {
                            child.gameObject.SetActive(false);
                        }
                    }
                    UIPotion.GetComponent<ChangePotion>().AddPotion(setType);
                    addedPotion.SetActive(true);
                    addedPotion.transform.GetChild(setType).gameObject.SetActive(true);
                    added = true;
                    UIPotion.transform.GetChild(4).GetComponent<Text>().text = "New potion";
                }
                addedPotion.transform.position = (potions[0].transform.position + potions[1].transform.position) / 2;
            }
            else
            {
                UIPotion.transform.GetChild(4).GetComponent<Text>().text = "";
                addedPotion.SetActive(false);
                added = false;
            }
        }
        else if (potions.Length == 1 && crystals.Length == 1)
        {
            dist = Vector3.Distance(potions[0].transform.position, crystals[0].transform.position);
            if (crystals[0].GetComponent<Crystal>().type == 0) 
            {
                if (dist <= 0.2f)
                {
                    potions[0].GetComponent<Potion>().SetUpTemp(1);
                    if (dist <= 0.1f)
                    {
                        potions[0].GetComponent<Potion>().SetUpTemp(2);
                    }
                }
            }
            else 
            {
                if (dist <= 0.2f)
                {
                    potions[0].GetComponent<Potion>().SetDownTemp(1);
                    if (dist <= 0.1f)
                    {
                        potions[0].GetComponent<Potion>().SetDownTemp(0);
                    }
                }
            }
            addedPotion.SetActive(false);
            added = false;
        }
        else
        {
            addedPotion.SetActive(false);
            added = false;
        }
        potions = null;
        }
        else
        {
            addedPotion.SetActive(false);
            added = false;
        }
    }
}
