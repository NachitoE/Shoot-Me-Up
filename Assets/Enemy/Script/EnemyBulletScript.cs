using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
{
    private Vector3 initialPos;
    private Vector3 currPos;
    public float distance;
    
    void Start()
    {
        initialPos = transform.position;
    }

    void Update()
    {
        currPos = transform.position;
        if ((currPos - initialPos).magnitude > distance) Destroy(this.gameObject); 
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            PlayerController playerC = collider.gameObject.GetComponent<PlayerController>();
            playerC.SwitchState(playerC.DeadState);
            Destroy(this.gameObject);
        }
        else if (!(collider.CompareTag("Enemy") | collider.CompareTag("EnemyContained"))) Destroy(this.gameObject);
    }
}
