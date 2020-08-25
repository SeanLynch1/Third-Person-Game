using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public float rotationSpeed = 2f;
    public Transform target;
    public Transform player;
    float mouseX;
    float mouseY;


    // Update is called once per frame
    void Update()
    {
        cameraControl();
        
    }

    void cameraControl()
    {
        mouseX += Input.GetAxis("Mouse X") * rotationSpeed;
        mouseY -= Input.GetAxis("Mouse Y") * rotationSpeed;
        mouseY = Mathf.Clamp(mouseY, -35, 60);

        transform.LookAt(target);

        if (Input.GetMouseButton(1))
        {
           //player.transform.rotation = Quaternion.Euler(0, 0, 0);
            target.transform.rotation = Quaternion.Euler(mouseY, mouseX, 0);
        }
        else
        {
            player.transform.rotation = Quaternion.Euler(0, mouseX, 0);
            target.transform.rotation = Quaternion.Euler(mouseY, mouseX, 0);
        }
    }

}
