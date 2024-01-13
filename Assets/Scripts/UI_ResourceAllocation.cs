using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_ResourceAllocation : MonoBehaviour
{
    [Header("Managers")]
    [SerializeField] private GameManager gameManager;
    [SerializeField] private ResourceManager resourceManager;
    [SerializeField] private UIManager uiManager;

    [Header("Data")]
    [SerializeField] private Data_ResourceAllocation dataResourceAllocation;

    [Header("UI Elements")]
    [SerializeField] private Image[] allocatedResourcesImg = new Image[10];
    [SerializeField] private Button nextBtn;

    [Space]
    [SerializeField] private TextMeshProUGUI growthValueText;
    [SerializeField] private TextMeshProUGUI environmentalValueText;
    [SerializeField] private TextMeshProUGUI socialValueText;
    [SerializeField] private TextMeshProUGUI longTermValueText;
    private List<ResourceType> allocatedResourcesType = new List<ResourceType>();

    [Header("GrowthRate Button")]
    [SerializeField] private Button addGrowthRateBtn;
    [SerializeField] private Button subGrowthRateBtn;

    [Header("Environmental Button")]
    [SerializeField] private Button addEnvironmentalBtn;
    [SerializeField] private Button subEnvironmentalBtn;

    [Header("Social Button")]
    [SerializeField] private Button addSocialBtn;
    [SerializeField] private Button subSocialBtn;

    [Header("Long Term Button")]
    [SerializeField] private Button addLongTermBtn;
    [SerializeField] private Button subLongTermBtn;

    private void Start()
    {
        SetNextBtnState();
        AddListeners();
    }

    private void AddListeners()
    {
        nextBtn.onClick.AddListener(() => OnClickNextBtn());

        addGrowthRateBtn.onClick.AddListener(() => AddResource(ResourceType.GrowthRate));
        subGrowthRateBtn.onClick.AddListener(() => RemoveResource(ResourceType.GrowthRate));

        addEnvironmentalBtn.onClick.AddListener(() => AddResource(ResourceType.Environmental));
        subEnvironmentalBtn.onClick.AddListener(() => RemoveResource(ResourceType.Environmental));

        addSocialBtn.onClick.AddListener(() => AddResource(ResourceType.Social));
        subSocialBtn.onClick.AddListener(() => RemoveResource(ResourceType.Social));

        addLongTermBtn.onClick.AddListener(() => AddResource(ResourceType.LongTerm));
        subLongTermBtn.onClick.AddListener(() => RemoveResource(ResourceType.LongTerm));
    }

    private void OnClickNextBtn()
    {
        uiManager.DisableUI(gameObject.name);
        uiManager.EnableUI("ResourceAllocationOverview");
    }

    private void AddResource(ResourceType resourceType)
    {
        if (resourceManager.allocatedResource >= resourceManager.totalResource)
        {
            Debug.Log("No more resource to allocate");
            return;
        }
        allocatedResourcesType.Add(resourceType);
        int lastIndex = allocatedResourcesType.Count - 1;
        allocatedResourcesImg[lastIndex].color = resourceManager.GetResourceColor(resourceType);
        resourceManager.allocatedResource++;
        switch (resourceType)
        {
            case ResourceType.GrowthRate:
                resourceManager.meetingGrowthRate++;
                growthValueText.text = resourceManager.meetingGrowthRate.ToString();
                break;
            case ResourceType.Environmental:
                resourceManager.environmentalResponsiblity++;
                environmentalValueText.text = resourceManager.environmentalResponsiblity.ToString();
                break;
            case ResourceType.Social:
                resourceManager.socialResponsibility++;
                socialValueText.text = resourceManager.socialResponsibility.ToString();
                break;
            case ResourceType.LongTerm:
                resourceManager.longTermDevelopment++;
                longTermValueText.text = resourceManager.longTermDevelopment.ToString();
                break;
        }
        
        SetNextBtnState();
        resourceManager.OnResourceValueChange?.Invoke();
    }

    private void SetNextBtnState()
    {
        if (resourceManager.allocatedResource >= resourceManager.totalResource)
        {
            nextBtn.enabled = true;
        }
        else
        {
            nextBtn.enabled = false;
        }
    }

    private void RemoveResource(ResourceType resourceType)
    {
        if (resourceManager.GetResourceCount(resourceType) <= 0)
        {
            Debug.Log("No more resource to remove");
            return;
        }
        int indexToRemove = allocatedResourcesType.IndexOf(resourceType);
        allocatedResourcesType.RemoveAt(indexToRemove);
        for (int i = indexToRemove; i < allocatedResourcesType.Count; i++)
        {
            allocatedResourcesImg[i].color = resourceManager.GetResourceColor(allocatedResourcesType[i]);
        }
        allocatedResourcesImg[allocatedResourcesType.Count].color = resourceManager.GetResourceColor(ResourceType.Normal);
        resourceManager.allocatedResource--;
        switch (resourceType)
        {
            case ResourceType.GrowthRate:
                resourceManager.meetingGrowthRate--;
                growthValueText.text = resourceManager.meetingGrowthRate.ToString();
                break;
            case ResourceType.Environmental:
                resourceManager.environmentalResponsiblity--;
                environmentalValueText.text = resourceManager.environmentalResponsiblity.ToString();
                break;
            case ResourceType.Social:
                resourceManager.socialResponsibility--;
                socialValueText.text = resourceManager.socialResponsibility.ToString();
                break;
            case ResourceType.LongTerm:
                resourceManager.longTermDevelopment--;
                longTermValueText.text = resourceManager.longTermDevelopment.ToString();
                break;
        }
        SetNextBtnState();
        resourceManager.OnResourceValueChange?.Invoke();
    }
}
