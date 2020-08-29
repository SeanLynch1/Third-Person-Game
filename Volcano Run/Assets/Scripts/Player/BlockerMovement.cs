using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockerMovement : MonoBehaviour
{
    public bool moveOtherWay;
    public bool move;
    public bool flipDirection;

    public float delta = 1.5f;  // Amount to move left and right from the start point
    public float speed = 2.0f;
    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void FixedUpdate()
    {
        BackAndForth();
    }
    public void BackAndForth()
    {
        if(move)
        {
            Vector3 v = startPos;
            v.x += delta * Mathf.Sin(Time.time * speed);
            transform.position = v;
        }
        if(move && flipDirection)
        {
            Vector3 v = startPos;
            v.x -= delta * Mathf.Sin(Time.time * speed);
            transform.position = v;
        }
        if(moveOtherWay)
        {
            Vector3 v = startPos;
            v.z += delta * Mathf.Sin(Time.time * speed);
            transform.position = v;
        }
        if (moveOtherWay && flipDirection)
        {
            Vector3 v = startPos;
            v.z -= delta * Mathf.Sin(Time.time * speed);
            transform.position = v;
        }

    }
}
