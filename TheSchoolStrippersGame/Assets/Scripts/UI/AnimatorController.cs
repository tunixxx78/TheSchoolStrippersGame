using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    [SerializeField] Animator lockAnimator;
    public DataHolderForLevels dataHolderForLevels;

    private void Awake()
    {
        if(dataHolderForLevels.levelOne == true)
        {
            lockAnimator.SetTrigger("break");
        }


    }
    
}