using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public float musicVolume; 
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate=60;
        musicVolume = GameObject.Find("Visualizer").GetComponent<VisualizerScript>().audioSource.volume;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.M)){
            if(GameObject.Find("Visualizer").GetComponent<VisualizerScript>().audioSource.volume!=0){
                GameObject.Find("Visualizer").GetComponent<VisualizerScript>().audioSource.volume=0;
            }
            else{
                GameObject.Find("Visualizer").GetComponent<VisualizerScript>().audioSource.volume=musicVolume;
            }
        }
    }
}
