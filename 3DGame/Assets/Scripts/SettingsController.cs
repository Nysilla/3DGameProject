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
        if (Input.GetButtonDown("Q"))
        {
            if(activeButton == 0) { return; }
            lastButton = activeButton;
            activeButton--;
            UpdateButtons();
        }
        if (Input.GetButtonDown("E"))
        {
            if (activeButton >= Buttons.Length-1) { return; }
            lastButton = activeButton;
            activeButton++;
            UpdateButtons();
        }
    }
    void UpdateButtons()
    {
        Buttons[activeButton].Select();
        Buttons[activeButton].GetComponent<Image>().sprite = null;
        Buttons[activeButton].GetComponentInChildren<TextMeshProUGUI>().color = Color.black;
        var colors1 = Buttons[activeButton].colors;
        colors1.normalColor = new Color(1, 1, 0.788f);
        Buttons[activeButton].colors = colors1;
        Menus[activeButton].SetActive(true);
        Buttons[lastButton].GetComponent<Image>().sprite = DefaultSprite;
        Buttons[lastButton].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
        var colors2 = Buttons[lastButton].colors;
        colors2.normalColor = Color.white;
        Buttons[lastButton].colors = colors2;
        Menus[lastButton].SetActive(false);
    }
}
