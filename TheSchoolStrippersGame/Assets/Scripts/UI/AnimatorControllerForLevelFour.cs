using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorControllerForLevelFour : MonoBehaviour
{
    [SerializeField] Animator lockAnimator;
    public DataHolderForLevels dataHolderForLevels;
    [SerializeField] GameObject lockImage;
    SFXManager sFXManager;

    private void Awake()
    {
        dataHolderForLevels = FindObjectOfType<DataHolderForLevels>();
        sFXManager = FindObjectOfType<SFXManager>();

        if (dataHolderForLevels.levelFour == true && dataHolderForLevels.animationForLockFour == false)
        {
            lockAnimator.SetTrigger("break");
            sFXManager.OpeningLock();

            //GameObject.Find("Level5").GetComponent<LevelSelection>().UpdateLevelImage();
        }


    }

    private void Update()
    {
        if (dataHolderForLevels.levelFour == true)
        {
            Invoke("AnimationForPlayed", 2f);

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
