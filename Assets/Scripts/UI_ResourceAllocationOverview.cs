using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_ResourceAllocationOverview : MonoBehaviour
{
    [Header("Managers")]
    [SerializeField] private GameManager gameManager;
    [SerializeField] private ResourceManager resourceManager;
    [SerializeField] private UIManager uiManager;

    [Header("UI Elements")]
    [SerializeField] private List<Image> growthRateImg = new List<Image>();
    [SerializeField] private List<Image> environmentalImg = new List<Image>();
    [SerializeField] private List<Image> socialImg = new List<Image>();
    [SerializeField] private List<Image> longTermImg = new List<Image>();
    [Space]
    [SerializeField] private Button nextBtn;
    private void OnEnable()
    {
        UpdateUI(ResourceType.GrowthRate);
        UpdateUI(ResourceType.Environmental);
        UpdateUI(ResourceType.Social);
        UpdateUI(ResourceType.LongTerm);

        nextBtn.onClick.AddListener(() => OnClickNextBtn());
    }

    private void UpdateUI(ResourceType resourceType)
    {
        switch (resourceType)
        {
            case ResourceType.GrowthRate:
                for (int i = 0; i < resourceManager.meetingGrowthRate; i++)
                {
                    growthRateImg[i].gameObject.SetActive(true);
                    growthRateImg[i].color = resourceManager.GetResourceColor(resourceType);
                }
                break;
            case ResourceType.Environmental:
                for (int i = 0; i < resourceManager.environmentalResponsiblity; i++)
                {
                    environmentalImg[i].gameObject.SetActive(true);
                    environmentalImg[i].color = resourceManager.GetResourceColor(resourceType);
                }
                break;
            case ResourceType.Social:
                for (int i = 0; i < resourceManager.socialResponsibility; i++)
                {
                    socialImg[i].gameObject.SetActive(true);
                    socialImg[i].color = resourceManager.GetResourceColor(resourceType);
                }
                break;
            case ResourceType.LongTerm:
                for (int i = 0; i < resourceManager.longTermDevelopment; i++)
                {
                    longTermImg[i].gameObject.SetActive(true);
                    longTermImg[i].color = resourceManager.GetResourceColor(resourceType);
                }
                break;
        }
    }

    private void OnClickNextBtn()
    {
        uiManager.DisableUI(gameObject.name);
        uiManager.EnableUI("Result");
    }
}
