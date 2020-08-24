using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    public GameObject Belt;
    public Transform EndPoint;
    public float Speed;

    void OnTriggerStay(Collider other)
    {
        other.transform.position = Vector3.MoveTowards(other.transform.position, EndPoint.position, Speed * Time.deltaTime);
    }
}
