using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Enemy1Stats : MonoBehaviour
{
    public int hp = 100;
    public Animator animator;
    public Animator Enemy2Anim;
    private bool isDead = false; 
    public BloodManager bm;
    public AudioSource EnemySource;
    public AudioClip dieSfx;
     private static int remainingEnemy = 4;
    public TMP_Text remaingEnemyTxt; 
    public GameObject damageTxt;
    public TMP_Text trigger;
    public bool isLevel2 = false;
    

    public void TakeDamage(int damageAmount)
    {
        if (isDead) return;
        hp -= damageAmount;
        DamagePopUp popUp = Instantiate(damageTxt, transform.position, Quaternion.identity).GetComponent<DamagePopUp>();
        popUp.SetDamageText(damageAmount);

        if(hp <= 0)
        {
            isDead = true;

            if(!isLevel2)
            {
                AudioSource au = GetComponent<AudioSource>();
                au.PlayOneShot(dieSfx, 3.0f);
                trigger.text = "Get Onboard and Go To Next Village";
                Rigidbody rb1 = GetComponent<Rigidbody>();
                rb1.useGravity = false;
                rb1.velocity = Vector3.zero;
                rb1.angularVelocity = Vector3.zero;
            }

            animator.SetTrigger("Dying");
            Enemy2Anim.SetTrigger("Dying2");
            remainingEnemy -= 1;
            Debug.Log(remainingEnemy);
            remaingEnemyTxt.text =  "Remaining Enemy: " + remainingEnemy.ToString();
            if(remainingEnemy <= 0)
            {
                trigger.text = "Village saved successfully thanks to you";
            }

            //GetComponent<Collider>().enabled = false;
            bm.DestroyBlood();
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.useGravity = true;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
}
