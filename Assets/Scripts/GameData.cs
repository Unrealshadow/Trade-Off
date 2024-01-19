using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameData", menuName = "TradeoffGame/GameData", order = 1)]
public class GameData : ScriptableObject
{
    public GameColors gameColors;

    public Color GetColorByResourceType(ResourceType resourceType)
    {
        switch (resourceType)
        {
            case ResourceType.MeetingGrowthRate:
                return gameColors.meetingGrowthRate;
            case ResourceType.SocialResponsibility:
                return gameColors.socialResponsibility;
            case ResourceType.EnvironmentalResponsibility:
                return gameColors.environmentalResponsibility;
            case ResourceType.LongTermDevelopment:
                return gameColors.longTermDevelopment;
            default:
                return gameColors.resourceNotAllocated;
        }
    }

}


[Serializable]
public class GameColors
{
    public Color turnActiveColor;
    public Color turnInactiveColor;
    public Color turnTextColor;

    public Color meetingGrowthRate;
    public Color socialResponsibility;
    public Color environmentalResponsibility;
    public Color longTermDevelopment;
    public Color resourceNotAllocated;
}



