using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpfundScript : MonoBehaviour, Clickable
{
    public Button[] toggle;
    public PlanPreprocScript preproc;
    public Data data;

    public void OnEnable()
    {
        int money = data.getUserMoney();
        for(int i = 0; i < toggle.Length; i++)
        {
            //있는 돈 만큼
        }
    }

    public void onClicked()
    {
        for (int i = 0; i < toggle.Length; i++)
        {
            toggle[i].interactable = true;
        }
        int fund = 0;
        switch (gameObject.name)
        {
            case "three":
                fund = 30;
                break;
            case "six":
                fund = 60;
                break;
            case "twenty":
                fund = 120;
                break;
            case "eighteen":
                fund = 180;
                break;
        }
        preproc.setFund(fund);
        gameObject.GetComponent<Button>().interactable = false;
    }
}
