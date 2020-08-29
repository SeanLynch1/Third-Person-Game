using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerMovement
{

    [CreateAssetMenu(fileName = "New State", menuName = "Player/AbilityData/ForceTransition")]
    public class ForceTransition : StateData
    {
        [Range(0.01f, 1f)]
        public float TransitionTiming;


        public override void OnEnter(CharacterStateBase characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
           
        }
        public override void UpdateAbility(CharacterStateBase characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            if(stateInfo.normalizedTime >= TransitionTiming)
            {
                animator.SetBool("ForceTransition", true);
            }
         
        }
        public override void OnExit(CharacterStateBase characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            animator.SetBool("ForceTransition", false);
        }
    }
}


