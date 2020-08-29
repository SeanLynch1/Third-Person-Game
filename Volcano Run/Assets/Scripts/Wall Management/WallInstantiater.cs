using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MovingWalls
{
    public class WallInstantiater : MonoBehaviour
    {
        public float beginTime;
        public float timeInterval;
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
            beginTime -= Time.deltaTime;
           
           // for (int i = 0; i <= current; i++)
           // {
                if (beginTime <= 0f)
                {

                    MovingWallInstantiater = Instantiate(movingWalls[current], this.gameObject.transform.position, transform.rotation) as GameObject;
               
                    current = current + 1;
                    beginTime = timeInterval;
                }
         
                if(current == movingWalls.Length)
                {
                current = 0;
                }
        
        }
    }
}


