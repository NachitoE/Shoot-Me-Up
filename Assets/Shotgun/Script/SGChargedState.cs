using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SGChargedState : SGBaseState
{
    
    public override void EnterState(SGController sg)
    {
        base.EnterState(sg);

        ctx.OnShootPressed += Shoot;

    }
    public override void ExitState()
    {
        ctx.OnShootPressed -= Shoot; // desuscribe shoot method
    }

    public override void UpdateState()
    {
        if (ctx.currAmmo <= 0) ctx.SwitchState(ctx.ReloadingState);
        
    }

    public void Shoot()
    {
        PlayerLogic();
        ctx.StartCoroutine(ShootingAnim());
        ctx.SFX.SetAudioClip(ctx.SFX.clipList[0]);
        ctx.SFX.PlayAudioClip();
        ShootRaycasts();
        ctx.SwitchState(ctx.LockedState);
    }

    private void PlayerLogic()
    {
        //set player velocity to zero in shooting to avoid opposing vectors?
        ctx.playerRB.velocity = Vector3.zero;
        ctx.playerRB.angularVelocity = Vector3.zero;

        //Knockback player
        ctx.playerRB.AddForce(ctx.cameraTransform.forward.normalized * -1 * ctx.shotKnockback, ForceMode.Impulse);
        ctx.currAmmo--;

        ctx.OnShot?.Invoke();

        
    }

    private void ShootRaycasts()
    {
        for (int i = 0; i < ctx.pelletsAmount; i++)
        {
            RaycastHit hit;
            Vector3 shootDir;
            
            
            shootDir = ctx.cameraTransform.forward;

            shootDir += ctx.cameraTransform.up * Random.Range(-ctx.angleVariation, ctx.angleVariation);
            shootDir += ctx.cameraTransform.right * Random.Range(-ctx.angleVariation, ctx.angleVariation);





            if (Physics.Raycast(ctx.cameraTransform.position, shootDir, out hit, ctx.maxShootDistance))
            {
                if (hit.collider.CompareTag("Enemy")) //CAMBIAR A ENEMY
                {
                    var eHit = hit.collider.GetComponent<EnemyController>(); //short for "Enemy Hit"
                    if (eHit.currState != eHit.deadState)
                    {
                        eHit.SwitchState(eHit.deadState); //Kill enemy
                        var eHitRB = eHit.GetComponent<Rigidbody>();
                        eHitRB.constraints = RigidbodyConstraints.None;
                        eHitRB.AddForce(ctx.cameraTransform.forward * 5000f,ForceMode.Force);
                    }

                    Debug.DrawLine(ctx.cameraTransform.position, hit.point, Color.green, 5f);
                }
                else
                {
                    Debug.DrawLine(ctx.cameraTransform.position, hit.point, Color.red, 5f);
                }
                
                

            }
            

        }
        
    }

    IEnumerator ShootingAnim()
    {
        ctx.anim.Play("Shooting");
        yield return new WaitForSeconds(ctx.lockTime);
        ctx.anim.Play("ShootingFinished");
    }
    
}
