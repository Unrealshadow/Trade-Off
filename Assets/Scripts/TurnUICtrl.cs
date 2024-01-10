using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TurnUICtrl : MonoBehaviour
{//#007D86
    [Header("UI Elements")]
    [SerializeField] private TextMeshProUGUI desc;
    [SerializeField] private TextMeshProUGUI subDesc;
    [SerializeField] private Image illustration;
    [SerializeField] private Button nextBtn;

    [Header("Turn Data")]
    public TurnData[] turnData;

    private int currentInstructionIndex = 0;

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        nextBtn.onClick.AddListener(NextBtnOnClick);
        LoadTurnData(currentInstructionIndex);
    }

    private void NextBtnOnClick()
    {
        currentInstructionIndex++;

        if (currentInstructionIndex < turnData.Length)
        {
            LoadTurnData(currentInstructionIndex);
        }
        else
        {
            UIManager.instance.DisableSpecificUI("Turn");
            UIManager.instance.EnableSpecificUI("ResourceAllocation");
        }
    }

    private void LoadTurnData(int index)
    {
        if (index < 0 || index >= turnData.Length)
        {
            Debug.LogError("Invalid instruction index.");
            return;
        }

        TurnData currentTurn = turnData[index];

        desc.text = string.IsNullOrEmpty(currentTurn.desc) ? "" : currentTurn.desc;
        subDesc.text = string.IsNullOrEmpty(currentTurn.subDesc) ? "" : currentTurn.subDesc;
        // disable the illustration if there is no illustration
        illustration.sprite = currentTurn.illustration;
        illustration.enabled = currentTurn.illustration != null;
    }




}
