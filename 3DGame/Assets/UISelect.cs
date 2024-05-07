using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISelect : MonoBehaviour
{
    public Button[] MenuItems;
    public int ActiveItem;
    private void OnEnable()
    {
        MenuItems[0].Select();
    }

    /*

void FixedUpdate()
{
    if (Input.GetButtonDown("Cancel"))
    {
        MenuItems[ActiveItem].Select();
    }
    //Up
    if (Input.GetAxis("Vertical") > 0.9f && ActiveItem > 0 && Working)
    {
        ActiveItem--;
        Working = false;
    }
    //Down
    if (Input.GetAxis("Vertical") < -0.9f && ActiveItem < MenuItems.Length - 1 && Working)
    {
        ActiveItem++;
        Working = false;
    }
    if (Input.GetAxis("Vertical") > -0.2f && Input.GetAxis("Vertical") < 0.2f)
    {
        Working = true;
    }
    //MenuItems[ActiveItem].GetComponent<Button>().Select();
}
    */
}
