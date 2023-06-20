using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Numerics;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Tutorials : MonoBehaviour
{
    private int _currentPageNumber;
    private int _maxPageNumber;
    private int _minPageNumber;

    private GameObject[] _texts;

    [SerializeField] private Button nextBtn;
    [SerializeField] private Button backBtn;
    [SerializeField] private GameObject nextTxt;
    [SerializeField] private GameObject startTxt;
    // [SerializeField] private GameObject tutorMenu;
    // [SerializeField] private GameObject tutorPointer;
    // [SerializeField] private GameObject opener;
    // [SerializeField] private GameObject gun;
    // [SerializeField] private GameObject thunder;
    // [SerializeField] private GameObject distanceGrabRight;
    // [SerializeField] private GameObject distanceGrabLeft;
    // [SerializeField] private GameObject shield;
    
    // Start is called before the first frame update
    void Start()
    {
        _maxPageNumber = 15;
        _minPageNumber = 0;
        _currentPageNumber = 0;
        _texts = new GameObject[_maxPageNumber + 1];
        for (int i = _minPageNumber; i <= _maxPageNumber; i++)
        {
             _texts[i] = this.gameObject.transform.GetChild(i).gameObject;
        }
        
        nextBtn.onClick.AddListener(Next);
        backBtn.onClick.AddListener(Back);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Next()
    {
        if (_currentPageNumber == _maxPageNumber)
        {
            SceneManager.LoadScene("Scenes/SampleScene");
            // tutorMenu.SetActive(false);
            // tutorPointer.SetActive(false);
            //
            // opener.SetActive(true);
            // gun.SetActive(true);
            // thunder.SetActive(true);
            // distanceGrabRight.SetActive(true); 
            // distanceGrabLeft.SetActive(true);
            // shield.SetActive(true);
            return;
        }
        _texts[_currentPageNumber].SetActive(false);
        _currentPageNumber = Mathf.Min(_maxPageNumber, _currentPageNumber + 1);
        _texts[_currentPageNumber].SetActive(true);
        if (_currentPageNumber == _maxPageNumber)
        {
            nextTxt.SetActive(false);
            startTxt.SetActive(true);
        }
        else
        {
            nextTxt.SetActive(true);
            startTxt.SetActive(false);
        }
    }

    void Back()
    {
        _texts[_currentPageNumber].SetActive(false);
        _currentPageNumber = Mathf.Max(_minPageNumber, _currentPageNumber - 1);
        _texts[_currentPageNumber].SetActive(true);
        if (_currentPageNumber == _maxPageNumber)
        {
            nextTxt.SetActive(false);
            startTxt.SetActive(true);
        }
        else
        {
            nextTxt.SetActive(true);
            startTxt.SetActive(false);
        }
    }
}
