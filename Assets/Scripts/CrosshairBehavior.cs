using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrosshairBehavior : MonoBehaviour
{
    public LayerMask character; 
    private Color col;

    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Image>().color;
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
        if(col.a<255){
            col.a=col.a+0.15f;
        }
        GetComponent<Image>().color = col;
    }
    private void doDisable()
    {
        if(col.a>0){
            if(col.a<0.001){
                col.a=0f;
            }
            else{
            col.a=col.a*0.5f;
            }
        }
        GetComponent<Image>().color = col;
    }
}
