using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenuController : MonoBehaviour
{
    private GameplayData gpData;
    private AudioData audData;
    public GameDataManager gmDataM;

    public Button BackButton;
    public Slider FOVSlider;
    public Slider mouseSensSlider;
    public Slider musicSlider;
    public Slider SFXSlider;
    public SFXManager SFXExample;
   
    public TextMeshProUGUI FOVSliderTextValue;
    public TextMeshProUGUI mouseSensSliderTextValue;
    public TextMeshProUGUI musicSliderTextValue;
    public TextMeshProUGUI SFXSliderTextValue;

    public Action onSettingsChanged;
    

    void Start()
    {
        gpData = new();
        audData = new();
        gmDataM = GameDataManager.instance;

        //Initial values
        mouseSensSlider.value = gmDataM.GetGameplayData().mouseSens;
        mouseSensSliderTextValue.text = mouseSensSlider.value.ToString();

        FOVSlider.value = gmDataM.GetGameplayData().FOV;
        FOVSliderTextValue.text = FOVSlider.value.ToString();

        musicSlider.value = gmDataM.GetAudioData().BGM;
        musicSliderTextValue.text = (Mathf.CeilToInt(musicSlider.value * 100)).ToString();

        SFXSlider.value = gmDataM.GetAudioData().SFX;
        SFXSliderTextValue.text = (Mathf.CeilToInt(SFXSlider.value * 100)).ToString();




        //On Change
        FOVSlider.onValueChanged.AddListener(f => ChangeFOV((int)(f)));
        mouseSensSlider.onValueChanged.AddListener(f => ChangeMouseSens((int)(f)));
        musicSlider.onValueChanged.AddListener(f => ChangeMusicVol((float)(f)));
        SFXSlider.onValueChanged.AddListener(f => ChangeSFXVol((float)(f)));

        BackButton.onClick.AddListener (() => gmDataM.SAVE_DATA()); //Save on leaving options menu



    }

    public void ChangeFOV(int fov)
    {
        Debug.Log(fov);
        gpData.FOV = fov;
        FOVSliderTextValue.text = fov.ToString();
        gmDataM.SetGameData(gpData);
        onSettingsChanged?.Invoke();

    }

    public void ChangeMouseSens(int sens) {
        Debug.Log(sens);
        gpData.mouseSens = sens;
        mouseSensSliderTextValue.text = sens.ToString();
        gmDataM.SetGameData(gpData);
        onSettingsChanged?.Invoke();
    }

    public void ChangeMusicVol(float vol)
    {
        audData.BGM = vol;
        musicSliderTextValue.text = (Mathf.CeilToInt(vol * 100)).ToString();
        gmDataM.SetAudioData(audData);
        onSettingsChanged?.Invoke();
    }

    public void ChangeSFXVol (float vol) {
        audData.SFX = vol;
        SFXSliderTextValue.text = (Mathf.CeilToInt(vol * 100)).ToString();
        gmDataM.SetAudioData(audData);
        SFXExample.audioSrc.clip = SFXExample.clipList[0];
        SFXExample.PlayAudioClip();
        onSettingsChanged?.Invoke();
    } 
}
