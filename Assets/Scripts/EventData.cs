using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EventData", menuName = "Trade-Off/EventData", order = 1)]
public class EventData : ScriptableObject
{
    public int showHowManyEvents = 0;
    public string eventDesc_1;
    public string eventDesc_2;

    public ResourceData resourceData;
    #region Round_1
    public void SetEventDesc()
    {
        if (Gamemanager.Instance.currentTurn == 1)
        {
            if (resourceData.socialResponsibility == 1 || resourceData.socialResponsibility == 2)
            {
                eventDesc_1 = "One of the charities you funded has been exposed for hosting a boozy annual fundraising rife with inappropriate behavior.\r\nYou sever ties with them as soon as the story breaks, but the reputational damage has been done.";
            }
            else
            {
                eventDesc_1 = "";
            }

            if (resourceData.longTermDevelopment >= 3)
            {
                eventDesc_2 = "Your researchers have started on a few moonshot projects, but with few tangible results.";
            }
            else
            {
                eventDesc_2 = "";
            }

        }
    }
    #endregion
}
