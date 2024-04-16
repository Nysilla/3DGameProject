using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner1 : MonoBehaviour
{
    public GameObject[] PrefabPreview;
    public GameObject[] Prefabs;
    public int ActiveTower;
    public GameObject ActiveInstantiate;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ActiveTower = 0; Destroy(ActiveInstantiate); ActiveInstantiate = Instantiate(PrefabPreview[ActiveTower]);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ActiveTower = 1; Destroy(ActiveInstantiate); ActiveInstantiate = Instantiate(PrefabPreview[ActiveTower]);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ActiveTower = 2; Destroy(ActiveInstantiate); ActiveInstantiate = Instantiate(PrefabPreview[ActiveTower]);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            ActiveTower = 3; Destroy(ActiveInstantiate); ActiveInstantiate = Instantiate(PrefabPreview[ActiveTower]);
        }

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if(ActiveInstantiate != null)
                ActiveInstantiate.transform.position = hit.point;
            if (Input.GetButtonDown("Fire2"))
            {
                Destroy(ActiveInstantiate);
                Instantiate(Prefabs[ActiveTower], hit.point, Quaternion.identity);
            }
        }
    }
}
