using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogBoxBehavior : MonoBehaviour
{

    public bool isDialogBoxActive = false;
    public bool isDone = true;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(isDialogBoxActive)
        {
            doEnable();
        }
        else{
            doDisable();
        }
    }

    void doEnable()
    {
        if(transform.position.y < 0)
        {
            isDone = false;
            transform.position += new Vector3(0,4f,0);
        }
        else{
            isDone = true;
        }
    }
    private void doDisable()
    {
        if(transform.position.y > -148)
        {
            isDone = false;
            transform.position += new Vector3(0,-2f,0);
        }
        else{
            isDone = true;
        }
    }
}
