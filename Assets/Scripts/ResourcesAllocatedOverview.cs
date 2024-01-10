using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourcesAllocatedOverview : MonoBehaviour
{
   
    public List<GameObject> growthResourceUsed;
    public List<GameObject> environmentResourceUsed;
    public List<GameObject> socialResourceUsed;
    public List<GameObject> longTermDevelopmentResourceUsed;

    public Button nextBtn;

    public ResourceData resourceData;

    private void Start()
    {
        nextBtn.onClick.AddListener(NextBtnClicked);
        // set the number of objects active in the growthResourceUsed list 
        for (int i = 0; i < resourceData.growthRate; i++)
        {
            growthResourceUsed[i].SetActive(true);
        }
        // set the number of objects active in the environmentResourceUsed list
        for (int i = 0; i < resourceData.environmentalResponsibility; i++)
        {
            environmentResourceUsed[i].SetActive(true);
        }
        // set the number of objects active in the socialResourceUsed list
        for (int i = 0; i < resourceData.socialResponsibility; i++)
        {
            socialResourceUsed[i].SetActive(true);
        }
        // set the number of objects active in the longTermDevelopmentResourceUsed list
        for (int i = 0; i < resourceData.longTermDevelopment; i++)
        {
            longTermDevelopmentResourceUsed[i].SetActive(true);
        }
    }

    private void NextBtnClicked()
    {
        resourceData.hudData.ResetHudResource?.Invoke();
        UIManager.instance.DisableSpecificUI("ResourceAllocationOverview");
        UIManager.instance.EnableSpecificUI("Result");
    }
}
