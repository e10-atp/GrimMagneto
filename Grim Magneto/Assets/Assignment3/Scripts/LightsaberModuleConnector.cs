﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsaberModuleConnector : MonoBehaviour
{
    //The GameObject this connector is going to connect
    public GameObject m_ObjectToConnect;

    //Does connecting this object requires glue
    public bool m_RequiresGlue;

    //The boolean shows if the object is connected. Would be accessed from the LightsaberBehavior script
    private bool m_isConnected;
    public bool isConnected
    {
        get
        {
            return m_isConnected;
        }

        set
        {
            m_isConnected = value;
        }
    }

    

    private void OnTriggerEnter(Collider other)
    {
        if (!m_RequiresGlue)
        {
            if (other.gameObject == m_ObjectToConnect)
            {
                isConnected = true;
            }
        }

        if(m_RequiresGlue)
        {
            //check if the other object is GlueZone
            //if so switch off requiresGlue
            if (other.gameObject.name.Equals("GlueZone"))
            {
                m_RequiresGlue = false;
            }
            
        }
    }
}
