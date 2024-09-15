using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogSidebarBehavior : MonoBehaviour
{

    public bool isDialogSideBarActive = false;
    public bool isDone = true;

    void Start()
    {
        
    }

    void Update()
    {
        if(isDialogSideBarActive)
        {
            doEnable();
        }
        else{
            doDisable();
        }
    }

    void doEnable()
    {
        if(transform.position.x < 0)
        {
            isDone = false;
            transform.position += new Vector3(4f,0,0);
        }
        else{
            isDone = true;
        }
    }
    private void doDisable()
    {
        if(transform.position.x > -80)
        {
            isDone = false;
            transform.position += new Vector3(-2f,0,0);
        }
        else{
            isDone = true;
        }
    }
}
