using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float moveSpd;

    [SerializeField]
    float jumpPower;

    Rigidbody2D myRigidbody2d;

    void Awake()
    {
        myRigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        myRigidbody2d.AddForce(Vector2.right * Input.GetAxis("Horizontal") * moveSpd);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        myRigidbody2d.AddForce(Vector2.up * jumpPower);
    }
}
