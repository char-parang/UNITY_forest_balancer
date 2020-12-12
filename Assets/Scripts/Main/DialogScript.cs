using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogScript : MonoBehaviour
{
    public Data data;
    private string group;
    private int code;
    private List<string> script1 = new List<string>(), 
        answer = new List<string>(), 
        script2 = new List<string>(), 
        results = new List<string>();

    public void OnEnable()
    {

        Debug.Log(group + code);
        List<string> sc = data.getScript(code, group);

        for(int i = 0; i < sc.Count; i+=4)
        {
            script1.Add(sc[i]);
            answer.Add(sc[i + 1]);
            script2.Add(sc[i + 2]);
            results.Add(sc[i + 3]);
        }
        Animator icons = gameObject.transform.Find("icons").GetComponent<Animator>();
        GameObject canvas = gameObject.transform.Find("Canvas").gameObject;
        icons.SetBool(group, true);
        switch (group)
        {
            case "farmer":
                canvas.transform.Find("name").GetComponent<Text>().text = "< 농부 >";
                break;
            case "wood":
                canvas.transform.Find("name").GetComponent<Text>().text = "< 나무꾼 >";
                break;
            case "deer":
                canvas.transform.Find("name").GetComponent<Text>().text = "< 사슴 사냥꾼 >";
                break;
            case "wolf":
                canvas.transform.Find("name").GetComponent<Text>().text = "< 늑대 사냥꾼 >";
                break;
        }
        canvas.transform.GetChild(1).GetComponent<Text>().text = script1[0];
    }

    public void setGroup(string g)
    {
        group = g;
    }
    public void setCode(int i)
    {
        code = i;
    }
}
