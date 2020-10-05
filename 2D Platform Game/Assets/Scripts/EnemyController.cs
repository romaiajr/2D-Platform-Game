using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    public int life = 50;
    private Transform enemy;
    public float fireRate = 0.997f;
    public GameObject attack;
    [SerializeField] ParticleSystem psystem = null;
    void Start()
    {
        enemy = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Shot();
    }
    void Shot(){
        foreach(Transform Firepoint in enemy){
            if(Random.value > fireRate)
                Instantiate(attack, Firepoint.position, Firepoint.rotation);
        }
    }
    void OnTriggerEnter2D(Collider2D other){
        if(other.tag=="Attack")
        {
            life -= 1;
            psystem.Play();
            if(life == 0){
                Destroy(gameObject);
                // SceneManager.LoadScene("Menu");
            }
        }
    }
}
