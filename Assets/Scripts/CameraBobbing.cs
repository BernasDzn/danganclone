using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.UIElements;
using UnityEngine;

public class CameraBobbing : MonoBehaviour
{

    private GameObject parent;
    public float bobbingAmplitude;
    public float bobbingSpeed;
    public float currentAngle;
    public float displacement;
    private float originalY;

    public bool stepSound = false;
    public bool hold = false;
    public float displacementTemp=1f;
    
    void Start()
    {
        parent = gameObject.transform.parent.gameObject;
        originalY=transform.position.y;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(GameObject.Find("GameManager").GetComponent<GameManager>().state != GameState.PLAYING){
            return;
        }
        if(parent.GetComponent<PlayerMovement>().currentSpeed != 0){
            doBobbing();
        }
        else{
            if(displacement != 0f){
                if(Math.Abs(displacement)<0.005){
                    displacement=0f;
                    return;
                } 
                displacement = displacement * 0.99f;
                Vector3 newPosition = transform.position;
                newPosition.y = originalY+displacement;
                transform.position = newPosition;
            }
            else{
                currentAngle = 0f;
                Vector3 newPosition = transform.position;
                newPosition.y = originalY;
                transform.position = newPosition;
            }
        }
    }

    void doBobbing(){
        Vector3 newPosition = transform.position;
        displacement = -1f*bobbingAmplitude + (float)Math.Abs(Math.Cos(Math.PI * currentAngle / 180.0))*bobbingAmplitude;
        if(displacement<(-1f*bobbingAmplitude+(float)Math.Abs(Math.Cos(Math.PI*90/180.0))*bobbingAmplitude+0.05))
        {
            hold = true;
        }
        if(displacement>(-1f*bobbingAmplitude+(float)Math.Abs(Math.Cos(Math.PI*90/180.0))*bobbingAmplitude+0.05) && hold){
            stepSound=true;
            displacementTemp=1f;
            hold = false;
        }

        newPosition.y = originalY + displacement;
        transform.position = newPosition;
        currentAngle+=bobbingSpeed*50f*Time.deltaTime;
        if(currentAngle>360) currentAngle-=360;
    }
}
