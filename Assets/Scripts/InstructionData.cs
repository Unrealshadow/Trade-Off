using UnityEngine;

[CreateAssetMenu(fileName = "Instruction", menuName = "Trade-Off/Instruction", order = 1)]
public class InstructionData : ScriptableObject
{
    [TextArea(3, 10)]
    public string desc;

    [TextArea(3, 5)]
    public string subDesc;

    public Sprite illustration;
}
