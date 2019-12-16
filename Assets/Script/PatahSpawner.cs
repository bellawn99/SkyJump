using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatahSpawner : MonoBehaviour
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
    Transform platformSecond;

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

        if(platformSecond.childCount <= 0){

            playerGO = Instantiate(playerPrefabs, Vector3.zero, Quaternion.identity) as GameObject;

            playerBoxCol2d = playerGO.GetComponent<BoxCollider2D>();

            GetComponentForPlayerScript(playerGO.GetComponent<PlayerController>());

            cameraScript.player = playerGO.transform;

            GetComponentForGameManager();

        }else{
            playerGO.SetActive(true);
        }

       

        for (int i = 0; i < 12; i++ )
        {
            xPos = Random.Range(-1.5f, 1.5f);

            if(platformSecond.childCount <=i){
                platformGO = Instantiate(platformPrefabs, new Vector3(xPos, yPos, 0f), Quaternion.identity) as GameObject;
                platformGO.transform.SetParent(platformSecond);
                Patah patahScript = platformGO.GetComponent<Patah>();
                GetComponentForPlatformScript(patahScript);
            }else{
                platformGO =platformSecond.GetChild(i).gameObject;
                platformGO.transform.position = new Vector3(xPos, yPos, 0f);
            }
          

            if (i <= 0)
            {
                playerGO.transform.position = new Vector3(xPos, yPos + 1f, 0f);
            }

            topPlatformYPos = yPos;
            yPos += 4f;
        }

    }

    void GetComponentForPlatformScript(Patah _platformScript)
    {
        //Mengambil semua komponen yang dibutuhkan oleh PlatformScript
        _platformScript.playerBoxCollider2d = playerBoxCol2d;
        _platformScript.patahSpawnerScript = this;
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
