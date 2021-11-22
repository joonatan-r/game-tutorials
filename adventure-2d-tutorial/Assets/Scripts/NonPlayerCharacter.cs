using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NonPlayerCharacter : MonoBehaviour
{
    public float displayTime = 4.0f;
    public GameObject dialogBox;
    public GameObject dialogTextObject; // added, not from tutorial

    TextMeshProUGUI dialogText; // added, not from tutorial
    float timerDisplay;

    void Start()
    {
        dialogBox.SetActive(false);
        timerDisplay = -1.0f;
        dialogText = dialogTextObject.GetComponent<TextMeshProUGUI>(); // added, not from tutorial
    }

    void Update()
    {
        if (timerDisplay >= 0)
        {
            timerDisplay -= Time.deltaTime;

            if (timerDisplay < 0)
            {
                dialogBox.SetActive(false);
            }
        }
    }

    public void DisplayDialog()
    {
        // added, not from tutorial
        if (GameObject.Find("Ruby").GetComponent<RubyController>().FixedRobots == GameObject.FindGameObjectsWithTag("Robot").Length)
        {
            dialogText.text = "Good job!";
        }
        timerDisplay = displayTime;
        dialogBox.SetActive(true);
    }
}
