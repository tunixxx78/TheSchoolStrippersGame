using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SFXManager : MonoBehaviour
{
    public AudioSource swim, breakingShip, collecting1, collecting2, button, wrongDot, taser, eagle;

    public void Swim()
    {
        swim.Play();
    }

    public void BreakingShip()
    {
        breakingShip.Play();
    }

    public void CollectingOne()
    {
        collecting1.Play();
    }

    public void CollectingTwo()
    {
        collecting2.Play();
    }

    public void ButtonPress()
    {
        button.Play();
    }

    public void WrongDotSound()
    {
        wrongDot.Play();
    }

    public void GetHitByObstacle()
    {
        taser.Play();
    }

    public void ScreamingEagle()
    {
        eagle.Play();
    }
}
