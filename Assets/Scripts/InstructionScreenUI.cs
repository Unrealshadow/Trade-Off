using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InstructionScreenUI : MonoBehaviour
{
    [SerializeField] private InstructionData instructionData;
    [SerializeField] private TextMeshProUGUI description;
    [SerializeField] private TextMeshProUGUI subtitle;
    [SerializeField] private Image illustration;
    [SerializeField] private TextMeshProUGUI subDescription;
    [SerializeField] private Button nextInstructionButton;

    private int currentInstructionIndex = 0;

    private void OnEnable()
    {
        nextInstructionButton.onClick.AddListener(GoToNextInstruction);
        currentInstructionIndex = 0;
        DisplayCurrentInstruction();
    }


    private void DisplayCurrentInstruction()
    {

        if (currentInstructionIndex < instructionData.instructions[GameManager.Instance.CurrentTurn-1].instructionDetails.Count)
        {
            InstructionDetails currentInstruction = instructionData.instructions[GameManager.Instance.CurrentTurn - 1].instructionDetails[currentInstructionIndex];
            description.text = currentInstruction.description;
            subtitle.text = currentInstruction.subtitle;

            DisableIllustration();

            subDescription.text = currentInstruction.subDescription;
        }
        else
        {
            gameObject.SetActive(false);
            UIManager.Instance.ShowTurnUI(GameManager.Instance.CurrentTurn);
            GameManager.Instance.StartTurn(GameManager.Instance.CurrentTurn);
        }
    }

    private void GoToNextInstruction()
    {
        currentInstructionIndex++;
        DisplayCurrentInstruction();
    }

    private void DisableIllustration()
    {
        // First, update the sprite for the current instruction
        illustration.sprite = instructionData.instructions[GameManager.Instance.CurrentTurn - 1].instructionDetails[currentInstructionIndex].illustration;

        // Then, check if the sprite is null and update the 'enabled' state accordingly
        if (illustration.sprite == null)
        {
            illustration.enabled = false;
        }
        else
        {
            illustration.enabled = true;
        }
    }


}
