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
        if(!unlocked)
        {
            for(int i = 0; i < stars.Length; i++)
            {
                stars[i].gameObject.SetActive(false);
                text.text = "???????";
            }
        }
        else
        {
            for(int i = 0; i < stars.Length; i++)
            {
                //stars[i].gameObject.SetActive(true);
                text.text = text.text;
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
