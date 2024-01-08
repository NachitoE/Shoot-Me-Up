using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeadState : EnemyBaseState
{
    public override void EnterState(EnemyController enemy)
    {
        base.EnterState(enemy);
        ctx.StopAllCoroutines();
        ctx.pCheckSys.enabled = false;
        ctx.anim.Stop("DefaultAnim");
    }
    public override void ExitState()
    {

    }

    public override void UpdateState()
    {

    }
    public override void OnCollisionEnter(Collision collision)
    {

    }
}
