using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SGController : MonoBehaviour
{
    public float shotKnockback;
    public float lockTime;
    public int currAmmo; //Current ammo
    public int Ammo; //How many rounds can shoot
    public int pelletsAmount; //Ammount of pellets that a single round will shoot
    public float angleVariation; //Determines the angle variation between different shots
    public int maxShootDistance;
    public float reloadTime;


    public Rigidbody playerRB;
    public Transform cameraTransform;
    public Transform SGShootPositionTransform; //tip of shotgun, prob used for shaders

    //STATE MANAGER
    public SGBaseState currState;
    public SGChargedState ChargedState = new SGChargedState();
    public SGReloadingState ReloadingState = new SGReloadingState();
    public SGLockedState LockedState = new SGLockedState();

    //MANAGEMENT
    public Animation anim;
    public SFXManager SFX;

    //INPUT 
    public PlayerInput input;
    public Action OnShootPressed;
    public Action OnShot;

    public void Start()
    {
        currAmmo = Ammo;
        input.actions["fire"].performed += CBctx => OnShootPressed?.Invoke();
        currState = ChargedState;     
        currState.EnterState(this);
    }

    private void Update()
    {
        currState.UpdateState();

        //Debug.Log(currState);
    }

    public void SwitchState(SGBaseState state)
    {
        currState.ExitState();
        currState = state;
        state.EnterState(this);
    }
 

}
