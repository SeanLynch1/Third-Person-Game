using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int Health;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HealthBar();
        Debug.Log(Health);
    }

    public void HealthBar()
    {
        if(Health == 0)
        {
            Destroy(this.gameObject);
        }
    }
}
