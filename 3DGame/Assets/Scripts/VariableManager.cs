using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class VariableManager : MonoBehaviour
{
    public static VariableManager Instance { get; private set; }
    public int AnimalDeaths;
    public int MobCap;
    private void Awake()
    {
        Instance = this;
    }
}
