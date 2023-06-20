using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    //public AudioClip hapticAudioClip;
    public AudioSource source;
    //public AudioClip laserSound;
    public GameObject laser;
    public Transform barrelLocation;

    private float fireRate = 0.05f;
    private float nextFire = 0.0f;

    public float shootPower;
    private bool triggerDown = false;

    private OVRHapticsClip clip;
    
    // Start is called before the first frame update
    void Start()
    {
        if (barrelLocation == null) {
            barrelLocation = transform;
        }

        source.loop = true;
        
        clip = new OVRHapticsClip();
        for (var i = 0; i < 40; i++)
        {
            clip.WriteSample((i%2 == 0) ? (byte) 255 : (byte) 0);
        }

    }

    // Update is called once per frame
    void Update()
    {
        CheckTrigger();
        Shoot();
    }

    private void CheckTrigger() 
    {
        if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger)) {
            triggerDown = true;
            source.Play();
            // OVRInput.SetControllerVibration(0.5f, 0.5f, OVRInput.Controller.LTouch);
        }
        if (OVRInput.GetUp(OVRInput.Button.SecondaryIndexTrigger)) {
            triggerDown = false;
            source.Stop();
            OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.RTouch);
            // OVRInput.SetControllerVibration(0f, 0f, OVRInput.Controller.LTouch);
        }
    }

    private void Shoot()
    {
        if (triggerDown && Time.time > nextFire) {
            nextFire = Time.time + fireRate;
            OVRInput.SetControllerVibration(1f, 0.3f, OVRInput.Controller.RTouch);
            Instantiate(laser, barrelLocation.position, barrelLocation.rotation * Quaternion.Euler(90f, 0, 0)).GetComponent<Rigidbody>().AddForce(barrelLocation.forward * shootPower);

            // VibrationManager.Singleton.TriggerVibration(40, 2, 255, OVRInput.Controller.LTouch);
            
            //source.PlayOneShot(laserSound);
            //OVRHapticsClip hapticsClip = new OVRHapticsClip(hapticAudioClip);
            //OVRHaptics.RightChannel.Preempt(hapticsClip);
        }
    }
}
