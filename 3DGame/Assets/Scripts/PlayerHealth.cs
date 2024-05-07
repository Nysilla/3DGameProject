using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public bool paused;
    public GameObject PauseMenu;
    public GameObject Tools;
    public bool BeingHealed;
    public GameObject HealUI;

    public int Money;
    public TextMeshProUGUI MoneyText;

    private void Start()
    {
        Invoke("NoAnim", 1);
        health = maxHealth;
    }

    private void Update()
    {
        MoneyText.text = "$" + Money.ToString();
        HealUI.SetActive(BeingHealed);
        if (Input.GetButtonDown("Escape") || Input.GetKeyDown(KeyCode.Escape))
        {
            paused = !paused;
            Cursor.visible = paused;
            if (!paused)
                Cursor.lockState = CursorLockMode.Locked;
            else
                Cursor.lockState = CursorLockMode.None;

            Tools.SetActive(!paused);
            Time.timeScale = Convert.ToInt32(!paused);
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
