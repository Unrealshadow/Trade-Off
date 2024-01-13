using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class UI_Hud : MonoBehaviour
{
    [Header("Managers")]
    [SerializeField] private GameManager gameManager;
    [SerializeField] private UIManager uiManager;
    [SerializeField] private ResourceManager resourceManager;
    
    [Header("UI Elements")]
    [SerializeField] private TextMeshProUGUI investorValue;
    [SerializeField] private TextMeshProUGUI stakeHolderValue;
    [SerializeField] private TextMeshProUGUI resourceValue;

    private void OnEnable()
    {
        resourceManager.OnResourceValueChange += UpdateResource;
        resourceManager.OnInvestorStkValueChange += UpdateInvestorStkValue;
    }

    private void Start()
    {
        UpdateUI();
        UpdateResource();
    }

    private void UpdateUI()
    {
        investorValue.text = resourceManager.investor.ToString();
        stakeHolderValue.text = resourceManager.stakeHolder.ToString();
        resourceValue.text = resourceManager.GetRemainingResource();
    }

    private void UpdateResource()
    {
        resourceValue.text = resourceManager.GetRemainingResource();
    }

    private void UpdateInvestorStkValue()
    {
        investorValue.text = resourceManager.investor.ToString();
        stakeHolderValue.text = resourceManager.stakeHolder.ToString();
    }
}
