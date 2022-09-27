using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeWeapons : MonoBehaviour
{
    public int upgradeAmmo = 60;
    public int upgradeDamage = 5;
    AmmoBox ammoBox;
    EnemyLife enemyLife;

    void Start()
    {
        enemyLife = FindObjectOfType<EnemyLife>();
    }

    // Update is called once per frame
    void Update()
    {
        UpgradeAmmo();
    }

    public void UpgradeAmmo()
    {
        enemyLife.life = enemyLife.life + upgradeAmmo;
        Debug.Log(enemyLife.life);
    }
}
