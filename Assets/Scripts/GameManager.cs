using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{
    public Player player;
    private Spawner spawner;

    public TMP_Text scoreText;
    public GameObject playButton,gameOver,winner,getReady;
    AudioManager audioManager;

   


    private int score;
    void Start(){
        getReady.SetActive(true);
        gameOver.SetActive(false);
        winner.SetActive(false);

    }

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        Application.targetFrameRate = 60;

        player = FindObjectOfType<Player>();
        spawner = FindObjectOfType<Spawner>();
        Pause();
    }

    public void Play()
    {
        audioManager.Startbgm();
        score = 0;
        scoreText.text = score.ToString();

        playButton.SetActive(false);
        gameOver.SetActive(false);
        winner.SetActive(false);
        getReady.SetActive(false);

        Time.timeScale = 1f;
        player.enabled = true;

        Pipes[] pipes = FindObjectsOfType<Pipes>();

        for (int i = 0; i < pipes.Length; i++)
        {
            Destroy(pipes[i].gameObject);
        }
        
    }

    public void GameOver()
    {
        audioManager.PlaySE(audioManager.game_over);
        playButton.SetActive(true);
        gameOver.SetActive(true);
        getReady.SetActive(false);

        Pause();
    }
    

    public void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
        if (scoreText.text == "50")
        {
            audioManager.PlaySE(audioManager.game_complete);
            playButton.SetActive(true);
            winner.SetActive(true);
            gameOver.SetActive(false);

            Pause();
            // Application.Quit();

        }
    }

}
