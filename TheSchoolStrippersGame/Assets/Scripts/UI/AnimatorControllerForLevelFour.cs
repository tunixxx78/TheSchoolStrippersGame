using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorControllerForLevelFour : MonoBehaviour
{
    [SerializeField] Animator lockAnimator;
    public DataHolderForLevels dataHolderForLevels;
    [SerializeField] GameObject lockImage;

    private void Awake()
    {
        if(dataHolderForLevels.levelFour == true)
        {
            lockAnimator.SetTrigger("break");
        }


    }

    private void Update()
    {
        if (dataHolderForLevels.levelFour == true)
        {
            Invoke("AnimationForPlayed", 3f);

        }
        if (dataHolderForLevels.animationForLockFour == true)
        {
            lockImage.SetActive(false);
        }
    }

    private void AnimationForPlayed()
    {
        dataHolderForLevels.animationForLockFour = true;
        dataHolderForLevels.SaveData();
    }

}
