using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Level Management
    public GameObject[] levels;
    public GameObject currLevel;
    public LevelController currLevelC;
    public MusicManager musicM;
    public int l;
    public GameObject credits;
    


    private void Start()
    {
        CreateLevel();

    }

    public void NextLevel()
    {
        Destroy(currLevel);
        l++; // VERIFY LESS THAN ARRAY LEN
        CreateLevel();
    }

    public void CreateLevel()
    {
        if (l < levels.Length)
        {
            currLevel = Instantiate(levels[l], transform);
            currLevelC = currLevel.GetComponent<LevelController>();
            currLevelC.onLevelComplete += NextLevel;
            musicM.musicSrc.clip = currLevelC.musicClip;
            musicM.PlayMusic();
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene(0);
            
        }
        
    }
}
