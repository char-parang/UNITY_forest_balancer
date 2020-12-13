using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultNextScript : MonoBehaviour, Clickable
{
    public void onClicked()
    {
        SceneManager.LoadScene("Loading");
    }
}
