using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PostResultUI : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private PostResultData postResultData;

    [Header("UI Elements")]
    [SerializeField] private TextMeshProUGUI headerText;
    [SerializeField] private TextMeshProUGUI desc;
    [SerializeField] private TextMeshProUGUI desc_1;
    [SerializeField] private TextMeshProUGUI desc_2;

    [Space]
    [SerializeField] private TextMeshProUGUI investorText;
    [SerializeField] private TextMeshProUGUI stakeHolderText;
    [SerializeField] private TextMeshProUGUI investorValue;
    [SerializeField] private TextMeshProUGUI stakeHolderValue;

    [Space]
    [SerializeField] private Button cancelTheContract;
    [SerializeField] private Button keepTheContract;
    [SerializeField] private Button nextBtn;

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        nextBtn.gameObject.SetActive(false);
        desc_1.gameObject.SetActive(true);
        desc_2.gameObject.SetActive(true);
        cancelTheContract.onClick.AddListener(CancelContract);
        keepTheContract.onClick.AddListener(KeepTheContract);
        nextBtn.onClick.AddListener(() => OnClickNextBtn());
        headerText.text = postResultData.postResultTurnData[GameManager.Instance.CurrentTurn - 1].headerText;
        desc.text = postResultData.postResultTurnData[GameManager.Instance.CurrentTurn - 1].desc;
        desc_1.text = postResultData.postResultTurnData[GameManager.Instance.CurrentTurn - 1].desc_1;
        desc_2.text = postResultData.postResultTurnData[GameManager.Instance.CurrentTurn - 1].desc_2;



        investorText.text = postResultData.postResultTurnData[GameManager.Instance.CurrentTurn - 1].investorText;
        stakeHolderText.text = postResultData.postResultTurnData[GameManager.Instance.CurrentTurn - 1].stakeHolderText;
        investorValue.text = postResultData.postResultTurnData[GameManager.Instance.CurrentTurn - 1].investorValue;
        stakeHolderValue.text = postResultData.postResultTurnData[GameManager.Instance.CurrentTurn - 1].stakeHolderValue;

        CheckStkInvestorValue(investorValue, stakeHolderValue);
    }

    private void OnClickNextBtn()
    {
        ShowFinalResult();
    }

    private void CancelContract()
    {
        headerText.text = "YOUR RESPONSE";
        desc.text = postResultData.postResultTurnData[GameManager.Instance.CurrentTurn - 1].responseData.cancelTheContract;
        desc_1.gameObject.SetActive(false);
        desc_2.gameObject.SetActive(false);
        investorText.text = postResultData.postResultTurnData[GameManager.Instance.CurrentTurn - 1].investorText;
        stakeHolderText.text = postResultData.postResultTurnData[GameManager.Instance.CurrentTurn - 1].stakeHolderText;
        investorValue.text = postResultData.postResultTurnData[GameManager.Instance.CurrentTurn - 1].responseData.cancelInvestorValue.ToString();
        stakeHolderValue.text = postResultData.postResultTurnData[GameManager.Instance.CurrentTurn - 1].responseData.cancelStakeHolderValue.ToString();
        CheckStkInvestorValue(investorValue, stakeHolderValue);
        ResourceManagement.Instance.UpdateInvestorScore(postResultData.postResultTurnData[GameManager.Instance.CurrentTurn - 1].responseData.cancelInvestorValue);
        ResourceManagement.Instance.UpdateStakeHolderScore(postResultData.postResultTurnData[GameManager.Instance.CurrentTurn - 1].responseData.cancelStakeHolderValue);
        ResourceManagement.Instance.OnUpdateInvestorStk?.Invoke();
      SetBtns();
    }

    private void KeepTheContract()
    {
        headerText.text = "YOUR RESPONSE";

        desc.text = postResultData.postResultTurnData[GameManager.Instance.CurrentTurn - 1].responseData.keepTheContract;
        desc_1.gameObject.SetActive(false);
        desc_2.gameObject.SetActive(false);
        investorText.text = postResultData.postResultTurnData[GameManager.Instance.CurrentTurn - 1].investorText;
        stakeHolderText.text = postResultData.postResultTurnData[GameManager.Instance.CurrentTurn - 1].stakeHolderText;
        investorValue.text = postResultData.postResultTurnData[GameManager.Instance.CurrentTurn - 1].responseData.keepInvestorValue.ToString();
        stakeHolderValue.text = postResultData.postResultTurnData[GameManager.Instance.CurrentTurn - 1].responseData.keepStakeHolderValue.ToString();
        CheckStkInvestorValue(investorValue, stakeHolderValue);
        ResourceManagement.Instance.UpdateInvestorScore(postResultData.postResultTurnData[GameManager.Instance.CurrentTurn - 1].responseData.keepInvestorValue);
        ResourceManagement.Instance.UpdateStakeHolderScore(postResultData.postResultTurnData[GameManager.Instance.CurrentTurn - 1].responseData.keepStakeHolderValue);
        ResourceManagement.Instance.OnUpdateInvestorStk?.Invoke();
        SetBtns();
       }

    private void SetBtns()
    {
        nextBtn.gameObject.SetActive(true);
        cancelTheContract.gameObject.SetActive(false);
        keepTheContract.gameObject.SetActive(false);

    }

    private void ShowFinalResult()
    {
        nextBtn.onClick.RemoveAllListeners();
        nextBtn.onClick.AddListener(GotoNextTurn);
        desc_1.gameObject.SetActive(true);
        
        investorValue.transform.parent.gameObject.SetActive(false);
        stakeHolderValue.transform.parent.gameObject.SetActive(false);

        headerText.text = postResultData.postResultTurnData[GameManager.Instance.CurrentTurn-1].finalResultData.headerText;
        desc.text = postResultData.postResultTurnData[GameManager.Instance.CurrentTurn - 1].finalResultData.desc;
        desc_1.text = postResultData.postResultTurnData[GameManager.Instance.CurrentTurn - 1].finalResultData.desc_1;

    }

    private void GotoNextTurn()
    {
        GameManager.Instance.IncrementTurn();
        UIManager.Instance.NextTurnUI();
    }

    private void CheckStkInvestorValue(TextMeshProUGUI investorValue, TextMeshProUGUI stakeholderValue)
    {
        if (investorValue.text == "0")
        {
            investorValue.transform.parent.gameObject.SetActive(false);
        }
        else
        {
            investorValue.transform.parent.gameObject.SetActive(true);
        }
        if (stakeholderValue.text == "0")
        {
            stakeholderValue.transform.parent.gameObject.SetActive(false);
        }
        else
        {
            stakeholderValue.transform.parent.gameObject.SetActive(true);
        }
    }
}
