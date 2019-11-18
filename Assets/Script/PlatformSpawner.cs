using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    
    [SerializeField]
    GameManagers gameManagerScript;

    [SerializeField]
    CameraFollow cameraScript;

    [SerializeField]
    GameObject platformPrefabs;

    [SerializeField]
    GameObject playerPrefabs;

    [SerializeField]
    Transform platformParent;

    BoxCollider2D playerBoxCol2d;

    GameObject playerGO;

     GameObject platformGO;

    public float topPlatformYPos = 0;

    void OnEnable()
    {
        SpawnPlatformStart();
    }

    void SpawnPlatformStart()
    {
        float yPos = -3f;

        float xPos = 0f;

        topPlatformYPos = 0;

        if(platformParent.childCount <= 0){

            playerGO = Instantiate(playerPrefabs, Vector3.zero, Quaternion.identity) as GameObject;

            playerBoxCol2d = playerGO.GetComponent<BoxCollider2D>();

            GetComponentForPlayerScript(playerGO.GetComponent<PlayerController>());

            cameraScript.player = playerGO.transform;

            GetComponentForGameManager();

        }else{
            playerGO.SetActive(true);
        }

       

        for (int i = 0; i < 6; i++ )
        {
            xPos = Random.Range(-1.5f, 1.5f);

            if(platformParent.childCount <=i){
                platformGO = Instantiate(platformPrefabs, new Vector3(xPos, yPos, 0f), Quaternion.identity) as GameObject;
                platformGO.transform.SetParent(platformParent);
                Platform platformScript = platformGO.GetComponent<Platform>();
                GetComponentForPlatformScript(platformScript);
            }else{
                platformGO =platformParent.GetChild(i).gameObject;
                platformGO.transform.position = new Vector3(xPos, yPos, 0f);
            }
          

            if (i <= 0)
            {
                playerGO.transform.position = new Vector3(xPos, yPos + 1f, 0f);
            }

            topPlatformYPos = yPos;
            yPos += 2f;
        }

    }

    void GetComponentForPlatformScript(Platform _platformScript)
    {
        //Mengambil semua komponen yang dibutuhkan oleh PlatformScript
        _platformScript.playerBoxCollider2d = playerBoxCol2d;
        _platformScript.platformSpawnerScript = this;
        _platformScript.cameraTrans = cameraScript.gameObject.transform;
        _platformScript.gameManagerScript= this.gameManagerScript;
    }

    void GetComponentForPlayerScript(PlayerController _playerScript)
    {
        //Mengambil semua komponen yang dibutuhkan oleh PlayermScript
        _playerScript.cameraTrans = cameraScript.gameObject.transform;
        _playerScript.gameManagerScript= this.gameManagerScript;
    }

    void GetComponentForGameManager(){
        gameManagerScript.playerScript= playerGO.GetComponent<PlayerController>();
    }
}
