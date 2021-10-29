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
        dataHolderForLevels = FindObjectOfType<DataHolderForLevels>();

        if (dataHolderForLevels.levelThree == true)
        {
            lockAnimator.SetTrigger("break");
            GameObject.Find("Level4").GetComponent<LevelSelection>().UpdateLevelImage();
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
