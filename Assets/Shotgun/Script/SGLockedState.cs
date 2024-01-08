using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SGLockedState : SGBaseState
{
    public override void EnterState(SGController sg)
    {
        base.EnterState(sg);

        ctx.StartCoroutine(UnlockGun(ctx.lockTime));

    }

    public override void ExitState()
    {

    }

    public override void UpdateState()
    {
        
    }
    public IEnumerator UnlockGun(float lockTime) //lockTime determines the time in which the shotgun can be activated
    {
        yield return new WaitForSeconds(lockTime);
        //CHECK AMMOCHECK AMMOCHECK AMMOCHECK AMMOCHECK AMMOCHECK AMMO
        ctx.SwitchState(ctx.ChargedState);

    }
}
