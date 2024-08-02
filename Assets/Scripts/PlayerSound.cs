using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    public AudioSource source;
    public AudioClip clip;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Camera.main.GetComponent<CameraBobbing>().stepSound){
            source.PlayOneShot(clip);
            Camera.main.GetComponent<CameraBobbing>().stepSound=false;
        }
    }
}
