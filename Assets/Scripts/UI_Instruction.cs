using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class UI_Instruction : MonoBehaviour
{
    [SerializeField] private UIManager uIManager;
    [SerializeField] private SpriteAtlas spriteAtlas;
    
    [Header("UI Elements")]
    [SerializeField] private TextMeshProUGUI title;
    [SerializeField] private TextMeshProUGUI desc;
    [SerializeField] private TextMeshProUGUI subtitle;
    [SerializeField] private TextMeshProUGUI subDesc;
    [SerializeField] private Image illustration;
    [SerializeField] private Button nextBtn;

    [Header("Data")]
    [SerializeField] private Data_Instruction dataInstruction;
    
    private int currentInstruction = 1;

    private void Start()
    {
        nextBtn.onClick.AddListener(NextInstruction);
        currentInstruction = 1;
        UpdateUI();
    }

    public void NextInstruction()
    {
        currentInstruction++;
        UpdateUI();
    }

    private void UpdateUI()
    {
        switch (currentInstruction)
        {
            case 1:
                desc.text = dataInstruction.desc_1;
                subtitle.text = dataInstruction.subtitle_1;
                subDesc.text = dataInstruction.subDesc_1;
                illustration.enabled = true;
                illustration.sprite = spriteAtlas.GetSprite(dataInstruction.illustrationName_1);
                break;
            case 2:
                desc.text = dataInstruction.desc_2;
                subtitle.text = dataInstruction.subtitle_2;
                subDesc.text = dataInstruction.subDesc_2;
                illustration.enabled = true;
                illustration.sprite = spriteAtlas.GetSprite( dataInstruction.illustrationName_2);
                break;
            case 3:
                desc.text = dataInstruction.desc_3;
                subtitle.text = dataInstruction.subtitle_3;
                subDesc.text = dataInstruction.subDesc_3;
                illustration.enabled = false;
                break;
            case 4:
                desc.text = dataInstruction.desc_4;
                subtitle.text = dataInstruction.subtitle_4;
                subDesc.text = dataInstruction.subDesc_4;
                illustration.enabled = true;
                illustration.sprite = spriteAtlas.GetSprite(dataInstruction.illustrationName_4);
                break;
            case 5:
                //Close current UI
                uIManager.DisableUI(gameObject.name);
                uIManager.EnableUI("Turn");
                break;
        }
    }

}
