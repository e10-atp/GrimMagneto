using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(EndGame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void EndGame()
    {
        SceneManager.LoadScene("Scenes/Main Menu");
    }
}
