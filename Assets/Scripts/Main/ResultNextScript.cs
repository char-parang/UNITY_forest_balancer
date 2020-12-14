using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultNextScript : MonoBehaviour, Clickable
{
    public int endcode = -1;
    public void onClicked()
    {
        if(endcode == -1)
            SceneManager.LoadScene("Loading");
        else
        {
            SceneManager.LoadScene("Ending");
        }
    }

}
