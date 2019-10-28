using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform cameraTrans;

    [SerializeField]
    float moveSpd;

    [SerializeField]
    float jumpPower;

    Rigidbody2D myRigidbody2d;
    SpriteRenderer mySpriteRenderer;

    bool isDead = false;

    void Awake()
    {
        myRigidbody2d = GetComponent<Rigidbody2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        FlipCharacter();
        CheckIfDead();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Movement();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Jumpable"))
        {
            myRigidbody2d.velocity = new Vector2(myRigidbody2d.velocity.x, 0f);
            myRigidbody2d.AddForce(Vector2.up * jumpPower);
        }
    }

    void Movement()
    {
        Vector3 pos = myRigidbody2d.position;
        myRigidbody2d.AddForce(Vector2.right * Input.GetAxis("Horizontal") * moveSpd);
        pos.x = Mathf.Clamp(pos.x, -1.7f, 1.7f);
        myRigidbody2d.position = pos;
    }

    void FlipCharacter()
    {
        if (Input.GetAxisRaw("Horizontal") < 0)
            mySpriteRenderer.flipX = true;
        else if (Input.GetAxisRaw("Horizontal") > 0)
            mySpriteRenderer.flipX = false;
    }

    void CheckIfDead()
    {
        if (transform.position.y <= cameraTrans.position.y - 6f && !isDead)
        {
            isDead = true;
            print("Game Over");
        }
    }

}
