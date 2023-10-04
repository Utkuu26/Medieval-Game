using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weaponcontroller : MonoBehaviour
{
    public GameObject sword, axe;
    public bool canAttack = true;
    public float attackCooldown = 1.0f;
    public AudioClip swordAttackSfx;
    public AudioClip axeAttackSfx;
    public AudioClip changeWeaponSfx;
    public bool isAttacking = false;
    public bool isSword = true;
    public bool isAxe = false;
    public GameObject[] Weapons;
    public GameObject swordImg;
    public GameObject axeImg;

    void Update() 
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            foreach (GameObject obj in Weapons)
            {
                obj.SetActive(false);
            }
            Weapons[0].SetActive(true);
            AudioSource au = GetComponent<AudioSource>();
            au.PlayOneShot(changeWeaponSfx);
            swordImg.SetActive(true);
            axeImg.SetActive(false);
            isSword = true;
            isAxe = false;
        }

         if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            foreach (GameObject obj in Weapons)
            {
                obj.SetActive(false);
            }
            Weapons[1].SetActive(true);
            AudioSource au = GetComponent<AudioSource>();
            au.PlayOneShot(changeWeaponSfx);
            swordImg.SetActive(false);
            axeImg.SetActive(true);
            isSword = false;
            isAxe = true;
        }

        if(Input.GetMouseButtonDown(0))
        {
            if(canAttack & isSword)
            {
                SwordAttack();
            }

            if(canAttack & isAxe)
            {
                AxeAttack();
            }
        }
    }

    public void SwordAttack()
    {
        isAttacking = true;
        canAttack = false;
        Animator anim = sword.GetComponent<Animator>();
        anim.SetTrigger("Attack");
        AudioSource au = GetComponent<AudioSource>();
        au.PlayOneShot(swordAttackSfx);
        StartCoroutine(ResetAttackCooldown());
    }

    public void AxeAttack()
    {
        isAttacking = true;
        canAttack = false;
        Animator anim = axe.GetComponent<Animator>();
        anim.SetTrigger("Attack");
        AudioSource au = GetComponent<AudioSource>();
        au.PlayOneShot(axeAttackSfx);
        StartCoroutine(ResetAttackCooldown());
    }

    IEnumerator ResetAttackCooldown()
    {
        StartCoroutine(ResetAttackBool());
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }

    IEnumerator ResetAttackBool()
    {
        yield return new WaitForSeconds(1.0f);
        isAttacking = false;
    }

}
