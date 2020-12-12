using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FestivalButtonScript : MonoBehaviour, Clickable
{
    public Data data;
    public int code;
    public GameObject dpa;
    public GameObject plan;

    public void onClicked()
    {
        List<string> d = data.getFestivalScript(code);
        DoPlanAnimationScript dpascript = dpa.GetComponent<DoPlanAnimationScript>();
        int sat = Convert.ToInt32(d[2]);
        float income = Convert.ToInt32(d[3]) /10.0f;
        dpascript.setCode(code);
        dpascript.setMoney(Convert.ToInt32(getMoney() * income));

        dpa.SetActive(true);
        plan.SetActive(false);
    }
    private int getMoney()
    {
        int[] units = data.getUserForestUnits();
        int res = units[0] * 100;
        res += (units[1] > 1000) ? 1000 : units[1];
        res += (units[2] > 150) ? 150 : units[2] * 5;
        res += (units[3] > 40) ? 40 : units[3] * 15;
        return res;
    }
}
