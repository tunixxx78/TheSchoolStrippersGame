using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelSelection : MonoBehaviour
{
    public int level;
    [SerializeField] public bool unlocked;
    public GameObject[] stars;
    public TMP_Text text;

    private float threeStars = 10000;
    private float twoStars = 5000;
    private float oneStar = 5000;

    public DataHolderForLevels dataHolderForLevels;

    private void Start()
    {
        //PlayerPrefs.DeleteAll();
    }
    private void Update()
    {
        UpdateLevelStatus();
        UpdateLevelImage();
    }
    public void UpdateLevelStatus()
    {
        int previousLevelNum = level;
        if (PlayerPrefs.GetInt("Lv" + previousLevelNum) > 0)
        {
            unlocked = true;
        }
    }

    private void UpdateLevelImage()
    {
        if (!unlocked)
        {
            text.text = "???????";
        }
        else
        {
            text.text = text.text;

            if (ScoringSystem.theScore <= oneStar && ScoringSystem.theScore > 0)
            {
                stars[1].SetActive(true);
            }
            else if (ScoringSystem.theScore > twoStars && ScoringSystem.theScore > 0)
            {
                stars[1].SetActive(true);
                stars[2].SetActive(true);
            }

            else if (ScoringSystem.theScore >= threeStars)
            {
                stars[1].SetActive(true);
                stars[2].SetActive(true);
                stars[3].SetActive(true);
            }
        }
    }

    public void PressSelection()
    {
        if(unlocked)
        {
            SceneManager.LoadScene(this.gameObject.name);
        }
    }
}
