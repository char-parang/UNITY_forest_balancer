using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventScript : MonoBehaviour
{
    public DoPlanAnimationScript dpa;
    public void animFinishNotice()
    {
        dpa.setAnimFinish(true);
    }
}
