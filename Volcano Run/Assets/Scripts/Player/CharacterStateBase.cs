using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace PlayerMovement
{

    public class CharacterStateBase : StateMachineBehaviour
    {
        public List<StateData> ListAbilityData = new List<StateData>();

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            foreach(StateData d in ListAbilityData)
            {
                d.OnEnter(this, animator, stateInfo);
            }
        }
        
        public void UpdateAll(CharacterStateBase characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            foreach(StateData d in ListAbilityData)
            {
                d.UpdateAbility(characterState, animator, stateInfo);
            }
        }
    
        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            UpdateAll(this, animator, stateInfo);
        }
        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            foreach (StateData d in ListAbilityData)
            {
                d.OnExit(this, animator, stateInfo);
            }
        }
        private PlayerBlendMovement characterControl;
        public PlayerBlendMovement GetCharacterControl(Animator animator)
        {
            if(characterControl == null )
            {
               characterControl = animator.GetComponentInParent<PlayerBlendMovement>();
            }
            
            return characterControl;
        }
  

     
    }
}