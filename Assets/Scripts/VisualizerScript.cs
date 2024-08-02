﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VisualizerScript : MonoBehaviour {
	public float minHeight = 0f;
	public float maxHeight = 10.0f;
    
    public float volume = 0.10f;
	public float updateSentivity = 10.0f;
	public Color visualizerColor = Color.gray;
	[Space (15)]
	public AudioClip audioClip;
	public bool loop = true;
	[Space (15), Range (64, 8192)]
	public int visualizerSamples = 64;

	VisualizerObjectScript[] visualizerObjects;
	public AudioSource audioSource;

	// Use this for initialization
	void Start() {
		visualizerObjects = GetComponentsInChildren<VisualizerObjectScript>();

		if(!audioClip)
			return;

		audioSource = new GameObject("_AudioSource").AddComponent<AudioSource>();
		audioSource.loop = loop;
		audioSource.clip = audioClip;
        audioSource.volume = volume;
		audioSource.Play();
	}
	
	// Update is called once per frame
	void FixedUpdate() {
        float[] spectrumData = new float[visualizerSamples];
        audioSource.GetSpectrumData(spectrumData, 0, FFTWindow.Triangle);
        for (int i = 0; i < visualizerObjects.Length; i++) {
			Vector2 newSize = visualizerObjects[i].GetComponent<RectTransform>().rect.size;

			newSize.y = Mathf.Clamp(Mathf.Lerp(newSize.y, minHeight + (spectrumData[i] * (maxHeight - minHeight) * ((i*3.5f)+10.0f)), updateSentivity * 0.5f), minHeight, maxHeight);
            
            if(newSize.y > visualizerObjects[i].GetComponent<RectTransform>().sizeDelta.y){
                visualizerObjects[i].GetComponent<RectTransform>().sizeDelta = newSize;
            }
            else{
                newSize = new Vector2(visualizerObjects[i].GetComponent<RectTransform>().sizeDelta.x, visualizerObjects[i].GetComponent<RectTransform>().sizeDelta.y-0.5f);
                visualizerObjects[i].GetComponent<RectTransform>().sizeDelta = newSize;
            }
			
            visualizerObjects[i].GetComponent<Image>().color = visualizerColor;
		}
	}
}