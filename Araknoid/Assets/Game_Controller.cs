using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game_Controller : MonoBehaviour
{    public static Game_Controller instance;
    public Text scoreText;
    public GameObject wintext;
    public GameObject gameOvertext;
    public bool gameOver = false;
    private int score = 0;
    public GameObject[] blocks;
    public int BlocksNumber = 6;
    //singleton
    private void Awake()
    {
        if (instance != this)
        {
            Destroy(gameObject);
        }else if (instance == null)
        {
            instance = this;
        }
    }
    void Update()
    {
        //If the game is over and the player has pressed some input...
        if (gameOver && Input.GetKey(KeyCode.Space))
        {
            //...reload the current scene.
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (BlocksNumber == 0 )
        {
            Wingame();
        }
    }
    public void Scored()
    {
        //The brick can't score if the game is over.
        if (gameOver)
            return;
        //If the game is not over, increase the score...
        score++;
        //...and adjust the score text.
        scoreText.text = "Score: " + score;
        // reduce the number of bricks
        BlocksNumber--;
    }

    public void lose()
    {
        //Activate the game over text.
        gameOvertext.SetActive(true);
        //Set the game to be over.
        gameOver = true;
    }
    public void Wingame()
    {
        wintext.SetActive(true);
        gameOver = true;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "ball")
        {
            gameOver = true;
            lose();
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.rigidbody.tag == "ball")
        {
            gameOver = true;
            lose();
        }

    }
}
