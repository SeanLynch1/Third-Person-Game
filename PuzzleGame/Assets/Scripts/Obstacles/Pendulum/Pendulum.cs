using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class Pendulum : MonoBehaviour
    {
    public float knockForce;

        [SerializeField, Range(0.0f, 360f)]
        private float angle = 90.0f;

        [SerializeField, Range(0.0f, 5f)]
        private float speed = 2.0f;

        [SerializeField, Range(0.0f, 10f)]
        private float startTime = 0.0f;

        Quaternion start, end;
        // Start is called before the first frame update
        private void Start()
        {
            start = PendulumRotation(angle);
            end = PendulumRotation(-angle);
        }

        // Update is called once per frame
        private void FixedUpdate()
        {
            startTime += Time.deltaTime;
            transform.rotation = Quaternion.Lerp(start, end, (Mathf.Sin(startTime * speed + Mathf.PI / 2) + 1.0f) / 2.0f);
        }

        void ResetTimer()
        {
            startTime = 0.0f;
        }
        Quaternion PendulumRotation(float angle)
        {
            var pendulumRotation = transform.rotation;
            var angleZ = pendulumRotation.eulerAngles.z + angle;

            if (angleZ > 100)
            {
                angleZ -= 360;
            }
            else if (angleZ < -180)
            {
                angleZ += 360;
            }

            pendulumRotation.eulerAngles = new Vector3(pendulumRotation.eulerAngles.x, pendulumRotation.eulerAngles.y, angleZ);
            return pendulumRotation;

        }
        private void OnCollisionEnter(Collision hit)
        {
        Vector3 hitVector;// = (hit.transform.position - transform.position).normalized;
        hitVector = (hit.transform.position - transform.position);
        hitVector.y = 0;
        hitVector = hitVector.normalized;
            if (hit.gameObject.name == "Player")
            {
                Debug.Log("HIT");
                hit.rigidbody.AddForce(hitVector * knockForce);
            }
        }
}
