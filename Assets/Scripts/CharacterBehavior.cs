using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //transform.LookAt(new Vector3(
        //    GameObject.Find("Player").transform.position.x,
        //    GameObject.Find("Player").transform.position.y,
        //    GameObject.Find("Player").transform.position.z
        //    ), Vector3.up);
        
        Vector3 targetPostition = new Vector3(
            GameObject.Find("Player").transform.position.x,
            transform.position.y,
            GameObject.Find("Player").transform.position.z
            );
        transform.LookAt(targetPostition) ;
    }
}
