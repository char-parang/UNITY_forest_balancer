using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowMoneyScript : MonoBehaviour
{
    public Data data;
    void OnEnable()
    {
        gameObject.transform.GetChild(0).GetComponent<Text>().text = data.getUserMoney().ToString();
    }
}
