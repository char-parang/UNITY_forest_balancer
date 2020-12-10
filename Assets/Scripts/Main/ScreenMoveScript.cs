using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenMoveScript : MonoBehaviour, Clickable
{
    private bool moveTrig = false;
    public GameObject screen1, screen2, other;
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

        switch (gameObject.name)
        {
            case "screenMoveButtonRight":
                movement = -0.3f;
                gameObject.SetActive(false);
                break;
            case "screenMoveButtonLeft":
                gameObject.SetActive(true);
                movement = 0.3f;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (moveTrig)
        {
            if (gameObject.name == "screenMoveButtonLeft" && screen1.transform.position.x < 17.9 || gameObject.name == "screenMoveButtonRight" && screen1.transform.position.x > 0.0)
            {
                screen1.transform.position = new Vector3(screen1.transform.position.x + movement, 0, 0);
                screen2.transform.position = new Vector3(screen2.transform.position.x + movement, 0, 0);
            }
            else
            {
                if (gameObject.name == "screenMoveButtonLeft")
                {
                    gameObject.SetActive(false);
                    screen1.gameObject.SetActive(false);
                    other.SetActive(true);
                }
                else if (gameObject.name == "screenMoveButtonRight")
                {
                    gameObject.SetActive(false);
                    screen2.gameObject.SetActive(false);
                    other.SetActive(true);
                }
                moveTrig = false;
            }
        }
    }

}
