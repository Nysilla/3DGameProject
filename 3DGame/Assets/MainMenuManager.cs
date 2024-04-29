using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public Animator Birb;
    public void PlayGame()
    {
        Birb.SetBool("FlyingAway", true);
        Invoke("NextLevel", 4f);
    }
    void NextLevel()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
