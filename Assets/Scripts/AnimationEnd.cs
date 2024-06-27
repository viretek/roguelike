using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEnd : MonoBehaviour
{    
    public void TheEnd()
    {
        GetComponent<Animator>().speed = 0;
    }
}
