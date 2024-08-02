using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectLinesBehavior : MonoBehaviour
{

    private float horizontalScale;
    private float verticalScale;

    private float horizontalRate;

    private float verticalRate;

    public float steps = 10f;

    public LayerMask character;

    private Color col;

    // Start is called before the first frame update
    void Start()
    {
        horizontalScale = (Screen.width/2) - (GameObject.Find("selectSquare").GetComponent<RectTransform>().rect.width/2) + 40;
        verticalScale = (Screen.height/2) - (GameObject.Find("selectSquare").GetComponent<RectTransform>().rect.height/2) + 40;
        col = GetComponent<Image>().color;
        horizontalRate = horizontalScale/steps;
        verticalRate = verticalScale/steps;
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

    void doEnable()
    {
        if(col.a<255){
            col.a=col.a+0.15f;
        }
        GetComponent<Image>().color = col;

        if(gameObject.name.Contains("T") || gameObject.name.Contains("B")){
            var newV = Math.Clamp(GetComponent<RectTransform>().sizeDelta.y+verticalRate,0,verticalScale);
            GetComponent<RectTransform>().sizeDelta = new Vector2(50,newV);
        }
        else{
            var newH = Math.Clamp(GetComponent<RectTransform>().sizeDelta.x+horizontalRate,0,horizontalScale);
            GetComponent<RectTransform>().sizeDelta = new Vector2(newH,50);
        }
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
        if(col.a==0){
            if(gameObject.name.Contains("T") || gameObject.name.Contains("B")){
                GetComponent<RectTransform>().sizeDelta = new Vector2(50,0);
            }
            else{
                GetComponent<RectTransform>().sizeDelta = new Vector2(0,50);
            }
        }
    }
}
