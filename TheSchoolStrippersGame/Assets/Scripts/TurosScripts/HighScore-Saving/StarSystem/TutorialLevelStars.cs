using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialLevelStars : MonoBehaviour
{
    DataHolderForLevels dataHolderForLevels;
    [SerializeField] GameObject star1, star2, star3;

    private void Awake()
    {
        dataHolderForLevels = FindObjectOfType<DataHolderForLevels>();
    }

    private void Update()
    {
        if(dataHolderForLevels.levelOne == true)
        {
            star1.SetActive(true);
            star2.SetActive(true);
            star3.SetActive(true);
        }
    }
}
