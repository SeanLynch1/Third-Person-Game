using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerMovement
{

    [CreateAssetMenu(fileName = "New State", menuName = "Player/AbilityData/Grounded For Slopes")]
    public class Grounded_For_Slopes : StateData
    {
        [Range(0f, 5f)]
        public float CheckTime;
        public float Distance;




        public override void OnEnter(CharacterStateBase characterState, Animator animator, AnimatorStateInfo stateInfo)
        {


        }
        public override void UpdateAbility(CharacterStateBase characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            PlayerBlendMovement control = characterState.GetCharacterControl(animator);

            if (stateInfo.normalizedTime >= CheckTime)
            {
                if (isGrounded(control))
                {
                    control.GroundedSlope = true;
                    animator.SetBool("GroundedSlope", true);

                }
                else
                {
                    control.GroundedSlope = false;
                    animator.SetBool("GroundedSlope", false);
                }
            }


        }
        public override void OnExit(CharacterStateBase characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
     
        }
        bool isGrounded(PlayerBlendMovement control)
        {
            if (control.RIGID_BODY.velocity.y > -0.001f && control.RIGID_BODY.velocity.y <= 0f)
            {
                return true;
            }
            if (control.Moving || control.Sprinting || control.Idling)
            {
          
                foreach (GameObject o in control.BottomSpheres)
                {
                    Debug.DrawRay(o.transform.position, -Vector3.up * Distance, Color.yellow);
                    RaycastHit hit;
                    if (Physics.Raycast(o.transform.position, -Vector3.up, out hit, Distance))
                    {

                            return true;
                        
                        
                    }
                }
            }

            if (control.Moving || control.Sprinting || control.Idling)
            {
                foreach (GameObject o in control.FrontSpheres)
                {
                    for(int i = 0; i < 11; i ++ )
                    {
                        Debug.DrawRay(control.FrontSpheres[i].transform.position, control.transform.forward * Distance, Color.yellow);
                        RaycastHit hit;
                        if (Physics.Raycast(control.FrontSpheres[i].transform.position, control.transform.forward, out hit, Distance))
                        {

                            return true;
                        }
                    }
               
                }
            }
  


            return false;
        }

    }
}