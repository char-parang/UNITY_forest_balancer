using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreScript : MonoBehaviour
{
    public GameObject[] items;
    public Button perchase;
    public Text itemName, info;
    public Data data;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < items.Length; i++)
        {
            int prices = data.getItemPrice(items[i].name);
            Debug.Log(items[i].transform.Find("priceText"));
            GameObject t = items[i].transform.Find("priceText").gameObject;
            t.GetComponent<Text>().text = prices.ToString();
        }

        List<string> tmp = data.getItemInfo("ecobag");
        setItemInfos(tmp);
    }

    private void setItemInfos(List<string> infs)
    {
        itemName.text = "[" + infs[0] + "]";
        info.text = infs[1] + "\n<color=maroon> <i>" + infs[2] + "</i> </color>";
    }

    public void onItemclick(Button button)
    {
        Debug.Log(button.name);
        setItemInfos(data.getItemInfo(button.name));
        for (int i = 0; i < items.Length; i++)
        {
            items[i].GetComponent<Button>().enabled = true;
            items[i].transform.localScale = new Vector3(1.0f, 1.0f);
        }
        button.transform.localScale = new Vector3(1.2f, 1.2f);
        button.enabled = false;
    }
}
