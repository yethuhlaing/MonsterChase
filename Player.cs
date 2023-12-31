using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float moveForce = 10f;
    private float jumpForce = 12f;
    private float movementX;
    private Rigidbody2D myBody;
    
    private SpriteRenderer sr;
    private Animator anim;
    private bool isGround = true;
    private string WALK_ANIMATION = "Walk";
    private string GROUND_TAG = "ground";
    private string ENEMY_TAG = "enemy";
    // Start is called before the first frame update
    private void Awake(){
        myBody =  GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AnimatePlayer();
        
    }
    void FixedUpdate(){
        PlayerMoveKeyboard();
        JumpPlayer();
    }

    private void PlayerMoveKeyboard(){
        movementX = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(movementX, 0f , 0f) * Time.deltaTime * moveForce;
    }

    private void AnimatePlayer()
    {
        if (movementX > 0)
        {
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = false;
        } 
        else if( movementX < 0){
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = true;
        }
        else{
            anim.SetBool(WALK_ANIMATION, false);
        }
    }
    private void JumpPlayer(){
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            isGround = false;
            myBody.velocity = new Vector2(myBody.velocity.x, 0);
            myBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.CompareTag(GROUND_TAG))
        {
            isGround = true;
        }
        if (collision.gameObject.CompareTag(ENEMY_TAG))
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(ENEMY_TAG))
        {
            Destroy(gameObject);
        }
    }
}
