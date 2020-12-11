using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileManageScript : MonoBehaviour
{
    public Data data;
    public GameObject[] notices, texts;
    public GameObject nope;
    public RemainNumScript remains;
    private char[] fieldStatus = new char[12];
    private int clickedTileNum;

    void OnEnable()
    {
        init();
    }

    public void update()
    {
        init();
        remains.OnEnable();
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
            if (1000 > data.getUserMoney())
            {
                nope.SetActive(true);
                notices[0].transform.Find("buttons").Find("yes").GetComponent<Collider2D>().enabled = false;
                notices[0].transform.Find("buttons").Find("yes").GetComponent<SpriteRenderer>().color = Color.gray;
            }
            else
            {
                nope.SetActive(false);
                notices[0].transform.Find("buttons").Find("yes").GetComponent<Collider2D>().enabled = true;
                notices[0].transform.Find("buttons").Find("yes").GetComponent<SpriteRenderer>().color = Color.white;
                notices[0].transform.Find("buttons").Find("yes").GetComponent<TileChangeScript>().setIsFarm(true);
            }
        }
        else
        {
            notices[1].SetActive(true);
            texts[1].SetActive(true);
            if (500 > data.getUserMoney())
            {
                nope.SetActive(true);
                notices[1].transform.Find("buttons").Find("yes").GetComponent<Collider2D>().enabled = false;
                notices[1].transform.Find("buttons").Find("yes").GetComponent<SpriteRenderer>().color = Color.gray;
            }
            else
            {
                nope.SetActive(false);
                notices[1].transform.Find("buttons").Find("yes").GetComponent<Collider2D>().enabled = true;
                notices[1].transform.Find("buttons").Find("yes").GetComponent<SpriteRenderer>().color = Color.white;
                notices[1].transform.Find("buttons").Find("yes").GetComponent<TileChangeScript>().setIsFarm(true);
            }
        }
    }
}
