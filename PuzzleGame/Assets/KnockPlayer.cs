using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockPlayer : MonoBehaviour
{
    public float knockForce;
    private void OnCollisionEnter(Collision hit)
    {
        Vector3 hitVector;  

        hitVector = (hit.transform.position - transform.position);
        hitVector.y = 0f;
        hitVector = hitVector.normalized;
        if (hit.gameObject.name == "Player")
        {
            Debug.Log("HIT");
            hit.rigidbody.AddForce(hitVector * knockForce);
        }
    }
}
