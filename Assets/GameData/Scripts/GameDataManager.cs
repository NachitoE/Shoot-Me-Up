using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.InputSystem;
using static GameData;

public class GameDataManager : MonoBehaviour
{
    public static GameDataManager instance;
    private GameData GAMEDATA;
    private string GAMEDATA_PATH;
    public Action onSettingsChanged;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        instance = FindAnyObjectByType<GameDataManager>();
        GAMEDATA_PATH = $"{Application.dataPath}/CONFIG.cfg";

        LOAD_DATA();
    }

    public AudioData GetAudioData() { return GAMEDATA.audioData; }
    public void SetAudioData(AudioData d) { GAMEDATA.audioData = d; }

    public GameplayData GetGameplayData() { return GAMEDATA.gameplayData; }
    public void SetGameData(GameplayData d) { GAMEDATA.gameplayData = d; }




    public void SAVE_DATA()
    {
        string data = JsonUtility.ToJson(GAMEDATA);
        File.WriteAllText(GAMEDATA_PATH, data);
    }

    public void LOAD_DATA()
    {
        if (!File.Exists(GAMEDATA_PATH)) RESTORE_DATA();
        string DataString = File.ReadAllText(GAMEDATA_PATH);
        GAMEDATA = JsonUtility.FromJson<GameData>(DataString);
    }

    public void RESTORE_DATA()
    {
        GAMEDATA = new GameData();
        SAVE_DATA();
    }
}
