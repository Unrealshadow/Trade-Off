using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;
[CreateAssetMenu(fileName = "HUDData", menuName = "Trade-Off/HUDData", order = 1)]
public class HUDData : ScriptableObject
{
    public float investorValue = 5;
    public float stakeHolderValue = 5;
    public ResourceData resourceData;
    public ResultData resultData;

    public UnityAction UpdateHudResource;
    public UnityAction ResetHudResource;
    public UnityAction UpdateHudInvestor;
    public UnityAction UpdateHudStakeholder;

    public void UpdateInvestorValue(float value)
    {
        investorValue += value;
        UpdateHudInvestor?.Invoke();
    }

    public void UpdateStakeHolderValue(float value)
    {
        stakeHolderValue += value;
        UpdateHudStakeholder?.Invoke();
    }

}
