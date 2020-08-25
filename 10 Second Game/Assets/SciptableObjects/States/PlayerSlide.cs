using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerMovement
{

    [CreateAssetMenu(fileName = "New State", menuName = "Player/AbilityData/Player Slide")]
    public class PlayerSlide : StateData
    {
        public float zSize;
        public float xSize;
        public float ySize;
        public float slideForce;
        public override void OnEnter(CharacterStateBase characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            PlayerBlendMovement control = characterState.GetCharacterControl(animator);
           
            characterState.GetCharacterControl(animator).RIGID_BODY.AddForce(control.transform.forward * slideForce);
            control.boxCollider.size = new Vector3(xSize, ySize, zSize);
            control.boxCollider.center = new Vector3(0, 0.57f, 0);
          foreach (GameObject o in control.MiddleSpheres)
            {
                o.transform.position = new Vector3(o.transform.position.x, o.transform.position.y + .75f, o.transform.position.z);
            }
            foreach (GameObject o in control.BottomSpheres)
            {
                o.transform.position = new Vector3(o.transform.position.x, o.transform.position.y + .125f, o.transform.position.z);
            }

        }
        public override void UpdateAbility(CharacterStateBase characterState, Animator animator, AnimatorStateInfo stateInfo)
        {


        }
        public override void OnExit(CharacterStateBase characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            PlayerBlendMovement control = characterState.GetCharacterControl(animator);
            control.boxCollider.size = new Vector3(xSize / 3, ySize * 10, zSize / 2.5f);
            control.boxCollider.center = new Vector3(0, 1, 0);
            foreach (GameObject o in control.MiddleSpheres)
            {
                o.transform.position = new Vector3(o.transform.position.x, o.transform.position.y - .75f, o.transform.position.z);

            }
            foreach (GameObject o in control.BottomSpheres)
            {
                o.transform.position = new Vector3(o.transform.position.x, o.transform.position.y - .125f, o.transform.position.z);
            }

            control.Slide = false;
            animator.SetBool("Slide", false);
            //control.Grounded = true;
           // animator.SetBool("Grounded", true);
        }
    }
}
