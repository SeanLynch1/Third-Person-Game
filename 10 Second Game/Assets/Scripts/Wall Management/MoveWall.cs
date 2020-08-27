using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MoveWall : MonoBehaviour
{
    public GameObject[] target;

    public float speed;

    

    private int current;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {


        if (transform.position != target[current].transform.position)
        {
            Vector3 pos = Vector3.MoveTowards(transform.position, target[current].transform.position, speed * Time.deltaTime);
            GetComponent<Rigidbody>().MovePosition(pos);
        }
        else
        {
            current = (current + 1) % target.Length;
        }


    }
 
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "FinalTarget")
        {
            Destroy(this.gameObject);
        }
    }
}


