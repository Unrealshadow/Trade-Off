using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data_Instruction", menuName = "ScriptableObjects/Data_Instruction", order = 1)]
public class Data_Instruction : ScriptableObject
{

    public readonly string desc_1 = "You are the charismatic founder and chief executive of FlexBird, a technology company preparing for an initial public offering.";
    public readonly string subtitle_1 = "\r\nAs CEO, you will have to satisfy your investors by meeting quarterly targets to grow the business.\r\n\r\nYour investors start with an approval score of 5.";
    public readonly string subDesc_1 = "If their approval score falls to 0, you will lose the game.";
    public readonly string illustrationName_1 = "instruction_1_illustration";

    public readonly string desc_2 = "Businesses are increasingly under pressure to do more than just make money for their shareholders.";
    public readonly string subtitle_2 = "\r\nYou also have other stakeholders — your customers, workers, suppliers and the larger community — that you will have to keep happy.\r\n\r\nYour stakeholders start with an approval score of 5.";
    public readonly string subDesc_2 = "If their approval score falls to 0, you will also lose the game.";
    public readonly string illustrationName_2 = "instruction_2_illustration";

    public readonly string desc_3 = "You are going to have to balance profit and purpose as you lead FlexBird over the next four years.";
    public readonly string subtitle_3 = "\r\nDo you prioritize meeting short-term growth targets, or will you take a longer view? What about saving the planet, or doing right by your employees and society at large?";
    public readonly string subDesc_3 = "";

    public readonly string desc_4 = "You start with 10 resources, which represent the time, money and managerial energy available to you.";
    public readonly string subtitle_4 = "";
    public readonly string subDesc_4 = "In each round of the game, you will allocate these resources to indicate what FlexBird will focus on in the next year.";
    public readonly string illustrationName_4 = "instruction_4_illustration";
      
     

}
