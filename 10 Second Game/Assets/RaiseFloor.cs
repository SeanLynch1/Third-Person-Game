using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerMovement
{

    public class RaiseFloor : MonoBehaviour
    {
        public GameObject upperTarget;
        public GameObject lowerTarget;
        public bool moveFloorUp;
        public bool moveFloorDown;
        public float speed;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (moveFloorUp)
            {
                if (transform.position != upperTarget.transform.position)
                {
                    Vector3 pos = Vector3.MoveTowards(transform.position, upperTarget.transform.position, speed * Time.deltaTime);
                    GetComponent<Rigidbody>().MovePosition(pos);
                }
            }
            if (moveFloorDown)
            {
                if (transform.position != lowerTarget.transform.position)
                {
                    Vector3 pos = Vector3.MoveTowards(transform.position, lowerTarget.transform.position, speed  * Time.deltaTime);
                    GetComponent<Rigidbody>().MovePosition(pos);
                }
            }


        }



        private void OnTriggerEnter(Collider other)
        {
          
            if (other.tag == "FinalTargetLava")
            {
                Destroy(this.gameObject);
            }
        }
    }
}
