using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogCameraBehavior : MonoBehaviour
{

    private Vector3 originalPosition;

    private Quaternion originalRotation;

    private float startTime = 0;

    private bool enganged = false;

    public float lerpDuration = 1f;

    public float displacement = 0f;

    public Character curChar;

    public GameObject anchor;

    void Start()
    {
        curChar = GameObject.Find("Character").GetComponent<CharacterResources>().character;
        anchor = GameObject.Find("CameraAnchor");
    }

    void Update()
    {
        if(GameObject.Find("Character") != null)
        {
            curChar = GameObject.Find("Character").GetComponent<CharacterResources>().character;
        }
        else{
            curChar = Character.CHIAKI_NANAMI;
        }
        originalPosition = transform.position;
        originalRotation = transform.rotation;

        enganged = GameObject.Find("GameManager").GetComponent<GameManager>().state == GameState.DIALOG;

        if(curChar == Character.MONOKUMA){
            displacement = -1.9f;
        }
        else{
            displacement = 0f;
        }

        if(enganged)
        {
            doEnable();
        }
        else{
            doDisable();
        }
    }

    void doEnable()
    {
        var pos = new Vector3(  
                anchor.transform.position.x, 
                anchor.transform.position.y + displacement, 
                anchor.transform.position.z
                );
        if(transform.position != pos)
        {
            if(startTime == 0)
            {
                startTime = Time.time;
            }
            float t = (Time.time - startTime) / lerpDuration;
            transform.position = Vector3.Lerp(originalPosition, pos, t);
            transform.rotation = Quaternion.Lerp(originalRotation, GameObject.Find("CameraAnchor").transform.rotation, t);
        }
        else{
            startTime = 0;
        }
    }

    private void doDisable()
    {
        var pos = new Vector3(  
                anchor.transform.position.x, 
                anchor.transform.position.y + displacement, 
                anchor.transform.position.z
                );
        if(transform.position != originalPosition)
        {
            if(startTime == 0)
            {
                startTime = Time.time;
            }
            float t = (Time.time - startTime) / lerpDuration;
            transform.position = Vector3.Lerp(pos, originalPosition, t);
            transform.rotation = Quaternion.Lerp(GameObject.Find("CameraAnchor").transform.rotation, originalRotation, t);
        }
        else{
            startTime = 0;
        }
    }
}
