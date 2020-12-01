using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CitizenScript : MonoBehaviour, Clickable
{
    private bool cable;


    public void onClicked()
    {
        switch (gameObject.name)
        {
            case "farmer":
                Debug.Log("farmer clicked");
                break;
            case "factory":
                Debug.Log("factory clicked");
                break;
            case "deer":
                Debug.Log("deer clicked");
                break;
            case "wolf":
                Debug.Log("wolf clicked");
                break;
            case "woodcutter":
                Debug.Log("woodcutter clicked");
                break;
        }

    }
}
