using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCollisionDedection : MonoBehaviour
{
    public Weaponcontroller wc;
    public GameObject hitPartickle1;
    public GameObject hitPartickle2;
    public int swordDmgAmount = 20;
    public int axeDmgAmount = 25;
    public BloodManager bm;
    public AudioSource enemySource;
    public AudioClip hitSfx;

    private void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "Enemy" && wc.isAttacking)
        {
            //Debug.Log(other.name);
            other.GetComponent<Animator>().SetBool("Hitted", true);

            if(wc.isSword)
            {
                other.GetComponent<Enemy1Stats>().TakeDamage(swordDmgAmount);
            }

            if(wc.isAxe)
            {
                other.GetComponent<Enemy1Stats>().TakeDamage(axeDmgAmount);
            }
            
            AudioSource au = GetComponent<AudioSource>();
            au.PlayOneShot(hitSfx);

            int randomValue = Random.Range(0, 3);
            if (randomValue == 0)
            {
                bm.ActivateBlood1();
            }
            else if (randomValue == 1)
            {
                bm.ActivateBlood2();
            }
        }

         if(other.tag == "Enemy2" && wc.isAttacking)
        {
            other.GetComponent<Animator>().SetBool("Hitted", true);

            if(wc.isSword)
            {
                other.GetComponent<Enemy1Stats>().TakeDamage(swordDmgAmount);
            }

            if(wc.isAxe)
            {
                other.GetComponent<Enemy1Stats>().TakeDamage(axeDmgAmount);
            }
            
            AudioSource au = GetComponent<AudioSource>();
            au.PlayOneShot(hitSfx);

            int randomValue = Random.Range(0, 3);
            if (randomValue == 0)
            {
                bm.ActivateBlood1();
            }
            else if (randomValue == 1)
            {
                bm.ActivateBlood2();
            }
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if(other.tag == "Enemy" && wc.isAttacking)
        {
            other.GetComponent<Animator>().SetBool("Hitted", false);
        }

        if(other.tag == "Enemy2" && wc.isAttacking)
        {
            other.GetComponent<Animator>().SetBool("Hitted", false);
        }
    }
}
