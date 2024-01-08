using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerGroundCheckSystem : MonoBehaviour
{
    public bool isOnGround;
    public RaycastHit slopeHit;

    public Transform groundCheck;
    public float distance = 0.4f;
    public LayerMask groundMask;
    public LayerMask slopeMask;
    
    void FixedUpdate()
    {
        if (Physics.CheckSphere(groundCheck.position, distance, groundMask) | (Physics.Raycast(transform.position, Vector3.down, out slopeHit, 1.5f, slopeMask))){
            isOnGround = true;
        }else isOnGround = false;
        
        

    }
}
