using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Manager : MonoBehaviour
{

    public GameObject menu;
    
    void Start()
    {

        menu.SetActive(true);
        Time.timeScale = 0;
    }
    // Start is called before the first frame update
    public void Play() 
    {
        menu.SetActive(false);
        Time.timeScale = 0;
    }
    public void Quit()
    {
        Application.Quit();
    }
}
