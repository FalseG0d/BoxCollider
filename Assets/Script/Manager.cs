using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{

    public GameObject menu;
    public GameObject pauseMenu;

    public GameObject welcome;
    public GameObject score;
    public GameObject levelComplete;

    AudioSource audioData;

    void Start()
    {

        menu.SetActive(true);
        welcome.SetActive(true);
        score.SetActive(false);
        levelComplete.SetActive(false);
        Time.timeScale = 0;

        audioData = GetComponent<AudioSource>();
    }
    // Start is called before the first frame update

    void Update() 
    {

        if (Input.GetKey(KeyCode.Escape))
        {
            if (!menu.active)
            {
                menu.SetActive(true);
                pauseMenu.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                menu.SetActive(false);
                pauseMenu.SetActive(false);
                Time.timeScale = 1;
            }
        }
    }

    public void Continue()
    {
        if (!menu.active)
        {
            menu.SetActive(true);
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            menu.SetActive(false);
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void Play()
    {
        audioData.Play(0);
        menu.SetActive(true);
        welcome.SetActive(false);
        levelComplete.SetActive(false);
        score.SetActive(true);
        Time.timeScale = 1;
    }

    public void Quit()
    {
        audioData.Play(0);
        Application.Quit();
    }

    public void Replay()
    {
        audioData.Play(0);
        levelComplete.SetActive(false);
        SceneManager.LoadScene("Level1");
    }
}
