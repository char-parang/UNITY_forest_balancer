using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndingScript : MonoBehaviour
{
    public GameObject endingImage;
    public Data data;
    public int endcode;
    private GameObject[] imgList;
    public Text t;
    private int idx = 0;
    private string[] scripts;

    void Start()
    {
        endcode = getEnd();
        Debug.Log(endcode);
        scripts = data.getEndingScript(endcode);
        string end = "ending";
        end += endcode.ToString();
        GameObject x = endingImage.transform.Find(end).gameObject;
        int num = x.transform.childCount;
        imgList = new GameObject[num];
        for(int i = 0; i < num; i++)
        {
            imgList[i] = x.transform.GetChild(i).gameObject;
        }
        x.SetActive(true);
        imgList[0].SetActive(true);
        t.text = scripts[0];
    }

    public void OnClick()
    {
        if (idx >= imgList.Length-1)
        {
            string[] c = { "*" };
            data.deleteData("Char_info", "Char_num=1");
            data.insertData(c, "Char_info", true);
            data.deleteData("PreviousNum", "code=1");
            data.insertData(c, "PreviousNum", true);
            SceneManager.LoadScene("Title");
            return;
        }
        imgList[idx].SetActive(false);
        idx++;
        imgList[idx].SetActive(true);
        t.text = scripts[idx];
    }

    public int getEnd()
    {
        int[] cur = data.getUserForestUnits();
        Debug.Log(cur[0].ToString()+cur[1].ToString()+cur[2].ToString()+cur[3]);
        int[] prev = data.getPrevNum();
        int exNum = 0;
        int ex = 0;
        int code = -1;
        if (prev[0] > 2)
            code = 0;
        for (int i = 0; i < 3; i++) {
            if (cur[i + 1] <= 0)
            {
                exNum++;
                ex += (i+1) * (i+1);
            }
        }
        if(exNum > 1)
        {
            switch (ex)
            {
                case 5:
                    code = 2;
                    break;
                case 10:
                    code = 1;
                    break;
                case 13:
                    code = 3;
                    break;
            }
        }
        if(data.getUserMonth() > 20)
        {
            if (exNum > 0)
                code = 4;
            else if (data.getFactoryActivate())
                code = 6;
            else
                code = 5;
        }
        return code;
    }
}
