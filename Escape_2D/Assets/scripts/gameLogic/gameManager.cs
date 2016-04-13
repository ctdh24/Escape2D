using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour {

    public GameObject quickPauseUI;
    public GameObject gameOverUI;
    public GameObject boxSpawner;
    public GameObject ghost;
    public Camera mainCamera;

    public playerController2D player;
    public Animator player_Anim;

    private bool pause = false;
    private bool gameOver = false;
    void Start()
    {
        quickPauseUI.SetActive(false);
        gameOverUI.SetActive(false);
        player_Anim.SetBool("game_over", gameOver);
        //InvokeRepeating("spawnGhost", 5.0f, 5.0f);
    }

    void Update()
    {
        
        if (Input.GetButtonDown("Pause") && !pause && !gameOver)
        {
            quickPauseUI.SetActive(true);
            pause = !pause;
            Time.timeScale = 0;
        }
        else if (Input.GetButtonDown("Pause") && pause && !gameOver)
        {
            quickPauseUI.SetActive(false);
            pause = !pause;
            Time.timeScale = 1;
        }
        else if (playerController2D.health == 0)
        {
            quickPauseUI.SetActive(false);
            gameOverUI.SetActive(true);
            gameOver = true;
            Time.timeScale = 0;
        }
        if (gameOver)
        {
            if (Input.GetKey("r"))
            {
                Debug.Log("GAME OVER");
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                Time.timeScale = 1;
            }
        }
    }

    void spawnGhost()
    {
        float y_range = (2f * mainCamera.orthographicSize)/2.0f;
        float x_range = (y_range * mainCamera.aspect)/2.0f;
        float randomX = Random.Range(mainCamera.transform.position.x - x_range, mainCamera.transform.position.x + x_range);
        while (randomX > (player.transform.position.x - 0.5f) && randomX < (player.transform.position.x +0.5f))
        {
            randomX = Random.Range(mainCamera.transform.position.x - x_range, mainCamera.transform.position.x + x_range);
        }
        float randomY = Random.Range(mainCamera.transform.position.y - y_range, mainCamera.transform.position.y + y_range);
        while (randomY > (player.transform.position.y - 0.5f) && randomY < (player.transform.position.y + 0.5f))
        {
            randomY = Random.Range(mainCamera.transform.position.y - y_range, mainCamera.transform.position.y + y_range);
        }
        GameObject ghostTemp = Instantiate(ghost, new Vector2(randomX,randomY), Quaternion.identity) as GameObject;
        //Debug.Log("Height:" + y_range + ", width:" + x_range);
    }
}
