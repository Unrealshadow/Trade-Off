using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResourceAllocationUICtrl : MonoBehaviour
{
    public Transform resourceAllocationContainer;
    public ResourceData resourceData; // Reference to your ResourceData scriptable object
    public HUDData hudData;
    [Space(10)]
    public Image[] resourceDiamonds = new Image[10]; // Assuming you have an array of Image components for the diamonds
    [SerializeField] private List<ResourceType> resourceOrder = new List<ResourceType>();

    public Color originalColor;

    [Space(10)]
    public Button growthRateAddButton;
    public Button growthRateSubtractButton;
    public TextMeshProUGUI growthRateText;

    [Space(10)]
    public Button environmentalAddButton;
    public Button environmentalSubtractButton;
    public TextMeshProUGUI environmentalText;

    [Space(10)]
    public Button socialAddButton;
    public Button socialSubtractButton;
    public TextMeshProUGUI socialText;

    [Space(10)]
    public Button longTermAddButton;
    public Button longTermSubtractButton;
    public TextMeshProUGUI longTermText;

    [Space(10)]
    public Button submitButton;
    private void Start()
    {
        resourceData.ResetResourceData();

        if (resourceDiamonds == null || resourceDiamonds.Length == 0)
        {
            Debug.LogError("Resource Diamonds are not assigned or empty.");
            return;
        }

        AddButtonListeners(growthRateAddButton, null, ResourceType.GrowthRate);
        AddButtonListeners(null, growthRateSubtractButton, ResourceType.GrowthRate);

        AddButtonListeners(environmentalAddButton, null, ResourceType.EnvironmentalResponsibility);
        AddButtonListeners(null, environmentalSubtractButton, ResourceType.EnvironmentalResponsibility);

        AddButtonListeners(socialAddButton, null, ResourceType.SocialResponsibility);
        AddButtonListeners(null, socialSubtractButton, ResourceType.SocialResponsibility);

        AddButtonListeners(longTermAddButton, null, ResourceType.LongTermDevelopment);
        AddButtonListeners(null, longTermSubtractButton, ResourceType.LongTermDevelopment);

        submitButton.onClick.AddListener(() => Submit());
        submitButton.interactable = false;
    }

    private void Update()
    {
        if (resourceData.usedResources >= 10)
        {
            submitButton.interactable = true;
        }
        else
        {
            submitButton.interactable = false;
        }
    }

    private void Submit()
    {
        if (resourceData.usedResources >= 10)
        {
            UIManager.instance.DisableSpecificUI("ResourceAllocation");
            UIManager.instance.EnableSpecificUI("ResourceAllocationOverview");
        }
    }


    private void AddButtonListeners(Button addButton, Button subtractButton, ResourceType type)
    {
        if (addButton != null)
        {
            addButton.onClick.AddListener(() => ModifyResource(type, 1));
        }

        if (subtractButton != null)
        {
            subtractButton.onClick.AddListener(() => ModifyResource(type, -1));
        }
    }

    private void ModifyResource(ResourceType type, int amount)
    {
        if ((amount == 1 && resourceData.CanAddResource()))
        {
            if (resourceData.usedResources >= 10)
            {
                return;
            }
            int changeAmount = amount;

            if (amount < 0 && resourceData.GetResourceValue(type) == 0)
            {
                // Prevent subtracting when there are no resources of that type
                return;
            }

            resourceData.ModifyResource(type, changeAmount);
            UpdateUI(type, changeAmount);
        }
        else if ((amount == -1 && resourceData.CanRemoveResource()))
        {
            int changeAmount = amount;

            if (amount < 0 && resourceData.GetResourceValue(type) == 0)
            {
                // Prevent subtracting when there are no resources of that type
                return;
            }

            resourceData.ModifyResource(type, changeAmount);
            UpdateUI(type, changeAmount);
        }
    }

    private void UpdateUI(ResourceType type, int changeAmount)
    {
        if (resourceData.CanAddResource() && changeAmount == 1)
        {
            if (resourceData)
                resourceOrder.Add(type);
            int lastIndex = resourceOrder.Count - 1;
            resourceDiamonds[lastIndex].color = resourceData.GetResourceColor(type);
            UpdateText(type, lastIndex);
            hudData.UpdateHudResource?.Invoke();
        }
        else if ((resourceData.CanRemoveResource() || resourceData.usedResources == 0) && changeAmount == -1)
        {
            int indexToRemove = resourceOrder.IndexOf(type);
            resourceOrder.RemoveAt(indexToRemove);
            for (int i = indexToRemove; i < resourceOrder.Count; i++)
            {
                resourceDiamonds[i].color = resourceData.GetResourceColor(resourceOrder[i]);
                UpdateText(resourceOrder[i], i);
            }
            resourceDiamonds[resourceOrder.Count].color = originalColor;
            UpdateText(type, resourceOrder.Count);
            hudData.UpdateHudResource?.Invoke();

        }
    }


    private void UpdateText(ResourceType type, int index)
    {
        switch (type)
        {
            case ResourceType.GrowthRate:
                growthRateText.text = resourceData.GetResourceValue(type).ToString();
                break;

            case ResourceType.EnvironmentalResponsibility:
                environmentalText.text = resourceData.GetResourceValue(type).ToString();
                break;

            case ResourceType.SocialResponsibility:
                socialText.text = resourceData.GetResourceValue(type).ToString();
                break;

            case ResourceType.LongTermDevelopment:
                longTermText.text = resourceData.GetResourceValue(type).ToString();
                break;
            default:
                break;
        }
    }
}
