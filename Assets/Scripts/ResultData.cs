using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "ResultData", menuName = "Trade-Off/ResultData", order = 1)]
public class ResultData : ScriptableObject
{
    public ResourceData resourceData;

    [Header("Meeting Growth Target")]
    public Sprite meetingGrowthTargetSprite;
    public string meetingGrowthTargetHeader;
    public Color meetingGrowthTargetColor;
    public string meetingGrowthTargetDesc;

    [Header("Meeting Environmental Responsibility")]
    public Sprite meetingEnvironmentalResponsibilitySprite;
    public string meetingEnvironmentalResponsibilityHeader;
    public Color meetingEnvironmentalResponsibilityColor;
    public string meetingEnvironmentalResponsibilityDesc;

    [Header("Meeting Social Responsibility")]
    public Sprite meetingSocialResponsibilitySprite;
    public string meetingSocialResponsibilityHeader;
    public Color meetingSocialResponsibilityColor;
    public string meetingSocialResponsibilityDesc;

    [Header("Meeting Long Term Development")]
    public Sprite meetingLongTermDevelopmentSprite;
    public string meetingLongTermDevelopmentHeader;
    public Color meetingLongTermDevelopmentColor;
    public string meetingLongTermDevelopmentDesc;

    [Header("Result_1")]
    public string investorText;
    public string stakeholdersText;
    public string investorValue;
    public string stakeholdersValue;


    public UnityAction UpdateUI;

    #region Result_1
    public void SetResultsBasedOnGrowthSelection()
    {
        float investorScore = 0;
        float stkScore = 0;
        if (resourceData.growthRate >= 6)
        {
            meetingGrowthTargetDesc = "You burned through the IPO cash to expand as quickly as possible. Your rapid growth makes headlines and impresses your shareholders.";
            investorScore = 1;
            stkScore = -0.5f;
        }
        else if (resourceData.growthRate == 4 || resourceData.growthRate == 5)
        {
            meetingGrowthTargetDesc = "You knew your team could deliver and they did. FlexBird's share price growth delights your early investors.";
            investorScore = 1;
            stkScore = 0;
        }
        else if (resourceData.growthRate <= 3 && resourceData.growthRate >= 1)
        {
            meetingGrowthTargetDesc = "You missed analysts' expectations, but the cash you raised in the IPO gives you some buffer against a falling share price.";
            investorScore = -1;
            stkScore = 0;
        }
        else if (resourceData.growthRate == 0)
        {
            meetingGrowthTargetDesc = "You came nowhere near to meeting analysts' expectations. It is not a great start to life as a public company.";
            investorScore = -1;
            stkScore = 0;
        }

        investorValue = ( investorScore).ToString();
        stakeholdersValue = (stkScore).ToString();
    }

    public void SetResultsBasedOnEnvironmentalResponsibility()
    {
        float investorScore = 0;
        float stkScore = 0;

        if (resourceData.environmentalResponsibility >= 5)
        {
            meetingEnvironmentalResponsibilityDesc = "You intend to put your money where your mouth is: you pledge to change your entire business model to become more environmentally friendly, and set aggressive targets that will be externally audited.";
            investorScore = -1;
            stkScore = 1;
        }
        else if (resourceData.environmentalResponsibility == 4 || resourceData.environmentalResponsibility == 3)
        {
            meetingEnvironmentalResponsibilityDesc = "You divert FlexBird's lobbying money into calls for climate change regulation, even when the new rules could damage FlexBird's core business. You also set sustainability targets that will be vetted by an external auditor.";
            investorScore = 0;
            stkScore = 0.5f;
        }
        else if (resourceData.environmentalResponsibility == 2 || resourceData.environmentalResponsibility == 1)
        {
            meetingEnvironmentalResponsibilityDesc = "You tout FlexBird's new 'sustainability performance targets', but draw the line at getting them vetted by an external auditor because you don't want to be burdened by more compliance work.";
            investorScore = -0.5f;
            stkScore = 0;
        }
        else if (resourceData.environmentalResponsibility == 0)
        {
            meetingEnvironmentalResponsibilityDesc = "Your complete disregard of environmental issues has caught the attention of a few green groups, though they have done little so far.";
            investorScore = -1;
            stkScore = 0;
        }

        investorValue = (investorScore).ToString();
        stakeholdersValue = (stkScore).ToString();
    }

    public void SetResultsBasedOnSocialResponsibility()
    {
        float investorScore = 0;
        float stkScore = 0;

        if (resourceData.socialResponsibility >= 5)
        {
            meetingSocialResponsibilityDesc = "You don't just offer above-average wages and benefits, you actually hand a portion of your shares over to your employees.";
            investorScore = -0.5f;
            stkScore = 1;
        }
        else if (resourceData.socialResponsibility == 4 || resourceData.socialResponsibility == 3)
        {
            meetingSocialResponsibilityDesc = "FlexBird starts paying above the minimum wage and uses cash raised in the IPO to close the gender pay gap.";
            investorScore = 0.5f;
            stkScore = 0;
        }
        else if (resourceData.socialResponsibility == 2 || resourceData.socialResponsibility == 1)
        {
            meetingSocialResponsibilityDesc = "You make sure FlexBird sponsors a few charity events to show that the company cares about social issues.";
            investorScore = 0;
            stkScore = 0.5f;
        }
        else if (resourceData.socialResponsibility == 0)
        {
            meetingSocialResponsibilityDesc = "You don't really care how your employees act as long as they hit targets. Sure, there are some negative Glassdoor reviews, but those are just disgruntled ex-employees.";
            investorScore = -1;
            stkScore = 0;
        }

        investorValue = (investorScore).ToString();
        stakeholdersValue = (stkScore).ToString();
    }

    public void SetResultsBasedOnLongTermDevelopment()
    {
        float investorScore = 0;
        float stkScore = 0;

        if (resourceData.longTermDevelopment >= 5)
        {
            meetingLongTermDevelopmentDesc = "You announce plans to invest a substantial portion of revenue in a new R&D hub, hiring scientists and innovators and giving them the time, space and money to develop bright ideas for the long term.";
            investorScore = 1;
            stkScore = 0;
        }
        else if (resourceData.longTermDevelopment == 4 || resourceData.longTermDevelopment == 3)
        {
            meetingLongTermDevelopmentDesc = "You ramp up in-house innovation projects, based on strict criteria for profitability and feasibility.";
            investorScore = 1;
            stkScore = 0;
        }
        else if (resourceData.longTermDevelopment == 2 || resourceData.longTermDevelopment == 1)
        {
            meetingLongTermDevelopmentDesc = "You devote some money to funding innovative start-ups, figuring you can always buy them out if they develop a promising product.";
            investorScore = 0.5f;
            stkScore = 0;
        }
        else if (resourceData.longTermDevelopment == 0)
        {
            meetingLongTermDevelopmentDesc = "FlexBird is relentlessly focused on the short-term: you announce that any initiatives that do not generate returns within a year will be discontinued.";
            investorScore = 0;
            stkScore = 0;
        }

        investorValue = (investorScore).ToString();
        stakeholdersValue = (stkScore).ToString();
    }
    #endregion
}
