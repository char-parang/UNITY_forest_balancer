using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanPreprocScript : MonoBehaviour, ScrollControlable
{
    private int fund = 0;
    private float[] ratio = new float[4];
    public Data data;
    public DoPlanScript doPlan;
    public Image farmBar;
    public GameObject resultPredict;
    private GameObject numPredict;
    private GameObject satPredict;
    private CalculatorScript calculator;
    private int[] skills;

    public void OnEnable()
    {
        skills = data.getUserSkills();
        calculator = new CalculatorScript();
        numPredict = resultPredict.transform.Find("amountPredict").gameObject;
        satPredict = resultPredict.transform.Find("satPredict").gameObject;
        for(int i = 0; i < 4; i++)
        {
            Text t = numPredict.transform.GetChild(i).Find("Text").GetComponent<Text>();
            t.gameObject.transform.localRotation = new Quaternion(0, 0, 0, 0);
            t.text = "?";
            t = satPredict.transform.GetChild(i).Find("Text").GetComponent<Text>();
            t.gameObject.transform.localRotation = new Quaternion(0, 0, 0, 0);
            t.text = "?";
        }
        ratio[0] = data.getUserField() / 24.0f;
        farmBar.fillAmount = ratio[0];
        doPlan.setRatio(ratio);
    }
    public void setAmount(float r, string code)
    {
        switch (code)
        {
            case "woodScroll":
                ratio[1] = r;
                break;
            case "deerScroll":
                ratio[2] = r;
                break;
            case "wolfScroll":
                ratio[3] = r;
                break;
        }
        calculator.calculNum(res, );
        doPlan.setRatio(ratio);
    }

    public void setFund(int f)
    {
        doPlan.setFund(f);
    }
}
