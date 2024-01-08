using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementSystem : MonoBehaviour
{

    public PlayerInput input;

    public float playerSpeed, currDrag;
    private Vector3 moveDir, moveVector;
    public RaycastHit slopeHit;
    public LayerMask slopeMask;
    public Vector2 move;
    public PlayerController player;

    //GROUND AND AIR VARIABLES
    public float groundDrag;
    public float airDrag;
    public float groundSpeed;
    public float airSpeed;


    
    [SerializeField] private Rigidbody playerRB;

    private void FixedUpdate()
    {
        
        Movement();

    }
    public void OnMove(InputAction.CallbackContext ctx)
    {
        move = ctx.ReadValue<Vector2>();
        
    }

    private void Movement()
    {
        move = input.actions["Move"].ReadValue<Vector2>();
        moveDir = transform.forward * move.y + transform.right * move.x;
        moveDir = new Vector3(moveDir.x, 0f, moveDir.z);
        moveDir = Vector3.ProjectOnPlane(moveDir, player.GroundChecker.slopeHit.normal); //for sloping
        
        //Debug.Log("x: "+move.x+"\n y:"+move.y);
        moveVector = moveDir.normalized * playerSpeed * 10f; //10f makes player a tad faster
        playerRB.AddForce(moveVector, ForceMode.Force);
        //Debug.Log(moveVector);
        //Debug.Log("DRAGCHECK "+ dragCheck);

        playerRB.drag = currDrag;

        


    }

    

}
