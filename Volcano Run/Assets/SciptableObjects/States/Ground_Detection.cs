using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerMovement
{

    [CreateAssetMenu(fileName = "New State", menuName = "Player/AbilityData/Ground Detection")]
    public class Ground_Detection : StateData
    {
        [Range(0.01f, 12f)]
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
                    control.Grounded = true;
                    animator.SetBool("Grounded", true);

                }
                else
                {
                    control.Grounded = false;
                    animator.SetBool("Grounded", false);

                }
            }
        

        }
        public override void OnExit(CharacterStateBase characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

        }
        bool isGrounded(PlayerBlendMovement control)
        {

           if (control.RIGID_BODY.velocity.y > -0.01f && control.RIGID_BODY.velocity.y <=0f)
           {
                return true;
           }
        
            if (control.RIGID_BODY.velocity.y < 0f )
            {

                foreach (GameObject o in control.MiddleSpheres)
                {
                    Debug.DrawRay(o.transform.position, -Vector3.up * Distance, Color.yellow);
                    RaycastHit hit;
                    if (Physics.Raycast(o.transform.position, -Vector3.up, out hit, Distance))
                    {
                        return true;
                    }
                }

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

    
            return false;
        }

    }
}