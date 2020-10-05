using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyAttackController : MonoBehaviour{
    public Rigidbody2D rb;
    public float speed;
    void Start(){
    }

    void FixedUpdate(){
        rb.velocity = transform.right * -speed;
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){
            //  Destroy(other.gameObject);
            Destroy(gameObject);
            // GameOver.isPlayerDead = true;
        }
        if(other.tag == "Bricks"){
            Destroy(gameObject);
        }
        if(other.tag == "Attack"){
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
  

