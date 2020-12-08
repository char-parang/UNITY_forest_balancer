using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpfundScript : MonoBehaviour, Clickable
{
    public Button[] toggle;
    public PlanPreprocScript preproc;
    public Data data;
    private int thisButton = 0;
    private Outline outline;

    public void OnEnable()
    {
        outline = GetComponent<Outline>();
        outline.enabled = false;
        int money = data.getUserMoney();
        switch (gameObject.name)
        {
            case "zero":
                thisButton = 0;
                break;
            case "three":
                thisButton = 300;
                break;
            case "six":
                thisButton = 600;
                break;
            case "twenty":
                thisButton = 900;
                break;
        }
        if (money >= thisButton)
            gameObject.GetComponent<Button>().interactable = true;
        else
            gameObject.GetComponent<Button>().interactable = false;
    }

    public void onClicked()
    {
        for (int i = 0; i < toggle.Length; i++)
        {
            if (data.getUserMoney() >= toggle[i].GetComponent<OpfundScript>().getThisButtonPrice())
                toggle[i].interactable = true;
            toggle[i].GetComponent<Outline>().enabled = false;
        }
        int fund = thisButton;
        
        preproc.setFund(fund);
        gameObject.GetComponent<Button>().interactable = false;
        outline.enabled = true;
    }

    public int getThisButtonPrice()
    {
        return thisButton;
    }
}
