using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] popups;
    private GameObject[] clickables;
    // Start is called before the first frame update
    void Start()
    {
        onMainScreenStart();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void onMainScreenStart()
    {
        for(int i =0;i < popups.Length; i++)
        {
            popups[i].SetActive(false);
        }
        clickables = GameObject.FindGameObjectsWithTag("Clickable");
        for (int i = 0; i < clickables.Length; i++)
        {
            clickables[i].GetComponent<Collider2D>().enabled = true;
        }
    }

    public void setOtherClickable(GameObject obj, bool status)
    {
        obj.GetComponent<Collider2D>().enabled = status;
    }
    public void setOtherClickable(bool status)
    {
        for (int i = 0; i < clickables.Length; i++)
        {
            clickables[i].GetComponent<Collider2D>().enabled = status;
        }
    }

}
