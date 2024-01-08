using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOnAirState : PlayerBaseState
{

    public override void EnterState(PlayerController player)
    {
        base.EnterState(player);
        ctx.moveSys.currDrag = ctx.moveSys.airDrag;
        ctx.moveSys.playerSpeed = ctx.moveSys.airSpeed;
    }
    public override void ExitState()
    {

    }

    public override void UpdateState()
    {
        if (ctx.GroundChecker.isOnGround)
        {
            ctx.SwitchState(ctx.GroundState);
        }
    }

    public override void OnCollisionEnter(Collision collision)
    {
        
    }

    
}
