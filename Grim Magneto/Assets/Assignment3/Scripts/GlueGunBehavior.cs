using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Avatar;

public class GlueGunBehavior : MonoBehaviour
{
    OVRGrabbable m_GrabState;

    //The interactive area that would be activated when pressing down the trigger while grabbing the gluegun
    [SerializeField]
    GameObject m_GlueZone;

    private void Awake()
    {
        //Get component of the OVRGrabbable
        m_GrabState = GetComponent<OVRGrabbable>();
    }

    private void FixedUpdate()
    {
        //If the gluegun is being grabbed, the gluezone is active while the trigger is pressed
        float leftTriggerPressValue = OVRInput.Get(OVRInput.RawAxis1D.LIndexTrigger);
        float rightTriggerPressValue = OVRInput.Get(OVRInput.RawAxis1D.RIndexTrigger);
        bool eitherIndexFingerPressed = leftTriggerPressValue > 0.1f || rightTriggerPressValue > 0.1f;
        bool isGrabbed = m_GrabState.isGrabbed;
        if (isGrabbed && eitherIndexFingerPressed)
        {
            m_GlueZone.SetActive(true);
        }
        else
        {
            m_GlueZone.SetActive(false);
        }
    }
}
