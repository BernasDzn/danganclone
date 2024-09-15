using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    public GameState state;

    public static event Action<GameState> OnGameStateChanged;
    
    void Awake()
    {
        Instance = this;
    }

    GameObject bl, bubble, crossTL, crossTR, crossBL, crossBR, crossMain, selectL, selectR, selectT, selectB, selectSquare;

    void Start()
    {
        bl = GameObject.Find("BL");
        bubble = GameObject.Find("bubble");
        crossTL = GameObject.Find("crossTL");
        crossTR = GameObject.Find("crossTR");
        crossBL = GameObject.Find("crossBL");
        crossBR = GameObject.Find("crossBR");
        crossMain = GameObject.Find("crossMain");
        selectL = GameObject.Find("selectL");
        selectR = GameObject.Find("selectR");
        selectT = GameObject.Find("selectT");
        selectB = GameObject.Find("selectB");
        selectSquare = GameObject.Find("selectSquare");
        UpdateState(GameState.PLAYING);
    }
    
    public void UpdateState(GameState newState)
    {
        state = newState;

        switch (newState){
            case GameState.PLAYING:
                Time.timeScale = 1;
                SetDefaultUI();
                break;
            case GameState.DIALOG:
                SetDialogUI();
                break;
            case GameState.PAUSED:
                Time.timeScale = 0;
                break;
        }

        OnGameStateChanged?.Invoke(newState);
    }

    void SetDialogUI()
    {
        bl.SetActive(false);
        bubble.SetActive(false);
        crossTL.SetActive(false);
        crossTR.SetActive(false);
        crossBL.SetActive(false);
        crossBR.SetActive(false);
        crossMain.SetActive(false);
        selectL.SetActive(false);
        selectR.SetActive(false);
        selectT.SetActive(false);
        selectB.SetActive(false);
        selectSquare.SetActive(false);
        GameObject.Find("dialogBox").GetComponent<DialogBoxBehavior>().isDialogBoxActive = true;
        GameObject.Find("dialogSideBar").GetComponent<DialogSidebarBehavior>().isDialogSideBarActive = true;   
    }

    void SetDefaultUI()
    {
        bl.SetActive(true);
        bubble.SetActive(true);
        crossTL.SetActive(true);
        crossTR.SetActive(true);
        crossBL.SetActive(true);
        crossBR.SetActive(true);
        crossMain.SetActive(true);
        selectL.SetActive(true);
        selectR.SetActive(true);
        selectT.SetActive(true);
        selectB.SetActive(true);
        selectSquare.SetActive(true);
        GameObject.Find("dialogBox").GetComponent<DialogBoxBehavior>().isDialogBoxActive = false;
        GameObject.Find("dialogSideBar").GetComponent<DialogSidebarBehavior>().isDialogSideBarActive = false;
    }
}

public enum GameState
{
    PLAYING,
    DIALOG,
    PAUSED
}
