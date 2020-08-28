using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStayDown : MonoBehaviour
{
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "movingWall")
        {
            GetComponent<ConstantForce>().force = new Vector3(0, -15.0f, 0);
          //  Physics.gravity = new Vector3(0, -25.0f, 0);
        }
    }
    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "movingWall")
        {
             GetComponent<ConstantForce>().force = new Vector3(0, -0, 0);
            //Physics.gravity = new Vector3(0, -0, 0);
        }
    }
}
