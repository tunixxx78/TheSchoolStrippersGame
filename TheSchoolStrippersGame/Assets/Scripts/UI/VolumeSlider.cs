using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;


    private bool muted = false;

    // Start is called before the first frame update
    void Start()
    {
        if(!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
            Load();
        }
        else if(!PlayerPrefs.HasKey("muted"))
        {
            PlayerPrefs.SetInt("muted", 0);
            Load();
        }

        else
        {
            Load();
        }

        AudioListener.pause = muted;
    }
    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
        Save();
    }

    private void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
        muted = PlayerPrefs.GetInt("muted") == 1;
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
        PlayerPrefs.SetInt("muted", muted ? 1 : 0);
    }

    public void OnMutePress()
    {
        if (!muted)
        {
            muted = true;
            AudioListener.pause = true;
            Save();
            Debug.Log("mute " + muted);
        }
        else
        {
            Debug.Log("on mutella");
        }
    }
    public void OnUnmutePress()
    {
        if (muted)
        {
            muted = false;
            AudioListener.pause = false;
            Save();
            Debug.Log("Unmute " + muted);
        }
        else
        {
            Debug.Log("ei ole mutella");
        }
    }
}
