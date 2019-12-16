﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patah : MonoBehaviour
{

    public BoxCollider2D playerBoxCollider2d;

    public PatahSpawner patahSpawnerScript;

    public Transform cameraTrans;

    public GameManagers gameManagerScript;

    BoxCollider2D myBoxCollider2d;


    //use this for initialization
    void Start()
    {
        myBoxCollider2d = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
    
      if(gameManagerScript.gameRunning){
        if (playerBoxCollider2d.bounds.min.y < myBoxCollider2d.bounds.max.y && myBoxCollider2d.isTrigger == false)
            myBoxCollider2d.isTrigger = false; //player berada dibawah platform
        else if (playerBoxCollider2d.bounds.min.y > myBoxCollider2d.bounds.max.y && myBoxCollider2d.isTrigger == true)
            myBoxCollider2d.isTrigger = false;

        if (transform.position.y <= cameraTrans.position.y - 6f)
            SpawnANewPosition();
        }
    }
    void SpawnANewPosition()
    {
        transform.position = new Vector3(Random.Range(-1.5f, 1.5f), patahSpawnerScript.topPlatformYPos + 4f, 0f);
        patahSpawnerScript.topPlatformYPos += 4f;
    }
}
