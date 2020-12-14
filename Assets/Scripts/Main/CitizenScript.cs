using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CitizenScript : MonoBehaviour, Clickable
{
    private bool cable;
    public GameObject dialog;
    public Data data;
    private int code;

    public void OnEnable()
    {
        int[] nums = data.getUserForestUnits();
        switch (gameObject.name)
        {
            case "farmer":
                code = 1;
                break;
            case "deerHouse":
                code = 2;
                break;
            case "wolfHouse":
                code = 3;
                break;
            case "woodcutter":
                code = 4;
                break;
        }
        Debug.Log(gameObject.name+code+": "+nums[code - 1]);
        if (nums[code - 1] <= 0)
        {
            gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.gray;
            if (gameObject.GetComponent<Collider2D>() != null) Destroy(gameObject.GetComponent<Collider2D>());
        }
    }

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
