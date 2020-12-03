using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillScript : MonoBehaviour
{
    public Data data;
    public Text userMoney;
    public GameObject[] skills;
    private int[] prices = new int[4];
    private int[] skillLevels = new int[4];

    // Start is called before the first frame update
    void OnEnable()
    {
        Debug.Log(data.getUserMoney());
        userMoney.text = data.getUserMoney().ToString();
        setSkillNames();
        setSkillInfo();
        canBuy();
    }

    public void onReinfClick(Button button)
    {
        int idx = Int32.Parse(button.name) - 1;
        int[] skills = data.getUserSkills();
        data.setUserMoney(data.getUserMoney() - prices[idx]);
        userMoney.text = data.getUserMoney().ToString();
        skills[idx]++;
        data.setUserSkills(skills);
        setSkillNames();
        setSkillInfo();
        canBuy();
    }

    private void setSkillNames()
    {
        string[] col = { "Name" };
        skillLevels = data.getUserSkills();
        for (int i = 0; i < skills.Length; i++)
        {
            List<string> skillNames = data.selectData(col, "asset_Skill", "Num="+i);
            if (skillLevels[i] < 5)     skills[i].transform.Find("Text").GetComponent<Text>().text = skillNames[0] + " Lv" + skillLevels[i];
            else    skills[i].transform.Find("Text").GetComponent<Text>().text = skillNames[0] + " MAX";
            prices[i] = (skillLevels[i] + 1) * 100;
            Text priceText = skills[i].transform.Find("priceText").GetComponent<Text>();
            priceText.text = prices[i].ToString();
        }
    }

    private void setSkillInfo()
    {
        string[] col = { "Info" };
        for(int i = 0; i < skills.Length; i++)
        {
            List<string> infos = data.selectData(col, "asset_Skill", "Num=" + i);
            string[] splited = infos[0].Split('n');
            skills[i].transform.Find("infoText").GetComponent<Text>().text = splited[0] + "<color=maroon> <i> <size=14pt>" + (skillLevels[i] * 3).ToString() + "%</size> </i> </color>" + splited[1];
        }
    }

    private void canBuy()
    {
        Text priceText;
        for (int i = 0; i < skills.Length; i++)
        {
            priceText = skills[i].transform.Find("priceText").GetComponent<Text>();
            if (prices[i] <= data.getUserMoney())
            {
                priceText.color = Color.white;
                skills[i].transform.Find((i+1).ToString()).GetComponent<Button>().interactable = true;
            }
            else
            {
                skills[i].transform.Find((i+1).ToString()).GetComponent<Button>().interactable = false;
                priceText.color = Color.red;
            }  
            if(skillLevels[i] >= 5)
            {
                priceText.color = Color.white;
                priceText.text = "MAX";
                skills[i].transform.Find((i + 1).ToString()).GetComponent<Button>().interactable = false;
            }
        }
    }
}
