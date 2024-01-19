using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InstructionData", menuName = "Game/InstructionData", order = 1)]
public class InstructionData : ScriptableObject
{
   public List<Instruction> instructions;
    
}

[System.Serializable]
public class Instruction
{
    public List<InstructionDetails> instructionDetails;
    
}

[System.Serializable]
public class InstructionDetails
{
    [TextArea(3, 10)]
    public string description;
    [TextArea(3, 10)]
    public string subtitle;
    public Sprite illustration;
    [TextArea(3, 10)]
    public string subDescription;
}