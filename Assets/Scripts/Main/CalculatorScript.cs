using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculatorScript : MonoBehaviour
{
    public void calculNum(out int[] res, int[] cur, int[] harv)
    {
        res = new int[3];
        res[0] = cur[0] - harv[0];
        res[1] = cur[1] - harv[1];
        res[2] = cur[2] - harv[2];
        res[0] -= Convert.ToInt32(0.3f * res[1]);
        res[1] -= Convert.ToInt32((0.1f * res[2] > res[0] * 0.3) ? res[0] * 0.3 : 0.1f * res[2]);
        res[2] = Convert.ToInt32((res[2] > res[1] * 0.3f) ? res[1] * 0.3f : res[2]);
    }
}

