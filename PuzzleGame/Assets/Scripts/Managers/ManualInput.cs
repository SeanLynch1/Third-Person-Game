using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerMovement
{


    public class ManualInput : MonoBehaviour
    {
        private PlayerBlendMovement characterControl;


        private void Awake()
        {
            characterControl = this.gameObject.GetComponent<PlayerBlendMovement>();
        }
      
        void Update()
        {
            if(VirtualInputManager.Instance.Moving)
            {
                characterControl.Moving = true;
            }
            else
            {
                characterControl.Moving = false;
            }

            if (VirtualInputManager.Instance.Sprinting)
            {
                characterControl.Sprinting = true;
               
            }
            else
            {
                characterControl.Sprinting = false;
               
            }

            if(VirtualInputManager.Instance.Jump)
            {
                characterControl.Jump = true;
            }
            else
            {
                characterControl.Jump = false;
            }
          
        }
    }
}
