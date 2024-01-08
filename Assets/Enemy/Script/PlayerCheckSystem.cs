using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.HID;

public class PlayerCheckSystem : MonoBehaviour
{
    public bool isSeeingPlayer = false;
    public Vector3 playerPos;
    public LayerMask playerMask;

    private void OnTriggerStay(Collider collider)
    {
        if (collider.CompareTag("Player")) drawRay(collider);

    }
    private void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag("Player")) isSeeingPlayer = false;
    }
    

    private void drawRay(Collider collider)
    {
        //Drawing raycasts to assure player is not behind a surface or obstacle
        RaycastHit hit;
        if (Physics.Raycast(transform.position, collider.transform.position - transform.position, out hit, (collider.transform.position - transform.position).magnitude))
            {
            Debug.DrawLine(transform.position, collider.transform.position);
            if (hit.transform.CompareTag("Player"))
            {
                playerPos = hit.transform.position;
                isSeeingPlayer = true;
            }
            else isSeeingPlayer = false;

        }
    }
}
