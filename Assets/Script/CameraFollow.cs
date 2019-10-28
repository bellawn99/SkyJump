using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;

    Vector3 followPos;
    float yPos;

    void Awake()
    {
        followPos = new Vector3(transform.position.x, 1, transform.position.z);
    }

    // Start is called before the first frame update
    void Start()
    {
        yPos = player.position.y;
        transform.position = followPos + (Vector3.up * yPos);
    }

    // Update is called once per frame
    void Update()
    {
        yPos = Mathf.Max(yPos, player.position.y);
        transform.position = followPos + (Vector3.up * yPos);
    }
}
