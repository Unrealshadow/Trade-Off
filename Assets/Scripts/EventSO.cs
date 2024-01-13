using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EventType
{
 BoozyEvent,MoonshotEvent,None}

[CreateAssetMenu(fileName = "Event", menuName = "Responsibilities/Event")]
public class EventSO : ScriptableObject
{
    public EventType eventType;
    [TextArea(3, 10)]
    public string text;
    public float investorScore;
    public float stkScore;
    public string illustrationName;
}
