using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float distance;
    public Color color;
    public float Sensibilidad = 100;
    public Transform playerBody;
    public float xRotacion;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * Sensibilidad * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * Sensibilidad * Time.deltaTime;

        xRotacion -= mouseY;
        xRotacion = Mathf.Clamp(xRotacion, -90, 90);

        transform.localRotation = Quaternion.Euler(xRotacion, 0, 0);

        playerBody.Rotate(Vector3.up * mouseX);

        Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward, Color.red);

        if (Input.GetKey(KeyCode.E))
        {
            RaycastHit hit;
            if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, distance))
            {
                Renderer renderer;
                if(hit.transform.gameObject.TryGetComponent<Renderer>(out renderer))
                {
                    Vector3 lol = hit.transform.InverseTransformPoint(hit.point)* -1 + new Vector3(0.50f, 0, 0.50f);

                    //SplashingSystem.instace.SplashOnTexture(lol, renderer.material, color);
                }
            }
        }

    }
}