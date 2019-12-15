using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform cameraTrans;

    public GameManagers gameManagerScript;

    public int score = 0;

    float playerFirstYPos;

    [SerializeField]
    AudioSource myAudioSource;

    [SerializeField]
    AudioClip jumpSound;

    [SerializeField]
    float moveSpd;

    [SerializeField]
    float jumpPower;

    Rigidbody2D myRigidbody2d;
    SpriteRenderer mySpriteRenderer;

    public bool isDead = false;


    void Awake()
    {
        myRigidbody2d = GetComponent<Rigidbody2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        playerFirstYPos = transform.position.y;
    }
    void Update()
    {
        FlipCharacter();
        CheckIfDead();
        SetScore();
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
            PlaySound(jumpSound);
        }
    }

    void Movement()
    {
        myRigidbody2d.AddForce(Vector2.right * TouchInput() * moveSpd);     
        float maxXVel = Mathf.Clamp(myRigidbody2d.velocity.x, -5f, 5f);
        myRigidbody2d.velocity= new Vector2(maxXVel, myRigidbody2d.velocity.y);
    }

    void FlipCharacter()
    {
        if (TouchInput() < 0 && !mySpriteRenderer.flipX)
            mySpriteRenderer.flipX = true;
        else if (TouchInput() > 0 && mySpriteRenderer.flipX)
            mySpriteRenderer.flipX = false;

    }
    void CheckIfDead()
    {
        if (transform.position.y <= cameraTrans.position.y - 6f && !isDead)
        {
            //player mati
            isDead = true;
            gameManagerScript.GameOver(score);
        }
    }

    void SetScore(){
        score = Mathf.Max(score,Mathf.FloorToInt(transform.position.y - playerFirstYPos) * 10);
    }
    
    int TouchInput(){
        if(Input.touchCount > 0){
            if(Input.GetTouch(0).position.x < Screen.width/2f)
                return -1;
            else if(Input.GetTouch(0).position.x >= Screen.width/2f)
                return 1;
          }      
        return 0;
    }

    void PlaySound(AudioClip clipToPlay){
    	myAudioSource.clip = clipToPlay;

    	myAudioSource.Play ();
    }
}
