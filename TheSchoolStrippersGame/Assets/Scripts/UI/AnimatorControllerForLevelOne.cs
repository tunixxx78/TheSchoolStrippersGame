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

        Invoke("AnimationForPlayed", 3f);

        if(dataHolderForLevels.levelTwo)
        {
            GameObject.Find("Level2").GetComponent<LevelSelection>().UpdateLevelImage();
        }

    }

    private void Update()
    {
        
        if(dataHolderForLevels.animationForLockOne == true)
        {
            lockImage.SetActive(false);
        }
    }

    private void AnimationForPlayed()
    {
        dataHolderForLevels.animationForLockOne = true;
        dataHolderForLevels.SaveData();
    }

}
