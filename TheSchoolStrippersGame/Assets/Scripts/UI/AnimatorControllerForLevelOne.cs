using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorControllerForLevelOne : MonoBehaviour
{
    [SerializeField] Animator lockAnimator;
    public DataHolderForLevels dataHolderForLevels;
    [SerializeField] GameObject lockImage;
    SFXManager sFXManager;

    private void Awake()
    {
        dataHolderForLevels = FindObjectOfType<DataHolderForLevels>();
        sFXManager = FindObjectOfType<SFXManager>();

        lockAnimator.SetTrigger("break");
        sFXManager.OpeningLock();

        Invoke("AnimationForPlayed", 2f);

    }


    private void AnimationForPlayed()
    {
        dataHolderForLevels.animationForLockOne = true;
        dataHolderForLevels.SaveData();
    }

}
