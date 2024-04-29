using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SetText : MonoBehaviour
{
    public TextMeshProUGUI txt;
    public string format = "0.00";
    public void SetText1(float Value)
    {
        txt.text = Value.ToString(format);
    }
}
