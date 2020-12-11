using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventManager : MonoBehaviour, ScrollControlable
{
    private List<GameObject> holdingButton = new List<GameObject>();
    public AudioSource aud;
    private bool scrTrig = false;
    private AudioSource es;

    void Start()
    {
        es = gameObject.GetComponent<AudioSource>();
        es.volume = 0.5f;
    }

    void Update()
    {
        if (Input.GetMouseButton(0)) mouseDown();
        if (Input.GetMouseButtonUp(0)) mouseUp();
    }

    private void mouseDown()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

        RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
        if (!scrTrig && hit.collider != null && hit.collider.GetComponent<Scrollable>() != null)
        {
            scrTrig = true;
            holdingButton.Add(hit.collider.gameObject);
            Animator anim = holdingButton[holdingButton.Count - 1].GetComponent<Animator>();
            anim.SetBool("hold", true);
            aud.Play();
        }
        if (scrTrig)
        {
            Scrollable s = holdingButton[holdingButton.Count-1].GetComponent<Scrollable>();
            if(s != null)
            {
                s.onScrolled(mousePos.x, mousePos.y);
            }
        }

        if(!scrTrig && hit.collider != null && !holdingButton.Contains(hit.collider.gameObject))
        {
            GameObject cur = hit.collider.gameObject;
            if (cur.GetComponent<Button>() != null)
                if (!cur.GetComponent<Button>().interactable) return;
            holdingButton.Add(hit.collider.gameObject);
            Animator anim = holdingButton[holdingButton.Count - 1].GetComponent<Animator>();
            anim.SetBool("hold", true);
            aud.Play();
            if (holdingButton.Count > 1)
            {
                for (int i = 0; i < holdingButton.Count - 1; i++)
                {
                    anim = holdingButton[0].GetComponent<Animator>();
                    anim.SetBool("hold", false);
                    holdingButton.RemoveAt(0);
                }
            }
        }
    }

    private void mouseUp()
    {
        scrTrig = false;
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

        RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

        if (holdingButton.Count > 0)
        {
            Animator anim = holdingButton[holdingButton.Count - 1].GetComponent<Animator>();
            anim.SetBool("hold", false);
            if (hit.collider != null)
            {
                Clickable ca = holdingButton[holdingButton.Count - 1].GetComponent<Clickable>();
                ca.onClicked();
            }
            holdingButton.RemoveAt(holdingButton.Count - 1);
        }

        
        /*else holdingButton.Clear();*/
    }

    public void setAmount(float ratio, string code)
    {
        es.volume = ratio;
    }
}