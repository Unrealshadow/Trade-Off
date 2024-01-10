using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class InstructionUICtrl : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private TextMeshProUGUI desc;
    [SerializeField] private TextMeshProUGUI subDesc;
    [SerializeField] private Image illustration;
    [SerializeField] private Button nextBtn;

    [Header("Instruction Data")]
    public InstructionData[] instructions;

    private int currentInstructionIndex = 0;

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        nextBtn.onClick.AddListener(NextBtnOnClick);
        LoadInstructionData(currentInstructionIndex);
    }

    private void LoadInstructionData(int index)
    {
        if (index < 0 || index >= instructions.Length)
        {
            Debug.LogError("Invalid instruction index.");
            return;
        }

        InstructionData currentInstruction = instructions[index];

        desc.text = string.IsNullOrEmpty(currentInstruction.desc) ? "" : currentInstruction.desc;
        subDesc.text = string.IsNullOrEmpty(currentInstruction.subDesc) ? "" : currentInstruction.subDesc;
        // disable the illustration if there is no illustration
        illustration.sprite = currentInstruction.illustration;
        illustration.enabled = currentInstruction.illustration != null;
    }


    private void NextBtnOnClick()
    {
        currentInstructionIndex++;

        if (currentInstructionIndex < instructions.Length)
        {
            if (currentInstructionIndex == 3)
            {
                desc.rectTransform.sizeDelta = new Vector2(1400, 100);
            }
            else
            {
                desc.rectTransform.sizeDelta = new Vector2(1400, 343.18f);

            }
            LoadInstructionData(currentInstructionIndex);
        }
        else
        {
            // Handle the case when all instructions are displayed
            UIManager.instance.DisableSpecificUI("Instruction");
            UIManager.instance.EnableSpecificUI("Turn");
        }
    }
}
