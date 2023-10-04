using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Triggers : MonoBehaviour
{
    public TMP_Text trigger;
    public GameObject trigger1Object;
    public GameObject trigger2Object;
    public GameObject playerControl;
    public GameObject cutControl;
    public GameObject cutCanvas;
    public GameObject mainCanvas;
    public Animator animator;
    public AudioClip nameSfx;
    public AudioClip music;
    public AudioSource ac;
    

    void Start()
    {
        trigger.text = "Find The Last Enemy On Village";
        cutControl.SetActive(false);
        cutCanvas.SetActive(false);
    }

    void OnTriggerEnter(Collider collider)
    {
        if(this.gameObject.tag == "Trigger1")
        {
            trigger.text = "His Sword Is Broken, Be Quick and Kill Him";
            trigger1Object.GetComponent<Collider>().enabled = false;
            trigger2Object.SetActive(true);
        }

         if(this.gameObject.tag == "Trigger2")
        {
            mainCanvas.SetActive(false);
            trigger2Object.GetComponent<Collider>().enabled = false;
            cutControl.SetActive(true);
            animator.SetTrigger("Sail");
            Invoke("ActivateCutCanvas", 5f);
            playerControl.SetActive(false);
            Invoke("LoadScene2", 13f);
            ac.PlayOneShot(music);
        }
    }

     void ActivateCutCanvas()
    {
        cutCanvas.SetActive(true);
        ac.PlayOneShot(nameSfx);
    }

    void LoadScene2()
    {
        SceneManager.LoadScene(2); 
    }
}
