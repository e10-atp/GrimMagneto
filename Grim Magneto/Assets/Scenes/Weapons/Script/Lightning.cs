using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour
{
    //public AudioClip hapticAudioClip;
    [SerializeField] AudioSource source;
    [SerializeField] private GameObject lightning;
    private bool triggerDown = false;
    private OVRHapticsClip clip;
    
    // Start is called before the first frame update
    void Start()
    {
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
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger)) {
            triggerDown = true;
            lightning.SetActive(true);
            source.Play();
            // OVRInput.SetControllerVibration(0.5f, 0.5f, OVRInput.Controller.LTouch);
        }
        if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger)) {
            triggerDown = false;
            lightning.SetActive(false);
            source.Stop();
            OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.LTouch);
            // OVRInput.SetControllerVibration(0f, 0f, OVRInput.Controller.LTouch);
        }
    }

    private void Shoot()
    {
        if (triggerDown)
        {
            OVRInput.SetControllerVibration(1f, 0.3f, OVRInput.Controller.LTouch);
        }

        

            // VibrationManager.Singleton.TriggerVibration(40, 2, 255, OVRInput.Controller.LTouch);
            
            //source.PlayOneShot(laserSound);
            //OVRHapticsClip hapticsClip = new OVRHapticsClip(hapticAudioClip);
            //OVRHaptics.RightChannel.Preempt(hapticsClip);
        }
    }

