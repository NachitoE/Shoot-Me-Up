using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SGReloadingState : SGBaseState
{
   public override void EnterState(SGController sg)
    {
        base.EnterState(sg);
        ctx.StartCoroutine(Reload());
        ctx.SFX.SetAudioClip(ctx.SFX.clipList[1]);
        ctx.SFX.PlayAudioClip();


    }

    public override void ExitState()
    {

    }

    public override void UpdateState()
    {
        
    }

  

    IEnumerator Reload()
    {
        ctx.anim.Play("Reloading");
        yield return new WaitForSeconds(ctx.reloadTime);
        ctx.currAmmo = ctx.Ammo;
        ctx.anim.Play("ReloadingFinished");
        ctx.SwitchState(ctx.ChargedState);
        

    }
}
