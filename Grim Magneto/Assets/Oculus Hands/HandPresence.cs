using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandPresence : MonoBehaviour
{
    [SerializeField] private bool isRight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isRight)
        {
            float i = OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger);
            GetComponent<Animator>().SetFloat("Trigger", i);
            GetComponent<Animator>().SetFloat("Grip", i);

        
            Behaviour halo =(Behaviour)gameObject.GetComponent ("Halo");
            if (i == 1f)
            {
                halo.enabled = true;
            }
            else
            {
                halo.enabled = false;
            }
        }
        else
        {
            float i = Math.Max(OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger), OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger));
            GetComponent<Animator>().SetFloat("Trigger", i);
            GetComponent<Animator>().SetFloat("Grip", i);

        
            Behaviour halo =(Behaviour)gameObject.GetComponent ("Halo");
            if (i == 1f)
            {
                halo.enabled = true;
            }
            else
            {
                halo.enabled = false;
            }
        }
        
    }
}
