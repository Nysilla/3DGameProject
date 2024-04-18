using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{
    public Button[] Buttons;
    public GameObject[] Menus;
    public int activeButton;
    public int lastButton;
    public Sprite DefaultSprite;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if(activeButton == 0) { return; }
            lastButton = activeButton;
            activeButton--;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (activeButton >= Buttons.Length-1) { return; }
            lastButton = activeButton;
            activeButton++;
        }
        Buttons[activeButton].Select();
        Buttons[activeButton].GetComponent<Image>().sprite = null;
        Buttons[activeButton].GetComponentInChildren<TextMeshProUGUI>().color = Color.black;
        Menus[activeButton].SetActive(true);
        Buttons[lastButton].GetComponent<Image>().sprite = DefaultSprite;
        Buttons[lastButton].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
        Menus[lastButton].SetActive(false);
    }
}
