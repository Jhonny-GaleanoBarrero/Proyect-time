using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Procedural : MonoBehaviour
{
    public GameObject[] possibleObjects;
    [Range(0f,1f)]
    public float probability=0.75f;
    // Start is called before the first frame update
    void Start()
    {
        if(Random.Range(0f,1f)<=probability){
            Instantiate(
            possibleObjects[Random.Range(0,possibleObjects.Length)],
            transform.position,
            Quaternion.identity
        );
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
