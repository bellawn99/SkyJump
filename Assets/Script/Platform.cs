using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{

    public BoxCollider2D playerBoxCollider2d;

    public PlatformSpawner platformSpawnerScript;

    public Transform cameraTrans;

    BoxCollider2D myBoxCollider2d;

    //use this for initialization
    void Start()
    {
        myBoxCollider2d = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerBoxCollider2d.bounds.min.y < myBoxCollider2d.bounds.max.y && myBoxCollider2d.isTrigger == false)
            myBoxCollider2d.isTrigger = true; //player berada dibawah platform
        else if (playerBoxCollider2d.bounds.min.y > myBoxCollider2d.bounds.max.y && myBoxCollider2d.isTrigger == true)
            myBoxCollider2d.isTrigger = false;

        if (transform.position.y <= cameraTrans.position.y - 6f)
            SpawnANewPosition();
    }
    void SpawnANewPosition()
    {
        transform.position = new Vector3(Random.Range(-1.5f, 1.5f), platformSpawnerScript.topPlatformYPos + 2f, 0f);
        platformSpawnerScript.topPlatformYPos += 2f;
    }
}
