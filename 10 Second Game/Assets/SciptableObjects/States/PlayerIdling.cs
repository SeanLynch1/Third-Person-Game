using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace PlayerMovement
{

    [CreateAssetMenu(fileName = "New State", menuName = "Player/AbilityData/Idle")]
    public class PlayerIdling : StateData
    {
       
        public override void OnEnter(CharacterStateBase characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            PlayerBlendMovement control = characterState.GetCharacterControl(animator);
            control.Idling = true;
        }

        public override void UpdateAbility(CharacterStateBase characterState, Animator animator,AnimatorStateInfo stateInfo)
        {
            PlayerBlendMovement control = characterState.GetCharacterControl(animator);
           
            //JUMP
            if(control.Jump)
            {
                animator.SetBool("Jump", true);
               
            }
         
            //ACTIVATE BLEND STATE
            if (VirtualInputManager.Instance.Moving)
            {
                animator.SetBool("Moving", true);
            }
            else
            {
                animator.SetBool("Moving", false);
            }

            //SPRINT
            if (VirtualInputManager.Instance.Sprinting)
            {
                Debug.Log("Sprint");
                animator.SetBool("Sprinting", true);
            }
        }

        public override void OnExit(CharacterStateBase characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            PlayerBlendMovement control = characterState.GetCharacterControl(animator);
            control.Idling = false;
        }
    }
}
