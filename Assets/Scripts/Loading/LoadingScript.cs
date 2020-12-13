using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScript : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(waitLoading());
    }

    private IEnumerator waitLoading()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Main_ver3");
    }
}