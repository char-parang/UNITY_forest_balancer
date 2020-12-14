using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_title : MonoBehaviour
{
    public GameObject[] popups;
    private GameObject[] clickables;
    private AudioSource bgm;

    // Start is called before the first frame update
    void Start()
    {
        bgm = gameObject.GetComponent<AudioSource>();
        bgm.volume = 0.5f;
    }
}
