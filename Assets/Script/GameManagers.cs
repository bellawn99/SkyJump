using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagers : MonoBehaviour{

    [SerializeField]
    UIManager uiManagerScript;

    [SerializeField]
    CameraFollow cameraScript;

    [SerializeField]
    PlatformSpawner platformSpawnerScript;

    [SerializeField]
    ScoreManager scoreManagerScript;

    [SerializeField]
    AudioClip gameOverSound;

    [HideInInspector]
    public PlayerController playerScript;

    [SerializeField]
    AudioSource myAudioSource;

    public bool gameRunning = false;
    // Start is called beforSe the first frame update

    void Update()
    {
        if(gameRunning)
        uiManagerScript.ShowScoreText(playerScript.score);
    }

    public void GameOver(int score)
    {
        scoreManagerScript.AddScore(score);
        gameRunning = false;
        playerScript.gameObject.SetActive(false);
        uiManagerScript.GameEnd();
        platformSpawnerScript.enabled =false;
        PlaySound(gameOverSound);
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

    public void QuitGame(){
        Application.Quit();
    }

    void PlaySound(AudioClip clipToPlay){
    	myAudioSource.clip = clipToPlay;

    	myAudioSource.Play ();
    }
}
