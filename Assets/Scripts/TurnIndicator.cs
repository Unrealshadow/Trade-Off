using UnityEngine;
using UnityEngine.UI;

public class TurnIndicator : MonoBehaviour
{
    public Transform turnContainer;
    public int totalTurns = 4;

    private Color activeColor = new Color(26f / 255f, 236f / 255f, 255f / 255f);
    private Color inactiveColor = new Color(0f / 255f, 125f / 255f, 134f / 255f);

    private void Start()
    {
        InitializeTurnIndicator();
    }

    private void InitializeTurnIndicator()
    {
        UpdateActiveDots(1);
    }

    public void UpdateActiveDots(int currentTurn)
    {
        // Deactivate all dots
        foreach (Transform dotTransform in turnContainer)
        {
            Image turnImage = dotTransform.GetComponent<Image>();
            turnImage.color = inactiveColor; // Set to inactive color
        }

        // Activate the specified number of dots
        for (int i = 0; i < currentTurn; i++)
        {
            Image turnImage = turnContainer.GetChild(i).GetComponent<Image>();
            turnImage.color = activeColor; // Set to active color
        }
    }
}
