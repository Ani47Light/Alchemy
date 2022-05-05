using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;


public class ObjectManag : MonoBehaviour
{
    public ARTrackedImageManager ImageManager;
    public XRReferenceImageLibrary ImageLibrary;

    public int[] newType = {11,11};
    public GameObject Potion;
    public GameObject CrystalHot;
    public GameObject CrystalCold;
    GameObject ActivePotion1;
    GameObject ActivePotion2;
    GameObject ActivePotion3;
    GameObject ActivePotion4;
    GameObject ActivePotion5;
    GameObject ActivePotion6;
    GameObject Crystal1;
    GameObject Crystal2;

    static Guid Image1;
    static Guid Image2;
    static Guid Image3;
    static Guid Image4;
    static Guid Image5;
    static Guid Image6;
    static Guid Image7;
    static Guid Image8;

    void OnEnable()
    {
        Image1 = ImageLibrary[0].guid;
        Image2 = ImageLibrary[1].guid;
        Image3 = ImageLibrary[2].guid;
        Image4 = ImageLibrary[3].guid;
        Image5 = ImageLibrary[4].guid;
        Image6 = ImageLibrary[5].guid;
        Image7 = ImageLibrary[6].guid;
        Image8 = ImageLibrary[7].guid;
        
        ImageManager.trackedImagesChanged += ImageManagerOnTrackedImagesChanged;
    }

    void OnDisable()
    {
        ImageManager.trackedImagesChanged -= ImageManagerOnTrackedImagesChanged;
    }

