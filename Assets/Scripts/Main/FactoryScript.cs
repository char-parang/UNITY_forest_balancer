using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryScript : MonoBehaviour, Clickable
{
    public GameManager gm;
    public Data data;

    public void OnEnable()
    {
        if (data.getFactoryActivate())
        {
            gameObject.transform.Find("factoryImage").GetComponent<SpriteRenderer>().color = Color.white;
            Destroy(gameObject.GetComponent<BoxCollider2D>());
        }
    }
    public void onClicked()
    {
        gm.setOtherClickable(false);
        gameObject.transform.Find("Canvas").Find("factoryActivate").gameObject.SetActive(true);
    }
}
