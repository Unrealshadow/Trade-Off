using UnityEngine;
using UnityEngine.UI;

public class StartScreenUI : MonoBehaviour
{
    [Header("Button")]
    [SerializeField] private Button startGameButton;

    private void Awake()
    {
        // Add a listener to the Start Game button
        startGameButton.onClick.AddListener(OnStartGameButtonPressed);
    }

    public void ShowStartScreen()
    {
        gameObject.SetActive(true);
    }

    public void OnStartGameButtonPressed()
    {
        UIManager.Instance.ShowInstructionScreen();
    }

}
