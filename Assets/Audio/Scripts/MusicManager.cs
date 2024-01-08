using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource musicSrc;
    public OptionsMenuController optionsMenu;

    private void Start()
    {
        SetVolume();
        if (optionsMenu != null) optionsMenu.onSettingsChanged += SetVolume;



    }
    public void PlayMusic()
    {
        
        musicSrc?.Play();
    }

    private void SetVolume()
    {
        musicSrc.volume = GameDataManager.instance.GetAudioData().BGM;
    }
}
