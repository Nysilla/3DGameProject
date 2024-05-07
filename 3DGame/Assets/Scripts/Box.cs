using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public GameObject UnParent;
    private void Start()
    {
        UnParent.transform.parent = null;
    }
}
