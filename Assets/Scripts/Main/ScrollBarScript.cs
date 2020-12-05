using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollBarScript : MonoBehaviour, Clickable, Scrollable
{
    public GameObject button, scrollBar;
    public GameObject target;
    public float minPos, maxPos;
    private bool isXcoord = true;

    public float getMaxCoord()
    {
        return maxPos;
    }

    public float getMinCoord()
    {
        return minPos;
    }

    public bool isX()
    {
        return isXcoord;
    }

    public void onClicked()
    {
        return;
    }

    public void onScrolled(float x, float y)
    {
        if (isXcoord)
        {
            if (maxPos < x) x = maxPos;
            else if (minPos > x) x = minPos;
            button.transform.position = new Vector3(x, button.transform.position.y, button.transform.position.z);
            Image img = scrollBar.GetComponent<Image>();
            img.fillAmount = (x - minPos) / (maxPos - minPos);
            target.GetComponent<ScrollControlable>().setAmount((x - minPos) / (maxPos - minPos));
        }
    }

    void OnEnable()
    {

    }
}
