using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;

public class DataHolderForLevels : MonoBehaviour
{

    public static DataHolderForLevels dataInstance;

    public bool levelOne, levelTwo, levelThree, levelFour, levelFive;

    

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

    public void SaveData()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/testdata.dat");
        LevelData data = new LevelData();

        data.levelOne = levelOne;
        data.levelTwo = levelTwo;
        data.levelThree = levelThree;
        data.levelFour = levelFour;
        data.levelFive = levelFive;

        bf.Serialize(file, data);
        file.Close();
    }

    public void LoadData()
    {
        if(File.Exists(Application.persistentDataPath + "/testdata.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/testdata.dat", FileMode.Open);
            LevelData data = (LevelData)bf.Deserialize(file);

            levelOne = data.levelOne;
            levelTwo = data.levelTwo;
            levelThree = data.levelThree;
            levelFour = data.levelFour;
            levelFive = data.levelFive;
        }
    }

}

[Serializable]

class LevelData
{
    public bool levelOne, levelTwo, levelThree, levelFour, levelFive;
}