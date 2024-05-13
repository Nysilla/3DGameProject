using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public static Tutorial Instance { get; private set; }
    public TextMeshProUGUI text;
    public string[] Paragraphs;
    public int CurrentParagraph = 0;
    private void Start()
    {
        Instance = this;
        text.text = Paragraphs[0];
        CurrentParagraph = 0;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha4) && CurrentParagraph == 0)
        {
            MoveOnInParagraph();
        }
        if (Input.GetButtonDown("Fire2") && CurrentParagraph == 1)
        {
            MoveOnInParagraph();
        }
        if (VariableManager.Instance.AnimalDeaths > 0 && CurrentParagraph == 2)
        {
            MoveOnInParagraph();
        }
        if (FindObjectsByType<CannonTower>(FindObjectsSortMode.InstanceID).Length > 0 && CurrentParagraph == 3)
        {
            MoveOnInParagraph();
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene(2);
        }
    }

    public void MoveOnInParagraph()
    {
        CurrentParagraph++;
        text.text = Paragraphs[CurrentParagraph];
    }
}
