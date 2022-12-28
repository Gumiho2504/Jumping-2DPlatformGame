using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class fiinis : MonoBehaviour
{
    private AudioSource finishSound;
    private bool levelCompleted = false;
    // Start is called before the first frame update
    void Start()
    {
        finishSound = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "player" && !levelCompleted)
        {
            finishSound.Play(); 
            levelCompleted = true;
            Invoke("completedLevel", 2f);// 2 secound to load new sence
        }
    }
    private void completedLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }

}
