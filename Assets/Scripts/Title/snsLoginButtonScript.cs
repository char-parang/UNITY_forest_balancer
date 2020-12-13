using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class snsLoginButtonScript : MonoBehaviour, Clickable
{
    private bool cable;
    public void onClicked()
    {
        //TODO: SNS LOGIN
        //TODO: LOAD DATA
        SceneManager.LoadScene("Loading");
    }
}
