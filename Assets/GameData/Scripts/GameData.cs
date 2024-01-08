using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public GameplayData gameplayData = new GameplayData();
    public AudioData audioData = new AudioData();
}


[System.Serializable]
public class GameplayData
{
    public int mouseSens = 150;
    public int FOV = 60;
}
[System.Serializable]
public class AudioData
{
    public float BGM = 1.0f;
    public float SFX = 1.0f;
}