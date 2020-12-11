using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YesNoButtonScript : MonoBehaviour, Clickable
{
    public GameManager gm;
    public GameObject parentObject;
    public bool isYesButton = false;
    private bool isFarm;
    private int clickedTileNum;

    public void onClicked()
    {
        gm.setOtherClickable(true);
        parentObject.SetActive(false);
        if (isYesButton)
        {
            gameObject.GetComponent<ButtonDoOtherAction>().onYesClick();
        }
    }
}
