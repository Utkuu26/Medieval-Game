using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float agroDistance;
    public Transform target;
    Vector3 pos;
    Animator animator;
    public Animator enemy2Anim;
    public GameObject enemyWeapon;
    public bool isEnemyAttacking = false;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        agroDistance = Vector3.Distance(transform.position, target.position);
        pos = new Vector3(target.position.x, transform.position.y, target.position.z);

        if(agroDistance < 30f)
        {
            transform.LookAt(pos);
            enemy2Anim.SetBool("CombatMode", true);
            isEnemyAttacking = true;
        }

        else
        {
            enemy2Anim.SetBool("CombatMode", false);
        }

    }
}
