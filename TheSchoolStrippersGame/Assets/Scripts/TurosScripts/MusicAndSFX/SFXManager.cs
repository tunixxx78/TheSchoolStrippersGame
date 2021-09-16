using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SFXManager : MonoBehaviour
{
    public AudioSource swim, breakingShip, collecting1, collecting2;
    public static SFXManager sfxInstance;

    private void Awake()
    {
        if(sfxInstance != null && sfxInstance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        sfxInstance = this;
        DontDestroyOnLoad(this);
    }

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
}
