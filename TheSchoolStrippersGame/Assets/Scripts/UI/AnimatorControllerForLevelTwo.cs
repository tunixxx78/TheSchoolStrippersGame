using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorControllerForLevelTwo : MonoBehaviour
{
    [SerializeField] Animator lockAnimator;
    public DataHolderForLevels dataHolderForLevels;

    private void Awake()
    {
        if(dataHolderForLevels.levelTwo == true)
        {
            lockAnimator.SetTrigger("break");
        }
    }
    
}
