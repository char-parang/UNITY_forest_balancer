using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryActivateScript : MonoBehaviour, ButtonDoOtherAction
{
    public Data data;
    public GameObject factory;

    public void onYesClick()
    {
        data.setFactoryActivate(true);
        factory.transform.Find("factoryImage").GetComponent<SpriteRenderer>().color = Color.white;
        Destroy(factory.GetComponent<BoxCollider2D>());
    }
}
