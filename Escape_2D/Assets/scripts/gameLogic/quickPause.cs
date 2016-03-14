using System;
using UnityEngine;
using System.Collections;

public class quickPause : MonoBehaviour {

    public GameObject quickPauseUI;
    public GameObject gameOverUI;
    private bool pause = false;
    void Start()
    {
        quickPauseUI.SetActive(false);
        gameOverUI.SetActive(false);
    }

    void Update()
    {
        if (Input.GetButtonDown("Pause") && !pause)
        {
            quickPauseUI.SetActive(true);
            pause = !pause;
            Time.timeScale = 0;
        }
        else if (Input.GetButtonDown("Pause") && pause)
        {
            quickPauseUI.SetActive(false);
            pause = !pause;
            Time.timeScale = 1;
        }
    }

}
