﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagers : MonoBehaviour{

  

    [SerializeField]
    UIManager uiManagerScript;

    [SerializeField]
    CameraFollow cameraScript;

    [SerializeField]
    PlatformSpawner platformSpawnerScript;

    [HideInInspector]
    public PlayerController playerScript;

    public bool gameRunning = false;
    // Start is called beforSe the first frame update

    void Update()
    {
        if(gameRunning)
        uiManagerScript.ShowScoreText(playerScript.score);
    }

    public void GameOver()
    {
        gameRunning = false;
        playerScript.gameObject.SetActive(false);
        uiManagerScript.GameEnd();
        platformSpawnerScript.enabled =false;
    }

    public void StartGame()
    {
        
        platformSpawnerScript.enabled= true;
        cameraScript.ResetCam();
        uiManagerScript.GameStart();
        playerScript.score=0;
        playerScript.isDead= false;
        gameRunning = true;
    }
}