using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Avatar;

public class LightsaberBehavior : MonoBehaviour
{
    //Accessing the script that take care of lightsaber's grabbing state
    OVRGrabbable m_GrabState;

    //The Quillon that already installed on the handle. Should be inactive at the begginning of the game
    [SerializeField]
    GameObject m_LightsaberQuillonInstalled;
    //The Quillon module that has not been installed yet.
    [SerializeField]
    GameObject m_LightsaberQuillonModule;
    //The active area to snap the quillon module to the handle
    [SerializeField]
    GameObject m_QuillonConnectZone;
    bool m_QuillonIsInstalled;

    //The Power that already installed on the handle. Should be inactive at the beginning of the game
    [SerializeField]
    GameObject m_LightsaberPowerInstalled;
    //The Power module that has not been installed yet
    [SerializeField]
    GameObject m_LightsaberPowerModule;
    //The active area to snap the power module to the handle
    [SerializeField]
    GameObject m_PowerConnectZone;
    bool m_PowerIsInstalled;

    //bool to signal if the lightsaber is done assembling
    bool m_LightsaberIsAssembled;

    //The blade that already installed on the handle
    [SerializeField]
    GameObject m_LightsaberBlade;
    [SerializeField]
    float m_LightsaberLength = 0.5f;
    [SerializeField]
    float m_BladeSmooth = 1f;
    bool m_BladeIsActivated = false;
    private bool m_FirstDraw = true;

    private float bladeDrawTime = 1.0f;
    private float currentDrawTime = 0.0f;
    private Vector3 bladeDrawnScale;
    private Vector3 bladeSheathedScale;
    
    // audio sources
    private AudioSource powerOnAudio;
    private AudioSource bladeWooshAudio;
    private Vector3 quillonPosition;

    private void Awake()
    {
        //[TODO]Getting the info of OVRGrabbable
        m_GrabState = GetComponent<OVRGrabbable>();
        Vector3 bladeScale = m_LightsaberBlade.transform.localScale;
        bladeDrawnScale = new Vector3(m_LightsaberLength, bladeScale.y, bladeScale.z);
        bladeSheathedScale = new Vector3(0.0f, bladeScale.y, bladeScale.z);
        powerOnAudio = m_LightsaberPowerInstalled.GetComponent<AudioSource>();
        bladeWooshAudio = m_LightsaberQuillonInstalled.GetComponent<AudioSource>();
        quillonPosition = m_LightsaberQuillonInstalled.transform.position;
    }

    private void FixedUpdate()
    {
        //[TODO]Step one: check if the power is connected.
        ConnectingPower();

        //[TODO]Step two: check in the Quillon is connected.
        ConnectingQuillon();

        //[TODO]Once the lightsaber is done assembling, set the blade GameObject active.
        if (m_PowerIsInstalled && m_QuillonIsInstalled)
        {
            m_LightsaberIsAssembled = true;
            m_LightsaberBlade.SetActive(true);
        }
        
        
        //[TODO]If the lightsaber is done assembled, change bladeIsActivated after pressing the A button on the R-Controller while the player is grabbing it
        if (m_LightsaberIsAssembled && OVRInput.GetDown(OVRInput.Button.One))
        {
            if (m_FirstDraw)
            {
                m_BladeIsActivated = true;
                m_FirstDraw = false;
            }
            else
            {
                m_BladeIsActivated = !m_BladeIsActivated;
            }
            powerOnAudio.Play();
        }
        
        SetBladeStatus(m_BladeIsActivated);
        
        Vector3 newQuillonPosition = m_LightsaberQuillonInstalled.transform.position;

        if (m_BladeIsActivated && (newQuillonPosition - quillonPosition).magnitude / Time.deltaTime > 0.02f)
        {
            bladeWooshAudio.Play();
        }

        quillonPosition = newQuillonPosition;
    }

    void ConnectingPower()
    {
        
        //get the connector state of power
        LightsaberModuleConnector powerModuleConnector = m_PowerConnectZone.GetComponent<LightsaberModuleConnector>();
        
        //if it is connected:
        if (powerModuleConnector.isConnected)
        {
            //simply make the power module "invisible" by switching off its mesh renderer
            m_LightsaberPowerModule.GetComponent<MeshRenderer>().enabled = false;

            //we dont need the connect area anymore so switch it off
            m_PowerConnectZone.SetActive(false);
            
            //activate the pre-installed power part on the handle
            m_PowerIsInstalled = true;
            m_LightsaberPowerInstalled.SetActive(true);
        }
       


    }

    void ConnectingQuillon()
    {
        LightsaberModuleConnector quillonModuleConnector = m_QuillonConnectZone.GetComponent<LightsaberModuleConnector>();
  
        if (quillonModuleConnector.isConnected)
        {
            m_LightsaberQuillonModule.GetComponent<MeshRenderer>().enabled = false;
            
            m_QuillonConnectZone.SetActive(false);
            
            m_QuillonIsInstalled = true;
            m_LightsaberQuillonInstalled.SetActive(true);
        }
    }

    void SetBladeStatus(bool bladeStatus)
    {

        if(!bladeStatus)
        {
            if (currentDrawTime > 0.0f)
            {
                currentDrawTime -= Time.deltaTime;
                currentDrawTime = currentDrawTime > 0.0f ? currentDrawTime : 0.0f;
                Vector3 curBladeScale =
                    Vector3.Lerp(bladeDrawnScale, bladeSheathedScale, 1 - (currentDrawTime / bladeDrawTime));
                m_LightsaberBlade.transform.localScale = curBladeScale;
            }
        }

        if(bladeStatus)
        {
            if (currentDrawTime < bladeDrawTime)
            {
                currentDrawTime += Time.deltaTime;
                currentDrawTime = currentDrawTime < bladeDrawTime ? currentDrawTime : bladeDrawTime;
                Vector3 curBladeScale =
                    Vector3.Lerp(bladeSheathedScale, bladeDrawnScale, currentDrawTime / bladeDrawTime);
                m_LightsaberBlade.transform.localScale = curBladeScale;
            }
        }
    }
}
