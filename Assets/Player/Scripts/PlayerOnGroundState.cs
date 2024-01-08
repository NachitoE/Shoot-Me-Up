using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOnGroundState : PlayerBaseState
{
    public float GroundDrag = 5f;
    public override void EnterState(PlayerController player)
    {
        base.EnterState(player);
        ctx.moveSys.currDrag = ctx.moveSys.groundDrag;
        ctx.moveSys.playerSpeed = ctx.moveSys.groundSpeed;

    }
    public override void ExitState()
    {
        
    }

    public override void UpdateState()
    {
        if (!ctx.GroundChecker.isOnGround)
        {
            ctx.SwitchState(ctx.AirState);
        }
    }

    public override void OnCollisionEnter(Collision collision)
    {
        
    }

   
}
