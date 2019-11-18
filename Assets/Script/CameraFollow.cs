using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    GameManagers gameManagerScript;

    public Transform player;

    Vector3 startPos;
    Vector3 followPos;
    float yPos;

    void Awake()
    {
        followPos = new Vector3(transform.position.x, 0, transform.position.z);
        startPos= transform.position;
    }

    // Update is called once per frame
    void Update()
    {
       if(gameManagerScript.gameRunning)
       Follow();
    }

    void Follow()
    {
        yPos = Mathf.Max(yPos, player.position.y);
        transform.position = followPos + (Vector3.up * yPos);
    }

    public void ResetCam()
    {
        transform.position= startPos;
        yPos = player.position.y;
    }
}
