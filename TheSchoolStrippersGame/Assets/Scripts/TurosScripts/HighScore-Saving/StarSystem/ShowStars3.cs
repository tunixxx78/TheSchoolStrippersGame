using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowStars3 : MonoBehaviour
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

        if (dataHolderForLevels.levelFive == true)
        {
            if (dataHolderForLevels.level4Score > 0 && dataHolderForLevels.level4Score < oneStar)
            {
                star1.SetActive(true);
            }
            else if (dataHolderForLevels.level4Score > twoStars && dataHolderForLevels.level4Score > 0 && dataHolderForLevels.level4Score < threeStars)
            {
                star1.SetActive(true);
                star2.SetActive(true);
            }

            else if (dataHolderForLevels.level4Score >= threeStars)
            {
                star1.SetActive(true);
                star2.SetActive(true);
                star3.SetActive(true);
            }
        }
    }
}
