using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : EnemyBaseState
{
    public override void EnterState(EnemyController enemy)
    {
        base.EnterState(enemy);
        ctx.StartCoroutine(Attack());
        ctx.pCheckSys.enabled = true;
    }
    public override void ExitState()
    {
        
    }

    public override void UpdateState()
    {
        if (!ctx.pCheckSys.isSeeingPlayer) ctx.SwitchState(ctx.idleState);
        else ctx.transform.rotation = Quaternion.LookRotation( (ctx.pCheckSys.playerPos - ctx.transform.position).normalized.z * Vector3.forward + (ctx.pCheckSys.playerPos - ctx.transform.position).normalized.x * Vector3.right, Vector3.up);
    }
    public override void OnCollisionEnter(Collision collision)
    {

    }

    IEnumerator Attack()
    {
        yield return new WaitForSeconds(ctx.attackTime);
        if (ctx.pCheckSys.isSeeingPlayer)
        {
            
            GameObject newB = GameObject.Instantiate(ctx.bullet, ctx.shootingPosTransform.position, Quaternion.identity);
            newB.GetComponent<Rigidbody>().AddForce((ctx.pCheckSys.playerPos - ctx.transform.position) * ctx.bulletForce, ForceMode.Force);
            ctx.StartCoroutine(Attack());
        }
        
    }
}
