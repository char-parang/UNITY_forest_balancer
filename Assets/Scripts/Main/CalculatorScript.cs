using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculatorScript : MonoBehaviour
{
    public void calculNum(out int[] res, int[] cur, int[] harv, int money)
    {
        int[] result = new int[4];
        // 수확
        float farm = cur[0] * 100;
        float wood = cur[1] - harv[1];
        float deer = cur[2] - harv[2];
        float wolf = cur[3] - harv[3];

        // 천적관계에 의한 감소
        wood -= 0.3f * deer;
        deer -= 0.2f * wolf;
        deer = (deer > wood * 0.4f) ? wood * 0.4f : deer;
        wolf = (wolf > deer * 0.4f) ? deer * 0.4f : wolf;

        // 회복에 의한 증가
        wood += wood * 0.1f;
        deer += deer * 0.4f;
        wolf += wolf * 0.2f;

        float x = 1;
        if (money > 0)
            x = money * 2 / 100;

        result[0] = Convert.ToInt32(farm * x);
        result[1] = Convert.ToInt32(wood * x);
        result[2] = Convert.ToInt32(deer * x);
        result[3] = Convert.ToInt32(wolf * x);

        res = result;
    }
}

