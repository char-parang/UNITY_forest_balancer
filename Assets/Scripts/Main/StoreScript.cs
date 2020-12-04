using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreScript : MonoBehaviour
{
    public GameObject[] items;
    public Button perchase;
    public Text itemName, info, userMoney;
    public Data data;

    private GameObject selected;
    // Start is called before the first frame update
    void OnEnable()
    {
        for(int i = 0; i < items.Length; i++)
        {
            int prices = data.getItemPrice(items[i].name);
            GameObject t = items[i].transform.Find("priceText").gameObject;
            t.GetComponent<Text>().text = prices.ToString();
        }

        userMoney.text = data.getUserMoney().ToString();
        for(int i = 0; i < items.Length; i++)
        {
            List<string> t = data.getItemInfo(items[i].name);
            Int32.TryParse(t[3], out int soldout);
            if (soldout == 1)
                items[i].GetComponent<Button>().interactable = false;
        }
        List<string> tmp = new List<string>{ "상점 주인", "이장님 아니십니까. 어서 오십쇼.\n여기선 주민들에게 나누어 줄 수 있는 물건들을 팔고 있습니다.\n물론 대부분은 주민들이 만든 것들이지만요.", "" };
        setItemInfos(tmp);
        perchase.interactable = false;
    }

    private void setItemInfos(List<string> infs)
    {
        itemName.text = "[" + infs[0] + "]";
        info.text = infs[1] + "\n<color=maroon> <i>" + infs[2] + "</i> </color>";
    }

    public void onItemclick(Button button)
    {
        setItemInfos(data.getItemInfo(button.name));
        canBuy(data.getItemPrice(button.name), data.getUserMoney());
        for (int i = 0; i < items.Length; i++)
        {
            items[i].GetComponent<Button>().enabled = true;
            items[i].transform.localScale = new Vector3(1.0f, 1.0f);
        }
        button.transform.localScale = new Vector3(1.2f, 1.2f);
        button.enabled = false;
        selected = button.gameObject;
    }

    private void canBuy(int price, int money) {
        if (price <= money)
        {
            perchase.interactable = true;
            userMoney.color = Color.black;
        }
        else
        {
            perchase.interactable = false;
            userMoney.color = Color.red;
        }
    }

    public void onPurchaseClicked()
    {
        data.setUserMoney(data.getUserMoney() - data.getItemPrice(selected.name));
        userMoney.text = data.getUserMoney().ToString();
        selected.transform.localScale = new Vector3(1.0f, 1.0f);
        selected.GetComponent<Button>().interactable = false;
        perchase.interactable = false;
        List<string> tmp = new List<string> { "상점 주인", "감사합니다! 마을 사람들이 분명히 좋아할 겁니다!", "" };
        setItemInfos(tmp);
    }
}
