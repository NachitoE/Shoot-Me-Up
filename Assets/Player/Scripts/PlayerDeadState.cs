using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class PlayerDeadState : PlayerBaseState
{
    public override void EnterState(PlayerController player)
    {
        base.EnterState(player);
        ctx.moveSys.enabled = false;
    }
    public override void ExitState()
    {
        ctx.moveSys.enabled = true;
    }

    public override void OnCollisionEnter(Collision collision)
    {
        
    }

    public override void UpdateState()
    {
        
    }
}
