using System;
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
    private int[] income;
    private bool isFactoryAcitve;

    public void OnEnable()
    {
        skills = data.getUserSkills();
        forestNums = data.getUserForestUnits();
        isFactoryAcitve = data.getFactoryActivate();
        calculator = new CalculatorScript();
        numPredict = resultPredict.transform.Find("amountPredict").gameObject;
        satPredict = resultPredict.transform.Find("satPredict").gameObject;

        numHarv[0] = forestNums[0] * 100;
        numHarv[1] = Convert.ToInt32(MAX_HARV_WOOD * 0.5f);
        numHarv[2] = Convert.ToInt32(MAX_HARV_DEER * 0.5f);
        numHarv[3] = Convert.ToInt32(MAX_HARV_WOLF * 0.5f);
        farmBar.fillAmount = forestNums[0] / 12.0f;

        int[] calcul = new int[4];
        calculator.calculNum(out calcul, forestNums, numHarv, fund, isFactoryAcitve);
        drawPredict(calcul);
        doplan.setNum(calcul);
        doplan.setHarvs(numHarv);

        string[] t;

        needs = data.getUserNeeds();
        Debug.Log(needs[0]);

        for (int i = 0; i < 4; i++)
        {
            units[i].transform.Find("predict").localPosition = new Vector3(23.9f+(231.9f - 23.9f) / 10 * needs[i], units[i].transform.Find("predict").localPosition.y);
        }

        needs[0] = 1200 * needs[0]/10;
        needs[1] = MAX_HARV_WOOD * needs[1] / 10;
        needs[2] = MAX_HARV_DEER * needs[2] / 10;
        needs[3] = MAX_HARV_WOLF * needs[3] / 10;
        doplan.setNeeds(needs);

        calculator.calculSat(out calcul, out t, data.getSats(), numHarv, needs, 0);
        doplan.setSat(calcul);
        drawPredict(t);

        int m = calculator.calculMoney(out income, numHarv, 0, isFactoryAcitve);
        moneyPredict.text = m.ToString() + "G";
        doplan.setAddMoney(income);
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
        calculator.calculNum(out calcul, data.getUserForestUnits(), numHarv, fund, isFactoryAcitve);
        Debug.Log(calcul[3]);
        drawPredict(calcul);
        doplan.setNum(calcul);
        doplan.setHarvs(numHarv);

        string[] t;
        calculator.calculSat(out calcul, out t, data.getSats(), numHarv, needs, 0);
        doplan.setSat(calcul);
        drawPredict(t);

        int m = Convert.ToInt32(calculator.calculMoney(out income, numHarv, 0, isFactoryAcitve));
        moneyPredict.text = m.ToString() + "G";
        doplan.setAddMoney(income);
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
        calculator.calculNum(out calcul, forestNums, numHarv, fund, isFactoryAcitve);
        drawPredict(calcul);
        doplan.setfund(f);
        doplan.activatable();
    }
}
