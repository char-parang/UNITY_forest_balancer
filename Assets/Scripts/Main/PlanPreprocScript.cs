﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanPreprocScript : MonoBehaviour, ScrollControlable
{

    private int fund = 0;
    private int[] numHarv = new int[4];
    public Data data;
    public Image farmBar;
    public DoPlanScript doplan;
    public GameObject resultPredict;
    public GameObject[] units;
    public Text moneyPredict;
    private GameObject numPredict, satPredict;
    private CalculatorScript calculator;
    private int[] skills, forestNums;
    private int MAX_HARV_WOOD = 1000, MAX_HARV_DEER = 150, MAX_HARV_WOLF = 40;
    private int[] needs;

    public void OnEnable()
    {
        skills = data.getUserSkills();
        forestNums = data.getUserForestUnits();
        calculator = new CalculatorScript();
        numPredict = resultPredict.transform.Find("amountPredict").gameObject;
        satPredict = resultPredict.transform.Find("satPredict").gameObject;

        numHarv[0] = forestNums[0] * 100;
        farmBar.fillAmount = forestNums[0] / 12.0f;

        int[] calcul = new int[4];
        calculator.calculNum(out calcul, forestNums, numHarv, fund);
        drawPredict(calcul);
        doplan.setNum(calcul);

        string[] t;
        int[] prevNeeds = data.getUserNeeds();

        calculator.calculNeeds(out needs, prevNeeds);
        for(int i = 0; i < 4; i++)
        {
            units[i].transform.Find("predict").localPosition = new Vector3(23.9f+(231.9f - 23.9f) / 10 * needs[i], units[i].transform.Find("predict").localPosition.y);
        }

        needs[0] *= 100;
        needs[1] = (MAX_HARV_WOOD * needs[1] / 10);
        needs[2] = (MAX_HARV_DEER * needs[2] / 10);
        needs[3] = (MAX_HARV_WOLF * needs[3] / 10);

        calculator.calculSat(out calcul, out t, data.getSats(), numHarv, needs, 0);
        doplan.setSat(calcul);
        drawPredict(t);

        moneyPredict.text = "0G";
    }
    public void setAmount(float r, string code)
    {
        switch (code)
        {
            case "woodScroll":
                numHarv[1] = Convert.ToInt32(r * MAX_HARV_WOOD);
                break;
            case "deerScroll":
                numHarv[2] = Convert.ToInt32(r * MAX_HARV_DEER);
                break;
            case "wolfScroll":
                numHarv[3] = Convert.ToInt32(r * MAX_HARV_WOLF);
                break;
        }
        int[] calcul;
        calculator.calculNum(out calcul, data.getUserForestUnits(), numHarv, fund);
        drawPredict(calcul);
        doplan.setNum(calcul);

        string[] t;
        calculator.calculSat(out calcul, out t, data.getSats(), numHarv, needs, 0);
        doplan.setSat(calcul);
        drawPredict(t);

        moneyPredict.text = (Convert.ToInt32(calculator.calculMoney(numHarv, 0)*0.2)).ToString() + "G";
    }

    private void drawPredict(int[] calcul)
    {
        for (int i = 0; i < calcul.Length; i++)
        {
            Text t = numPredict.transform.GetChild(i).Find("Text").GetComponent<Text>();
            if (calcul[i] > forestNums[i] * 1.2) t.text = ">>";
            else if (calcul[i] > forestNums[i]) t.text = ">";
            else if (calcul[i] <= 0) t.text = "X";
            else if (forestNums[i] > calcul[i] * 1.2) t.text = "<<";
            else if (forestNums[i] > calcul[i]) t.text = "<";
            else t.text = "|";
        }
    }
    private void drawPredict(string[] t)
    {
        for (int i = 0; i < t.Length; i++)
        {
            Text tx = satPredict.transform.GetChild(i).Find("Text").GetComponent<Text>();
            tx.text = t[i];
        }
    }

    public void setFund(int f)
    {
        fund = f;
        int[] calcul = new int[4];
        calculator.calculNum(out calcul, forestNums, numHarv, fund);
        drawPredict(calcul);
        doplan.setFund(f);
    }
}
