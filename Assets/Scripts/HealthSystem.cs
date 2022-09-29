using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{

    public int maxHealth = 100;
    [SerializeField] private HealthBar healthBar;
    public int damage = 10;
    private int boss_damage;
    public GameObject player;
   
    // Start is called before the first frame update
    void Start()
    {
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (maxHealth <= -12)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        //maxHealth -= damage;
        //healthBar.SetHealth(maxHealth);
        boss_damage = damage;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "weapon")
        {
            maxHealth -= boss_damage;
            healthBar.SetHealth(maxHealth);
        }
    }
}
