using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerMovement
{

    [CreateAssetMenu(fileName = "New State", menuName = "Player/AbilityData/Jump")]
    public class Jump: StateData
    {
        public float ySize;
        public float jumpForce;
        public AnimationCurve Gravity;
        public AnimationCurve Pull;
       
        public override void OnEnter(CharacterStateBase characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

            PlayerBlendMovement control = characterState.GetCharacterControl(animator);

            characterState.GetCharacterControl(animator).RIGID_BODY.AddForce(Vector3.up * jumpForce);

            control.boxCollider.size = new Vector3(control.boxCollider.size.x, ySize, control.boxCollider.size.z);
    

            control.Grounded = false;
            animator.SetBool("Grounded", false);

            control.GroundedSlope = false;
            animator.SetBool("GroundedSlope", false);
        }
        public override void UpdateAbility(CharacterStateBase characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            PlayerBlendMovement control = characterState.GetCharacterControl(animator);

            control.GravityMultiplier = Gravity.Evaluate(stateInfo.normalizedTime);
           control.PullMultiplier =  Pull.Evaluate(stateInfo.normalizedTime);

        }
        public override void OnExit(CharacterStateBase characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            PlayerBlendMovement control = characterState.GetCharacterControl(animator);
            control.boxCollider.size = new Vector3(control.boxCollider.size.x, ySize * 8, control.boxCollider.size.z);
 

        }
    }
}

