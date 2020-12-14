using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileChangeScript : MonoBehaviour, ButtonDoOtherAction
{
    public Data data;
    public TileManageScript tileManager;
    private bool isFarm;
    private int clickedTileNum;
    public void onYesClick()
    {
        int remainMoney = data.getUserMoney();
        int needMoney = 0;

        if (isFarm)
            needMoney = 1000;
        else
            needMoney = 500;

        data.setUserMoney(remainMoney - needMoney);
        int[] units = data.getUserForestUnits();
        units[1] = Convert.ToInt32(units[1] * 0.9f);
        data.setForestUnits(units);
        int farmNum = units[0];
        string fieldStat = data.getFieldStatus();
        char[] tmp = fieldStat.ToCharArray();
        Debug.Log(tmp);
        if (tmp[clickedTileNum - 1] == '0')
        {
            tmp[clickedTileNum - 1] = '1';
            farmNum++;
        }
        else
        {
            tmp[clickedTileNum - 1] = '0';
            farmNum--;
        }
        fieldStat = new string(tmp);
        Debug.Log(fieldStat);
        data.setFieldStatus(fieldStat, farmNum);
        tileManager.update();
    }

    internal void setClickedTileNum(int v)
    {
        clickedTileNum = v;
    }

    internal void setIsFarm(bool v)
    {
        isFarm = v;
    }
}