    void ImageManagerOnTrackedImagesChanged(ARTrackedImagesChangedEventArgs obj)
    {
        // added, spawn prefab
        foreach(ARTrackedImage image in obj.added)
        {
            if (image.referenceImage.guid == Image1)
            {
                ActivePotion1 = Instantiate(Potion, image.transform.position, image.transform.rotation);
                ActivePotion1.GetComponent<Potion>().SetType(0);
            }
            else if (image.referenceImage.guid == Image2)
            {
                ActivePotion2 = Instantiate(Potion, image.transform.position, image.transform.rotation);
                ActivePotion2.GetComponent<Potion>().SetType(1);
            }
            else if (image.referenceImage.guid == Image3)
            {
                ActivePotion3 = Instantiate(Potion, image.transform.position, image.transform.rotation);
                ActivePotion3.GetComponent<Potion>().SetType(2);
            }
            else if (image.referenceImage.guid == Image4)
            {
                ActivePotion4 = Instantiate(Potion, image.transform.position, image.transform.rotation);
                ActivePotion4.GetComponent<Potion>().SetType(3);
            }
            else if (image.referenceImage.guid == Image5)
            {
                ActivePotion5 = Instantiate(Potion, image.transform.position, image.transform.rotation);
                Transform[] allChildren = ActivePotion5.GetComponentsInChildren<Transform>();
                    foreach (Transform child in allChildren)
                    {
                        if (child.gameObject.tag == "Child")
                        {
                            child.gameObject.SetActive(false);
                        }
                    }
                ActivePotion5.GetComponent<Potion>().SetType(newType[0]);
            }
            else if (image.referenceImage.guid == Image6)
            {
                ActivePotion6 = Instantiate(Potion, image.transform.position, image.transform.rotation);
                Transform[] allChildren = ActivePotion6.GetComponentsInChildren<Transform>();
                    foreach (Transform child in allChildren)
                    {
                        if (child.gameObject.tag == "Child")
                        {
                            child.gameObject.SetActive(false);
                        }
                    }
                ActivePotion6.GetComponent<Potion>().SetType(newType[1]);
            }
            else if (image.referenceImage.guid == Image7)
            {
                Crystal1 = Instantiate(CrystalHot, image.transform.position, image.transform.rotation);
            }
            else if (image.referenceImage.guid == Image8)
            {
                Crystal2 = Instantiate(CrystalCold, image.transform.position, image.transform.rotation);
            }
        }
        
        // updated, set prefab position and rotation
        foreach(ARTrackedImage image in obj.updated)
        {
            // image is tracking or tracking with limited state, show visuals and update it's position and rotation
            if (image.trackingState == TrackingState.Tracking)
            {
                if (image.referenceImage.guid == Image1)
                {
                    ActivePotion1.SetActive(true);
                    ActivePotion1.transform.SetPositionAndRotation(image.transform.position, image.transform.rotation);
                }
                else if (image.referenceImage.guid == Image2)
                {
                    ActivePotion2.SetActive(true);
                    ActivePotion2.transform.SetPositionAndRotation(image.transform.position, image.transform.rotation);
                }
                else if (image.referenceImage.guid == Image3)
                {
                    ActivePotion3.SetActive(true);
                    ActivePotion3.transform.SetPositionAndRotation(image.transform.position, image.transform.rotation);
                }
                else if (image.referenceImage.guid == Image4)
                {
                    ActivePotion4.SetActive(true);
                    ActivePotion4.transform.SetPositionAndRotation(image.transform.position, image.transform.rotation);
                }
                else if (image.referenceImage.guid == Image5)
                {
                    ActivePotion5.SetActive(true);
                    Transform[] allChildren = ActivePotion5.GetComponentsInChildren<Transform>();
                    foreach (Transform child in allChildren)
                    {
                        if (child.gameObject.tag == "Child")
                        {
                            child.gameObject.SetActive(false);
                        }
                    }
                    ActivePotion5.GetComponent<Potion>().SetType(newType[0]);
                    ActivePotion5.transform.SetPositionAndRotation(image.transform.position, image.transform.rotation);
                }
                else if (image.referenceImage.guid == Image6)
                {
                    ActivePotion6.SetActive(true);
                    Transform[] allChildren = ActivePotion6.GetComponentsInChildren<Transform>();
                    foreach (Transform child in allChildren)
                    {
                        if (child.gameObject.tag == "Child")
                        {
                            child.gameObject.SetActive(false);
                        }
                    }
                    ActivePotion6.GetComponent<Potion>().SetType(newType[1]);
                    ActivePotion6.transform.SetPositionAndRotation(image.transform.position, image.transform.rotation);
                }
                else if (image.referenceImage.guid == Image7)
                {
                    Crystal1.SetActive(true);
                    Crystal1.transform.SetPositionAndRotation(image.transform.position, image.transform.rotation);
                }
                else if (image.referenceImage.guid == Image8)
                {
                    Crystal2.SetActive(true);
                    Crystal2.transform.SetPositionAndRotation(image.transform.position, image.transform.rotation);
                }
            }
            else
            {
                if (image.referenceImage.guid == Image1)
                {
                    ActivePotion1.SetActive(false);
                }
                else if (image.referenceImage.guid == Image2)
                {
                    ActivePotion2.SetActive(false);
                }
                else if (image.referenceImage.guid == Image3)
                {
                    ActivePotion3.SetActive(false);
                }
                else if (image.referenceImage.guid == Image4)
                {
                    ActivePotion4.SetActive(false);
                }
                else if (image.referenceImage.guid == Image5)
                {
                    ActivePotion5.SetActive(false);
                }
                else if (image.referenceImage.guid == Image6)
                {
                    ActivePotion6.SetActive(false);
                }
                else if (image.referenceImage.guid == Image7)
                {
                    Crystal1.SetActive(false);
                }
                else if (image.referenceImage.guid == Image8)
                {
                    Crystal2.SetActive(false);
                }
            }
        }
        
        // removed, destroy spawned instance
        foreach(ARTrackedImage image in obj.removed)
        {
            if (image.referenceImage.guid == Image1)
            {
                Destroy(ActivePotion1);
            }
            else if (image.referenceImage.guid == Image2)
            {
                Destroy(ActivePotion2);
            }
            else if (image.referenceImage.guid == Image3)
            {
                Destroy(ActivePotion3);
            }
            else if (image.referenceImage.guid == Image4)
            {
                Destroy(ActivePotion4);
            }
            else if (image.referenceImage.guid == Image5)
            {
                Destroy(ActivePotion5);
            }
            else if (image.referenceImage.guid == Image6)
            {
                Destroy(ActivePotion6);
            }
            else if (image.referenceImage.guid == Image7)
            {
                Destroy(Crystal1);
            }
            else if (image.referenceImage.guid == Image8)
            {
                Destroy(Crystal2);
            }
        }
    }

    public int NumberOfTrackedImages()
    {
        int m_NumberOfTrackedImages = 0;
        foreach (ARTrackedImage image in ImageManager.trackables)
        {
            if (image.trackingState == TrackingState.Tracking)
            {
                m_NumberOfTrackedImages++;
            }
        }
        return m_NumberOfTrackedImages;
    }

}

