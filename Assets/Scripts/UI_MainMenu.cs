using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_MainMenu : MonoBehaviour
{
    [SerializeField] private UIManager uIManager;
    [Header("UI Elements")]
    [SerializeField] private Button startGameBtn;

    private void Start()
    {
        startGameBtn.onClick.AddListener(StartGame);
    }

    private void StartGame()
    {
        uIManager.DisableUI("MainMenu");
        uIManager.EnableUI("Instruction");
        uIManager.EnableUI("HUD");
    }
}
