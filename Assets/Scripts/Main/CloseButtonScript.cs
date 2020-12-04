using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseButtonScript : MonoBehaviour, Clickable
{
    public GameManager gm;

    public void onClicked()
    {
        gm.setOtherClickable(true);
        GameObject parent = this.transform.parent.transform.GetChild(0).gameObject;
        for (int i = 0; i < parent.transform.childCount; i++)
        {
            parent.transform.GetChild(i).gameObject.SetActive(false);
        }
    }
}
