using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUDUI : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private HudData hudData;

    [Header("UI Elements")]
    [SerializeField] private TextMeshProUGUI investorScoreText;
    [SerializeField] private TextMeshProUGUI stakeholderScoreText;
    [SerializeField] private TextMeshProUGUI currentResourcesText;
    [Header("Sprites")]
    [SerializeField] private Image investorSprite;
    [SerializeField] private Image stakeholderSprite;
    [SerializeField] private Image resourceSprite;
    [Header("Buttons")]
    [SerializeField] private Button burgerMenuButton;

    private void OnEnable()
    {
        SetHudUI();
        UpdateHUD(ResourceManagement.Instance.GetInvestorScore()
            , ResourceManagement.Instance.GetStakeholderScore());

        UpdateResourceAllocationInHud(ResourceManagement.Instance.GetRemainingResources());
    
        ResourceManagement.Instance.OnResourceChange += UpdateResourceAllocationInHud;
        ResourceManagement.Instance.OnUpdateInvestorStk += UpdateInvestorStkUI;
    }

    private void OnDisable()
    {
        ResourceManagement.Instance.OnResourceChange -= UpdateResourceAllocationInHud;
        ResourceManagement.Instance.OnUpdateInvestorStk -= UpdateInvestorStkUI;
    }

    private void SetHudUI()
    {
        investorSprite.sprite = hudData.investorSprite;
        stakeholderSprite.sprite = hudData.stakeHolderSprite;
        resourceSprite.sprite = hudData.resourceSprite;
        burgerMenuButton.image.sprite = hudData.burgerMenuSprite;
    }

    public void UpdateHUD(float investorScore, float stakeholderScore)
    {
        investorScoreText.text = investorScore.ToString();
        stakeholderScoreText.text = stakeholderScore.ToString();
    }

    public void UpdateResourceAllocationInHud(int currentResources)
    {
        currentResourcesText.text = currentResources.ToString();

    }

    private void UpdateInvestorStkUI()
    {
        UpdateHUD(ResourceManagement.Instance.GetInvestorScore()
                       , ResourceManagement.Instance.GetStakeholderScore());
    }

}
