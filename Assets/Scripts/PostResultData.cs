using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PostResultData", menuName = "Game/PostResultData", order = 1)]
public class PostResultData : ScriptableObject
{

    public List<PostResultTurnData> postResultTurnData;

    [System.Serializable]
    public class PostResultTurnData
    {
        public string headerText;
        [TextArea(3, 10)]
        public string desc;
        [TextArea(3, 10)]
        public string desc_1;
        [TextArea(3, 10)]
        public string desc_2;

        public string investorText;
        public string stakeHolderText;
        public string investorValue;
        public string stakeHolderValue;
        public ResponseData responseData; 
        public FinalResultData finalResultData;
    }

    [System.Serializable]
    public class ResponseData
    {
        [TextArea(3, 10)]
        public string keepTheContract;
        [TextArea(3, 10)]
        public string cancelTheContract;

        public float keepInvestorValue;
        public float keepStakeHolderValue;

        public float  cancelInvestorValue;
        public float  cancelStakeHolderValue;
    }

    [System.Serializable]
    public class FinalResultData
    {
        public string headerText;
        [TextArea(3, 10)]
        public string desc;
        [TextArea(3, 10)]
        public string desc_1;
        [TextArea(3, 10)]
        public string desc_2;

    }


}
