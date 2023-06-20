using System;
using UnityEngine;

public class GrenadeThrow: MonoBehaviour
{
    public GameObject grenade;
    private Boolean hasGrenade = false;
    private GameObject currentGrenade;

    private void Update()
    {
        // float i = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger);
        // if (i == 1f)
        // {
        //     if (!hasGrenade)
        //     {
        //         CreateGrenade();
        //         hasGrenade = true;
        //     }
        // }
        // else
        // {
        //     if (hasGrenade)
        //     {
        //         hasGrenade = false;
        //     }
        // }
    }

    private void CreateGrenade()
    {
        currentGrenade = Instantiate(grenade);
        currentGrenade.transform.position = gameObject.transform.position;
        OVRGrabber grabber = gameObject.GetComponent<OVRGrabber>();
        grabber.OnUpdatedAnchors();
        // grabber.GrabBegin();
    }
}