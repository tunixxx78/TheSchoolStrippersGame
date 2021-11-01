using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowStars2 : MonoBehaviour
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

        if (dataHolderForLevels.levelFour == true)
        {
            if (dataHolderForLevels.level3Score > 0 && dataHolderForLevels.level3Score < oneStar)
            {
                star1.SetActive(true);
            }
            else if (dataHolderForLevels.level3Score > twoStars && dataHolderForLevels.level3Score > 0 && dataHolderForLevels.level3Score < threeStars)
            {
                star1.SetActive(true);
                star2.SetActive(true);
            }

            else if (dataHolderForLevels.level3Score >= threeStars)
            {
                star1.SetActive(true);
                star2.SetActive(true);
                star3.SetActive(true);
            }
        }
    }
}
