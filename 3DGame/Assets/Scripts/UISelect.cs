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
}
