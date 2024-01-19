using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    public StartScreenUI startScreenUI;
    public HUDUI hudUI;
    public InstructionScreenUI instructionScreenUI;
    public TurnUI turnUI;
    public ResourceAllocationUI resourceAllocationUI;
    public ResourceAllocationOverviewUI resourceAllocationOverviewUI;
    public ResultUI resultUI;
    public PostResultUI postResultUI;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        // Game starts with the Start Screen
        startScreenUI.ShowStartScreen();
    }
   

    public void ShowInstructionScreen()
    {
        startScreenUI.gameObject.SetActive(false);
        instructionScreenUI.gameObject.SetActive(true);
        hudUI.gameObject.SetActive(true);
    }


    public void UpdateTurnUI(int turnNumber)
    {
        // Logic to update the Turn UI based on the current turn
        turnUI.SetTurnData(turnNumber);
    }

    public void ShowTurnUI(int turnNumber)
    {
        instructionScreenUI.gameObject.SetActive(false);
        turnUI.gameObject.SetActive(true);
        UpdateTurnUI(turnNumber);
    }

    public void ShowResourceAllocationUI(int currentTurn)
    {
        turnUI.gameObject.SetActive(false);
        resourceAllocationUI.gameObject.SetActive(true);
    }

    public void ShowResourceAllocationOverviewUI()
    {
        resourceAllocationUI.gameObject.SetActive(false);
        resourceAllocationOverviewUI.gameObject.SetActive(true);
    }

    public void ShowResultUI()
    {
        resourceAllocationOverviewUI.gameObject.SetActive(false);
        resultUI.gameObject.SetActive(true);
    }

    public void ShowPostResultUI()
    {
        resultUI.gameObject.SetActive(false);
        postResultUI.gameObject.SetActive(true);
    }

    public void NextTurnUI()
    {
        postResultUI.gameObject.SetActive(false);
        instructionScreenUI.gameObject.SetActive(true);
    }
}

