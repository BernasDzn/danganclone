using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public float sensitivity = 1f;
    public float yRotationLimit = 30f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState=CursorLockMode.Locked;
        Cursor.visible=false;
    }

    Vector2 rotation = Vector2.zero;
    // Update is called once per frame
    void LateUpdate()
    {
        if(GameObject.Find("GameManager").GetComponent<GameManager>().state != GameState.PLAYING){
            return;
        }
        rotation.x += Input.GetAxis("Mouse X") * sensitivity;
        rotation.y += Input.GetAxis("Mouse Y") * sensitivity;
        rotation.y = Mathf.Clamp(rotation.y, -yRotationLimit, yRotationLimit);
        var xQuat = Quaternion.AngleAxis(rotation.x, Vector3.up);
        var yQuat = Quaternion.AngleAxis(rotation.y, Vector3.left);

        gameObject.transform.parent.gameObject.transform.rotation = xQuat;
        transform.localRotation = yQuat;
    }
}
