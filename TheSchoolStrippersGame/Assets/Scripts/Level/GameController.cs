using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public int levelIndex;
    public int currentStarValue = 0;

    public void WinLevel(int _starNum)
    {
        currentStarValue = _starNum;
        if (currentStarValue > PlayerPrefs.GetInt("Lv" + levelIndex))
        {
            PlayerPrefs.SetInt("Lv" + levelIndex, _starNum);
        }
    }
}
