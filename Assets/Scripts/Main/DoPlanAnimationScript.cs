using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoPlanAnimationScript : MonoBehaviour
{
    private bool[] fails;
    Animator animator;
    private bool finish;
    private GameObject obj;
    public Data data;
    private int[] nums;
    private int[] money;

    public void OnEnable()
    {
        startAnimation();
    }
    public void setFail(bool[] f)
    {
        fails = f;
    }

    internal void setAnimFinish(bool v)
    {
        finish = v;
    }

    public void startAnimation()
    {
        drawAnim("farmer", 0);
        StartCoroutine(waitAndDraoAnim("wood", 1));
        StartCoroutine(waitAndDraoAnim("deer", 2));
        StartCoroutine(waitAndDraoAnim("wolf", 3));
    }

    private void drawAnim(string animName, int idx)
    {
        obj = gameObject.transform.Find(animName).gameObject;
        Text t = obj.transform.Find("Text").GetComponent<Text>();
        t.text = data.getRandomWorkScipt(1, idx);
        animator = obj.GetComponent<Animator>();
        obj.SetActive(true);
        animator.Play(animName);
        StartCoroutine(waitFinishFirst(3, animName, idx));
    }

    private IEnumerator waitFinishFirst(float a, string animName, int idx)
    {
        yield return new WaitForSeconds(a);
        obj = gameObject.transform.Find(animName).gameObject;
        Text t = obj.transform.Find("Text").GetComponent<Text>();
        if (fails[idx])
        {
            animator.Play(animName + "_fail");
            string[] tmp = data.getRandomWorkScipt(3, idx).Split(';');
            t.text = tmp[0] + nums[idx] + tmp[1] + money[idx] + tmp[2];
        }
        else
        {
            animator.Play(animName+"_again");
            string[] tmp = data.getRandomWorkScipt(2, idx).Split(';');
            t.text = tmp[0] + nums[idx] + tmp[1] + money[idx] + tmp[2];
        }
        StartCoroutine(waitFinishSecond(3, animName));
    }

    private IEnumerator waitFinishSecond(float a, string animName)
    {
        yield return new WaitForSeconds(a);
        obj = gameObject.transform.Find(animName).gameObject;
        obj.SetActive(false);
    }

    private IEnumerator waitAndDraoAnim(string animName, int idx)
    {
        yield return new WaitForSeconds(6*idx);
        drawAnim(animName, idx);
    }

    public void setNums(int[] n)
    {
        nums = n;
    }

    public void setMoney(int[] m)
    {
        money = m;
    }

}
