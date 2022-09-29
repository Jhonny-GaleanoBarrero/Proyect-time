using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SRBossBehavior : MonoBehaviour
{
    [Header ("Boss Movement")]
    public Animator ani;
    [Range(1, 4)] public int walkSpeed;
    [Range(4, 6)] public int runSpeed;
    private int animation_flow;
    private float animator_control;
    private Quaternion grade;
    private float twist;

    [Header ("Target")]
    public GameObject target;
    [Range(5, 10)] public int distanceDetection;
    [Range(2, 3)] public int attackDistance;
    private HealthSystem damage;
    private int attack_flow;
    private float attack_control;
    private bool attacking;

    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player");
        boss_entrance();
    }

    // Update is called once per frame
    void Update()
    {
        Boss_movement();
    }

    public void boss_entrance()
    {
        ani.SetBool("Intro", true);
        ani.SetBool("Idle", true);
    }


    public void Boss_movement()
    {

        if (Vector3.Distance(transform.position, target.transform.position) > distanceDetection)
        {
            ani.SetBool("Run", false);
            animator_control += 1 * Time.deltaTime;
            if (animator_control >= 4)
            {
                animation_flow = Random.Range(0, 2);
                animator_control = 0;
            }
            switch (animation_flow)
            {
                case 0:
                    ani.SetBool("Walk", false);
                    break;

                case 1:
                    twist = Random.Range(0, 360);
                    grade = Quaternion.Euler(0, twist, 0);
                    animation_flow++;
                    break;

                case 2:
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, grade, 0.5f);
                    transform.Translate(Vector3.forward * walkSpeed * Time.deltaTime);
                    ani.SetBool("Walk", true);
                    break;
            }
        }
        else
        {
            if (Vector3.Distance(transform.position, target.transform.position) > attackDistance && !attacking)
            {
                var lookPos = target.transform.position - transform.position;
                lookPos.y = 0;
                var rotation = Quaternion.LookRotation(lookPos);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 3);
                ani.SetBool("Walk", false);
                ani.SetBool("Run", true);
                transform.Translate(Vector3.forward * runSpeed * Time.deltaTime);
                ani.SetBool("Attack1", false);
                ani.SetBool("Attack2", false);
            }
            else
            {

                attack_control += 1 * Time.deltaTime;
                if (attack_control >= 1)
                {
                    attack_flow = Random.Range(0, 2);
                    attack_control = 0;
                }
                switch (attack_flow)
                {
                    case 0:
                        ani.SetBool("Walk", false);
                        ani.SetBool("Run", false);
                        ani.SetBool("Attack1", true);
                        damage.TakeDamage(5);
                    break;

                    case 1:
                        ani.SetBool("Walk", false);
                        ani.SetBool("Run", false);
                        ani.SetBool("Attack2", true);
                        damage.TakeDamage(10);
                    break;
                }
                attacking = true;
            }
        }
    }

    public void Final_ani_attack1()
    {
        ani.SetBool("Attack1", false);
        attack_flow = 0;
        attacking = false;
    }

    public void Final_ani_attack2()
    {
        ani.SetBool("Attack2", false);
        attack_flow = 0;
        attacking = false;
    }

    public void End_intro()
    {
        ani.SetBool("Intro", false);
    }
}
