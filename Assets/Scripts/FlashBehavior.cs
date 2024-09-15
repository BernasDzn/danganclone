using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class FlashBehavior : MonoBehaviour
{

    public bool flash = false;

    public int phase = 1;

    public float flashSpeed = 0.2f;

    void Start()
    {
    }

    void FixedUpdate()
    {
        gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width, Screen.height);
        if(flash){
            if(phase == 1){
                doFlash();
            }
            if(phase == 2){
                undoFlash();
            }
        }
    }

    public void doFlash(){
        var c = gameObject.GetComponent<Image>().color;
        c.a = Math.Clamp(c.a + flashSpeed, 0, 1);
        gameObject.GetComponent<Image>().color = c;
        if(gameObject.GetComponent<Image>().color.a >= 1){
            phase = 2;
        }
    }

    public void undoFlash(){
        var c = gameObject.GetComponent<Image>().color;
        c.a = Math.Clamp(c.a - (flashSpeed/8), 0, 1);
        gameObject.GetComponent<Image>().color = c;
        if(gameObject.GetComponent<Image>().color.a <= 0){
            phase = 1;
            flash = false;
        }
    }
}
