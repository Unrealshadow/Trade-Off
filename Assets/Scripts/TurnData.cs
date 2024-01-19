using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TurnData", menuName = "Game/TurnData", order = 1)]
public class TurnData : ScriptableObject
{
    public int turnNumber;
    public List<ScenarioData> scenarios;
    public List<Events> events;
    public List<ResultData> results;
}

[System.Serializable]
public class ScenarioData
{
    [TextArea(3, 10)]
    public string scenarioDescription;
    [TextArea(3, 10)]
    public string scenarioSubtitle;
    [TextArea(3, 10)]
    public string scenarioSubDescription;
    public Sprite scenarioImage;

}

[System.Serializable]
public class Events
{
    public List<EventData> eventDatas; 
}

[System.Serializable]
public class EventData
{
    [TextArea(3, 10)]
    public string eventDescription;
    public float investorScoreChange;
    public float stakeholderScoreChange;
    public int currentTurn;
    public string eventTitle;
}

[System.Serializable]
public class ResultData
{
    public List<ResourceTypeDataForResult> resourceTypeDataForResults;
}

[System.Serializable]
public class ResourceTypeDataForResult
{

    public List<ResourceDetails> resourceDetails;
    [TextArea(3, 3)]
    public string investorText;
    [TextArea(3, 3)]
    public string stakeHolderText;
    public Sprite illustration;
    public ResourceType resourceType;
    
}

[System.Serializable]
public class ResourceDetails
{
    [TextArea(3, 10)]
    public string resultDescription;
    
    public float investorValueText;
    public float stakeHolderValueText;
}

[System.Serializable]
public class PostResult
{

}