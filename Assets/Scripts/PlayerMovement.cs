using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float walkSpeed;
    public float runSpeed;
    public float currentSpeed;
    private Vector3 lastPosition;

    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        lastPosition = Vector3.zero;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float speed;
        if(Input.GetKey(KeyCode.LeftShift)){
            speed = runSpeed;
        }
        else{
            speed = walkSpeed;
        }
        Vector3 movement = Input.GetAxis("Horizontal")*transform.right + Input.GetAxis("Vertical")*transform.forward;
        rb.velocity = movement * Time.deltaTime * speed * 80;
        currentSpeed = Vector3.Distance(transform.position, lastPosition) / Time.deltaTime;
        lastPosition = transform.position;
    }
}
