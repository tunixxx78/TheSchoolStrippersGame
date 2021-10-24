using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorControllerForLevelThree : MonoBehaviour
{
    [SerializeField] Animator lockAnimator;
    public DataHolderForLevels dataHolderForLevels;

    private void Awake()
    {
        if(dataHolderForLevels.levelThree == true)
        {
            lockAnimator.SetTrigger("break");
        }

    }
    
}
