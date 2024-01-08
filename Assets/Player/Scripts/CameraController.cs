using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float xAxisMouse;
    private float yAxisMouse;

    //public float cameraMovRotSpeed;
    //public float cameraMovRot;
    private float xRotation = 0f; // la guardamos para hacer el clamping (el personaje no se rompe el cuello)
    public float mouseSens = 150f;
    private GameplayData gmData;



    public Transform player;
    //public PlayerController playerC;

    private void Start()
    {
        gmData = GameDataManager.instance.GetGameplayData();
        mouseSens = gmData.mouseSens;
        Camera.main.fieldOfView = gmData.FOV;
        Cursor.lockState = CursorLockMode.Locked;
        
    }
    void FixedUpdate()
    {
        MouseLook();
        //RotateOnMovement();
    }

    private void MouseLook()
    {
        xAxisMouse = Input.GetAxis("Mouse X") * mouseSens * Time.fixedDeltaTime;
        yAxisMouse = Input.GetAxis("Mouse Y") * mouseSens * Time.fixedDeltaTime;

        //mov en y
        xRotation -= yAxisMouse;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        //mov en x
        player.Rotate(Vector3.up * xAxisMouse);
        
        
    }
    /*
    private void RotateOnMovement() {
        
        Debug.Log(playerC.moveSys.move.x);
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(transform.rotation.x, transform.rotation.y, playerC.moveSys.move.x * cameraMovRot * -1), cameraMovRotSpeed * Time.deltaTime);
    }
    */
}
