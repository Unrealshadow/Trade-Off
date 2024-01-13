using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class UI_Turn : MonoBehaviour
{
    [SerializeField] private UIManager uIManager;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private SpriteAtlas spriteAtlas;

    [Header("UI Elements")]
    [SerializeField] private TextMeshProUGUI title;
    [SerializeField] private TextMeshProUGUI desc;
    [SerializeField] private TextMeshProUGUI subtitle;
    [SerializeField] private TextMeshProUGUI subDesc;
    [SerializeField] private Transform turnIndicators;
    [SerializeField] private Image illustration;
    [SerializeField] private Button nextBtn;

    [Header("Data")]
    [SerializeField] private Data_Turn dataTurn;
    [SerializeField] private Data_Color dataColor;

    private void Start()
    {
        nextBtn.onClick.AddListener(NextBtnClicked);
        UpdateUI();
        UpdateTurnIndicators();
    }

    private void UpdateUI()
    {
        switch (gameManager.currentTurn)
        {
            case 1:
                title.text = $"Turn 1 of {gameManager.totalTurns}";
                desc.text = dataTurn.desc_1;
                subtitle.text = dataTurn.subtitle_1;
                subDesc.text = dataTurn.subDesc_1;
                illustration.enabled = dataTurn.illustrationName_1 == "" ? false : true;
                illustration.sprite = spriteAtlas.GetSprite(dataTurn.illustrationName_1);
                break;
                //case 2:
                //title.text = $"Turn 2 of {gameManager.totalTurns}";
                //desc.text = dataTurn.desc_2;
                //subtitle.text = dataTurn.subtitle_2;
                //subDesc.text = dataTurn.subDesc_2;
                //illustration.enabled = dataTurn.illustrationName_2 == "" ? false : true;
                //illustration.sprite = spriteAtlas.GetSprite(dataTurn.illustrationName_2);
                //break;
        }
    }

    private void UpdateTurnIndicators()
    {
        for (int i = 0; i < gameManager.currentTurn; i++)
        {
            turnIndicators.GetChild(i).GetComponent<Image>().color = dataColor.turnActiveColor;
        }
    }

    private void NextBtnClicked()
    {
        uIManager.DisableUI(gameObject.name);
        uIManager.EnableUI("ResourceAllocation");
    }
}
