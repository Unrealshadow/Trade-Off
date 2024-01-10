using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUDUICtrl : MonoBehaviour
{
    public TextMeshProUGUI investorsValue;
    public TextMeshProUGUI stakeHolderValue;
    public TextMeshProUGUI resourcesValue;

    public HUDData hudData;


    private void OnEnable()
    {
        hudData.UpdateHudResource += UpdateResourceValue;
        hudData.ResetHudResource += ResetHudResource;

        hudData.UpdateHudInvestor += UpdateInvestorValue;
        hudData.UpdateHudStakeholder += UpdateStakeholderValue;
    }
    private void OnDisable()
    {
        hudData.UpdateHudResource -= UpdateResourceValue;
        hudData.ResetHudResource -= ResetHudResource;

        hudData.UpdateHudInvestor -= UpdateInvestorValue;
            hudData.UpdateHudStakeholder -= UpdateStakeholderValue;
    }

    private void Start()
    {
        investorsValue.text = hudData.investorValue.ToString();
        stakeHolderValue.text = hudData.stakeHolderValue.ToString();
        resourcesValue.text = hudData.resourceData.NUM_RESOURCES.ToString();

    }

    private void UpdateInvestorValue()
    {
        investorsValue.text = hudData.investorValue.ToString();
    }

    private void UpdateStakeholderValue()
    {
        stakeHolderValue.text = hudData.stakeHolderValue.ToString();
    }


    private void UpdateResourceValue()
    {
        resourcesValue.text = (hudData.resourceData.NUM_RESOURCES - hudData.resourceData.usedResources).ToString();
    }

    private void ResetHudResource()
    {
        resourcesValue.text = hudData.resourceData.NUM_RESOURCES.ToString();
    }


}
