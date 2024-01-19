using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;
using UnityEngine.UI;

public class ResourceAllocationOverviewUI : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private GameData gameData;
    [Header("UI Elements")]
    [SerializeField] private List<Image> growthRateImg = new List<Image>();
    [SerializeField] private List<Image> environmentalImg = new List<Image>();
    [SerializeField] private List<Image> socialImg = new List<Image>();
    [SerializeField] private List<Image> longTermImg = new List<Image>();
    [Space]
    [SerializeField] private Button nextBtn;
    private void OnEnable()
    {
        UpdateUI(ResourceType.MeetingGrowthRate);
        UpdateUI(ResourceType.EnvironmentalResponsibility);
        UpdateUI(ResourceType.SocialResponsibility);
        UpdateUI(ResourceType.LongTermDevelopment);

        nextBtn.onClick.AddListener(() => OnClickNextBtn());
    }

    private void UpdateUI(ResourceType resourceType)
    {
        switch (resourceType)
        {
            case ResourceType.MeetingGrowthRate:
                for (int i = 0; i < ResourceManagement.Instance.meetingGrowthRate; i++)
                {
                    growthRateImg[i].gameObject.SetActive(true);
                    growthRateImg[i].color = gameData.GetColorByResourceType(resourceType);
                }
                break;
            case ResourceType.EnvironmentalResponsibility:
                for (int i = 0; i < ResourceManagement.Instance.environmentalResponsibility; i++)
                {
                    environmentalImg[i].gameObject.SetActive(true);
                    environmentalImg[i].color = gameData.GetColorByResourceType(resourceType);
                }
                break;
            case ResourceType.SocialResponsibility:
                for (int i = 0; i < ResourceManagement.Instance.socialResponsibility; i++)
                {
                    socialImg[i].gameObject.SetActive(true);
                    socialImg[i].color = gameData.GetColorByResourceType(resourceType);
                }
                break;
            case ResourceType.LongTermDevelopment:
                for (int i = 0; i < ResourceManagement.Instance.longTermDevelopment; i++)
                {
                    longTermImg[i].gameObject.SetActive(true);
                    longTermImg[i].color = gameData.GetColorByResourceType(resourceType);
                }
                break;
        }
    }

    private void OnClickNextBtn()
    {
        UIManager.Instance.ShowResultUI();
    }
}
