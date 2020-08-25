﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerMovement
{

    public class KeyboardInput : MonoBehaviour
    {
        public PlayerBlendMovement control;
        public void Update()
        {


            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            {
                VirtualInputManager.Instance.Moving = true;
               
                //VirtualInputManager.Instance.Idling = false;

            }
            else if (!Input.GetKey(KeyCode.W) || !Input.GetKey(KeyCode.A) || !Input.GetKey(KeyCode.S) || !Input.GetKey(KeyCode.D))
            {
                VirtualInputManager.Instance.Moving = false;
                //VirtualInputManager.Instance.Idling = true;

            }
    
            //SPRINT
            if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
            {
                VirtualInputManager.Instance.Sprinting = true;
                VirtualInputManager.Instance.Moving = false;
                // VirtualInputManager.Instance.Idling = false;
            }
            else
            {
                VirtualInputManager.Instance.Sprinting = false;
            }

          //JUMP
            if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Space) && Input.GetKey(KeyCode.LeftShift))
            {
                VirtualInputManager.Instance.Jump = true;
       
            }
            else
            {
               VirtualInputManager.Instance.Jump = false;
            }
            //Slide
            if(Input.GetKey(KeyCode.R) && Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
            {
                VirtualInputManager.Instance.Slide = true;
            }
            else
            {
                VirtualInputManager.Instance.Slide = false;
            }
          
        }
    }
}