using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallOfDoom : MonoBehaviour
{
    public float Speed;
    public PlayerHealth playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(Vector3.left * Speed * Time.deltaTime);
    }

    public void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        { 
        
            playerHealth.Health -= 1;
        }
    }
  
}
