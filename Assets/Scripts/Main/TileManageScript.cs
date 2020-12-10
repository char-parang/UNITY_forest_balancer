using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManageScript : MonoBehaviour
{
    public Data data;
    private char[] fieldStatus = new char[12];

    void OnEnable()
    {
        string s = data.getFieldStatus();
        for (int i = 0; i < 12; i++)
        {
            fieldStatus[i] = s[i];
            Transform child = gameObject.transform.GetChild(i).GetChild(0);
            Animator anim = child.GetComponent<Animator>();
            if (fieldStatus[i] == '1')
            {
                anim.SetBool("isFarm", true);
            }
            else
            {
                anim.SetBool("isFarm", false);
            }
            //anim.runtimeAnimatorController = child.GetComponent<TileScript>().click;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
