using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseButtonScript : MonoBehaviour
{
    public GameManager gm;
    public void onClick()
    {
        gm.setOtherClickable(true);
        GameObject parent = this.transform.parent.transform.GetChild(0).gameObject;
        for(int i = 0; i < parent.transform.childCount; i++)
        {
            parent.transform.GetChild(i).gameObject.SetActive(false);
            Debug.Log(parent.transform.GetChild(i).name);
        }
    }
}
