using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerMovement
{

    [CreateAssetMenu(fileName = "New State", menuName = "Player/AbilityData/Air Control")]
    public class AirControl : StateData
    {



        public float jumpForce;
        public float BlockDistance;
        public float speed;
      //  public float jumpForce;
        public AnimationCurve SpeedGraph;



        public override void OnEnter(CharacterStateBase characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

      
        }
        public override void UpdateAbility(CharacterStateBase characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            PlayerBlendMovement control = characterState.GetCharacterControl(animator);

            if(control.Grounded == false)
            {

                //FORWARD
                if (control.y > 0f && control.x == 0)
                {
                    if (!CheckFront(control))
                    {
                        control.transform.Translate(Vector3.forward * speed * Time.deltaTime);
                        control.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                    }
                }
                //BACK
                if (control.y < 0f && control.x == 0)
                {
                    if (!CheckBack(control))
                    {
                        control.transform.Translate(Vector3.back * speed * SpeedGraph.Evaluate(stateInfo.normalizedTime) * Time.deltaTime);
                        control.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                    }
                  
                }
                //LEFT
                if (control.y == 0f && control.x < 0)
                {
                   
                        if (!CheckLeft(control))
                        {
                            control.transform.Translate(Vector3.left * speed * SpeedGraph.Evaluate(stateInfo.normalizedTime) * Time.deltaTime);
                            control.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                        }
                }
                //RIGHT
                if (control.y == 0f && control.x > 0)
                {
                    if(!CheckRight(control))
                    {
                        control.transform.Translate(Vector3.right * speed * SpeedGraph.Evaluate(stateInfo.normalizedTime) * Time.deltaTime);
                        control.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                 
                    }
                    if(CheckRight(control) && control.Jump)
                    {
                        characterState.GetCharacterControl(animator).RIGID_BODY.AddForce(Vector3.left * jumpForce);
                    }


                }
                //LEFT FORWARD
                if (control.y > 0f && control.x < 0)
                {
                    control.transform.Translate(Vector3.forward * speed * SpeedGraph.Evaluate(stateInfo.normalizedTime) * Time.deltaTime);
                    control.transform.Translate(Vector3.left * speed * Time.deltaTime);
                    control.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                }
                //RIGHT FORWARD
                if (control.y > 0f && control.x > 0)
                {
                    control.transform.Translate(Vector3.forward * speed * SpeedGraph.Evaluate(stateInfo.normalizedTime) * Time.deltaTime);
                    control.transform.Translate(Vector3.right * speed * Time.deltaTime);
                    control.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                }
                //LEFT BACK
                if (control.y < 0f && control.x < 0)
                {
                    control.transform.Translate(Vector3.back * speed * SpeedGraph.Evaluate(stateInfo.normalizedTime) * Time.deltaTime);
                    control.transform.Translate(Vector3.left * speed * Time.deltaTime);
                    control.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                }
                //RIGHT BACK
                if (control.y < 0f && control.x > 0)
                {
                    control.transform.Translate(Vector3.back * speed * SpeedGraph.Evaluate(stateInfo.normalizedTime) * Time.deltaTime);
                    control.transform.Translate(Vector3.right * speed * Time.deltaTime);
                    control.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                }
                else
                {
                    control.Moving = false;
                }

       
            }

        }
        public override void OnExit(CharacterStateBase characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

        }
  
        bool CheckFront(PlayerBlendMovement control)
        {

            foreach (GameObject o in control.FrontSpheres)
            {
                for (int i = 7; i <= 10; i++)
                {

                    Debug.DrawRay(control.FrontSpheres[i].transform.position, control.transform.forward * BlockDistance, Color.yellow);
                    RaycastHit hit;
                    if (Physics.Raycast(control.FrontSpheres[i].transform.position, control.transform.forward, out hit, BlockDistance))
                    {
                        return true;
                    }

                }
            }
            return false;
        }
        bool CheckBack(PlayerBlendMovement control)
        {

            foreach (GameObject o in control.BackSpheres)
            {
                for (int i = 7; i <= 10; i++)
                {

                    Debug.DrawRay(control.BackSpheres[i].transform.position, -control.transform.forward * BlockDistance, Color.yellow);
                    RaycastHit hit;
                    if (Physics.Raycast(control.BackSpheres[i].transform.position, -control.transform.forward, out hit, BlockDistance))
                    {
                        return true;
                    }

                }
            }
            return false;
        }
        bool CheckRight(PlayerBlendMovement control)
        {
            
           
            foreach (GameObject o in control.FrontSpheres)
            {
                for(int i = 8; i < 11; i ++)
                {
             
                        Debug.DrawRay(control.BackSpheres[i].transform.position, control.transform.right * BlockDistance, Color.yellow);
                        RaycastHit hit;
                        if (Physics.Raycast(control.BackSpheres[i].transform.position, control.transform.right, out hit, BlockDistance))
                        {
                            return true;
                        }
               
                }

            }

            return false;
        }
        bool CheckLeft(PlayerBlendMovement control)
        {
            foreach( GameObject o in control.FrontSpheres)
            {
                for (int i = 8; i <= 10; i++)
                {

                    Debug.DrawRay(control.BackSpheres[i].transform.position, -control.transform.right * BlockDistance, Color.yellow);
                    RaycastHit hit;
                    if (Physics.Raycast(control.BackSpheres[i].transform.position, -control.transform.right, out hit, BlockDistance))
                    {
                        return true;
                    }

                }
            }
       
            return false;
        }

    }
}