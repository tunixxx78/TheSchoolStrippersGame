using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetScreenResolution : MonoBehaviour
{
    private void Start()
    {
        Screen.SetResolution(1920, 1080, Screen.fullScreen);
    }
}
