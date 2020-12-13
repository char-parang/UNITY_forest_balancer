using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour, ScrollControlable
{
    public GameObject[] popups;
    private GameObject[] clickables;
    private AudioSource bgm;
    public Data data;
    public GameObject village;

    // Start is called before the first frame update
    void Start()
    {
        onMainScreenStart();
        bgm = gameObject.GetComponent<AudioSource>();
        bgm.volume = 0.5f;
    }

    private void onMainScreenStart()
    {
        for(int i =0;i < popups.Length; i++)
        {
            popups[i].SetActive(false);
        }
        clickables = GameObject.FindGameObjectsWithTag("Clickable");
        setOtherClickable(true);
    }

    public void setOtherClickable(GameObject obj, bool status)
    {
        obj.GetComponent<Collider2D>().enabled = status;
    }
    public void setOtherClickable(bool status)
    {
        for (int i = 0; i < clickables.Length; i++)
        {
            if (clickables[i].GetComponent<Collider2D>() != null)
                clickables[i].GetComponent<Collider2D>().enabled = status;
        }
    }

    public void setAmount(float ratio, string code)
    {
        bgm.volume = ratio;
    }
}
