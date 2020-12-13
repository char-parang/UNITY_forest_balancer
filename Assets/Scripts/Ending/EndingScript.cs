using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndingScript : MonoBehaviour
{
    public GameObject endingImage;
    private Data data;
    public int endcode;
    private GameObject[] imgList;
    public Text t;
    private int idx = 0;
    private string[] scripts;

    void Start()
    {
        data = new Data();
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
        imgList[idx].SetActive(false);
        idx++;
        imgList[idx].SetActive(true);
        t.text = scripts[idx];
        if (idx >= imgList.Length)
        {
            string[] c = { "*" };
            data.deleteData("Char_info", "Char_num=1");
            data.insertData(c, "Char_info", true);
            data.deleteData("PreviousNum", "code=1");
            data.insertData(c, "PreviousNum", true);
            SceneManager.LoadScene("Title");
        }
    }
}
