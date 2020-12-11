using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScript : MonoBehaviour, Clickable
{

    private Animator anim;
    private bool isFarm;
    private TileManageScript tileManager;

    public void onClicked()
    {
        if (isFarm)
        {
            tileManager.showNotice("A2F");
        }
        else
        {
            tileManager.showNotice("F2A");
        }
        tileManager.setCilckedTile(Convert.ToInt32(gameObject.name));
    }

    public void setTileManager(TileManageScript t)
    {
        tileManager = t;
    }
    public void setIsFarm(bool b)
    {
        isFarm = b;
    }
}
