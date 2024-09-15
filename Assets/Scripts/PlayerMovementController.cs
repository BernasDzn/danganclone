using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float walkSpeed;
    public float runSpeed;
    public float currentSpeed;
    private Vector3 lastPosition;


    // Start is called before the first frame update
    void Start()
    {
        lastPosition = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.Find("GameManager").GetComponent<GameManager>().state != GameState.PLAYING){
            return;
        }
        float speed;
        if(Input.GetKey(KeyCode.LeftShift)){
            speed = runSpeed;
        }
        else{
            speed = walkSpeed;
        }
        Vector3 movement = Input.GetAxis("Horizontal")*transform.right + Input.GetAxis("Vertical")*transform.forward;
        transform.position += movement * Time.deltaTime * speed;
        currentSpeed = Vector3.Distance(transform.position, lastPosition) / Time.deltaTime;
        lastPosition = transform.position;
    }
}
