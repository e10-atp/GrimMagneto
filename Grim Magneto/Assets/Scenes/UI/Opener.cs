using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opener : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject ingameMenu;
    [SerializeField] private GameObject pointer;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.Get(OVRInput.Button.Start, OVRInput.Controller.LTouch))
        {
            pointer.SetActive(true);
            ingameMenu.SetActive(true);
        }
    }
}
