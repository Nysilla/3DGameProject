using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class Spawner1 : MonoBehaviour
{
    public GameObject[] PrefabPreview;
    public GameObject[] Prefabs;
    public int[] Prices;
    public int ActiveTower;
    public GameObject ActiveInstantiate;
    public TextMeshProUGUI MoneyText;
    float nextTimeToFire = 0;
    int selected;
    void Update()
    {
        if (GetComponentInParent<PlayerHealth>().paused)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            summonTower(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            summonTower(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            summonTower(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            summonTower(3);
        }

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if(ActiveInstantiate != null)
                ActiveInstantiate.transform.position = hit.point;
            if (Input.GetButtonDown("Fire2") || Input.GetAxis("Fire2") > 0.9f)
            {
                if (GetComponentInParent<PlayerHealth>().Money - Prices[ActiveTower] >= 0 && nextTimeToFire < Time.time)
                {
                    nextTimeToFire = Time.time + 2;
                    Destroy(ActiveInstantiate);
                    MoneyText.text = "-$" + Prices[ActiveTower].ToString();
                    Invoke("MakeTextNullAgain", 2);
                    GetComponentInParent<PlayerHealth>().Money -= Prices[ActiveTower];
                    Instantiate(Prefabs[ActiveTower], hit.point, Quaternion.identity);
                }
            }
        }

        if (Input.GetButtonDown("B"))
        {
            Destroy(ActiveInstantiate);
        }

        if (Input.GetButtonDown("E"))
        {
            if (ActiveTower < 3)
            {
                ActiveTower++;
            }
            else
            {
                ActiveTower = 0;
            }
            summonTower(ActiveTower);
        }
        if (Input.GetButtonDown("Q"))
        {
            if (ActiveTower > 0)
            {
                ActiveTower--;
            }
            else
            {
                ActiveTower = 3;
            }
            summonTower(ActiveTower);
        }
    }

    void summonTower(int ActiveTowerInt)
    {
        ActiveTower = ActiveTowerInt; Destroy(ActiveInstantiate); ActiveInstantiate = Instantiate(PrefabPreview[ActiveTower]);
    }

    void MakeTextNullAgain()
    {
        MoneyText.text = "";
    }
}
