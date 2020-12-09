using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculatorScript : MonoBehaviour
{
    private Data data;
    public CalculatorScript()
    {
    }
    public void calculNum(out int[] res, int[] cur, int[] harv, int money)
    {
        int[] result = new int[4];
        // 수확
        float farm = cur[0];
        float wood = cur[1] - harv[1];
        float deer = cur[2] - harv[2];
        float wolf = cur[3] - harv[3];

        // 천적관계에 의한 감소
        wood -= 0.3f * deer;
        deer -= 0.2f * wolf;
        deer = (deer > wood * 0.4f) ? wood * 0.4f : deer;
        wolf = (wolf > deer * 0.3f) ? deer * 0.3f : wolf;

        // 회복에 의한 증가
        wood += wood * 0.1f;
        deer += deer * 0.4f;
        wolf += wolf * 0.2f;


        result[0] = Convert.ToInt32(farm);
        result[1] = Convert.ToInt32(wood + money);
        result[2] = Convert.ToInt32(deer + deer * money / 3000);
        result[3] = Convert.ToInt32(wolf + wolf * money / 3000);

        res = result;
    }

    public void calculSat(out int[] res, out string[] t, int[] cur,  int[] harv, int[] needs, int itemBuf) {
        int[] result = new int[4];
        t = new string[4];

        for(int i = 0; i < 4; i++)
        {
            if (needs[i] > harv[i] * 2)
            {
                result[i] = cur[i] - 25;
                t[i] = "<<";
            }
            else if (needs[i] > harv[i])
            {
                result[i] = cur[i] - 10;
                t[i] = "<";
            }
            else if (needs[i] * 2 < harv[i])
            {
                result[i] = cur[i] + 25;
                t[i] = ">>";
            }
            else if (needs[i] < harv[i])
            {
                result[i] = cur[i] + 10;
                t[i] = ">";
            }
            else
            {
                result[i] = cur[i];
                t[i] = "|";
            }

            if (result[i] > 100)
                result[i] = 100;
            else if(result[i] < 0)
            {
                result[i] = 0;
                t[i] = "X";
            }

            result[i] += itemBuf;
        }

        res = result;
    }

    public void calculNeeds(out int[] needs, int[] prevNeeds)
    {
        int[] result = new int[4];

        if(prevNeeds[0] == 0&& prevNeeds[1] ==0&& prevNeeds[2] ==0&& prevNeeds[3] == 0)
        {
            for(int i = 0; i < 4; i++)
                result[i] = UnityEngine.Random.Range(3, 9);
            
        }
        else
        {
            for (int i = 0; i < 4; i++)
                result[i] = (result[i] + UnityEngine.Random.Range(-3, 3) > 10)?
                    9 : (result[i] + UnityEngine.Random.Range(-3, 3) <= 0)?
                    1: result[i] + UnityEngine.Random.Range(-3, 3);
        }

        needs = result;
    }

    public int calculMoney(out int[] money, int[] harv, int skillBuf)
    {
        int sum = 0;
        int[] tmp = new int[4];
        tmp[0] = harv[0] * 1;
        tmp[1] = harv[1] * 1;
        tmp[2] = harv[2] * 5;
        tmp[3] = harv[3] * 15;
        for (int i = 0; i < 4; i++)
            sum += tmp[i];
        money = tmp;
        return sum;
    }
}

