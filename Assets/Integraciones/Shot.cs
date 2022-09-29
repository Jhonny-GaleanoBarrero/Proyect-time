using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Shot : MonoBehaviour
{
    private Transform cameraTransform;
    public Transform spawnPoint;
    public GameObject bullet;
    public float shotForce = 1500f;
    public float shotRate = 0.5f;
    public AudioClip soundShoot;
    public AudioSource soundControl;



    
    void Start()
    {
        cameraTransform = Camera.main.transform;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))   
        {
            if ( GameManager.Instance.gunAmmo > 0)
            {
                GameManager.Instance.gunAmmo--;

                
                GameObject newBullet;
                newBullet = Instantiate(bullet, spawnPoint.position, cameraTransform.rotation);
                soundControl.PlayOneShot(soundShoot);
                Bullet bulletController = newBullet.GetComponent<Bullet>();
                int ignoreRaycastLayer = 1 << 2;
                ignoreRaycastLayer = ~ignoreRaycastLayer;
                RaycastHit hit;
                if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out hit, Mathf.Infinity, ignoreRaycastLayer))
                {
                    bulletController.target = hit.point;
                    bulletController.hit = true;
                }
                else
                {
                    bulletController.target = cameraTransform.position + cameraTransform.forward * 25f;
                    bulletController.hit = false;
                }
                    
                    
            }
        }

    }
}
