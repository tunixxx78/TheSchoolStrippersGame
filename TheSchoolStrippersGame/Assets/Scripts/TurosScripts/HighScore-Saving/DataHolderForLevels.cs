using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;

public class DataHolderForLevels : MonoBehaviour
{

    public static DataHolderForLevels dataInstance;

    public bool levelOne, levelTwo, levelThree, levelFour, levelFive, animationForLockOne, animationForLockTwo, animationForLockThree, animationForLockFour;
    public int level1Score, level2Score, level3Score, level4Score;

    private void Awake()
    {
        

        LoadData();

        if(dataInstance != null && dataInstance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        dataInstance = this;
        DontDestroyOnLoad(this);


    }

    private void Update()
    {
        // only for developement purposes.
        /*if (Input.GetKeyDown(KeyCode.A))
        {
            levelOne = false;
            levelTwo = false;
            levelThree = false;
            levelFour = false;
            levelFive = false;
            animationForLockOne = false;
            animationForLockTwo = false;
            animationForLockThree = false;
            animationForLockFour = false;
            level1Score = 0;
            level2Score = 0;
            level3Score = 0;
            level4Score = 0;

            SaveData();
        }*/

        
    }

    public void SaveData()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/testdataa.dat");
        LevelData data = new LevelData();

        data.levelOne = levelOne;
        data.levelTwo = levelTwo;
        data.levelThree = levelThree;
        data.levelFour = levelFour;
        data.levelFive = levelFive;

        data.animationForLockOne = animationForLockOne;
        data.animationForLockTwo = animationForLockTwo;
        data.animationForLockThree = animationForLockThree;
        data.animationForLockFour = animationForLockFour;

        data.level1Score = level1Score;
        data.level2Score = level2Score;
        data.level3Score = level3Score;
        data.level4Score = level4Score;

        bf.Serialize(file, data);
        file.Close();
    }

    public void LoadData()
    {
        if(File.Exists(Application.persistentDataPath + "/testdataa.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/testdataa.dat", FileMode.Open);
            LevelData data = (LevelData)bf.Deserialize(file);

            levelOne = data.levelOne;
            levelTwo = data.levelTwo;
            levelThree = data.levelThree;
            levelFour = data.levelFour;
            levelFive = data.levelFive;

            animationForLockOne = data.animationForLockOne;
            animationForLockTwo = data.animationForLockTwo;
            animationForLockThree = data.animationForLockThree;
            animationForLockFour = data.animationForLockFour;

            level1Score = data.level1Score;
            level2Score = data.level2Score;
            level3Score = data.level3Score;
            level4Score = data.level4Score;
        }
    }

}

[Serializable]

class LevelData
{
    public bool levelOne, levelTwo, levelThree, levelFour, levelFive, animationForLockOne, animationForLockTwo, animationForLockThree, animationForLockFour;
    public int level1Score, level2Score, level3Score, level4Score;
}