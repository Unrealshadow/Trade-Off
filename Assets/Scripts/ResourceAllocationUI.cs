using System.Collections;
using System.Collections.Generic;
using System.Resources;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResourceAllocationUI : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private GameData gameData;

    [Header("Buttons")]
    [SerializeField] private Button incrementMeetingGrowthRateButton;
    [SerializeField] private Button decrementMeetingGrowthRateButton;
    [SerializeField] private Button incrementSocialResponsibilityButton;
    [SerializeField] private Button decrementSocialResponsibilityButton;
    [SerializeField] private Button incrementEnvironmentalResponsibilityButton;
    [SerializeField] private Button decrementEnvironmentalResponsibilityButton;
    [SerializeField] private Button incrementLongTermDevelopmentButton;
    [SerializeField] private Button decrementLongTermDevelopmentButton;
    [SerializeField] private Button iAmDoneBtn;
    [Header("Text")]
    [SerializeField] private TextMeshProUGUI meetingGrowthRateText;
    [SerializeField] private TextMeshProUGUI socialResponsibilityText;
    [SerializeField] private TextMeshProUGUI environmentalResponsibilityText;
    [SerializeField] private TextMeshProUGUI longTermDevelopmentText;

    [Header("Diamonds")]
    [SerializeField] private Image[] allocatedResourcesImg;

    private List<ResourceType> allocatedResourcesType = new List<ResourceType>();

    private void OnEnable()
    {
        incrementEnvironmentalResponsibilityButton.onClick.AddListener(() => IncrementResourceValue(ResourceType.EnvironmentalResponsibility));
        decrementEnvironmentalResponsibilityButton.onClick.AddListener(() => DecrementResourceValue(ResourceType.EnvironmentalResponsibility));
        incrementMeetingGrowthRateButton.onClick.AddListener(() => IncrementResourceValue(ResourceType.MeetingGrowthRate));
        decrementMeetingGrowthRateButton.onClick.AddListener(() => DecrementResourceValue(ResourceType.MeetingGrowthRate));
        incrementSocialResponsibilityButton.onClick.AddListener(() => IncrementResourceValue(ResourceType.SocialResponsibility));
        decrementSocialResponsibilityButton.onClick.AddListener(() => DecrementResourceValue(ResourceType.SocialResponsibility));
        incrementLongTermDevelopmentButton.onClick.AddListener(() => IncrementResourceValue(ResourceType.LongTermDevelopment));
        decrementLongTermDevelopmentButton.onClick.AddListener(() => DecrementResourceValue(ResourceType.LongTermDevelopment));
        iAmDoneBtn.onClick.AddListener(OnPressIAmDoneBtn);

        SetIAmDoneBtnState();
    }

    private void OnDisable()
    {
        incrementEnvironmentalResponsibilityButton.onClick.RemoveAllListeners();
        decrementEnvironmentalResponsibilityButton.onClick.RemoveAllListeners();
        incrementMeetingGrowthRateButton.onClick.RemoveAllListeners();
        decrementMeetingGrowthRateButton.onClick.RemoveAllListeners();
        incrementSocialResponsibilityButton.onClick.RemoveAllListeners();
        decrementSocialResponsibilityButton.onClick.RemoveAllListeners();
        incrementLongTermDevelopmentButton.onClick.RemoveAllListeners();
        decrementLongTermDevelopmentButton.onClick.RemoveAllListeners();
        iAmDoneBtn.onClick.RemoveAllListeners();
    }

    private void SetIAmDoneBtnState()
    {
        if (ResourceManagement.Instance.currentResources >= ResourceManagement.Instance.GetTotalResources())
        {
            iAmDoneBtn.enabled = true;
        }
        else
        {
            iAmDoneBtn.enabled = false;
        }
    }

    private void OnPressIAmDoneBtn()
    {
        UIManager.Instance.ShowResourceAllocationOverviewUI();
    }

    private void IncrementResourceValue(ResourceType resourceType)
    {
        if (ResourceManagement.Instance.currentResources >= ResourceManagement.Instance.GetTotalResources())
        {
            return;
        }
       
        allocatedResourcesType.Add(resourceType);
        int lastIndex = allocatedResourcesType.Count - 1;
        allocatedResourcesImg[lastIndex].color = gameData.GetColorByResourceType(resourceType);
        UpdateResourceValue(resourceType, 1);
        SetIAmDoneBtnState();
    }

    private void DecrementResourceValue(ResourceType resourceType)
    {
        if (ResourceManagement.Instance.currentResources <= 0)
        {
            return;
        }
        int indexToRemove = allocatedResourcesType.IndexOf(resourceType);
        allocatedResourcesType.RemoveAt(indexToRemove);
        for (int i = indexToRemove; i < allocatedResourcesType.Count; i++)
        {
            allocatedResourcesImg[i].color = gameData.GetColorByResourceType(allocatedResourcesType[i]);
        }
        allocatedResourcesImg[allocatedResourcesType.Count].color = gameData.GetColorByResourceType(ResourceType.None);
        UpdateResourceValue(resourceType, -1);
        SetIAmDoneBtnState();

    }

    private void UpdateResourceValue(ResourceType resourceType, int change)
    {
        // Update the corresponding resource value
        switch (resourceType)
        {
            case ResourceType.MeetingGrowthRate:
                UpdateResourceTextAndValue(meetingGrowthRateText, ref ResourceManagement.Instance.meetingGrowthRate, change);
                break;
            case ResourceType.SocialResponsibility:
                UpdateResourceTextAndValue(socialResponsibilityText, ref ResourceManagement.Instance.socialResponsibility, change);
                break;
            case ResourceType.EnvironmentalResponsibility:
                UpdateResourceTextAndValue(environmentalResponsibilityText, ref ResourceManagement.Instance.environmentalResponsibility, change);
                break;
            case ResourceType.LongTermDevelopment:
                UpdateResourceTextAndValue(longTermDevelopmentText, ref ResourceManagement.Instance.longTermDevelopment, change);
                break;

        }

        // Update the overall current resources
        ResourceManagement.Instance.currentResources += change;
        ResourceManagement.Instance.OnResourceChange?.Invoke(ResourceManagement.Instance.GetRemainingResources());
    }

    private void UpdateResourceTextAndValue(TextMeshProUGUI textElement, ref int resourceValue, int change)
    {
        resourceValue = Mathf.Clamp(resourceValue + change, 0, ResourceManagement.Instance.GetTotalResources());
        textElement.text = resourceValue.ToString();
    }

}