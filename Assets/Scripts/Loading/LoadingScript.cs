using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScript : MonoBehaviour
{
    void Start()
    {
        gameObject.GetComponent<Animator>().SetInteger("random", UnityEngine.Random.Range(1, 6));
        StartCoroutine(waitLoading());
    }

    private IEnumerator waitLoading()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Main_ver3");
    }
}