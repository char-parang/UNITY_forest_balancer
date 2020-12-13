using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FestivalInitScript : MonoBehaviour
{
    public GameObject plan;
    private GameObject moon, forest, rich;

    public void OnEnable()
    {
        moon = gameObject.transform.Find("moon").gameObject;
        forest = gameObject.transform.Find("forest").gameObject;
        rich = gameObject.transform.Find("rich").gameObject;

        moon.GetComponent<Image>().color = Color.gray;
        forest.GetComponent<Image>().color = Color.gray;
        rich.GetComponent<Image>().color = Color.gray;

        moon.transform.Find("hold").GetComponent<Button>().interactable = false;
        forest.transform.Find("hold").GetComponent<Button>().interactable = false;
        rich.transform.Find("hold").GetComponent<Button>().interactable = false;

        switch (plan.GetComponent<PlanScript>().getMonth()%12 + 1)
        {
            case 1:
            case 2:
                moon.GetComponent<Image>().color = Color.white;
                moon.transform.Find("hold").GetComponent<Button>().interactable = true;
                break;
            case 6:
            case 7:
                forest.GetComponent<Image>().color = Color.white;
                forest.transform.Find("hold").GetComponent<Button>().interactable = true;
                break;
            case 10:
            case 11:
                rich.GetComponent<Image>().color = Color.white;
                rich.transform.Find("hold").GetComponent<Button>().interactable = true;
                break;
        }
    }
}
