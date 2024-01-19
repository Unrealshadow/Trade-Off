using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public int CurrentTurn { get; private set; } = 1;
    public List<TurnData> allTurnsData;

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


    public void StartTurn(int turnNumber)
    {
        var currentTurnData = allTurnsData.FirstOrDefault(t => t.turnNumber == turnNumber);
        // Logic to handle the start of the turn using currentTurnData
    }

    public void IncrementTurn()
    {
        CurrentTurn++;
    }



}
