using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResultUI : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private GameData gameData;
    [SerializeField] private TurnData turnData;

    [Header("UI Elements")]
    [SerializeField] private Image illustration;
    [SerializeField] private TextMeshProUGUI description;
    [SerializeField] private TextMeshProUGUI investorText;
    [SerializeField] private TextMeshProUGUI stakeHolderText;
    [SerializeField] private TextMeshProUGUI resultHeaderText;
    [Space]
    [SerializeField] private Button nextBtn;

    [Space]
    [SerializeField] private TextMeshProUGUI investorValueText;
    [SerializeField] private TextMeshProUGUI stakeHolderValueText;

    [Space]
    [SerializeField] private GameObject eventHeader;
    [SerializeField] private GameObject resultHeader;

    private ResourceType currentResourceType;

    private int eventIndex = 0;
    private void OnEnable()
    {
        currentResourceType = ResourceType.MeetingGrowthRate;

        ShowMeetingGrowthRateResult(GameManager.Instance.CurrentTurn);

        SetResultHeaderTextColorAndLineColor();

        nextBtn.onClick.AddListener(() => OnNextButtonClick(currentResourceType));

    }

    private void SetResultHeaderTextColorAndLineColor()
    {
        resultHeader.transform.GetChild(0).GetComponent<Image>().color = gameData.GetColorByResourceType(currentResourceType);
        resultHeader.transform.GetChild(1).GetComponent<TextMeshProUGUI>().color = gameData.GetColorByResourceType(currentResourceType);
        resultHeader.transform.GetChild(2).GetComponent<Image>().color = gameData.GetColorByResourceType(currentResourceType);
    }

    private void OnNextButtonClick(ResourceType resourceType)
    {
        switch (resourceType)
        {
            case ResourceType.MeetingGrowthRate:
                ShowEnvironmentalResponsibilityResult(GameManager.Instance.CurrentTurn);
                currentResourceType = ResourceType.EnvironmentalResponsibility;
                SetResultHeaderTextColorAndLineColor();
                break;
            case ResourceType.EnvironmentalResponsibility:
                ShowSocialResponsiblityResult(GameManager.Instance.CurrentTurn);
                currentResourceType = ResourceType.SocialResponsibility;
                SetResultHeaderTextColorAndLineColor();
                break;
            case ResourceType.SocialResponsibility:
                ShowLongTermDevelopmentResult(GameManager.Instance.CurrentTurn);
                currentResourceType = ResourceType.LongTermDevelopment;
                SetResultHeaderTextColorAndLineColor();
                break;
            case ResourceType.LongTermDevelopment:
                if(ResourceManagement.Instance.turnEvents.Count <= 0)
                {
                    ResourceManagement.Instance.GetEventsForCurrentTurn();
                }
                if (ResourceManagement.Instance.turnEvents.Count > 0 && eventIndex < ResourceManagement.Instance.turnEvents.Count)
                {
                    resultHeader.gameObject.SetActive(false);
                    illustration.gameObject.SetActive(false);
                    eventHeader.gameObject.SetActive(true);
                    ShowEvents();
                }
                else
                {
                    UIManager.Instance.ShowPostResultUI();
                }
                break;

        }
    }

    private void ShowEvents()
    {
        if (eventIndex < ResourceManagement.Instance.turnEvents.Count)
        {
            TurnEvent currentEvent = ResourceManagement.Instance.turnEvents[eventIndex];

            description.text = currentEvent.description;

            investorValueText.text = currentEvent.investorScoreChange.ToString();
            stakeHolderValueText.text = currentEvent.stakeholderScoreChange.ToString();
            ResourceManagement.Instance.UpdateInvestorScore(currentEvent.investorScoreChange);
            ResourceManagement.Instance.UpdateStakeHolderScore(currentEvent.stakeholderScoreChange);
            ResourceManagement.Instance.OnUpdateInvestorStk?.Invoke();
            eventIndex++;
        }
        else
        {
        }
    }


    private void ShowMeetingGrowthRateResult(int currentTurn)
    {
        resultHeaderText.text = "Meeting Growth Rate";
        switch (currentTurn)
        {
            case 1:
                illustration.sprite = turnData.results[currentTurn - 1].resourceTypeDataForResults[0].illustration;
                investorText.text = turnData.results[currentTurn - 1].resourceTypeDataForResults[currentTurn - 1].investorText;
                stakeHolderText.text = turnData.results[currentTurn - 1].resourceTypeDataForResults[currentTurn - 1].stakeHolderText;

                if (ResourceManagement.Instance.meetingGrowthRate >= 6)
                {
                    description.text = turnData.results[currentTurn - 1].resourceTypeDataForResults[0].resourceDetails[0].resultDescription;
                    investorValueText.text = turnData.results[currentTurn - 1].resourceTypeDataForResults[0].resourceDetails[0].investorValueText.ToString();
                    stakeHolderValueText.text = turnData.results[currentTurn - 1].resourceTypeDataForResults[0].resourceDetails[0].stakeHolderValueText.ToString();
                    ResourceManagement.Instance.UpdateInvestorScore(turnData.results[currentTurn - 1].resourceTypeDataForResults[0].resourceDetails[0].investorValueText);
                    ResourceManagement.Instance.UpdateStakeHolderScore(turnData.results[currentTurn - 1].resourceTypeDataForResults[0].resourceDetails[0].stakeHolderValueText);
                    ResourceManagement.Instance.OnUpdateInvestorStk?.Invoke();
                }
                else if (ResourceManagement.Instance.meetingGrowthRate == 4 || ResourceManagement.Instance.meetingGrowthRate == 5)
                {
                    description.text = turnData.results[currentTurn - 1].resourceTypeDataForResults[0].resourceDetails[1].resultDescription;
                    investorValueText.text = turnData.results[currentTurn - 1].resourceTypeDataForResults[0].resourceDetails[1].investorValueText.ToString();
                    stakeHolderValueText.text = turnData.results[currentTurn - 1].resourceTypeDataForResults[0].resourceDetails[1].stakeHolderValueText.ToString();
                    ResourceManagement.Instance.UpdateInvestorScore(turnData.results[currentTurn - 1].resourceTypeDataForResults[0].resourceDetails[1].investorValueText);
                    ResourceManagement.Instance.UpdateStakeHolderScore(turnData.results[currentTurn - 1].resourceTypeDataForResults[0].resourceDetails[1].stakeHolderValueText);
                    ResourceManagement.Instance.OnUpdateInvestorStk?.Invoke();
                }
                else if (ResourceManagement.Instance.meetingGrowthRate >= 1 || ResourceManagement.Instance.meetingGrowthRate <= 3)
                {
                    description.text = turnData.results[currentTurn - 1].resourceTypeDataForResults[0].resourceDetails[2].resultDescription;
                    investorValueText.text = turnData.results[currentTurn - 1].resourceTypeDataForResults[0].resourceDetails[2].investorValueText.ToString();
                    stakeHolderValueText.text = turnData.results[currentTurn - 1].resourceTypeDataForResults[0].resourceDetails[2].stakeHolderValueText.ToString();
                    ResourceManagement.Instance.UpdateInvestorScore(turnData.results[currentTurn - 1].resourceTypeDataForResults[0].resourceDetails[2].investorValueText);
                    ResourceManagement.Instance.UpdateStakeHolderScore(turnData.results[currentTurn - 1].resourceTypeDataForResults[0].resourceDetails[2].stakeHolderValueText);
                    ResourceManagement.Instance.OnUpdateInvestorStk?.Invoke();
                }
                else if (ResourceManagement.Instance.meetingGrowthRate == 0)
                {
                    description.text = turnData.results[currentTurn - 1].resourceTypeDataForResults[0].resourceDetails[3].resultDescription;
                    investorValueText.text = turnData.results[currentTurn - 1].resourceTypeDataForResults[0].resourceDetails[3].investorValueText.ToString();
                    stakeHolderValueText.text = turnData.results[currentTurn - 1].resourceTypeDataForResults[0].resourceDetails[3].stakeHolderValueText.ToString();
                    ResourceManagement.Instance.UpdateInvestorScore(turnData.results[currentTurn - 1].resourceTypeDataForResults[0].resourceDetails[3].investorValueText);
                    ResourceManagement.Instance.UpdateStakeHolderScore(turnData.results[currentTurn - 1].resourceTypeDataForResults[0].resourceDetails[3].stakeHolderValueText);
                    ResourceManagement.Instance.OnUpdateInvestorStk?.Invoke();
                }
                break;
        }
    }

    private void ShowEnvironmentalResponsibilityResult(int currentTurn)
    {
        resultHeaderText.text = "Environmental Responsibility";
        switch (currentTurn)
        {
            case 1:
                illustration.sprite = turnData.results[currentTurn - 1].resourceTypeDataForResults[1].illustration;
                investorText.text = turnData.results[currentTurn - 1].resourceTypeDataForResults[currentTurn - 1].investorText;
                stakeHolderText.text = turnData.results[currentTurn - 1].resourceTypeDataForResults[currentTurn - 1].stakeHolderText;
                if (ResourceManagement.Instance.environmentalResponsibility >= 5)
                {
                    description.text = turnData.results[currentTurn - 1].resourceTypeDataForResults[1].resourceDetails[0].resultDescription;
                    investorValueText.text = turnData.results[currentTurn - 1].resourceTypeDataForResults[1].resourceDetails[0].investorValueText.ToString();
                    stakeHolderValueText.text = turnData.results[currentTurn - 1].resourceTypeDataForResults[1].resourceDetails[0].stakeHolderValueText.ToString();
                    ResourceManagement.Instance.UpdateInvestorScore(turnData.results[currentTurn - 1].resourceTypeDataForResults[1].resourceDetails[0].investorValueText);
                    ResourceManagement.Instance.UpdateStakeHolderScore(turnData.results[currentTurn - 1].resourceTypeDataForResults[1].resourceDetails[0].stakeHolderValueText);
                    ResourceManagement.Instance.OnUpdateInvestorStk?.Invoke();
                }
                else if (ResourceManagement.Instance.environmentalResponsibility == 3 || ResourceManagement.Instance.environmentalResponsibility == 4)
                {
                    description.text = turnData.results[currentTurn - 1].resourceTypeDataForResults[1].resourceDetails[1].resultDescription;
                    investorValueText.text = turnData.results[currentTurn - 1].resourceTypeDataForResults[1].resourceDetails[1].investorValueText.ToString();
                    stakeHolderValueText.text = turnData.results[currentTurn - 1].resourceTypeDataForResults[1].resourceDetails[1].stakeHolderValueText.ToString();
                    ResourceManagement.Instance.UpdateInvestorScore(turnData.results[currentTurn - 1].resourceTypeDataForResults[1].resourceDetails[1].investorValueText);
                    ResourceManagement.Instance.UpdateStakeHolderScore(turnData.results[currentTurn - 1].resourceTypeDataForResults[1].resourceDetails[1].stakeHolderValueText);
                    ResourceManagement.Instance.OnUpdateInvestorStk?.Invoke();
                }
                else if (ResourceManagement.Instance.environmentalResponsibility == 1 || ResourceManagement.Instance.environmentalResponsibility == 2)
                {
                    description.text = turnData.results[currentTurn - 1].resourceTypeDataForResults[1].resourceDetails[2].resultDescription;
                    investorValueText.text = turnData.results[currentTurn - 1].resourceTypeDataForResults[1].resourceDetails[2].investorValueText.ToString();
                    stakeHolderValueText.text = turnData.results[currentTurn - 1].resourceTypeDataForResults[1].resourceDetails[2].stakeHolderValueText.ToString();
                    ResourceManagement.Instance.UpdateInvestorScore(turnData.results[currentTurn - 1].resourceTypeDataForResults[1].resourceDetails[2].investorValueText);
                    ResourceManagement.Instance.UpdateStakeHolderScore(turnData.results[currentTurn - 1].resourceTypeDataForResults[1].resourceDetails[2].stakeHolderValueText);
                    ResourceManagement.Instance.OnUpdateInvestorStk?.Invoke();
                }
                else if (ResourceManagement.Instance.environmentalResponsibility == 0)
                {
                    description.text = turnData.results[currentTurn - 1].resourceTypeDataForResults[1].resourceDetails[3].resultDescription;
                    investorValueText.text = turnData.results[currentTurn - 1].resourceTypeDataForResults[1].resourceDetails[3].investorValueText.ToString();
                    stakeHolderValueText.text = turnData.results[currentTurn - 1].resourceTypeDataForResults[1].resourceDetails[3].stakeHolderValueText.ToString();
                    ResourceManagement.Instance.UpdateInvestorScore(turnData.results[currentTurn - 1].resourceTypeDataForResults[1].resourceDetails[3].investorValueText);
                    ResourceManagement.Instance.UpdateStakeHolderScore(turnData.results[currentTurn - 1].resourceTypeDataForResults[1].resourceDetails[3].stakeHolderValueText);
                    ResourceManagement.Instance.OnUpdateInvestorStk?.Invoke();
                }
                break;
        }
    }

    private void ShowSocialResponsiblityResult(int currentTurn)
    {
        resultHeaderText.text = "Social Responsibility";
        switch (currentTurn)
        {
            case 1:
                illustration.sprite = turnData.results[currentTurn - 1].resourceTypeDataForResults[2].illustration;
                investorText.text = turnData.results[currentTurn - 1].resourceTypeDataForResults[currentTurn - 1].investorText;
                stakeHolderText.text = turnData.results[currentTurn - 1].resourceTypeDataForResults[currentTurn - 1].stakeHolderText;
                if (ResourceManagement.Instance.socialResponsibility >= 5)
                {
                    description.text = turnData.results[currentTurn - 1].resourceTypeDataForResults[2].resourceDetails[0].resultDescription;
                    investorValueText.text = turnData.results[currentTurn - 1].resourceTypeDataForResults[2].resourceDetails[0].investorValueText.ToString();
                    stakeHolderValueText.text = turnData.results[currentTurn - 1].resourceTypeDataForResults[2].resourceDetails[0].stakeHolderValueText.ToString();
                    ResourceManagement.Instance.UpdateInvestorScore(turnData.results[currentTurn - 1].resourceTypeDataForResults[2].resourceDetails[0].investorValueText);
                    ResourceManagement.Instance.UpdateStakeHolderScore(turnData.results[currentTurn - 1].resourceTypeDataForResults[2].resourceDetails[0].stakeHolderValueText);
                    ResourceManagement.Instance.OnUpdateInvestorStk?.Invoke();
                }
                else if (ResourceManagement.Instance.socialResponsibility == 3 || ResourceManagement.Instance.socialResponsibility == 4)
                {
                    description.text = turnData.results[currentTurn - 1].resourceTypeDataForResults[2].resourceDetails[1].resultDescription;
                    investorValueText.text = turnData.results[currentTurn - 1].resourceTypeDataForResults[2].resourceDetails[1].investorValueText.ToString();
                    stakeHolderValueText.text = turnData.results[currentTurn - 1].resourceTypeDataForResults[2].resourceDetails[1].stakeHolderValueText.ToString();
                    ResourceManagement.Instance.UpdateInvestorScore(turnData.results[currentTurn - 1].resourceTypeDataForResults[2].resourceDetails[1].investorValueText);
                    ResourceManagement.Instance.UpdateStakeHolderScore(turnData.results[currentTurn - 1].resourceTypeDataForResults[2].resourceDetails[1].stakeHolderValueText);
                    ResourceManagement.Instance.OnUpdateInvestorStk?.Invoke();
                }
                else if (ResourceManagement.Instance.socialResponsibility == 1 || ResourceManagement.Instance.socialResponsibility == 2)
                {
                    description.text = turnData.results[currentTurn - 1].resourceTypeDataForResults[2].resourceDetails[2].resultDescription;
                    investorValueText.text = turnData.results[currentTurn - 1].resourceTypeDataForResults[2].resourceDetails[2].investorValueText.ToString();
                    stakeHolderValueText.text = turnData.results[currentTurn - 1].resourceTypeDataForResults[2].resourceDetails[2].stakeHolderValueText.ToString();
                    ResourceManagement.Instance.UpdateInvestorScore(turnData.results[currentTurn - 1].resourceTypeDataForResults[2].resourceDetails[2].investorValueText);
                    ResourceManagement.Instance.UpdateStakeHolderScore(turnData.results[currentTurn - 1].resourceTypeDataForResults[2].resourceDetails[2].stakeHolderValueText);
                    ResourceManagement.Instance.OnUpdateInvestorStk?.Invoke();

                }
                else if (ResourceManagement.Instance.socialResponsibility == 0)
                {
                    description.text = turnData.results[currentTurn - 1].resourceTypeDataForResults[2].resourceDetails[3].resultDescription;
                    investorValueText.text = turnData.results[currentTurn - 1].resourceTypeDataForResults[2].resourceDetails[3].investorValueText.ToString();
                    stakeHolderValueText.text = turnData.results[currentTurn - 1].resourceTypeDataForResults[2].resourceDetails[3].stakeHolderValueText.ToString();
                    ResourceManagement.Instance.UpdateInvestorScore(turnData.results[currentTurn - 1].resourceTypeDataForResults[2].resourceDetails[3].investorValueText);
                    ResourceManagement.Instance.UpdateStakeHolderScore(turnData.results[currentTurn - 1].resourceTypeDataForResults[2].resourceDetails[3].stakeHolderValueText);
                    ResourceManagement.Instance.OnUpdateInvestorStk?.Invoke();
                }
                break;
        }
    }

    private void ShowLongTermDevelopmentResult(int currentTurn)
    {
        resultHeaderText.text = "Long Term Development";
        switch (currentTurn)
        {
            case 1:
                illustration.sprite = turnData.results[currentTurn - 1].resourceTypeDataForResults[3].illustration;
                investorText.text = turnData.results[currentTurn - 1].resourceTypeDataForResults[currentTurn - 1].investorText;
                stakeHolderText.text = turnData.results[currentTurn - 1].resourceTypeDataForResults[currentTurn - 1].stakeHolderText;
                if (ResourceManagement.Instance.longTermDevelopment >= 5)
                {
                    description.text = turnData.results[currentTurn - 1].resourceTypeDataForResults[3].resourceDetails[0].resultDescription;
                    investorValueText.text = turnData.results[currentTurn - 1].resourceTypeDataForResults[3].resourceDetails[0].investorValueText.ToString();
                    stakeHolderValueText.text = turnData.results[currentTurn - 1].resourceTypeDataForResults[3].resourceDetails[0].stakeHolderValueText.ToString();
                    ResourceManagement.Instance.UpdateInvestorScore(turnData.results[currentTurn - 1].resourceTypeDataForResults[3].resourceDetails[0].investorValueText);
                    ResourceManagement.Instance.UpdateStakeHolderScore(turnData.results[currentTurn - 1].resourceTypeDataForResults[3].resourceDetails[0].stakeHolderValueText);
                    ResourceManagement.Instance.OnUpdateInvestorStk?.Invoke();
                }
                else if (ResourceManagement.Instance.longTermDevelopment == 3 || ResourceManagement.Instance.longTermDevelopment == 4)
                {
                    description.text = turnData.results[currentTurn - 1].resourceTypeDataForResults[3].resourceDetails[1].resultDescription;
                    investorValueText.text = turnData.results[currentTurn - 1].resourceTypeDataForResults[3].resourceDetails[1].investorValueText.ToString();
                    stakeHolderValueText.text = turnData.results[currentTurn - 1].resourceTypeDataForResults[3].resourceDetails[1].stakeHolderValueText.ToString();
                    ResourceManagement.Instance.UpdateInvestorScore(turnData.results[currentTurn - 1].resourceTypeDataForResults[3].resourceDetails[1].investorValueText);
                    ResourceManagement.Instance.UpdateStakeHolderScore(turnData.results[currentTurn - 1].resourceTypeDataForResults[3].resourceDetails[1].stakeHolderValueText);
                    ResourceManagement.Instance.OnUpdateInvestorStk?.Invoke();
                }
                else if (ResourceManagement.Instance.longTermDevelopment == 1 || ResourceManagement.Instance.longTermDevelopment == 2)
                {
                    description.text = turnData.results[currentTurn - 1].resourceTypeDataForResults[3].resourceDetails[2].resultDescription;
                    investorValueText.text = turnData.results[currentTurn - 1].resourceTypeDataForResults[3].resourceDetails[2].investorValueText.ToString();
                    stakeHolderValueText.text = turnData.results[currentTurn - 1].resourceTypeDataForResults[3].resourceDetails[2].stakeHolderValueText.ToString();
                    ResourceManagement.Instance.UpdateInvestorScore(turnData.results[currentTurn - 1].resourceTypeDataForResults[3].resourceDetails[2].investorValueText);
                    ResourceManagement.Instance.UpdateStakeHolderScore(turnData.results[currentTurn - 1].resourceTypeDataForResults[3].resourceDetails[2].stakeHolderValueText);
                    ResourceManagement.Instance.OnUpdateInvestorStk?.Invoke();

                }
                else if (ResourceManagement.Instance.longTermDevelopment == 0)
                {
                    description.text = turnData.results[currentTurn - 1].resourceTypeDataForResults[3].resourceDetails[3].resultDescription;
                    investorValueText.text = turnData.results[currentTurn - 1].resourceTypeDataForResults[3].resourceDetails[3].investorValueText.ToString();
                    stakeHolderValueText.text = turnData.results[currentTurn - 1].resourceTypeDataForResults[3].resourceDetails[3].stakeHolderValueText.ToString();
                    ResourceManagement.Instance.UpdateInvestorScore(turnData.results[currentTurn - 1].resourceTypeDataForResults[3].resourceDetails[3].investorValueText);
                    ResourceManagement.Instance.UpdateStakeHolderScore(turnData.results[currentTurn - 1].resourceTypeDataForResults[3].resourceDetails[3].stakeHolderValueText);
                    ResourceManagement.Instance.OnUpdateInvestorStk?.Invoke();

                }
                break;
        }
    }
}
