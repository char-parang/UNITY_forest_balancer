using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RemainNumScript : MonoBehaviour
{
    public Data data;

    public void OnEnable()
    {
        int[] nums = data.getUserForestUnits();
        Text t;
        for(int i = 0; i < 4; i++)
        {
            t = gameObject.transform.GetChild(i).GetComponent<Text>();
            if (nums[i] >= 1000)
                t.text = (nums[i] / 1000.0).ToString() + "k";
            else
                t.text = nums[i].ToString();
        }
    }
}
