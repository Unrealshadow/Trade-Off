using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Turn", menuName = "Trade-Off/Turn", order = 1)]

public class TurnData : ScriptableObject
{
    [TextArea(3, 10)]
    public string desc;

    [TextArea(3, 5)]
    public string subDesc;

    public Sprite illustration;
}
