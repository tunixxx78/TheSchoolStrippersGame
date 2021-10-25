using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    [SerializeField] Animator lockAnimator;
    public DataHolderForLevels dataHolderForLevels;

    private void Awake()
    {
        
            lockAnimator.SetTrigger("break");
        


    }
    
}
