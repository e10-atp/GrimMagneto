using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Numerics;
using UnityEngine;
using UnityEngine.UI;
using Vector3 = UnityEngine.Vector3;

public class Pointer : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private LineRenderer rend;
    
    [SerializeField]
    private LayerMask layerMask;
    private Vector3[] _points;
    
    [SerializeField]
    private float pointerOffset = 3.0f;

    [SerializeField] private GameObject ingameMenu;
    
    private Button btn;
    private bool btnDown;
    
    
    void Start()
    {
        _points = new Vector3[2];
        _points[0] = transform.position + Vector3.forward * 0.05f;
        _points[1] = transform.forward * pointerOffset + new Vector3(0, 0, pointerOffset);
        rend.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        var ray = new Ray(transform.position, transform.forward);
        
        _points[0] = transform.position + Vector3.forward * 0.05f;;
        
        if (Physics.Raycast(ray, out RaycastHit hit, pointerOffset, layerMask))
        {
            _points[1] = hit.point;
            if (btn != null && btn != hit.collider.GetComponent<Button>())
            {
                btn.GetComponent<Image>().color = Color.black;
            }
            btn = hit.collider.GetComponent<Button>();
            btn.GetComponent<Image>().color = Color.red;
            rend.startColor = Color.red;
            rend.endColor = Color.red;
            
            if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
            {
                btnDown = true;
                btn.GetComponent<Image>().color = Color.magenta;
            }
            if (OVRInput.GetUp(OVRInput.Button.SecondaryIndexTrigger) && btnDown)
            {
                btnDown = false;
                btn.onClick.Invoke();
            }
            
        }
        else
        {
            _points[1] = transform.position + (transform.forward * pointerOffset);
            rend.startColor = Color.green;
            rend.endColor = Color.green;
            if (btn != null)
            {
                btn.GetComponent<Image>().color = Color.black;
            }
        }

        rend.material.color = rend.startColor;
        rend.SetPositions(_points);
        rend.enabled = true;
    }
}
