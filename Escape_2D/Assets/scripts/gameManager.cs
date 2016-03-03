using System;
using UnityEngine;
using System.Collections;

public class gameManager : MonoBehaviour {

    public GameObject quickPauseUI;
    public GameObject gameOverUI;

    public playerController2D player;
    public Animator player_Anim;

    private bool pause = false;
    private bool gameOver = false;
    void Start()
    {
        quickPauseUI.SetActive(false);
        gameOverUI.SetActive(false);
        player_Anim.SetBool("game_over", gameOver);
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
        else if (player.health == 0)
        {
            quickPauseUI.SetActive(false);
            gameOverUI.SetActive(true);
            gameOver = true;
            Time.timeScale = 0;
        }
    }
}
