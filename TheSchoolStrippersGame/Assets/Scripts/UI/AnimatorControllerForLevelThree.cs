using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorControllerForLevelThree : MonoBehaviour
{
    [SerializeField] Animator lockAnimator;
    public DataHolderForLevels dataHolderForLevels;
    [SerializeField] GameObject lockImage;
    SFXManager sFXManager;

    private void Awake()
    {
        dataHolderForLevels = FindObjectOfType<DataHolderForLevels>();
        sFXManager = FindObjectOfType<SFXManager>();

        if (dataHolderForLevels.levelThree == true && dataHolderForLevels.animationForLockThree == false)
        {
            lockAnimator.SetTrigger("break");
            sFXManager.OpeningLock();
            //GameObject.Find("Level4").GetComponent<LevelSelection>().UpdateLevelImage();
        }

    }

    private void Update()
    {
        if (dataHolderForLevels.levelThree == true)
        {
            Invoke("AnimationForPlayed", 2f);

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
