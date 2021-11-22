using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// added, not from tutorial
public class UIGameOver : MonoBehaviour
{
    public static UIGameOver instance { get; private set; }

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        this.gameObject.SetActive(false);
    }

    public void gameOver()
    {
        this.gameObject.SetActive(true);
    }
}
