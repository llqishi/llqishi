using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UIbutton : MonoBehaviour
{
    enum enum_buttonMode {start,exit }

    [SerializeField]enum_buttonMode ButtonMode;

    [SerializeField]
    GameObject ui;

    void Awake()
    {
        ui.SetActive(false);
    }

    void OnMouseEnter()
    {
       ui.SetActive(true);
    }

    void OnMouseExit()
    {
        ui.SetActive(false);
    }

    void OnMouseDown()
    {
        if(ButtonMode==enum_buttonMode.start)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if(ButtonMode == enum_buttonMode.exit)
        {
            Application.Quit(); 
        }
    }
}
