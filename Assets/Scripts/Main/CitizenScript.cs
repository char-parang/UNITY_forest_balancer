using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CitizenScript : MonoBehaviour, Clickable
{
    private bool cable;
    public GameObject dialog;

    public void onClicked()
    {
        switch (gameObject.name)
        {
            case "farmer":
                dialog.GetComponent<DialogScript>().setGroup("farmer");
                dialog.GetComponent<DialogScript>().setCode(1);
                break;
            case "factory":
                //dialog.GetComponent<DialogScript>().setGroup("faremr");
                break;
            case "deerHouse":
                dialog.GetComponent<DialogScript>().setGroup("deer");
                dialog.GetComponent<DialogScript>().setCode(1);
                break;
            case "wolfHouse":
                dialog.GetComponent<DialogScript>().setGroup("wolf");
                dialog.GetComponent<DialogScript>().setCode(1);
                break;
            case "woodcutter":
                dialog.GetComponent<DialogScript>().setGroup("wood");
                dialog.GetComponent<DialogScript>().setCode(1);
                break;
        }
        dialog.SetActive(true);
    }
}
