using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using TMPro;

public class EventHandlerBehavior : MonoBehaviour
{

    [SerializeField] 
    public string sceneFilePath = "";

    private string sceneScript = "";

    private StreamReader sc;

    private AudioSource voiceLines;

    private string voiceLinesPath = "Sound/Voice Lines/";

    private string soundTrackPath = "Sound/OST/";

    private string soundEffectsPath = "Sound/SFX/";

    private string currentCharacter = "";

    private AudioSource sfx;

    // Start is called before the first frame update
    void Start()
    {
        sc = new StreamReader(sceneFilePath);
        voiceLines = GameObject.Find("Main Camera").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.E) && sc != null){
            if(GameObject.Find("GameManager").GetComponent<GameManager>().state != GameState.DIALOG){
                GameObject.Find("GameManager").GetComponent<GameManager>().UpdateState(GameState.DIALOG);
            }
            var v = 0;
            while(v != 2){
                v = ReadScript();
                if(v == -1){
                    break;
                }
            }
            
        }
        if(sc != null){
            if(sc.Peek() == -1){
                GameObject.Find("GameManager").GetComponent<GameManager>().UpdateState(GameState.PLAYING);
                GameObject.Find("Character").SetActive(false);
                sc.Close();
                sc = null;
            }
        }
    }

    void ChangeCharacter(string character){
        currentCharacter = character;
        Enum.TryParse(character, out Character c);
        GameObject.Find("Character").GetComponent<CharacterResources>().character = c;
    }

    void ChangeEmotion(string emotion){
        Enum.TryParse(emotion, out Emotion e);
        GameObject.Find("Character").GetComponent<CharacterResources>().emotion = e;
    }

    void PlaySoundEffect(string sound){
        voiceLines.PlayOneShot(Resources.Load<AudioClip>(soundEffectsPath + sound));
    }

    void PlayVoiceLine(string line){
        voiceLines.PlayOneShot(Resources.Load<AudioClip>(voiceLinesPath + currentCharacter + "/" + line));
    }

    void DisplayText(string text){
        if(text.Contains("(")){
            text = text.Replace("(", "<b><color=#fad51e>").Replace(")", "</color></b>");
        }
        while(!GameObject.Find("dialogBox").GetComponent<DialogBoxBehavior>().isDone){
        }
        GameObject.Find("Label").GetComponent<TMP_Text>().text = text;
    }

    void DisplayFX(string fx){
        switch(fx){
            case "shake":
                GameObject.Find("Main Camera").GetComponent<CameraShakeBehavior>().shake = true;
                break;
            case "flash":
                GameObject.Find("flash").GetComponent<FlashBehavior>().flash = true;
                break;
        }
    }

    void PlaySoundTrack(string track){
        GameObject.Find("Visualizer").GetComponent<VisualizerScript>().audioSource.Stop();
        GameObject.Find("Visualizer").GetComponent<VisualizerScript>().audioSource.clip = Resources.Load<AudioClip>(soundTrackPath + track);
        GameObject.Find("Visualizer").GetComponent<VisualizerScript>().audioSource.Play();
    }

    int ReadScript(){
        var line = sc.ReadLine();
        if(line == null){
            return -1;
        }
        if(line.Contains("CHARACTER:")){
            ChangeCharacter(line.Split(":")[1]);
            return 0;
        }
        else{
            if(line.Contains("SPRITE:")){
                ChangeEmotion(line.Split(":")[1]);
                return 0;
            }
            else{
                if(line.Contains("[") && line.Contains("]")){
                    PlayVoiceLine(line.Split("[")[1].Split("]")[0]);
                    if(line.Split("]")[1].Replace("\"", "") != ""){
                        DisplayText(line.Split("]")[1].Replace("\"", ""));
                    }
                    return 0;
                }
                else{
                    if(line.Contains("SFX:")){
                        PlaySoundEffect(line.Split(":")[1]);
                        return 0;
                    }
                    else{
                        if(line.Contains("OST:")){
                            PlaySoundTrack(line.Split(":")[1]);
                            return 0;
                        }
                        else{
                            if(line.Contains("PAUSE")){
                                return 2;
                            }
                            else{
                                if(line.Contains("FX:")){
                                    DisplayFX(line.Split(":")[1]);
                                    return 0;
                                }
                                else{
                                    DisplayText(line.Replace("\"", ""));
                                    return 0;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
