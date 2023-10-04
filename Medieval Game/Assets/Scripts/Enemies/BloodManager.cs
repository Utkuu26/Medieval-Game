using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodManager : MonoBehaviour
{
    public GameObject hitPartickle1;
    public GameObject hitPartickle2;

    public void DestroyBlood()
    {
        hitPartickle1.SetActive(false);
        hitPartickle2.SetActive(false);
    }

    public void ActivateBlood1()
    {
        hitPartickle1.SetActive(true);
    }

    public void ActivateBlood2()
    {
        hitPartickle2.SetActive(true);
    }
}
