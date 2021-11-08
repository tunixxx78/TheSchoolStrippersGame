using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowCredits : MonoBehaviour
{
    [SerializeField] GameObject credits, highscore;

    public void ShowPlayerCredits()
    {
        credits.SetActive(true);
        highscore.SetActive(false);
    }
}
