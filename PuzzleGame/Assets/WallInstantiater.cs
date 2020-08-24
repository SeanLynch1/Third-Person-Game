using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MovingWalls
{
    public class WallInstantiater : MonoBehaviour
    {
        public float Timer;
        public float Timer2 = 20f;
        GameObject MovingWallInstantiater;
        public GameObject[] movingWalls;
        private int current;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            Timer -= Time.deltaTime;
            Timer2 -= Time.deltaTime;
           // for (int i = 0; i <= current; i++)
           // {
                if (Timer <= 0f)
                {

                    MovingWallInstantiater = Instantiate(movingWalls[current], this.gameObject.transform.position, transform.rotation) as GameObject;
               
                    current = current + 1;
                    Timer = 6f;
                }
         
                if(current == movingWalls.Length)
                {
                current = 0;
                }
        
        }
    }
}


