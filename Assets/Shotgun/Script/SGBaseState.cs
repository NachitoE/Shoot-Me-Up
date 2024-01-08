using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SGBaseState
{
    protected SGController ctx;
    public virtual void EnterState(SGController sg)
    {
        ctx = sg;
    }
    public abstract void ExitState();
    public abstract void UpdateState();
    
}
