using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject platformPrefabs;

    [SerializeField]
    GameObject playerPrefabs;

    void Start()
    {
        SpawnPlatformStart();
    }

    void SpawnPlatformStart()
    {
        float yPos = -3f;

        float xPos = 0f;

        for (int i = 0; i < 6; i++ )
        {
            xPos = Random.Range(-1.5f, 1.5f);

            Instantiate(platformPrefabs, new Vector3(xPos, yPos, 0f), Quaternion.identity);

            if (i <= 0)
                Instantiate(playerPrefabs, new Vector3(xPos, yPos + 1f, 0f), Quaternion.identity);

            yPos += 2f;
        }
    }
}
