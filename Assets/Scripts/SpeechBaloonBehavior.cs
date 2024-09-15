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
        if(GameObject.Find("Character") == null){
            return;
        }
        var gotransform = GameObject.Find("Character").GetComponent<Transform>();
        var pos = (GameObject.Find("Character").transform.GetChild(0).GetComponent<SpriteRenderer>().bounds.size.y)/2f + 0.5f;
        transform.position = Camera.main.WorldToScreenPoint(gotransform.position+new Vector3(0,pos,0));
    }
}
