using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ResumeAndpause : MonoBehaviour
{
    public void PauseGame()
    {
        Time.timeScale = 0;
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
    }
    public void home()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;

    }
}
