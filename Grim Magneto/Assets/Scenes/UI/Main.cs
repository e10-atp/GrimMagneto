using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject tutorials;
    [SerializeField] private Button tutorStart;
    [SerializeField] private Button tutorSkip;

    [SerializeField] private GameObject main;


    void Start()
    {
        tutorSkip.onClick.AddListener(Skip);
        tutorStart.onClick.AddListener(StartTutorials);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Skip()
    {
        SceneManager.LoadScene("Scenes/SampleScene");
    }

    void StartTutorials()
    {
        main.SetActive(false);
        tutorials.SetActive(true);
    }
}