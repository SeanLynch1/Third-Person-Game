using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PlayerMovement
{

    public class PlayerBlendMovement : MonoBehaviour
    {

        public bool Idling;
        public bool Moving;
        public bool Sprinting;
        public bool Jump;
        public bool Grounded;
        public bool GroundedSlope;
        public bool Slide;
        public bool sprintBoost;
        public bool speedTimer;
      //  public bool WallDetection;
      //  public bool Falling;
      
        public Animator animator;

        public BoxCollider boxCollider;

        public GameObject ColliderEdgePrefab;
        public List<GameObject> BottomSpheres = new List<GameObject>();
        public List<GameObject> FrontSpheres = new List<GameObject>();
        public List<GameObject> BackSpheres = new List<GameObject>();
        public List<GameObject> MiddleSpheres = new List<GameObject>();

        public Timer timer;

        public List<Collider> RagdollParts = new List<Collider>();

        public float GravityMultiplier;
        public float PullMultiplier;

        private Rigidbody rigid;
        public Rigidbody RIGID_BODY
        {
            get
            {
                if(rigid==null)
                {
                    rigid = GetComponent<Rigidbody>();
                }
                return rigid;
            }

        }
        private void Awake()
        {
            boxCollider = this.gameObject.GetComponent<BoxCollider>();

            SetRagdollParts();
            SetColliderSpheres();
        
        }

        private void SetRagdollParts()
        {
            Collider[] colliders = this.gameObject.GetComponentsInChildren<Collider>();

            foreach(Collider c in colliders)
            {
               if( c.gameObject != this.gameObject)
               {
                    c.isTrigger = true; // if the collider is not the same from the player then it is turned into a trigger
                    RagdollParts.Add(c); //colliders added to the list
               }
               
            }
        }
        private void TurnOnRagdoll()
        {
            RIGID_BODY.useGravity = false;
            RIGID_BODY.velocity = Vector3.zero;

            this.gameObject.GetComponent<BoxCollider>().enabled = false;
            animator.enabled = false;
            animator.avatar = null;
            foreach (Collider c in RagdollParts)
            {
                c.isTrigger = false;
                c.attachedRigidbody.velocity = Vector3.zero;
            }


        }
        private void SetColliderSpheres()
        {
            BoxCollider box = GetComponent<BoxCollider>();

            float bottom = box.bounds.center.y - box.bounds.extents.y;
            float top = box.bounds.center.y + box.bounds.extents.y;
            float front = box.bounds.center.z + box.bounds.extents.z;
            float back = box.bounds.center.z - box.bounds.extents.z;
            float middle = box.bounds.center.y;

            GameObject bottomFront = CreateEdgeSphere(new Vector3(0f, bottom +0.25f , front));
            GameObject bottomBack = CreateEdgeSphere(new Vector3(0f, bottom + 0.25f , back));
            GameObject topFront = CreateEdgeSphere(new Vector3(0f, top, front));
            GameObject topBack = CreateEdgeSphere(new Vector3(0f, top, back));
            GameObject middleFront = CreateEdgeSphere(new Vector3(0f, middle + .25f, front));
            GameObject middleBack = CreateEdgeSphere(new Vector3(0f, middle + .25f, back));


            bottomFront.transform.parent = this.transform;
            bottomBack.transform.parent = this.transform;
            topFront.transform.parent = this.transform;
            topBack.transform.parent = this.transform;
            middleFront.transform.parent = this.transform;
            middleBack.transform.parent = this.transform;
        

            BottomSpheres.Add(bottomFront);
            BottomSpheres.Add(bottomBack);

            FrontSpheres.Add(bottomFront);
            FrontSpheres.Add(topFront);

            BackSpheres.Add(bottomBack);
            BackSpheres.Add(topBack);

            MiddleSpheres.Add(middleFront);
            MiddleSpheres.Add(middleBack);

            float horSec = (bottomFront.transform.position - bottomBack.transform.position).magnitude / 5f; //Getting the length between the front and back spheres and dividing that length by 5
            CreateMiddleSpheres(bottomFront, -this.transform.forward, horSec, 4, BottomSpheres);

            float verSec = (bottomFront.transform.position - topFront.transform.position).magnitude / 10f;
            CreateMiddleSpheres(bottomFront, this.transform.up, verSec, 9, FrontSpheres);

            float verSecBack = (bottomBack.transform.position - topBack.transform.position).magnitude / 10f;
            CreateMiddleSpheres(bottomBack, this.transform.up, verSec, 9, BackSpheres);

            float middleSec = (middleFront.transform.position - middleBack.transform.position).magnitude / 5f;
            CreateMiddleSpheres(middleFront, -this.transform.forward, middleSec, 4, MiddleSpheres);

        }

        private void FixedUpdate()
        {
            if(RIGID_BODY.velocity.y < 0f)
            {
                RIGID_BODY.velocity += (-Vector3.up * GravityMultiplier);

            }
            if(RIGID_BODY.velocity.y >0f && !Jump)
            {
                RIGID_BODY.velocity += (-Vector3.up * PullMultiplier);
            }
        }



        public void CreateMiddleSpheres(GameObject start, Vector3 dir, float sec, int iterations, List<GameObject> spheresList)
        {
            for (int i = 0; i < iterations; i++)
            {
                Vector3 pos = start.transform.position + (dir * sec * (i + 1));

                GameObject newObj = CreateEdgeSphere(pos); //the spheres inbetween the bottom front and back ones
                newObj.transform.parent = this.transform;
                spheresList.Add(newObj);
            }
        }
        public GameObject CreateEdgeSphere(Vector3 pos)
        {
            GameObject obj = Instantiate(ColliderEdgePrefab, pos, Quaternion.identity);
            return obj;
        }
     

        // public AudioSource[] blendSounds;
        // Start is called before the first frame update
        void Start()
        {

            /* blendSounds = GetComponents<AudioSource>();
             blendSounds[0].enabled = true;
             blendSounds[1].enabled = true;*/

            animator = GetComponent<Animator>();
            animator.enabled = true;
           
        }

        public float x;
        public float y;
        public float jumpForce;
        // Update is called once per frame
        void Update()
        {
            if (animator == null) return;

            x = Input.GetAxis("Horizontal");
            y = Input.GetAxis("Vertical");


            Move(x, y);
            if(speedTimer)
            {
                timer.speedUI = true;
                StartCoroutine(speedCoroutine());
               
              
              
            }
        
        }
        public  IEnumerator speedCoroutine()
        {
          
            yield return new WaitForSeconds(7);
            sprintBoost = false;
            timer.speedUI = false;
            speedTimer = false;

        }
        public void Move(float x, float y)
        {
            animator.SetFloat("VelX", x);
            animator.SetFloat("VelY", y);

        }
       
    }
}
