using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorControllerForLevelOne : MonoBehaviour
{
    [SerializeField] Animator lockAnimator;
    public DataHolderForLevels dataHolderForLevels;
    [SerializeField] GameObject lockImage;

    private void Awake()
    {
        dataHolderForLevels = FindObjectOfType<DataHolderForLevels>();

        lockAnimator.SetTrigger("break");

        Invoke("AnimationForPlayed", 2f);

    }


    private void AnimationForPlayed()
    {
        dataHolderForLevels.animationForLockOne = true;
        dataHolderForLevels.SaveData();
    }

}
