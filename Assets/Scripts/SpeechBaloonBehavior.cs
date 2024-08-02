using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeechBaloonBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        var gotransform = GameObject.Find("Kazuichi").GetComponent<Transform>();
        transform.position = Camera.main.WorldToScreenPoint(gotransform.position+new Vector3(0,0.5f,0));
    }
}
