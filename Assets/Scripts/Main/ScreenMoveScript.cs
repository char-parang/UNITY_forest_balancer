using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenMoveScript : MonoBehaviour, Clickable
{
    private bool moveTrig = false;
    private GameObject screen1, screen2;
    private float movement;
    private bool cable = true;

    public void onClicked()
    {
        Debug.Log(gameObject.name);
        screen1.SetActive(true);
        screen2.SetActive(true);
        moveTrig = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        screen1 = GameObject.Find("MainScreen1");
        screen2 = GameObject.Find("MainScreen2");

        switch (gameObject.name)
        {
            case "right":
                movement = -0.3f;
                break;
            case "left":
                movement = 0.3f;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (moveTrig)
        {
            if (gameObject.name == "left" && screen1.transform.position.x < 17.9 || gameObject.name == "right" && screen1.transform.position.x > 0.0)
            {
                screen1.transform.position = new Vector3(screen1.transform.position.x + movement, 0, 0);
                screen2.transform.position = new Vector3(screen2.transform.position.x + movement, 0, 0);
            }
            else
            {
                if (gameObject.name == "left") screen1.gameObject.SetActive(false);
                else if (gameObject.name == "right") screen2.gameObject.SetActive(false);
                moveTrig = false;
            }
        }
    }

}
