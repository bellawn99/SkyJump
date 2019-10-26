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
    SpriteRenderer mySpriteRenderer;

    void Awake()
    {
        myRigidbody2d = GetComponent<Rigidbody2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") < 0)
            mySpriteRenderer.flipX = true;
        else if(Input.GetAxisRaw("Horizontal") > 0)
            mySpriteRenderer.flipX = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        myRigidbody2d.AddForce(Vector2.right * Input.GetAxis("Horizontal") * moveSpd);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        myRigidbody2d.velocity = new Vector2(myRigidbody2d.velocity.x,0f);
        myRigidbody2d.AddForce(Vector2.up * jumpPower);
    }
}
