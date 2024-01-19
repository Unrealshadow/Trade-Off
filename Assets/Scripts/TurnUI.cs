using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TurnUI : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private GameData gameData;
    [SerializeField] private TurnData turnData;

    [Header("UI Elements")]
    [SerializeField] private TextMeshProUGUI turnNumberText;
    [SerializeField] private TextMeshProUGUI turnDescriptionText;
    [SerializeField] private TextMeshProUGUI turnSubtitleText;
    [SerializeField] private Transform turnIndicatorParent;
    [SerializeField] private Image turnIllustration;
    [SerializeField] private TextMeshProUGUI turnSubDescriptionText;
    [SerializeField] private Button nextButton;

    private void Start()
    {
        turnNumberText.color = gameData.gameColors.turnTextColor;
        nextButton.onClick.AddListener(OnClickNextBtn);
    }


    private void OnClickNextBtn()
    {
        UIManager.Instance.ShowResourceAllocationUI(GameManager.Instance.CurrentTurn);

    }

    public void SetTurnData(int turnNumber)
    {
        turnNumberText.text = "TURN " + turnNumber.ToString() + " OF 4";

        ScenarioData scenarioData = turnData.scenarios[turnNumber - 1];
        UpdateTurnIndicator(turnNumber-1);

        UpdateTurnUI(scenarioData);
    }


    public void UpdateTurnUI(ScenarioData scenarioData)
    {
        SetTextUIElement(turnDescriptionText, scenarioData.scenarioDescription);
        SetTextUIElement(turnSubtitleText, scenarioData.scenarioSubtitle);
        SetImageUIElement(turnIllustration, scenarioData.scenarioImage);
        SetTextUIElement(turnSubDescriptionText, scenarioData.scenarioSubDescription);
    }

    private void SetTextUIElement(TextMeshProUGUI textElement, string text)
    {
        if (!string.IsNullOrEmpty(text))
        {
            textElement.enabled = true;
            textElement.text = text;
        }
        else
        {
            textElement.enabled = false;
        }
    }

    private void SetImageUIElement(Image imageElement, Sprite sprite)
    {
        if (sprite != null)
        {
            imageElement.enabled = true;
            imageElement.sprite = sprite;
        }
        else
        {
            imageElement.enabled = false;
        }
    }

    private void UpdateTurnIndicator(int turnNumber)
    {
        foreach (Transform turnIndicator in turnIndicatorParent)
        {
            if (turnIndicator.GetSiblingIndex() == turnNumber)
            {
                turnIndicator.GetComponent<Image>().color = gameData.gameColors.turnActiveColor;
            }
            else
            {
                turnIndicator.GetComponent<Image>().color = gameData.gameColors.turnInactiveColor;
            }
        }
    }
}
