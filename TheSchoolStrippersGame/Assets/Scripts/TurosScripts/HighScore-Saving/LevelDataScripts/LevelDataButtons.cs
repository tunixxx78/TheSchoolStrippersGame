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

        if(ScoringSystem.theScore > DataHolderForLevels.dataInstance.level1Score)
        {
            DataHolderForLevels.dataInstance.level1Score = ScoringSystem.theScore;
        }
        
        DataHolderForLevels.dataInstance.SaveData();
    }

    public void LevelThreeDone()
    {
        DataHolderForLevels.dataInstance.levelThree = true;

        if (ScoringSystem.theScore > DataHolderForLevels.dataInstance.level2Score)
        {
            DataHolderForLevels.dataInstance.level2Score = ScoringSystem.theScore;
        }
        
        DataHolderForLevels.dataInstance.SaveData();
    }

    public void LevelFourDone()
    {
        DataHolderForLevels.dataInstance.levelFour = true;

        if (ScoringSystem.theScore > DataHolderForLevels.dataInstance.level3Score)
        {
            DataHolderForLevels.dataInstance.level3Score = ScoringSystem.theScore;
        }
        DataHolderForLevels.dataInstance.SaveData();
    }

    public void LevelFiveDone()
    {
        DataHolderForLevels.dataInstance.levelFive = true;

        if (ScoringSystem.theScore > DataHolderForLevels.dataInstance.level4Score)
        {
            DataHolderForLevels.dataInstance.level4Score = ScoringSystem.theScore;
        }
        DataHolderForLevels.dataInstance.SaveData();
    }
}
