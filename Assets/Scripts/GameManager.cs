using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


/**********
 * 
 * This script is a component of the Game Manager and 
 * manages which game the player is playing.
 * 
 * Nov 13, 2023
 * Alexandra Collier-Lake
 * 
 ***********/

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreboardText, timeRemainingText;
    [SerializeField] private GameObject toggleGroup, startButton, spawnManager;
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private ParticleSystem dirtSplatter;

    public static bool gameOver = true;
    private static float score;
    private AudioSource audioSource;
    private float timeRemaining = 60;
    private bool timedGame;
   
    




    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        DisplayUI();
        EndGame();

    }

    private void DisplayUI()
    {
        scoreboardText.text = "Score: " + Mathf.RoundToInt(score).ToString();
        if(timedGame)
        {
            if(timeRemaining > 0)
            {
                timeRemainingText.text = timeRemaining.ToString();
            }
            else
            {
                timeRemainingText.text = "Game\nOver";
            }
        }
    }

    private void TimeCountdown()
    {
        timeRemaining -= 1.0f;

        if (timeRemaining <= 0)
        {
            CancelInvoke("TimeCountdown");
        }
    }

    public void StartGame()
    {
        audioSource.Play();
        toggleGroup.SetActive(false);
        startButton.SetActive(false);

        if (timedGame)
        {

            timeRemainingText.gameObject.SetActive(true);
            InvokeRepeating("TimeCountdown", 1.0f, 1.0f);

        }

        gameOver = false;
        spawnManager.SetActive(true);
        playerAnimator.SetBool("BeginGame_b", true);
        dirtSplatter.Play();
        playerAnimator.SetFloat("Speed_f", 1.0f);
    }

    private void EndGame()
    {
        if (gameOver || timeRemaining <= 0)
        {
            gameOver = true;
            playerAnimator.SetBool("BeginGame_b", false);
            playerAnimator.SetFloat("Speed_f", 0);
            audioSource.Stop();
            CancelInvoke("TimeCountdown");
        }

        
    }

    public void SetTimed(bool timed)
    {
        Debug.Log("Is game over?");
        timedGame = timed;
    }

    public static void ChangeScore(int change)
    {
        score += change;
    }
}
