using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public List<GameObject> uiList = new List<GameObject>();
    public Dictionary<string, GameObject> uiDictionary = new Dictionary<string, GameObject>();

    private void Awake()
    {
        instance = this;
        AddUI();
        EnableSpecificUI("MainMenu");
    }

    public void AddUI()
    {
        foreach (GameObject ui in uiList)
        {
            uiDictionary[ui.name] = ui;
        }
    }

    public void EnableSpecificUI(string UIName)
    {
        foreach (KeyValuePair<string, GameObject> entry in uiDictionary)
        {
            if (entry.Key == UIName)
            {
                entry.Value.SetActive(true);
                break;
            }
        }
    }

    public void DisableSpecificUI(string UIName)
    {
        foreach (KeyValuePair<string, GameObject> entry in uiDictionary)
        {
            if (entry.Key == UIName)
            {
                entry.Value.SetActive(false);
                break;
            }
        }
    }

}
