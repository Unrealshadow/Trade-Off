using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemanager : MonoBehaviour
{
    public static Gamemanager Instance;

    public int currentTurn = 1;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void NextTurn()
    {
        if(currentTurn < 5)
        currentTurn++;
    }

}
