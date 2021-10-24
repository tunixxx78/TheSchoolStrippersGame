using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorControllerForLevelFour : MonoBehaviour
{
    [SerializeField] Animator lockAnimator;
    public DataHolderForLevels dataHolderForLevels;

    private void Awake()
    {
        if(dataHolderForLevels.levelFour == true)
        {
            lockAnimator.SetTrigger("break");
        }


    }
    
}
