using UnityEngine;
using System.Collections.Generic;
public class UIManager : MonoBehaviour
{
    private readonly Dictionary<string, GameObject> uiElements = new Dictionary<string, GameObject>();
    [SerializeField] private List<GameObject> uiElementsList = new List<GameObject>();

    // Register UI elements
    private void Awake()
    {
        foreach (GameObject uiElement in uiElementsList)
        {
            uiElements.Add(uiElement.name, uiElement);
        }
    }
    // Enable UI based on the UI name
    public void EnableUI(string uiName)
    {
        if (uiElements.TryGetValue(uiName, out GameObject uiElement))
        {
            uiElement.SetActive(true);
            Debug.Log($"UI '{uiName}' enabled.");
        }
        else
        {
            Debug.LogWarning($"UI '{uiName}' not found.");
        }
    }

    // Disable UI based on the UI name
    public void DisableUI(string uiName)
    {
        if (uiElements.TryGetValue(uiName, out GameObject uiElement))
        {
            uiElement.SetActive(false);
            Debug.Log($"UI '{uiName}' disabled.");
        }
        else
        {
            Debug.LogWarning($"UI '{uiName}' not found.");
        }
    }
}
