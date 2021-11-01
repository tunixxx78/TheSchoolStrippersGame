using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDataButtons : MonoBehaviour
{
    public DataHolderForLevels dataHolderForLevels;

    
    public void LevelOneDone()
    {
        DataHolderForLevels.dataInstance.levelOne = true;
        DataHolderForLevels.dataInstance.SaveData();
    }

    public void LevelTwoDone()
    {
        DataHolderForLevels.dataInstance.levelTwo = true;
        DataHolderForLevels.dataInstance.level1Score = ScoringSystem.theScore;
        DataHolderForLevels.dataInstance.SaveData();
    }

    public void LevelThreeDone()
    {
        DataHolderForLevels.dataInstance.levelThree = true;
        DataHolderForLevels.dataInstance.level2Score = ScoringSystem.theScore;
        DataHolderForLevels.dataInstance.SaveData();
    }

    public void LevelFourDone()
    {
        DataHolderForLevels.dataInstance.levelFour = true;
        DataHolderForLevels.dataInstance.level3Score = ScoringSystem.theScore;
        DataHolderForLevels.dataInstance.SaveData();
    }

    public void LevelFiveDone()
    {
        DataHolderForLevels.dataInstance.levelFive = true;
        DataHolderForLevels.dataInstance.level4Score = ScoringSystem.theScore;
        DataHolderForLevels.dataInstance.SaveData();
    }
}
