using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data_Turn", menuName = "ScriptableObjects/Data_Turn", order = 1)]
public class Data_Turn : ScriptableObject
{
    [Header("Turn 1")]
    public readonly string desc_1 = "You prepare to write the CEO's letter to investors for your IPO prospectus.";
    public readonly string subtitle_1 = "\r\nThis is an opportunity for you to set out FlexBird's priorities and indicate how the company plans to use its limited resources. Your choices will impact your investors and stakeholders level of approval.";
    public readonly string subDesc_1 = "";
    public readonly string illustrationName_1 = "";
}
