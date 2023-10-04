using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyWeapon : MonoBehaviour
{
    public EnemyController ec;
    public int enemySwordDmgAmount = 10;

        public void OnTriggerEnter(Collider other) 
        {
            if(other.tag == "Player" && ec.isEnemyAttacking)
            {
                other.GetComponent<Enemy1Stats>().TakeDamage(enemySwordDmgAmount);
            }
        }
  
}
