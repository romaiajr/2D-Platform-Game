using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int life = 50;
    private Rigidbody2D rig;
    private Transform enemy;
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        enemy = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag=="Attack")
        {
            life -= 1;
            if(life == 0){
                Destroy(gameObject);
            }
        }
    }
}
