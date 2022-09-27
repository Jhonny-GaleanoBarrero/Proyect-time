using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    public int life = 100;
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(life);
        Death();
    }


    public void Death()
    {
        if (life == 0)
        {
            anim.SetBool("dead", true);
            StartCoroutine(DestroidEnemy());

        }
    }

    IEnumerator DestroidEnemy()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
