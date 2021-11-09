using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorControllerForLevelTwo : MonoBehaviour
{
    [SerializeField] Animator lockAnimator;
    public DataHolderForLevels dataHolderForLevels;
    [SerializeField] GameObject lockImage;
    SFXManager sFXManager;

    private void Awake()
    {
        dataHolderForLevels = FindObjectOfType<DataHolderForLevels>();
        sFXManager = FindObjectOfType<SFXManager>();

        if (dataHolderForLevels.levelTwo == true && dataHolderForLevels.animationForLockTwo == false)
        {
            lockAnimator.SetTrigger("break");
            sFXManager.OpeningLock();

            //GameObject.Find("Level3").GetComponent<LevelSelection>().UpdateLevelImage();
        }
    }

    private void Update()
    {
        if (dataHolderForLevels.levelTwo == true)
        {
            Invoke("AnimationForPlayed", 2f);

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
