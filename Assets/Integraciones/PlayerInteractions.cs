using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("GunAmmoNormal")) 
        {
            GameManager.Instance.gunAmmo += other.gameObject.GetComponent<AmmoBox>().ammo;

            Destroy(other.gameObject);
        }
    }

}
