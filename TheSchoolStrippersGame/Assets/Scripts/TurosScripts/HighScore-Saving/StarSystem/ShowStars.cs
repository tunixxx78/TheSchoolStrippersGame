using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowStars : MonoBehaviour
{
    public DataHolderForLevels dataHolderForLevels;
    [SerializeField] GameObject star1, star2, star3;
    [SerializeField] int oneStar, twoStars, threeStars;

    private void Awake()
    {
        dataHolderForLevels = FindObjectOfType<DataHolderForLevels>();
    }

    private void Update()
    {

        if (dataHolderForLevels.levelTwo == true)
        {
            if (dataHolderForLevels.level1Score > 0 && dataHolderForLevels.level1Score < oneStar)
            {
                star1.SetActive(true);
            }
            else if (dataHolderForLevels.level1Score > twoStars && dataHolderForLevels.level1Score > 0 && dataHolderForLevels.level1Score < threeStars)
            {
                star1.SetActive(true);
                star2.SetActive(true);
            }

            else if (dataHolderForLevels.level1Score >= threeStars)
            {
                star1.SetActive(true);
                star2.SetActive(true);
                star3.SetActive(true);
            }
        }
    }
}
