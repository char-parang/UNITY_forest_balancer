using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogScript : MonoBehaviour, Clickable
{
    public Data data;
    public GameManager gm;
    private string group;
    private int code;
    private string[] script1, answer, scriptY, scriptN, resultY, resultN;
    private GameObject canvas, tellObj, nameObj, buttonYes, buttonNo;
    private List<string> toTell = new List<string>();
    private int scriptIdx = 0, seqIdx = 0;
    private Text tell;
    private string[] seq = { "scr1", "ans", "scr2" };
    private int YesNo;

    public void OnEnable()
    {
        gm.setOtherClickable(false);
        canvas = gameObject.transform.Find("Canvas").gameObject;
        tellObj = canvas.transform.Find("text").gameObject;
        nameObj = canvas.transform.Find("name").gameObject;
        buttonYes = canvas.transform.Find("buttonYes").gameObject;
        buttonNo = canvas.transform.Find("buttonNo").gameObject;
        tellObj.SetActive(true);
        nameObj.SetActive(true);
        buttonYes.SetActive(false);
        buttonNo.SetActive(false);

        selectAndPharseScript();

        Animator icons = gameObject.transform.Find("icons").GetComponent<Animator>();
        icons.SetBool(group, true);
        switch (group)
        {
            case "farmer":
                nameObj.GetComponent<Text>().text = "< 농부 >";
                break;
            case "wood":
                nameObj.GetComponent<Text>().text = "< 나무꾼 >";
                break;
            case "deer":
                nameObj.GetComponent<Text>().text = "< 사슴 사냥꾼 >";
                break;
            case "wolf":
                nameObj.GetComponent<Text>().text = "< 늑대 사냥꾼 >";
                break;
        }
        tell = canvas.transform.Find("text").GetComponent<Text>();
        onClicked();
    }

    private void selectAndPharseScript()
    {
        List<string> sc = data.getScript(code, group);
        List<string> s1 = new List<string>(), ans = new List<string>(), s2 = new List<string>(), res = new List<string>();
        for (int i = 0; i < sc.Count; i += 4)
        {
            s1.Add(sc[i]);
            ans.Add(sc[i + 1]);
            s2.Add(sc[i + 2]);
            res.Add(sc[i + 3]);
        }
        int rand = UnityEngine.Random.Range(0, s1.Count - 1);
        string tmps1 = s1[rand];
        string tmpan = ans[rand];
        string tmps2 = s2[rand];
        string tmpre = res[rand];
        script1 = tmps1.Split(';');
        answer = tmpan.Split(':');
        if (tmps2.Split(':').Length > 1)
        {
            string y = tmps2.Split(':')[0];
            string n = tmps2.Split(':')[1];
            scriptY = y.Split(';');
            scriptN = n.Split(';');
        }
        else
        {
            scriptY = tmps2.Split(';');
        }
        if (tmpre.Split(':').Length > 1)
        {
            string resY = tmpre.Split(':')[0];
            string resN = tmpre.Split(':')[1];
            resultY = resY.Split(';');
            resultN = resN.Split(';');
        }
        else
        {
            resultY = tmpre.Split(';');
        }
        toTell = new List<string>(script1);
    }

    public void setGroup(string g)
    {
        group = g;
    }
    public void setCode(int i)
    {
        code = i;
    }

    public void onClicked()
    {
        switch (seq[seqIdx])
        {
            case "scr1":
                tell.text = toTell[scriptIdx++];
                if (toTell.Count <= scriptIdx)  seqIdx++;
                break;
            case "ans":
                gameObject.GetComponent<Collider2D>().enabled = false;
                tellObj.SetActive(false);
                nameObj.SetActive(false);
                buttonYes.SetActive(true);
                buttonYes.transform.GetChild(0).GetComponent<Text>().text = answer[0];
                if (answer.Length > 1)
                {
                    buttonNo.SetActive(true);
                    buttonNo.transform.GetChild(0).GetComponent<Text>().text = answer[1];
                }
                break;
            case "scr2":
                if (toTell.Count <= scriptIdx) { 
                    gameObject.SetActive(false); 
                    setResult(YesNo);
                    scriptIdx = 0;
                    seqIdx = 0;
                    gm.setOtherClickable(true);
                    break; 
                }
                tell.text = toTell[scriptIdx++];
                break;
        }
    }

    public void yesClicked()
    {
        YesNo = 0;
        seqIdx++;
        scriptIdx = 0;
        toTell.Clear();
        toTell = new List<string>(scriptY);
        gameObject.GetComponent<Collider2D>().enabled = true;
        tellObj.SetActive(true);
        nameObj.SetActive(true);
        buttonYes.SetActive(false);
        buttonNo.SetActive(false);
        onClicked();
    }
    public void noClicked()
    {
        YesNo = 1;
        seqIdx++;
        scriptIdx = 0;
        toTell.Clear();
        toTell = new List<string>(scriptN);
        tellObj.SetActive(true);
        nameObj.SetActive(true);
        buttonYes.SetActive(false);
        buttonNo.SetActive(false);
        gameObject.GetComponent<Collider2D>().enabled = true;
        onClicked();
    }

    private void setResult(int x)
    {

    }
}
