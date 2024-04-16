using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float health;
    public bool paused;
    public GameObject PauseMenu;
    private void Start()
    {
        Invoke("NoAnim", 1);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            paused = !paused;
            Cursor.visible = paused;
            if (!paused)
                Cursor.lockState = CursorLockMode.Locked;
            else
                Cursor.lockState = CursorLockMode.None;

            PauseMenu.SetActive(paused);
        }

        if (health <= 0)
        {
            GetComponent<Animator>().enabled = true;
            GetComponent<Animator>().Play("DeathAnim");
            Invoke("Reset1", 4);
        }
    }

    void NoAnim()
    {
        GetComponent<Animator>().enabled = false;
    }

    private void Reset1()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
