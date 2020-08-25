using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace PlayerMovement
{
    [CreateAssetMenu(fileName = "New State", menuName = "Player/AbilityData/BasicMotion" )]
    public class BasicMotion : StateData
    {
        public float speed;
        public float BlockDistance;
        private bool Self;

        public override void OnEnter(CharacterStateBase characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            
        }
        public override void UpdateAbility(CharacterStateBase characterStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            PlayerBlendMovement control = characterStateBase.GetCharacterControl(animator);

            if(control.Jump)
            {
                animator.SetBool("Jump", true);
            }
            //ACTIVATE BLEND STATE
            if (control.Moving)
            {
                animator.SetBool("Moving", true);
                
                //FORWARD
                if (control.y > 0f && control.x == 0)
                {
                   // if(!CheckFront(control))
                   // {
                        control.transform.Translate(Vector3.forward * speed * Time.deltaTime);
                   
                  //  }
                   
                }
                //BACK
                if (control.y < 0f && control.x == 0)
                {
                   // if (!CheckBack(control))
                   // {
                        control.transform.Translate(Vector3.back * speed * Time.deltaTime);
                  
                   // }

                }
                //LEFT
                if (control.y == 0f && control.x < 0)
                {
                  //  if (!CheckLeft(control))
                  //  {
                        control.transform.Translate(Vector3.left * speed * Time.deltaTime);
              
                   // }
                }
                //RIGHT
                if (control.y == 0f && control.x > 0)
                {
                  //  if (!CheckRight(control))
                  //  {
                        control.transform.Translate(Vector3.right * speed * Time.deltaTime);
             
                  //  }

                }
                //LEFT FORWARD
                if (control.y > 0f && control.x < 0)
                {
                    control.transform.Translate(Vector3.forward * speed * Time.deltaTime);
                    control.transform.Translate(Vector3.left * speed * Time.deltaTime);
  
                }
                //RIGHT FORWARD
                if (control.y > 0f && control.x > 0)
                {
                    control.transform.Translate(Vector3.forward * speed * Time.deltaTime);
                    control.transform.Translate(Vector3.right * speed * Time.deltaTime);
           
                }
                //LEFT BACK
                if (control.y < 0f && control.x < 0)
                {
                    control.transform.Translate(Vector3.back * speed * Time.deltaTime);
                    control.transform.Translate(Vector3.left * speed * Time.deltaTime);
           
                }
                //RIGHT BACK
                if (control.y < 0f && control.x > 0)
                {
                    control.transform.Translate(Vector3.back * speed * Time.deltaTime);
                    control.transform.Translate(Vector3.right * speed * Time.deltaTime);
        
                }

            }
            else
            {
              
                animator.SetBool("Moving", false);
                
            }


            //SPRINT
            if (control.Sprinting)
            {

                Debug.Log("Sprint");
                animator.SetBool("Sprinting", true);
                animator.SetBool("Moving", false);


            }
            else
            {
              
                animator.SetBool("Sprinting", false);
            }

        }
        public override void OnExit(CharacterStateBase characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            PlayerBlendMovement control = characterState.GetCharacterControl(animator);
            control.Moving = false;
            animator.SetBool("Moving", false);
        }
       /* bool CheckFront(PlayerBlendMovement control)
        {
            Self = false;
            foreach (GameObject o in control.FrontSpheres)
            {
                Debug.DrawRay(o.transform.position, control.transform.forward * 0.9f, Color.yellow);
                RaycastHit hit;
                if (Physics.Raycast(o.transform.position, control.transform.forward, out hit, BlockDistance))
                {
                    foreach(Collider c in control.RagdollParts)
                    {
                        if(c.gameObject == hit.collider.gameObject)
                        {
                            Self = true;
                            break; // break out of the loop
                        }
                    }

                    if(!Self)
                    {
                         return true;
                          
                    }
          
                }
            }
            return false;
        }
        bool CheckBack(PlayerBlendMovement control)
        {
            Self = false;
            foreach (GameObject o in control.FrontSpheres)
            {
                Debug.DrawRay(o.transform.position, -control.transform.forward * 0.3f, Color.yellow);
                RaycastHit hit;
                if (Physics.Raycast(o.transform.position, -control.transform.forward, out hit, BlockDistance))
                {
                    foreach (Collider c in control.RagdollParts)
                    {
                        if (c.gameObject == hit.collider.gameObject)
                        {
                            Self = true;
                            break; // break out of the loop
                        }
                    }

                    if (!Self)
                    {
                        return true;

                    }
                }
            }
            return false;
        }
        bool CheckRight(PlayerBlendMovement control)
        {
            Self = false;
            foreach (GameObject o in control.FrontSpheres)
            {
                Debug.DrawRay(o.transform.position, control.transform.right * 0.9f, Color.yellow);
                RaycastHit hit;
                if (Physics.Raycast(o.transform.position, control.transform.right, out hit, BlockDistance))
                {
                    foreach (Collider c in control.RagdollParts)
                    {
                        if (c.gameObject == hit.collider.gameObject)
                        {
                            Self = true;
                            break; // break out of the loop
                        }
                    }

                    if (!Self)
                    {
                        return true;

                    }
                }
            }
            return false;
        }
        bool CheckLeft(PlayerBlendMovement control)
        {
            Self = false;
            foreach (GameObject o in control.FrontSpheres)
            {
                Debug.DrawRay(o.transform.position, -control.transform.right * 0.3f, Color.yellow);
                RaycastHit hit;
                if (Physics.Raycast(o.transform.position, -control.transform.right, out hit, BlockDistance))
                {
                    foreach (Collider c in control.RagdollParts)
                    {
                        if (c.gameObject == hit.collider.gameObject)
                        {
                            Self = true;
                            break; // break out of the loop
                        }
                    }

                    if (!Self)
                    {
                        return true;

                    }
                }
            }
            return false;
        }*/
    }
}


