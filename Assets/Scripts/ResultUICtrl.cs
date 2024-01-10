using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResultUICtrl : MonoBehaviour
{
    public int resultIndex = 0;
    [Header("UI Elements")]
    public TextMeshProUGUI investorText;
    public TextMeshProUGUI stakeholdersText;
    public TextMeshProUGUI investorValue;
    public TextMeshProUGUI stakeholdersValue;
    [Space]
    public Image headerIllustration;
    public Color headerColor;
    public TextMeshProUGUI headerText;
    public TextMeshProUGUI descriptionText;
    public List<Image> lines;

    public Button nextButton;

    [Header("Data Holder")]
    public ResultData resultData;
    public ResourceData resourceData;
    public HUDData hudData;
    public EventData eventData;

    private void OnEnable()
    {
        resultData.UpdateUI += UpdateUI;
    }

    private void UpdateUI()
    {
        investorText.text = resultData.investorText;
        stakeholdersText.text = resultData.stakeholdersText;
        investorValue.text = resultData.investorValue;
        stakeholdersValue.text = resultData.stakeholdersValue;

        hudData.UpdateInvestorValue(float.Parse(resultData.investorValue));
        hudData.UpdateStakeHolderValue(float.Parse(resultData.stakeholdersValue));
    }


    private void Start()
    {

        resultData.SetResultsBasedOnGrowthSelection();
        headerText.text = resultData.meetingGrowthTargetHeader;
        headerColor = resultData.meetingGrowthTargetColor;
        headerIllustration.sprite = resultData.meetingGrowthTargetSprite;
        descriptionText.text = resultData.meetingGrowthTargetDesc;
        headerText.color = headerColor;

        investorText.color = headerColor;
        stakeholdersText.color = headerColor;
        investorValue.color = headerColor;
        stakeholdersValue.color = headerColor;
        foreach (var line in lines)
        {
            line.color = headerColor;
        }

        UpdateUI();
        nextButton.onClick.AddListener(ShowNextResult);

        if(resourceData.socialResponsibility == 1 || resourceData.socialResponsibility == 2)
        {
            eventData.showHowManyEvents = 1;
        }

        if(resourceData.longTermDevelopment >= 3)
        {
            eventData.showHowManyEvents = 2;
        }
    }

    private void ShowNextResult()
    {
        resultIndex++;

        if (resultIndex == 1)
        {
            resultData.SetResultsBasedOnEnvironmentalResponsibility();
            headerText.text = resultData.meetingEnvironmentalResponsibilityHeader;
            headerColor = resultData.meetingEnvironmentalResponsibilityColor;
            headerIllustration.sprite = resultData.meetingEnvironmentalResponsibilitySprite;
            descriptionText.text = resultData.meetingEnvironmentalResponsibilityDesc;

            headerText.color = headerColor;

            investorText.color = headerColor;
            stakeholdersText.color = headerColor;
            investorValue.color = headerColor;
            stakeholdersValue.color = headerColor;
            foreach (var line in lines)
            {
                line.color = headerColor;
            }
            UpdateUI();

        }
        else if (resultIndex == 2)
        {
            resultData.SetResultsBasedOnSocialResponsibility();
            headerText.text = resultData.meetingSocialResponsibilityHeader;
            headerColor = resultData.meetingSocialResponsibilityColor;
            headerIllustration.sprite = resultData.meetingSocialResponsibilitySprite;
            descriptionText.text = resultData.meetingSocialResponsibilityDesc;
            headerText.color = headerColor;

            investorText.color = headerColor;
            stakeholdersText.color = headerColor;
            investorValue.color = headerColor;
            stakeholdersValue.color = headerColor;
            foreach (var line in lines)
            {
                line.color = headerColor;
            }
            UpdateUI();

        }
        else if (resultIndex == 3)
        {
            resultData.SetResultsBasedOnLongTermDevelopment();
            headerText.text = resultData.meetingLongTermDevelopmentHeader;
            headerColor = resultData.meetingLongTermDevelopmentColor;
            headerIllustration.sprite = resultData.meetingLongTermDevelopmentSprite;
            descriptionText.text = resultData.meetingLongTermDevelopmentDesc;
            headerText.color = headerColor;

            investorText.color = headerColor;
            stakeholdersText.color = headerColor;
            investorValue.color = headerColor;
            stakeholdersValue.color = headerColor;
            foreach (var line in lines)
            {
                line.color = headerColor;
            }
            UpdateUI();
            
        }else if(resultIndex == 4)
        {
            
                UIManager.instance.DisableSpecificUI("Result");
                UIManager.instance.EnableSpecificUI("Event");
        }

    }
}
