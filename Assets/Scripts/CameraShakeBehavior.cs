using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random=UnityEngine.Random;
public class CameraShakeBehavior : MonoBehaviour
{

    public bool shake = false;
    public float shakeDecay = 0.01f;
    public float shakeAmount = 0.1f;
    public float value = 0f;

    private Vector3 originalPos;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        if(shake){
            originalPos = transform.localPosition;
            value = shakeAmount;
            shake = false;
        }
        if(value > 0){
            transform.localPosition = new Vector3(originalPos.x + Random.Range(-value,value), originalPos.y + Random.Range(-value,value), originalPos.z);
            value = Math.Clamp(value - shakeDecay, 0, shakeAmount);
        }
    }
}
