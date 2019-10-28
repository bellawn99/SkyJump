using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField]
    CameraFollow cameraScript;

    [SerializeField]
    GameObject platformPrefabs;

    [SerializeField]
    GameObject playerPrefabs;

    BoxCollider2D playerBoxCol2d;

    public float topPlatformYPos = 0;

    void Start()
    {
        SpawnPlatformStart();
    }

    void SpawnPlatformStart()
    {
        float yPos = -3f;

        float xPos = 0f;

        GameObject playerGO = Instantiate(playerPrefabs, Vector3.zero, Quaternion.identity) as GameObject;

        playerBoxCol2d = playerGO.GetComponent<BoxCollider2D>();

        GetComponentForPlayerScript(playerGO.GetComponent<PlayerController>());

        cameraScript.player = playerGO.transform;

        for (int i = 0; i < 6; i++ )
        {
            xPos = Random.Range(-1.5f, 1.5f);

            GameObject platformGO = Instantiate(platformPrefabs, new Vector3(xPos, yPos, 0f), Quaternion.identity) as GameObject;

            if (i <= 0)
            {
                playerGO.transform.position = new Vector3(xPos, yPos + 1f, 0f);
            }

            Platform platformScript = platformGO.GetComponent<Platform>();

            GetComponentForPlatformScript(platformScript);

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
    }

    void GetComponentForPlayerScript(PlayerController _playerScript)
    {
        //Mengambil semua komponen yang dibutuhkan oleh PlayermScript
        _playerScript.cameraTrans = cameraScript.gameObject.transform;
    }
}
