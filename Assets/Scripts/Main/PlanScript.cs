using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanScript : MonoBehaviour, Clickable
{
    public Button[] planSelect;
    public GameObject[] planSet;
    public Data data;
    public Text monthText;
    private int month;
    void OnEnable()
    {
        planSelect[0].interactable = false;
        planSelect[1].interactable = true;
        planSet[0].SetActive(true);
        planSet[1].SetActive(false);
        month = data.getUserMonth();
        monthText.text = month + "번째 달: " + month / 12 + "년 " + (month % 12 + 1) + "월";
        if (data.getFactoryActivate())
            gameObject.transform.Find("generalPlanItems").Find("factoryActivate").gameObject.SetActive(true);
    }

    public void onClicked()
    {
        for(int i = 0; i < planSelect.Length; i++)
        {
            planSelect[i].interactable = !planSelect[i].interactable;
            planSet[i].SetActive(!planSet[i].activeSelf);
        }
    }

    public void festivalInfoClick(Button button)
    {
        GameObject info = button.gameObject.transform.Find("popup").gameObject;
        info.SetActive(!info.activeSelf);
    }
    public int getMonth()
    {
        return month;
    }
}
