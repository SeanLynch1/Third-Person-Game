using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateButton : MonoBehaviour
{
    private bool moveButton;
    public Transform target;
    public Transform target2;
    public float speed;
    float current;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      //  Vector3 currentPosition = this.gameObject.transform.position;

        Vector3 posDown = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        Vector3 posUp = Vector3.MoveTowards(transform.position, target2.transform.position, speed * Time.deltaTime);

        if (moveButton)
        {
            GetComponent<Rigidbody>().MovePosition(posDown);
        }
        if(!moveButton)
        {
            GetComponent<Rigidbody>().MovePosition(posUp);
        }
    }
    private void OnCollisionStay(Collision other)
    {
       
        if (other.gameObject.tag == "Player")
        {
            moveButton = true;
            
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        moveButton = false;
    }
}
