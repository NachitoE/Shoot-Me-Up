using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject player;
    public EnemyBaseState currState;
    public EnemyIdleState idleState = new EnemyIdleState();
    public EnemyAttackState attackState = new EnemyAttackState();
    public EnemyDeadState deadState = new EnemyDeadState();

    public Rigidbody rb;
    public float attackTime; //controls how much the enemy has to wait in order to shoot the player
    public GameObject bullet;
    public float bulletForce; //controls how much force the bullet is applied to the bullet
    public PlayerCheckSystem pCheckSys;
    public Transform shootingPosTransform;
    public SFXManager sfx;
    public Animation anim;

    private void Start()
    {
        StartEnemy();
        sfx.SetAudioClip(sfx.clipList[0]);
        StartCoroutine(PlayIdleSounds());
        
    }

    private void Update()
    {
        currState.UpdateState();
        //Debug.Log(currState);
    }

    public void SwitchState(EnemyBaseState state)
    {
        currState.ExitState();
        currState = state;
        state.EnterState(this);
    }

    public void StartEnemy()
    {
        //State management
        currState = idleState;
        rb.constraints = RigidbodyConstraints.FreezeAll;
        rb.constraints &= ~RigidbodyConstraints.FreezePositionY;
        rb.rotation = Quaternion.identity;
        anim.Play("DefaultAnim");
        currState.EnterState(this);

    }

    IEnumerator PlayIdleSounds()
    {
        if (currState == idleState)
        {
            sfx.PlayAudioClip();
            yield return new WaitForSeconds(5);
            StartCoroutine(PlayIdleSounds());
        }
    }


}
