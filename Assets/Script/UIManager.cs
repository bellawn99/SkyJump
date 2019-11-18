using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    Text gameOverText;

    [SerializeField]
    Text scoreText;

    [SerializeField]
    GameObject startButton;
    // Start is called before the first frame update
 
    public void ShowScoreText(int _score){
        scoreText.text="Score: " + _score.ToString();
    }

    public void GameEnd()
    {
        startButton.SetActive(true);
          gameOverText.gameObject.SetActive(true);
    
    }
    public void GameStart(){
        scoreText.gameObject.SetActive(true);
        startButton.SetActive(false);
        gameOverText.gameObject.SetActive(false);
    }
    
}
