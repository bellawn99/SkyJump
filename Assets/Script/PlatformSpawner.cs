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

            platformScript.playerBoxCollider2d = playerGO.GetComponent<BoxCollider2D>();
            platformScript.platformSpawnerScript = this;
            platformScript.cameraTrans = cameraScript.gameObject.transform;
            topPlatformYPos = yPos;
            yPos += 2f;
        }

    }
}
