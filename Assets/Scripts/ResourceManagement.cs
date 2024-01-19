using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum ResourceType
{
    None,
    MeetingGrowthRate,
    SocialResponsibility,
    EnvironmentalResponsibility,
    LongTermDevelopment,
}
public class ResourceManagement : MonoBehaviour
{
    public TurnData turnData;
    public List<TurnEvent> turnEvents = new List<TurnEvent>();
    public static ResourceManagement Instance { get; private set; }

    [SerializeField]private float investorScore = 5;
    [SerializeField]private float stakeholderScore = 5;

    [HideInInspector] public int currentResources = 0;
    private int totalResources = 10;

    public int meetingGrowthRate = 0;
    public int socialResponsibility = 0;
    public int environmentalResponsibility = 0;
    public int longTermDevelopment = 0;

    public UnityAction<int> OnResourceChange;
    public UnityAction OnUpdateInvestorStk;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }



    public float GetInvestorScore()
    {
        return investorScore;
    }

    public float GetStakeholderScore()
    {
        return stakeholderScore;
    }

    public int GetRemainingResources()
    {
        return totalResources - currentResources;
    }

    public int GetTotalResources()
    {
        return totalResources;
    }

    public void UpdateInvestorScore(float value)
    {
        investorScore += value;
    }

    public void UpdateStakeHolderScore(float value)
    {
        stakeholderScore += value;
    }

    public void GetEventsForCurrentTurn()
    {
        switch (GameManager.Instance.CurrentTurn)
        {
            case 1:
                if(socialResponsibility == 1 || socialResponsibility == 2)
                {
                    TurnEvent turnEvent = new TurnEvent();
                    turnEvent.description = turnData.events[0].eventDatas[0].eventDescription;
                    turnEvent.investorScoreChange = turnData.events[0].eventDatas[0].investorScoreChange;
                    turnEvent.stakeholderScoreChange = turnData.events[0].eventDatas[0].stakeholderScoreChange;
                    turnEvents.Add(turnEvent);
                }
                if(longTermDevelopment >= 3)
                {
                    TurnEvent turnEvent = new TurnEvent();
                    turnEvent.description = turnData.events[0].eventDatas[1].eventDescription;
                    turnEvent.investorScoreChange = turnData.events[0].eventDatas[1].investorScoreChange;
                    turnEvent.stakeholderScoreChange = turnData.events[0].eventDatas[1].stakeholderScoreChange;
                    turnEvents.Add(turnEvent);
                }
                break;
        }
    }

}
[Serializable]
public class TurnEvent
{
    public string description;
    public float investorScoreChange;
    public float stakeholderScoreChange;
}