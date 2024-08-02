using UnityEngine;
using System.Collections;
using System;

public class ClockBehavior : MonoBehaviour
{
    public AnimationCurve curve = AnimationCurve.Linear(0.0f, 0.0f, 1.0f, 1.0f);
    public float duration = 10000f;

    public float step = 30f;
    public float target = 30f;

    public float currentAngle;
    float t;
    // Use this for initialization
    void Start ()
    {
        t = 0.0f;
    }

    // Update is called once per frame
    void FixedUpdate ()
    {
        if(transform.rotation.eulerAngles.z>=target-0.01){
            t = 0.0f;
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, target);
            target=target+step;
            if(target>360) {
                target=target-360;
                transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z-360f);
            };
        }
        t += Time.deltaTime;
        float s = t / duration;
        transform.rotation = Quaternion.Lerp(
            transform.rotation, 
            Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, target), 
            curve.Evaluate(s)
            );
        currentAngle = transform.rotation.eulerAngles.z;
    }
}
