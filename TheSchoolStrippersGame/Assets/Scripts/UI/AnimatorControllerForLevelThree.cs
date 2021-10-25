using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorControllerForLevelThree : MonoBehaviour
{
    [SerializeField] Animator lockAnimator;
    public DataHolderForLevels dataHolderForLevels;
    [SerializeField] GameObject lockImage;

    private void Awake()
    {
        if(dataHolderForLevels.levelThree == true)
        {
            lockAnimator.SetTrigger("break");
        }

    }

    private void Update()
    {
        if (dataHolderForLevels.levelThree == true)
        {
            Invoke("AnimationForPlayed", 3f);

        }
        if (dataHolderForLevels.animationForLockThree == true)
        {
            lockImage.SetActive(false);
        }
    }

    private void AnimationForPlayed()
    {
        dataHolderForLevels.animationForLockThree = true;
        dataHolderForLevels.SaveData();
    }

}
