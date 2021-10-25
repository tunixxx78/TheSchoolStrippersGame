using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorControllerForLevelTwo : MonoBehaviour
{
    [SerializeField] Animator lockAnimator;
    public DataHolderForLevels dataHolderForLevels;
    [SerializeField] GameObject lockImage;

    private void Awake()
    {
        if(dataHolderForLevels.levelTwo == true)
        {
            lockAnimator.SetTrigger("break");
        }
    }

    private void Update()
    {
        if (dataHolderForLevels.levelTwo == true)
        {
            Invoke("AnimationForPlayed", 3f);

        }
        if (dataHolderForLevels.animationForLockTwo == true)
        {
            lockImage.SetActive(false);
        }
    }

    private void AnimationForPlayed()
    {
        dataHolderForLevels.animationForLockTwo = true;
        dataHolderForLevels.SaveData();
    }
}
