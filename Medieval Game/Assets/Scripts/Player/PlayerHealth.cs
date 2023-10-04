using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public float hp = 200;
    private bool isDead = false; 
    public TMP_Text triggerTxt;
    public TMP_Text hpTxt;

     public void TakeDamage(int damageAmount)
    {
        if (isDead) return;
        hp -= damageAmount;
        hpTxt.text = hp.ToString();
        if(hp <= 0)
        {
            isDead = true;

            //GetComponent<Collider>().enabled = false;
            Rigidbody rb = GetComponent<Rigidbody>();

            rb.useGravity = false;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
         
            triggerTxt.text = "You Need To Try Again";      
        }
    }
}
