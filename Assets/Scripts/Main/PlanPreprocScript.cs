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
    public DoPlanScript doPlan;
    public Image farmBar;
    public GameObject resultPredict;
    private GameObject numPredict;
    private GameObject satPredict;
    private CalculatorScript calculator;
    private int[] skills, forestNums;
    private int MAX_HARV_WOOD = 500, MAX_HARV_DEER = 100, MAX_HARV_WOLF = 40;

    public void OnEnable()
    {
        skills = data.getUserSkills();
        forestNums = data.getUserForestUnits();
        calculator = new CalculatorScript();
        numPredict = resultPredict.transform.Find("amountPredict").gameObject;
        satPredict = resultPredict.transform.Find("satPredict").gameObject;
        for(int i = 0; i < 4; i++)
        {
            Text t = satPredict.transform.GetChild(i).Find("Text").GetComponent<Text>();
            t.gameObject.transform.localRotation = new Quaternion(0, 0, 0, 0);
            t.text = "?";
        }
        numHarv[0] = Convert.ToInt32(forestNums[0] / 24.0f);
        farmBar.fillAmount = numHarv[0];
        int[] calcul = new int[4];
        calculator.calculNum(out calcul, forestNums, numHarv);
        drawPredict(calcul);
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
        int[] calcul = new int[3];
        int[] current = { forestNums[1], forestNums[2], forestNums[3] };
        calculator.calculNum(out calcul, data.getUserForestUnits(), numHarv);
        drawPredict(calcul);
    }

    private void drawPredict(int[] calcul)
    {
        for(int i = 0; i < calcul.Length; i++)
        {
            Text t = numPredict.transform.GetChild(i).Find("Text").GetComponent<Text>();
            Debug.Log(calcul[1] + ": " + forestNums[1]);
            if (calcul[i] > forestNums[i]* 2) t.text = ">>";
            else if (calcul[i] > forestNums[i]) t.text = ">";
            else if (forestNums[i] > calcul[i] * 2) t.text = "<<";
            else if (forestNums[i] > calcul[i]) t.text = "<";
            else t.text = "|";
        }
    }

    public void setFund(int f)
    {
        doPlan.setFund(f);
    }
}
