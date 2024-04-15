using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float health;
    private void Start()
    {
        Invoke("NoAnim", 1);
    }

    private void Update()
    {
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
