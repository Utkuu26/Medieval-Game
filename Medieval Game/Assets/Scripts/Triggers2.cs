using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Triggers2 : MonoBehaviour
{
    public TMP_Text Scene2trigger;
    public GameObject Scene2trigger1Object;
    void Start()
    {
        Scene2trigger.text = "Kill All Enemies In The Village";
    }

    void OnTriggerEnter(Collider collider)
    {
        if(this.gameObject.tag == "Trigger3")
        {
            //Scene2trigger.text = "His Sword Is Broken, Be Quick and Kill Him";
            Scene2trigger1Object.GetComponent<Collider>().enabled = false;
        }
         if(this.gameObject.tag == "Trigger4")
        {
            //trigger.text = "Get Onboard and Go To Next Village";
        }
    }
}
