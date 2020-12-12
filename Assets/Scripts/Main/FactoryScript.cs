using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryScript : MonoBehaviour, Clickable
{
    public void onClicked()
    {
        gameObject.transform.Find("Canvas").Find("factoryActivate").gameObject.SetActive(true);
    }
}
