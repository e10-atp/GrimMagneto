using System.Collections;
using System.Collections.Generic;
using Oculus.Platform;
using UnityEngine;
using UnityEngine.UI;

public class Continue : MonoBehaviour
{
    // Start is called before the first frame update    [SerializeField] private GameObject ingameMenu;
    [SerializeField] private GameObject ingameMenu;
    [SerializeField] private GameObject pointer;

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(CloseMenu);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CloseMenu()
    {
        ingameMenu.SetActive(false);
        pointer.SetActive(false);
    }
}
