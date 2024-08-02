using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectSquareBehavior : MonoBehaviour
{

    public AudioSource source;

    public AudioClip clip;

    public bool canPlay = true;

    public LayerMask character;

    public float rotationSpeed;

    public float startRotation;

    public float currentRotation;

    public float initialScale;

    public float currentScale;

    public float scaleSpeed; 
    private Color col;

    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Image>().color;
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, startRotation);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out var hit, 5, character))
        {
            //var obj = hit.collider.gameObject;
            doEnable();
        }
        else{
            doDisable();
        }
    }
    void doEnable(){
        if(canPlay && !source.isPlaying){
            canPlay=false;
            source.PlayOneShot(clip);
        }
        if(col.a<255){
            col.a=col.a+0.15f;
        }
        GetComponent<Image>().color = col;

        float newAngle = Mathf.Clamp(currentRotation - rotationSpeed, 0, startRotation);
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, newAngle);
        currentRotation = newAngle;

        float newScale = Mathf.Clamp(transform.localScale.x - scaleSpeed, 1, initialScale);
        transform.localScale = new Vector3(newScale, newScale, newScale);
        currentScale = transform.localScale.x;
    }
    private void doDisable()
    {
        canPlay=true;
        if(col.a>0){
            if(col.a<0.001){
                col.a=0f;
            }
            else{
            col.a=col.a*0.5f;
            }
        }
        GetComponent<Image>().color = col;
        if(col.a==0){
            transform.localScale = new Vector3(initialScale, initialScale, initialScale);
            currentRotation = startRotation;
            transform.localRotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, currentRotation);
            currentScale = transform.localScale.x;
        }
    }
}
