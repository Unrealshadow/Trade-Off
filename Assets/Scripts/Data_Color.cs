using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data_Color", menuName = "ScriptableObjects/Data_Color", order = 1)]
public class Data_Color : ScriptableObject
{
    [Header("Icon BG Color")]
    public Color meetingGrowthColor;
    public Color environmentalResponsibilityColor;
    public Color socialResponsibilityColor;
    public Color longTermDevelopmentColor;

    [Header("Turn Active-NonActive Color")]
    public Color turnActiveColor;
    public Color turnNonActiveColor;

    [Header("Resource Allocation Color")]
    public Color notAllocatedColor;
}
