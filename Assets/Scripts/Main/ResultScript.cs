using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultScript : MonoBehaviour
{
    public Data data;
    public ResultNextScript next;

    public void OnEnable()
    {
        int[] prev = data.getPrevNum();
        int[] cur = data.getUserForestUnits();
        int[] sat = data.getSats();
        GameObject bg = gameObject.transform.Find("Background").gameObject;

        if(prev[0] > 2)
        {
            bg.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = "<color=red>식량 생산 요구량을  3달째 충족하지 못했습니다.\n마을사람들이 통제에서 벗어납니다.</color>";
            next.endcode = 0;
        }
        else if (prev[0] > 1)
        {
            bg.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = "식량 생산 요구량을 " + prev[0] + "달째 충족하지 못했습니다.\n" +
                "앞으로 " + (3 - prev[0]) + "달 더 생산량을 충족하지 못할 경우 마을 사람들이 통제에서 벗어날 것입니다.";
            bg.transform.GetChild(0).GetChild(1).GetComponent<Text>().text = "!!!";
        }
        else
        {
            bg.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = "필요한 식량 식량 생산 요구량을 충족했습니다.";
            bg.transform.GetChild(0).GetChild(1).GetComponent<Text>().text = "-";
        }

        for (int i = 1; i < 4; i++)
        {
            int stack = 0;
            GameObject tmp = bg.transform.GetChild(i).gameObject;
            string incdec = "", group = "", d = "", person = "";
            switch (i)
            {
                case 1:
                    group = "나무";
                    d = "그루";
                    person = "나무꾼";
                    break;
                case 2:
                    group = "사슴";
                    d = "마리";
                    person = "사슴 사냥꾼";
                    break;
                case 3:
                    group = "늑대";
                    d = "마리";
                    person = "사슴 사냥꾼";
                    break;
            }
            if (prev[i] > cur[i])
            {
                incdec = "<color=red>감소</color>";
                stack++;
            }
            else if (prev[i] < cur[i])
                incdec = "<color=green>증가</color>";
            else
                incdec = "<color=green>유지</color>";
            if (prev[i] <= 0)
            {
                tmp.GetComponent<SpriteRenderer>().color = Color.gray;
                tmp.transform.GetChild(0).GetComponent<Text>().text = group + "는 멸종되었습니다.\n물론 " + person + "이 모두 떠난 것은 당연한 일이지요.";
                tmp.transform.GetChild(1).GetComponent<Text>().text = "X";
            }
            else
            {
                tmp.transform.GetChild(0).GetComponent<Text>().text = group + " 개체 수가 " + prev[i] + d + "에서 " + cur[i] + d + "로 " + incdec + "했습니다.\n";
                if (cur[i] <= 0)
                    tmp.transform.GetChild(0).GetComponent<Text>().text = "세상에! <color=red>" + group + "(이)가 멸종했습니다!</color>";
                if (sat[i] > 50)
                    tmp.transform.GetChild(0).GetComponent<Text>().text += person + "의 만족도가 <color=green>높습니다.</color> 훌륭하게 조율하고 있군요.";
                else if (sat[i] > 30)
                    tmp.transform.GetChild(0).GetComponent<Text>().text += person + "의 만족도가 보통입니다. 아직까진 괜찮아요.";
                else
                {
                    tmp.transform.GetChild(0).GetComponent<Text>().text += person + "의 만족도가 <color=red>낮습니다.</color> 주의하는 것이 좋겠어요.";
                    stack++;
                }
                if(stack > 0)
                    tmp.transform.GetChild(1).GetComponent<Text>().text = "!!!";
                else
                    tmp.transform.GetChild(1).GetComponent<Text>().text = "-";
            }
        }
        int exNum = 0;
        int ex = 0;
        for (int i = 0; i < 3; i++)
        {
            if (cur[i] <= 0)
            {
                exNum++;
                ex += (i + 1) * (i + 1);
            }
        }
        if (exNum > 1)
        {
            switch (ex)
            {
                case 1 + 4:
                    next.endcode = 2;
                    break;
                case 1 + 9:
                    next.endcode = 1;
                    break;
                case 4 + 9:
                    next.endcode = 3;
                    break;
            }
        }
        if (data.getUserMonth() > 20)
        {
            if (data.getFactoryActivate() && exNum > 0)
                next.endcode = 4;
            if (data.getFactoryActivate())
                next.endcode = 6;
            else
                next.endcode = 5;
        }
    }
}
