using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Transform PlayerControllerTransform;
    [SerializeField]
    private float displayOffset = 2.0f;
    
    
    // [SerializeField]
    // private LayerMask layerMask;
    // [SerializeField]
    // private LineRenderer rend;
    // private Vector3[] _points;
    // [SerializeField]
    // private float pointerOffset = 20.0f;


    void Start()
    {
        // _points = new Vector3[2];
    }

    // Update is called once per frame
    void Update()
    {
        
        // _points[0] = Vector3.zero;
        SetPanelPosition();
        // DisplayPointer();
    }

    void SetPanelPosition()
    {
        transform.position = PlayerControllerTransform.position + (PlayerControllerTransform.forward * displayOffset);
        transform.LookAt(PlayerControllerTransform);
        transform.rotation = Quaternion.LookRotation(-transform.forward, Vector3.up);
    }

    // void DisplayPointer()
    // {
    //     var ray = new Ray(rightHandTransform.position, rightHandTransform.forward);
    //     
    //     _points[0] = rightHandTransform.position;
    //     RaycastHit hit;
    //
    //     if (Physics.Raycast(ray, out hit, layerMask))
    //     {
    //         _points[1] = rightHandTransform.forward + new Vector3(0, 0, hit.distance);
    //         rend.startColor = Color.red;
    //         rend.endColor = Color.red;
    //     }
    //     else
    //     {
    //         _points[1] = rightHandTransform.forward + new Vector3(0, 0, pointerOffset);
    //     }
    //     rend.SetPositions(_points);
    //     rend.enabled = true;
    // }
    
}
