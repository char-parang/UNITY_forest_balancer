using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScript : MonoBehaviour, Clickable
{

    public RuntimeAnimatorController click, tswitch;
    private Animator anim;
    private bool cable= false;

    public void onClicked()
    {
        anim.runtimeAnimatorController = tswitch;
        /*anim.GetCurrentAnimatorStateInfo();*/
    }

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.runtimeAnimatorController = click;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
