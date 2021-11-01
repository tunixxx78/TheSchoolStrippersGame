using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowStars1 : MonoBehaviour
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

        if (dataHolderForLevels.levelThree == true)
        {
            if (dataHolderForLevels.level2Score > 0 && dataHolderForLevels.level2Score < oneStar)
            {
                star1.SetActive(true);
            }
            else if (dataHolderForLevels.level2Score > twoStars && dataHolderForLevels.level2Score > 0 && dataHolderForLevels.level2Score < threeStars)
            {
                star1.SetActive(true);
                star2.SetActive(true);
            }

            else if (dataHolderForLevels.level2Score >= threeStars)
            {
                star1.SetActive(true);
                star2.SetActive(true);
                star3.SetActive(true);
            }
        }
    }
}
