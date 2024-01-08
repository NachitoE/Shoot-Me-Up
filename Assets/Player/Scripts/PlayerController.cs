using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class PlayerController : MonoBehaviour
{
    public PlayerMovementSystem moveSys;
    public PlayerGroundCheckSystem GroundChecker;
    public PlayerBaseState currState;
    public PlayerOnGroundState GroundState = new PlayerOnGroundState();
    public PlayerOnAirState AirState = new PlayerOnAirState();
    public PlayerDeadState DeadState = new PlayerDeadState();

    public SGController shotgun;

    private void Start()
    {
        StartPlayer();
    }

    private void Update()
    {
        currState.UpdateState();
        //Debug.Log(currState);
        
        
    }

    public void SwitchState(PlayerBaseState state)
    {
        currState.ExitState();
        currState = state;
        state.EnterState(this);
    }

    public void StartPlayer() //Set initial state to ground state
    {
        currState = GroundState;
        currState.EnterState(this);
    }
   
}
