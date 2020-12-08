using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoPlanScript : MonoBehaviour, Clickable
{

    private int fund;
    private int[] num, sat;
    public GameManager gm;
    public GameObject plan;

    void OnEnable()
    {
        gameObject.GetComponent<Button>().interactable = false;
    }

    public void onClicked()
    {
        plan.SetActive(false);
        //animation popup set active ture
    }

    public void setFund(int f)
    {
        fund = f;
        gameObject.GetComponent<Button>().interactable = true;
    }
    public void setNum(int[] n)
    {
        num = n;
    }
    public void setSat(int[] s)
    {
        sat = s;
    }
}
