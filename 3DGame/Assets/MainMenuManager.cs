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
        Invoke("NextLevel", 0.5f);
    }
    void NextLevel()
    {
        SceneManager.LoadScene(1);
    }
}
