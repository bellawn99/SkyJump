using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{

    [SerializeField]
    BoxCollider2D playerBoxCollider2d;

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
    }
}
