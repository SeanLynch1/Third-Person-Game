using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerMovement
{

    [CreateAssetMenu(fileName = "New State", menuName = "Player/AbilityData/Landing")]
    public class Landing : StateData
    {

        public override void OnEnter(CharacterStateBase characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            PlayerBlendMovement control = characterState.GetCharacterControl(animator);
            control.Jump = false;
            animator.SetBool("Jump", false);

            control.Grounded = true;
            animator.SetBool("Grounded", true);

            control.GroundedSlope = true;
            animator.SetBool("GroundedSlope", true);
        }
        public override void UpdateAbility(CharacterStateBase characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

        }
        public override void OnExit(CharacterStateBase characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
           
        }
    }
}
