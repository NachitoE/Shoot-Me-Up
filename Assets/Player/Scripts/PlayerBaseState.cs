using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class PlayerBaseState
{
    protected PlayerController ctx;
    public virtual void EnterState(PlayerController player)
    {
        ctx = player;
    }
    public abstract void ExitState();
    public abstract void UpdateState();
    public abstract void OnCollisionEnter(Collision collision);
    
}
