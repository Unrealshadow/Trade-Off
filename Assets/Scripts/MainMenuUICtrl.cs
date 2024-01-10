using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUICtrl : MonoBehaviour
{
    public Button startGameBtn;

    private void Start()
    {
        startGameBtn.onClick.AddListener(StartGame);
    }

    public void StartGame()
    {
        UIManager.instance.EnableSpecificUI("HUD");
        UIManager.instance.EnableSpecificUI("Instruction");
        UIManager.instance.DisableSpecificUI("MainMenu");

    }
}
