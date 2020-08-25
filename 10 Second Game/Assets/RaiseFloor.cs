using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaiseFloor : MonoBehaviour
{
    public GameObject target;
    public bool moveFloor;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(moveFloor)
        {
            if (transform.position != target.transform.position)
            {
                Vector3 pos = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
                GetComponent<Rigidbody>().MovePosition(pos);
            }
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
