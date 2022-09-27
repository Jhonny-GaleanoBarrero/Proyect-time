using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 10;
    
    EnemyLife enemyLife;

    private float shotSpeed = 50f;
    private float timeToDestroy = 3f;
    public Vector3 target { get; set; }
    public bool hit { get; set; }

    void Start()
    {
        enemyLife = FindObjectOfType<EnemyLife>();
    }

    private void OnEnable()
    {
        Destroy(gameObject, timeToDestroy);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "enemy")
        {
            enemyLife.life = enemyLife.life - damage;
            Destroy(gameObject);
        }        
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, shotSpeed * Time.deltaTime);
        if(!hit && Vector3.Distance(transform.position, target) < .01f)
        {
            Destroy(gameObject);
        }
    }
    //private void OnCollisionEnter(Collision collision)
    //{

    //    if(collision.gameObject.CompareTag("enemy"))
    //    {

    //    }    
    //}
}
