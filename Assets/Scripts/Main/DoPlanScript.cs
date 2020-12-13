using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoPlanScript : MonoBehaviour, Clickable
{

    private int fund;
    private int[] num, sat, harvs, needs, income = new int[4];
    public GameManager gm;
    public GameObject plan;
    public Data data;
    public GameObject anim;

    void OnEnable()
    {
        gameObject.GetComponent<Button>().interactable = false;
    }

    public void onClicked()
    {
        data.setUserMoney(data.getUserMoney() - fund);
        bool[] p = calculFail();
        DoPlanAnimationScript animscript = anim.GetComponent<DoPlanAnimationScript>();
        animscript.setFail(p);
        animscript.setHarvs(harvs);
        animscript.setMoney(income);
        animscript.setCode(0);

        for(int i = 0; i < 4; i++)
        {
            if (p[i])
            {
                num[i] -= Convert.ToInt32(num[i] * 0.3f);
                sat[i] -= Convert.ToInt32(sat[i] * 0.1f);
                income[i] -= Convert.ToInt32(income[i] * 0.2f);
            }
        }
        int m = 0;
        for (int i = 0; i < income.Length; i++)
            m += income[i];
        data.setUserMoney(data.getUserMoney() + m);
        int getPrevFarm = data.getPrevNum()[0];
        if (needs[0] > harvs[0])
            getPrevFarm++;
        int[] tmp = data.getUserForestUnits();
        tmp[0] = getPrevFarm;
        data.setPrevNum(tmp);
        data.setForestUnits(num);
        data.setSatisfy(sat);

        anim.SetActive(true);
        plan.SetActive(false);
    }
    private bool[] calculFail()
    {
        bool[] p = new bool[4];
        for(int i = 0; i < 4; i++)
        {
            int a = UnityEngine.Random.Range(0, 9);
            if (a > 7)
                p[i] = true;
            else
                p[i] = false;
        }
        return p;
    }

    public void activatable()
    {
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
    public void setAddMoney(int[] m)
    {
        income = m;
    }
    public void setfund(int f)
    {
        fund = f;
    }
    public void setHarvs(int[] h)
    {
        harvs = h;
    }
    public void setNeeds(int[] n)
    {
        needs = n;
    }
}
