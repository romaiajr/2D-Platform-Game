﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
private Transform player;    
public float Speed;
public float JumpForce;
public int life;
[SerializeField] ParticleSystem psystem = null;

public bool isJumping;
public bool doubleJump;
public Text restart;

public GameObject shot;
public Transform shotSpawn;
public float fireRate;
private float nextFire;
private Rigidbody2D rig;
private Animator anim;

    // Start is called before the first frame update
    void Start(){
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        player = GetComponent<Transform> ();
        restart = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update(){
        Move();
        Jump();
        Attack();
        if(life == 0){
            restart.enabled = true;
        }
    }

    void Move(){
        float movement = Input.GetAxis("Horizontal");
        rig.velocity = new Vector2(movement * Speed, rig.velocity.y);
        if(movement > 0f){
            anim.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f,0f,0f);
        }
        if(movement < 0f){
            anim.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f,180f,0f);
        }
        if(movement == 0f){
            anim.SetBool("walk", false);
        }
    }

    void Jump(){
        if(Input.GetButtonDown("Jump")){
            if(!isJumping)
            {
                rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
                doubleJump = true;
            }
            else
            {
                if(doubleJump)
                {
                    rig.AddForce(new Vector2(0f, JumpForce/1.5f), ForceMode2D.Impulse);
                    doubleJump = false;
                }
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.layer == 8)
        {
            isJumping = false;
            anim.SetBool("jump", false);            
        }
    }

    void OnCollisionExit2D(Collision2D collision){
        if(collision.gameObject.layer == 8)
        {
            isJumping = true;
            anim.SetBool("jump", true);
        }
    }

    void Attack(){
        if(Input.GetButton ("Fire1") && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
		}
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag=="Enemy_attack"){
            life -= 1;
            psystem.Play();
            if(life == 0){
                Destroy(gameObject); 
                // SceneManager.LoadScene("Menu");
            }
        }
         if(other.tag=="Enemy"){
            life -= 1;
            psystem.Play();
            if(life == 0){
                Destroy(gameObject);
                Destroy(other.gameObject);
                // SceneManager.LoadScene("Menu");
            }
        }
    
    }
}
