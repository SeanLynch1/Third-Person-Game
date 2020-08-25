using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace PlayerMovement
{
    [CreateAssetMenu(fileName = "State Data", menuName = "Player/AbilityData/Sprint")]
    public class PlayerSprint : StateData
    {
        public float BlockDistance;
        public float speed;
        public override void OnEnter(CharacterStateBase characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
     
        }
        public override void UpdateAbility(CharacterStateBase characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            PlayerBlendMovement control = characterState.GetCharacterControl(animator);
            if (control.Jump)
            {
                animator.SetBool("Jump", true);
            }
            //ACTIVATE BLEND
            if (control.Moving)
            {
                animator.SetBool("Moving", true);
            }
            else
            {
                animator.SetBool("Moving", false);
                

            }

            //SPRINT
            if (control.Sprinting)
            {
              //  Debug.Log("Sprint");
                animator.SetBool("Sprinting", true);
                animator.SetBool("Moving", false);
              
             //  if(!CheckFront(control))
              // {
                    control.transform.Translate(Vector3.forward * speed * Time.deltaTime);
                
             //  }
                
            }
            else
            {
                
                animator.SetBool("Sprinting", false);
            }
            //SLIDE
            if(control.Slide)
            {
                animator.SetBool("Slide", true);
            }
        }

        public override void OnExit(CharacterStateBase characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
    
            animator.SetBool("Sprinting", false);
        }
        bool CheckFront(PlayerBlendMovement control)
        {

            foreach (GameObject o in control.FrontSpheres)
            {
                Debug.DrawRay(o.transform.position, control.transform.forward * BlockDistance, Color.yellow);
                RaycastHit hit;
                if (Physics.Raycast(o.transform.position, control.transform.forward, out hit, BlockDistance))
                {
                    return true;
                }
            }
            return false;
        }
    }
}

