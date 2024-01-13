using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class UI_Result : MonoBehaviour
{
    [SerializeField] private SpriteAtlas spriteAtlas;
    [Header("Managers")]
    [SerializeField] private GameManager gameManager;
    [SerializeField] private UIManager uiManager;
    [SerializeField] private ResourceManager resourceManager;

    [Header("Data")]
    [SerializeField] private EventSO boozySO;
    [SerializeField] private EventSO moonShotSO;
    [SerializeField] private LongTermSO longTermSO;
    [SerializeField] private SocialSO socialSO;
    [SerializeField] private EnvironmentalSO environmentalSO;
    [SerializeField] private GrowthRateSO growthRateSO;
    [Header("UI Elements")]
    [SerializeField] private TextMeshProUGUI title;
    [SerializeField] private TextMeshProUGUI desc;
    [SerializeField] private TextMeshProUGUI investorDesc;
    [SerializeField] private TextMeshProUGUI stkDesc;
    [SerializeField] private TextMeshProUGUI investorValue_1;
    [SerializeField] private TextMeshProUGUI stkValue_1;
    [SerializeField] private Image illustration_1;

    [Space]
    [SerializeField] private GameObject resultHeader;
    [SerializeField] private GameObject eventHeader;

    [Header("Button")]
    [SerializeField] private Button nextBtn;

    private bool showBoozyEvent;
    private bool showMoonShotEvent;

    private ResourceType currentType;
    private void Start()
    {
        nextBtn.onClick.AddListener(() => OnClickNextBtn());

        UpdateUI(ResourceType.GrowthRate);
    }

    private void SetUIState()
    {
        illustration_1.gameObject.SetActive(false);
        resultHeader.SetActive(false);
        eventHeader.SetActive(true);
    }

    private void OnClickNextBtn()
    {
        // change resource type on click next button and call update UI
        switch (currentType)
        {
            case ResourceType.GrowthRate:
                UpdateUI(ResourceType.Environmental);
                break;
            case ResourceType.Environmental:
                UpdateUI(ResourceType.Social);
                break;
            case ResourceType.Social:
                UpdateUI(ResourceType.LongTerm);
                break;
            case ResourceType.LongTerm:
                if (showBoozyEvent || showMoonShotEvent)
                {
                    ShowEvent(ResourceType.Normal);
                }
                break;
        }
    }

    private void ShowEvent(ResourceType resourceType)
    {
        SetUIState();
    }


    private void UpdateUI(ResourceType resourceType)
    {
        switch (resourceType)
        {
            case ResourceType.GrowthRate:
                SetHeaderColor(resourceType);
                ProcessGrowthRate();
                break;
            case ResourceType.Environmental:
                SetHeaderColor(resourceType);
                ProcessEnvironmental();
                break;
            case ResourceType.Social:
                SetHeaderColor(resourceType);
                ProcessSocial();
                break;
            case ResourceType.LongTerm:
                SetHeaderColor(resourceType);
                ProcessLongTerm();
                break;
        }
    }

    private void SetHeaderColor(ResourceType resourceType)
    {
        resultHeader.transform.GetChild(0).GetComponent<Image>().color = resourceManager.GetResourceColor(resourceType);
        resultHeader.transform.GetChild(1).GetComponent<TextMeshProUGUI>().color = resourceManager.GetResourceColor(resourceType);
        resultHeader.transform.GetChild(2).GetComponent<Image>().color = resourceManager.GetResourceColor(resourceType);
    }

    private void ProcessLongTerm()
    {
        currentType = ResourceType.LongTerm;
        switch (gameManager.currentTurn)
        {
            case 1:
                title.text = "LONG TERM DEVELOPMENT";
                illustration_1.sprite = spriteAtlas.GetSprite(longTermSO.illustrationName_1);
                if (resourceManager.longTermDevelopment >= 3)
                {
                    showMoonShotEvent = true;
                }
                if (resourceManager.longTermDevelopment >= 5)
                {
                    resourceManager.UpdateStkValue(longTermSO.stkScore_1);
                    resourceManager.UpdateInvestorValue(longTermSO.investorScore_1);

                    desc.text = longTermSO.text_1;
                    investorValue_1.text = longTermSO.investorScore_1.ToString();
                    stkValue_1.text = longTermSO.stkScore_1.ToString();

                    SetGameObjectActive(investorValue_1, longTermSO.investorScore_1);
                    SetGameObjectActive(stkValue_1, longTermSO.stkScore_1);

                    resourceManager.OnInvestorStkValueChange?.Invoke();
                }
                else if (resourceManager.longTermDevelopment == 4 || resourceManager.longTermDevelopment == 3)
                {
                    resourceManager.UpdateStkValue(longTermSO.stkScore_2);
                    resourceManager.UpdateInvestorValue(longTermSO.investorScore_2);

                    desc.text = longTermSO.text_2;
                    investorValue_1.text = longTermSO.investorScore_2.ToString();
                    stkValue_1.text = longTermSO.stkScore_2.ToString();

                    SetGameObjectActive(investorValue_1, longTermSO.investorScore_2);
                    SetGameObjectActive(stkValue_1, longTermSO.stkScore_2);

                    resourceManager.OnInvestorStkValueChange?.Invoke();
                }
                else if (resourceManager.longTermDevelopment == 1 || resourceManager.longTermDevelopment == 2)
                {
                    resourceManager.UpdateStkValue(longTermSO.stkScore_3);
                    resourceManager.UpdateInvestorValue(longTermSO.investorScore_3);

                    desc.text = longTermSO.text_3;
                    investorValue_1.text = longTermSO.investorScore_3.ToString();
                    stkValue_1.text = longTermSO.stkScore_3.ToString();

                    SetGameObjectActive(investorValue_1, longTermSO.investorScore_3);
                    SetGameObjectActive(stkValue_1, longTermSO.stkScore_3);

                    resourceManager.OnInvestorStkValueChange?.Invoke();
                }
                else if (resourceManager.longTermDevelopment == 0)
                {
                    resourceManager.UpdateStkValue(longTermSO.stkScore_4);
                    resourceManager.UpdateInvestorValue(longTermSO.investorScore_4);
                    desc.text = longTermSO.text_4;

                    investorValue_1.text = longTermSO.investorScore_4.ToString();
                    stkValue_1.text = longTermSO.stkScore_4.ToString();

                    SetGameObjectActive(investorValue_1, longTermSO.investorScore_4);
                    SetGameObjectActive(stkValue_1, longTermSO.stkScore_4);

                    resourceManager.OnInvestorStkValueChange?.Invoke();
                }
                break;
        }
    }

    private void ProcessSocial()
    {
        currentType = ResourceType.Social;
        switch (gameManager.currentTurn)
        {
            case 1:
                title.text = "SOCIAL RESPONSIBILITY";
                illustration_1.sprite = spriteAtlas.GetSprite(socialSO.illustrationName_1);
                if (resourceManager.socialResponsibility >= 5)
                {
                    resourceManager.UpdateStkValue(socialSO.stkScore_1);
                    resourceManager.UpdateInvestorValue(socialSO.investorScore_1);

                    desc.text = socialSO.text_1;
                    investorValue_1.text = socialSO.investorScore_1.ToString();
                    stkValue_1.text = socialSO.stkScore_1.ToString();

                    SetGameObjectActive(investorValue_1, socialSO.investorScore_1);
                    SetGameObjectActive(stkValue_1, socialSO.stkScore_1);

                    resourceManager.OnInvestorStkValueChange?.Invoke();
                }
                else if (resourceManager.socialResponsibility == 4 || resourceManager.socialResponsibility == 3)
                {
                    resourceManager.UpdateStkValue(socialSO.stkScore_2);
                    resourceManager.UpdateInvestorValue(socialSO.investorScore_2);

                    desc.text = socialSO.text_2;
                    investorValue_1.text = socialSO.investorScore_2.ToString();
                    stkValue_1.text = socialSO.stkScore_2.ToString();

                    SetGameObjectActive(investorValue_1, socialSO.investorScore_2);
                    SetGameObjectActive(stkValue_1, socialSO.stkScore_2);

                    resourceManager.OnInvestorStkValueChange?.Invoke();
                }
                else if (resourceManager.socialResponsibility == 1 || resourceManager.socialResponsibility == 2)
                {
                    showBoozyEvent = true;

                    resourceManager.UpdateStkValue(socialSO.stkScore_3);
                    resourceManager.UpdateInvestorValue(socialSO.investorScore_3);

                    desc.text = socialSO.text_3;
                    investorValue_1.text = socialSO.investorScore_3.ToString();
                    stkValue_1.text = socialSO.stkScore_3.ToString();

                    SetGameObjectActive(investorValue_1, socialSO.investorScore_3);
                    SetGameObjectActive(stkValue_1, socialSO.stkScore_3);

                    resourceManager.OnInvestorStkValueChange?.Invoke();
                }
                else if (resourceManager.socialResponsibility == 0)
                {
                    resourceManager.UpdateStkValue(socialSO.stkScore_4);
                    resourceManager.UpdateInvestorValue(socialSO.investorScore_4);

                    desc.text = socialSO.text_4;
                    investorValue_1.text = socialSO.investorScore_4.ToString();
                    stkValue_1.text = socialSO.stkScore_4.ToString();

                    SetGameObjectActive(investorValue_1, socialSO.investorScore_4);
                    SetGameObjectActive(stkValue_1, socialSO.stkScore_4);

                    resourceManager.OnInvestorStkValueChange?.Invoke();
                }
                break;
        }
    }

    private void ProcessEnvironmental()
    {
        currentType = ResourceType.Environmental;
        switch (gameManager.currentTurn)
        {
            case 1:
                title.text = "ENVIRONMENTAL RESPONSIBILITY";
                illustration_1.sprite = spriteAtlas.GetSprite(environmentalSO.illustrationName_1);
                if (resourceManager.environmentalResponsiblity >= 5)
                {
                    resourceManager.UpdateStkValue(environmentalSO.stkScore_1);
                    resourceManager.UpdateInvestorValue(environmentalSO.investorScore_1);

                    desc.text = environmentalSO.text_1;
                    investorValue_1.text = environmentalSO.investorScore_1.ToString();
                    stkValue_1.text = environmentalSO.stkScore_1.ToString();

                    SetGameObjectActive(investorValue_1, environmentalSO.investorScore_1);
                    SetGameObjectActive(stkValue_1, environmentalSO.stkScore_1);

                    resourceManager.OnInvestorStkValueChange?.Invoke();
                }
                else if (resourceManager.environmentalResponsiblity == 4 || resourceManager.environmentalResponsiblity == 3)
                {
                    resourceManager.UpdateStkValue(environmentalSO.stkScore_2);
                    resourceManager.UpdateInvestorValue(environmentalSO.investorScore_2);
                    desc.text = environmentalSO.text_2;
                    investorValue_1.text = environmentalSO.investorScore_2.ToString();
                    stkValue_1.text = environmentalSO.stkScore_2.ToString();

                    SetGameObjectActive(investorValue_1, environmentalSO.investorScore_2);
                    SetGameObjectActive(stkValue_1, environmentalSO.stkScore_2);

                    resourceManager.OnInvestorStkValueChange?.Invoke();

                }
                else if (resourceManager.environmentalResponsiblity == 1 || resourceManager.environmentalResponsiblity == 2)
                {
                    resourceManager.UpdateStkValue(environmentalSO.stkScore_3);
                    resourceManager.UpdateInvestorValue(environmentalSO.investorScore_3);
                    desc.text = environmentalSO.text_3;
                    investorValue_1.text = environmentalSO.investorScore_3.ToString();
                    stkValue_1.text = environmentalSO.stkScore_3.ToString();

                    SetGameObjectActive(investorValue_1, environmentalSO.investorScore_3);
                    SetGameObjectActive(stkValue_1, environmentalSO.stkScore_3);

                    resourceManager.OnInvestorStkValueChange?.Invoke();
                }
                else if (resourceManager.environmentalResponsiblity == 0)
                {
                    resourceManager.UpdateStkValue(environmentalSO.stkScore_4);
                    resourceManager.UpdateInvestorValue(environmentalSO.investorScore_4);
                    desc.text = environmentalSO.text_4;
                    investorValue_1.text = environmentalSO.investorScore_4.ToString();
                    stkValue_1.text = environmentalSO.stkScore_4.ToString();

                    SetGameObjectActive(investorValue_1, environmentalSO.investorScore_4);
                    SetGameObjectActive(stkValue_1, environmentalSO.stkScore_4);

                    resourceManager.OnInvestorStkValueChange?.Invoke();
                }
                break;
        }
    }

    private void ProcessGrowthRate()
    {
        currentType = ResourceType.GrowthRate;

        switch (gameManager.currentTurn)
        {
            case 1:
                title.text = "MEETING GROWTH TARGETS";
                illustration_1.sprite = spriteAtlas.GetSprite(growthRateSO.illustrationName_1);
                investorDesc.text = "Investor";
                stkDesc.text = "Stakeholder";
                if (resourceManager.meetingGrowthRate >= 6)
                {
                    resourceManager.UpdateStkValue(growthRateSO.stkScore_1);
                    resourceManager.UpdateInvestorValue(growthRateSO.investorScore_1);

                    desc.text = growthRateSO.text_1;
                    investorValue_1.text = growthRateSO.investorScore_1.ToString();
                    stkValue_1.text = growthRateSO.stkScore_1.ToString();

                    SetGameObjectActive(investorValue_1, growthRateSO.investorScore_1);
                    SetGameObjectActive(stkValue_1, growthRateSO.stkScore_1);

                    resourceManager.OnInvestorStkValueChange?.Invoke();
                }
                else if (resourceManager.meetingGrowthRate == 4 || resourceManager.meetingGrowthRate == 5)
                {
                    resourceManager.UpdateStkValue(growthRateSO.stkScore_2);
                    resourceManager.UpdateInvestorValue(growthRateSO.investorScore_2);

                    desc.text = growthRateSO.text_2;
                    investorValue_1.text = growthRateSO.investorScore_2.ToString();
                    stkValue_1.text = growthRateSO.stkScore_2.ToString();

                    SetGameObjectActive(investorValue_1, growthRateSO.investorScore_2);
                    SetGameObjectActive(stkValue_1, growthRateSO.stkScore_2);

                    resourceManager.OnInvestorStkValueChange?.Invoke();
                }
                else if (resourceManager.meetingGrowthRate >= 1 && resourceManager.meetingGrowthRate <= 3)
                {
                    resourceManager.UpdateStkValue(growthRateSO.stkScore_3);
                    resourceManager.UpdateInvestorValue(growthRateSO.investorScore_3);

                    desc.text = growthRateSO.text_3;
                    investorValue_1.text = growthRateSO.investorScore_3.ToString();
                    stkValue_1.text = growthRateSO.stkScore_3.ToString();

                    SetGameObjectActive(investorValue_1, growthRateSO.investorScore_3);
                    SetGameObjectActive(stkValue_1, growthRateSO.stkScore_3);

                    resourceManager.OnInvestorStkValueChange?.Invoke();
                }
                else if (resourceManager.meetingGrowthRate == 0)
                {
                    resourceManager.UpdateStkValue(growthRateSO.stkScore_4);
                    resourceManager.UpdateInvestorValue(growthRateSO.investorScore_4);

                    desc.text = growthRateSO.text_4;
                    investorValue_1.text = growthRateSO.investorScore_4.ToString();
                    stkValue_1.text = growthRateSO.stkScore_4.ToString();

                    SetGameObjectActive(investorValue_1, growthRateSO.investorScore_4);
                    SetGameObjectActive(stkValue_1, growthRateSO.stkScore_4);

                    resourceManager.OnInvestorStkValueChange?.Invoke();
                }
                break;
        }
    }
    private void SetGameObjectActive(TextMeshProUGUI textElement, float score)
    {
        textElement.transform.parent.gameObject.SetActive(score != 0);
    }
}