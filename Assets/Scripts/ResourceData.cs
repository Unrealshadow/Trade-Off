using UnityEngine;

[CreateAssetMenu(fileName = "ResourceData", menuName = "Trade-Off/ResourceData", order = 1)]
public class ResourceData : ScriptableObject
{
    public int turn = 1;
    public HUDData hudData;
    
    public int NUM_RESOURCES = 10;
    public int usedResources = 0;

    [Header("Resource Data")]
    public int growthRate = 0;
    public int environmentalResponsibility = 0;
    public int socialResponsibility = 0;
    public int longTermDevelopment = 0;

    [Header("Colors")]
    public Color growthRateColor;
    public Color environmentalResponsibilityColor;
    public Color socialResponsibilityColor;
    public Color longTermDevelopmentColor;

    public bool CanAddResource()
    {
        return usedResources <= NUM_RESOURCES ;
    }
    public bool CanRemoveResource()
    {
        return usedResources > 0;
    }

    public void ResetResourceData()
    {
        growthRate = 0;
        environmentalResponsibility = 0;
        socialResponsibility = 0;
        longTermDevelopment = 0;
        usedResources = 0;
    }

    // Additional methods for getting resource values
    public int GetResourceValue(ResourceType type)
    {
        switch (type)
        {
            case ResourceType.GrowthRate:
                return growthRate;
            case ResourceType.EnvironmentalResponsibility:
                return environmentalResponsibility;
            case ResourceType.SocialResponsibility:
                return socialResponsibility;
            case ResourceType.LongTermDevelopment:
                return longTermDevelopment;
            default:
                return 0;
        }
    }

    // Additional methods for modifying resource values directly
    public void ModifyResource(ResourceType type, int amount)
    {
        switch (type)
        {
            case ResourceType.GrowthRate:
                growthRate += amount;
                break;
            case ResourceType.EnvironmentalResponsibility:
                environmentalResponsibility += amount;
                break;
            case ResourceType.SocialResponsibility:
                socialResponsibility += amount;
                break;
            case ResourceType.LongTermDevelopment:
                longTermDevelopment += amount;
                break;
        }
        
        if (amount == 1)
        {
            usedResources++;
        }
        else if (amount == -1)
        {
            usedResources--;
        }
    }

    // Method for getting resource color
    public Color GetResourceColor(ResourceType type)
    {
        switch (type)
        {
            case ResourceType.GrowthRate:
                return growthRateColor;
            case ResourceType.EnvironmentalResponsibility:
                return environmentalResponsibilityColor;
            case ResourceType.SocialResponsibility:
                return socialResponsibilityColor;
            case ResourceType.LongTermDevelopment:
                return longTermDevelopmentColor;
            default:
                return Color.white; // Default color
        }
    }
}

public enum ResourceType
{
    GrowthRate,
    EnvironmentalResponsibility,
    SocialResponsibility,
    LongTermDevelopment
}
