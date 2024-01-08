using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    //Entities
    public Transform playerInitialPos;
    public PlayerController playerC;

    public List<Vector3> enemiesInitialPos = new List<Vector3>();
    public List<GameObject> enemies = new List<GameObject>();

    //Enviromental
    public GoalSystem goalSys;
    public int minHeight; //Player will die after reaching minHeight in map
    public AudioClip musicClip;

    //Level Management
    public Action onLevelComplete;

    private void Start()
    {
        goalSys.onGoalReached += onLevelComplete;
        SetPlayer();
        SetEnemies();
    }

    private void Update()
    {
        PlayerChecks();
    }

    
    public void SetPlayer() //Register player initial pos
    {
        playerC = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        
        playerC.transform.position = playerInitialPos.position;
    }

    public void SetEnemies()
    {
        
        enemies = GameObject.FindGameObjectsWithTag("Enemy").ToList();
        
        foreach(GameObject enemy in enemies)
        {
            enemiesInitialPos.Add(enemy.transform.position);
        }
        
    }


    public void RestartLevel()
    {
        playerC.SwitchState(playerC.GroundState);
        playerC.transform.position = playerInitialPos.position;
        playerC.shotgun.currAmmo = playerC.shotgun.Ammo;

        int i = 0;
        foreach (GameObject enemy in enemies)
        {
            EnemyController enemyC = enemy.GetComponent<EnemyController>();

            enemyC.StartEnemy();
            enemy.transform.position = enemiesInitialPos[i];

            i++;
        }
        
    }

    public void PlayerChecks()
    {
        if (playerC != null)
        {
            if (playerC.transform.position.y < minHeight) playerC.SwitchState(playerC.DeadState); //PLAYER DEAD IF REACHING MINHEIGHT
            if (playerC.currState == playerC.DeadState) RestartLevel(); //RESTART LEVEL LOGIC   }
        }
    }
    
}
