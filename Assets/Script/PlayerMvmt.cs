using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMvmt : MonoBehaviour
{
    public Rigidbody rb;
    public float forwardForce,sideForce;
    private Scene scene;
    bool score;
    public Text scoreText;
    float time = 0;
    int scoreTime;
    public GameObject pauseUI;
    int penalty = 0;

    public GameObject levelCompleteUI;


    // Start is called before the first frame update
    void Start()
    {
        forwardForce=1000f;
        sideForce = 50f;
        score = true;
        scene = SceneManager.GetActiveScene();
    }


    void OnCollisionEnter(Collision col)
    {
        if (col.collider.tag == "Obstacle")
        {
            Debug.Log("We hit an obstacle");
            if (scoreTime - 3 > 0)
            {
                penalty += 3;
                col.collider.GetComponent<Collider>().enabled = !col.collider.GetComponent<Collider>().enabled;
            }
            else
            {
                
                SceneManager.LoadScene(scene.name);
            }
        }
        else if (col.collider.tag == "Net")
        {
            Debug.Log("We fell from the plane");
            SceneManager.LoadScene(scene.name);
        }
        else if (col.collider.tag == "Finish")
        {
            score = false;
            Debug.Log("Level Complete");
            levelCompleteUI.SetActive(true);
        }
    }

    void Movenment()
    {
        if (Input.GetKey("d")){
            rb.AddForce(sideForce * Time.deltaTime, 0, 0,ForceMode.VelocityChange);
        }
        if (Input.GetKey("a"))
        {
            rb.AddForce(-sideForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            if (!pauseUI.active)
            {
                pauseUI.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                pauseUI.SetActive(false);
                Time.timeScale = 1;
            }
        }

    }
    // Update is called once per frame
    void Update()
    {
        rb.AddForce(0,0,forwardForce * Time.deltaTime);
        Movenment();
        if (score)
        {
            time += Time.deltaTime;
            scoreTime = (int)time - penalty;
            scoreText.text = scoreTime.ToString();
        }
    }
}
