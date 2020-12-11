using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManageScript : MonoBehaviour
{
    public Data data;
    public GameObject[] notices, texts;
    private char[] fieldStatus = new char[12];
    private int clickedTileNum;

    void OnEnable()
    {
        init();
    }

    public void update()
    {
        init();
    }

    private void init()
    {
        string s = data.getFieldStatus();
        for (int i = 0; i < 12; i++)
        {
            fieldStatus[i] = s[i];
            Transform child = gameObject.transform.GetChild(i).GetChild(0);
            gameObject.transform.GetChild(i).GetComponent<TileScript>().setTileManager(this);
            Animator anim = child.GetComponent<Animator>();
            if (fieldStatus[i] == '1')
            {
                anim.SetBool("isFarm", true);
                gameObject.transform.GetChild(i).GetComponent<TileScript>().setIsFarm(true);
            }
            else
            {
                anim.SetBool("isFarm", false);
                gameObject.transform.GetChild(i).GetComponent<TileScript>().setIsFarm(false);
            }
        }
    }

    internal void setCilckedTile(int v)
    {
        clickedTileNum = v;
        notices[0].transform.Find("buttons").Find("yes").GetComponent<TileChangeScript>().setClickedTileNum(clickedTileNum);
        notices[1].transform.Find("buttons").Find("yes").GetComponent<TileChangeScript>().setClickedTileNum(clickedTileNum);
    }

    public void showNotice(string v)
    {
        if (v == "A2F")
        {
            notices[0].SetActive(true);
            texts[0].SetActive(true);
            notices[0].transform.Find("buttons").Find("yes").GetComponent<TileChangeScript>().setIsFarm(true);
        }
        else
        {
            notices[1].SetActive(true);
            texts[1].SetActive(true);
            notices[1].transform.Find("buttons").Find("yes").GetComponent<TileChangeScript>().setIsFarm(false);
        }
    }
}
