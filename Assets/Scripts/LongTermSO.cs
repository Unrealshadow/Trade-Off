using UnityEngine;

[CreateAssetMenu(fileName = "LongTerm", menuName = "Responsibilities/LongTerm")]
public class LongTermSO : ScriptableObject
{
    [TextArea(3, 10)]
    public string text_1;
    [TextArea(3, 10)]
    public string text_2;
    [TextArea(3, 10)]
    public string text_3;
    [TextArea(3, 10)]
    public string text_4;
    public int resourceAllocated_1;
    public int resourceAllocated_2;
    public int resourceAllocated_3;
    public int resourceAllocated_4;
    public float investorScore_1;
    public float investorScore_2;
    public float investorScore_3;
    public float investorScore_4;
    public float stkScore_1;
    public float stkScore_2;
    public float stkScore_3;
    public float stkScore_4;
    public int turn;
    public readonly string illustrationName_1= "longterm_development_submission";
}
