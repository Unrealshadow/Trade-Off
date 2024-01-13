using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum ResourceType
{
    GrowthRate,
    Environmental,
    Social,
    LongTerm,
    Normal
}
public class ResourceManager : MonoBehaviour
{
    public int totalResource = 10;
    public int allocatedResource = 0;
    public int meetingGrowthRate = 0;
    public int environmentalResponsiblity= 0;
    public int socialResponsibility = 0;
    public int longTermDevelopment = 0;

    public float investor = 5;
    public float stakeHolder = 5;
    [SerializeField] private Data_Color dataColor;

    public UnityAction OnResourceValueChange;
    public UnityAction OnInvestorStkValueChange;
    public void ResetResource()
    {
        allocatedResource = 0;
    }

    public string GetRemainingResource()
    {
        return (totalResource - allocatedResource).ToString();
    }

    public int GetResourceCount(ResourceType resourceType)
    {
        switch (resourceType)
        {
            case ResourceType.GrowthRate:
                return meetingGrowthRate;
            case ResourceType.Environmental:
                return environmentalResponsiblity;
            case ResourceType.Social:
                return socialResponsibility;
            case ResourceType.LongTerm:
                return longTermDevelopment;
            default:
                return 0;
        }
    }

    public Color GetResourceColor(ResourceType resourceType)
    {
        switch (resourceType)
        {
            case ResourceType.GrowthRate:
                return dataColor.meetingGrowthColor;
            case ResourceType.Environmental:
                return dataColor.environmentalResponsibilityColor;
            case ResourceType.Social:
                return dataColor.socialResponsibilityColor;
            case ResourceType.LongTerm:
                return dataColor.longTermDevelopmentColor;
            case ResourceType.Normal:
                return dataColor.notAllocatedColor;
            default:
                return Color.white;
        }
    }

    public float UpdateInvestorValue(float value)
    {
        investor += value;
        return investor;
        
    }

    public float UpdateStkValue(float value)
    {
        stakeHolder += value;
        return stakeHolder;
    }
}
