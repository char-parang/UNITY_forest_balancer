using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculatorScript : MonoBehaviour
{
    public void calculNum(out int[] res, int[] cur, int[] harv)
    {
        int[] result = new int[4];
        // 수확
        int farm = cur[0] * 100;
        int wood = cur[1] - harv[1];
        int deer = cur[2] - harv[2];
        int wolf = cur[3] - harv[3];

        // 천적관계에 의한 감소
        wood -= Convert.ToInt32(0.1f * deer);
        deer -= Convert.ToInt32((0.1f * wolf > wood * 0.3) ? 0.1f * wolf : wood * 0.3);
        wolf = Convert.ToInt32((wolf > deer * 0.8f) ? deer * 0.8f : wolf);

        // 회복에 의한 증가
        wood += Convert.ToInt32(wood * 0.2f);
        deer += Convert.ToInt32(deer * 0.3f);
        wolf += Convert.ToInt32(wolf * 0.3f);

        result[0] = farm;
        result[1] = wood;
        result[2] = deer;
        result[3] = wolf;

        res = result;
    }
}

