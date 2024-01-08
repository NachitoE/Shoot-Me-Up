using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : EnemyBaseState
{
    public override void EnterState(EnemyController enemy)
    {
        base.EnterState(enemy);
    }
    public override void ExitState()
    {
        
    }

    public override void UpdateState()
    {
        if (ctx.pCheckSys.isSeeingPlayer) ctx.SwitchState(ctx.attackState);
    }
    public override void OnCollisionEnter(Collision collision)
    {

    }
}
