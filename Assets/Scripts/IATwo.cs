using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IATwo : MonoBehaviour
{
    public NavMeshAgent nav;
    public GameObject objective;
    EnemyLife enemyLife;

    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        objective = GameObject.Find("Player");
        enemyLife = GetComponent<EnemyLife>();
    }

    // Update is called once per frame
    void Update()
    {
        nav.destination = objective.transform.position;
        if (enemyLife.life <= 0)
        {
            nav.destination = gameObject.transform.position;
        }
    }


}
