using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupScript : MonoBehaviour, Clickable
{
    public GameObject popup;
    public GameManager gm;
    private bool cable = false;

    public void Start()
    {
        cable = true;

    }
    public void onClicked()
    {
        popup.SetActive(true);
        gm.setOtherClickable(false);
    }
}
